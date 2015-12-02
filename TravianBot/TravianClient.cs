//--------------------------------------------------------
// <copyright file="TravianClient.cs" company="company">
//        Copyright (c) company. All rights reserved.
// </copyright>
// <author>Muhammed Emir Özçevik</author>
//--------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NLog;
using TravianBot.Data;
using TravianBot.Enums;
using TravianBot.Parsing;
using TravianBot.Structs;
using TravianBot.Utilities;

namespace TravianBot
{
    /// <summary>
    ///     Client for making requests and getting data from travian server.
    /// </summary>
    public class TravianClient
    {
        /// <summary>
        ///     Logger for logging.
        /// </summary>
        private static readonly Logger Logger =
            LogManager.GetCurrentClassLogger();

        /// <summary>
        ///     Initializes a new instance of the TravianClient class.
        /// </summary>
        /// <param name="a">Travian account.</param>
        /// <param name="client">Http client.</param>
        public TravianClient(Account a, HttpClient client)
        {
            Account = a;
            Client = client;
            Tasks = new List<Task>();
            Status = ClientStatus.NotLogged;
        }

        /// <summary>
        ///     Fires when there is a player data.
        /// </summary>
        public event PlayerDataEventHandler NewPlayerData;

        /// <summary>
        ///     Fires when there is a new village data.
        /// </summary>
        public event VillageDataEventHandler NewVillageData;

        /// <summary>
        ///     Gets or sets the Account.
        /// </summary>
        public Account Account { get; private set; }

        /// <summary>
        ///     Gets player.
        /// </summary>
        public MyPlayer Player
        {
            get { return Account.Player; }
        }

        /// <summary>
        ///     Gets villages.
        /// </summary>
        public IDictionary<int, MyVillage> Villages
        {
            get { return Player.MyVillages; }
        }

        /// <summary>
        ///     Gets or sets http client.
        /// </summary>
        public HttpClient Client { get; set; }

        /// <summary>
        ///     Gets tasks.
        /// </summary>
        public IList<Task> Tasks { get; private set; }

        /// <summary>
        ///     Gets status.
        /// </summary>
        public ClientStatus Status { get; private set; }

        /// <summary>
        ///     Sends request to server.
        /// </summary>
        /// <param name="page">Page string.</param>
        /// <param name="extra">Url values.</param>
        /// <param name="post">Post values.</param>
        public Task Send(
            Page page,
            KeyValuePair<string, string>[] extra = null,
            KeyValuePair<string, string>[] post = null)
        {
            var url = new StringBuilder();
            url.Append(PageUtils.GetPageName(page));
            url.Append(".php");

            if (extra != null)
            {
                url.Append('?');
                foreach (var e in extra)
                {
                    url.AppendUrlEncoded(e.Key, e.Value);
                }
            }
            var urlStr = url.ToString();

            Logger.Trace("New request : {0}", urlStr);

            Task<HttpResponseMessage> task;
            if (post == null)
            {
                task = Client.GetAsync(urlStr);
            }
            else
            {
                var content = new FormUrlEncodedContent(post);
                task = Client.PostAsync(urlStr, content);
            }
            Tasks.Add(task);

            return task.ContinueWith(OnTaskEnd);
        }

        /// <summary>
        ///     Handles HttpClient responses.
        /// </summary>
        /// <param name="task">HttpClient async task object.</param>
        public void OnTaskEnd(Task<HttpResponseMessage> task)
        {
            var response = task.Result;
            response.EnsureSuccessStatusCode();

            var content = response.Content.ReadAsStringAsync().Result;
            var from = response.RequestMessage.RequestUri.Segments.Last();
            from = from.Split('.').First();
            Page page = PageUtils.GetPageEnum(from);

            OnNewContent(content, page);

            Tasks.Remove(task);
        }

        /// <summary>
        ///     Handles new http contents.
        /// </summary>
        /// <param name="content">Http content.</param>
        /// <param name="page">Which page content came from.</param>
        public void OnNewContent(string content, Page page)
        {
            switch (page)
            {
                case Page.INDEX:
                    break;
                case Page.LOGIN:
                    Status = ClientStatus.NotLogged;
                    break;
                case Page.VILLAGE1:
                    if (Status == ClientStatus.NotLogged)
                    {
                        Status = ClientStatus.NotInitialized;
                        break;
                    }
                    string villageName = Parser.VillageName(content);
                    Player.ActiveVillage.Name = villageName;

                    int villageType = Parser.VillageType(content);
                    Player.ActiveVillage.SetBuildings(
                        BuildingFactory.GetBuildings(villageType));

                    BuildingData[] fields = Parser.Fields(content);
                    foreach (var bd in fields)
                    {
                        Building b = Player.ActiveVillage.Buildings[bd.Id];
                        b.Level = bd.Level;
                    }
                    break;
                case Page.VILLAGE2:
                    BuildingData[] buildings = Parser.Buildings(content);
                    foreach (var bd in buildings)
                    {
                        Building b = Player.ActiveVillage.Buildings[bd.Id];
                        b.Level = bd.Level;
                        b.Type = bd.Type;
                    }
                    break;
                case Page.VILLAGE3:
                    break;
                case Page.V2V:
                    break;
                case Page.BUILD:
                    break;
                case Page.STATISTICS:
                    PlayerData[] players = Parser.Players(content);
                    if (NewPlayerData != null)
                    {
                        NewPlayerData.Invoke(players);
                    }
                    break;
                case Page.PROFILE:
                    VillageData[] villages = Parser.Villages(content);
                    if (NewVillageData != null)
                    {
                        NewVillageData.Invoke(villages);
                    }
                    break;
                case Page.MAP:
                    break;
                case Page.MESSAGES:
                    break;
                case Page.REPORTS:
                    break;
                default:
                    throw new ArgumentOutOfRangeException("page", page, null);
            }
        }

        /// <summary>
        ///     Changes the active village.
        /// </summary>
        /// <param name="id">Village id.</param>
        public void ChangeVillage(int id)
        {
            // Wait for all requests to end to change village.
            Wait();

            var val = new KeyValuePair<string, string>("vid", id.ToString());

            Send(Page.VILLAGE1, new[] {val}).Wait();
        }

        /// <summary>
        ///     Initialize all data.
        /// </summary>
        public void Initialize()
        {
            // Initialize player.
            Send(Page.STATISTICS).Wait();

            // Initialize village list.
            Send(Page.PROFILE).Wait();

            // Initialize all village's buildings.
            Account.Player.MyVillages.ToList().ForEach(v =>
            {
                ChangeVillage(v.Key);
                Send(Page.VILLAGE1);
                Send(Page.VILLAGE2);
            });

            
            if (!Player.CheckIfInitialied())
            {
                Logger.Error("{0} Initialization error.", Player);
                throw new InitializationException();
            }
            Status = ClientStatus.Ready;
        }

        /// <summary>
        ///     Pauses the thread until all requests are completed.
        /// </summary>
        public void Wait()
        {
            while (Tasks.Count != 0)
            {
                Thread.Sleep(10);
            }
        }

        /// <summary>
        ///     Logs the client in.
        /// </summary>
        public void Login()
        {
            Logger.Info("{0} logging in...", Account.Username);

            var post = new KeyValuePair<string, string>[3];
            post[0] = new KeyValuePair<string, string>("name", Account.Username);
            post[1] = new KeyValuePair<string, string>("password", Account.Password);
            post[2] = new KeyValuePair<string, string>("s1", "anmelden");

            Send(Page.LOGIN, null, post).Wait();
        }

        public void Run()
        {
            while (true)
            {
                switch (Status)
                {
                    case ClientStatus.Ready:
                        Action();
                        break;
                    case ClientStatus.NotLogged:
                        Login();
                        break;
                    case ClientStatus.NotInitialized:
                        Initialize();
                        break;
                }
                Thread.Sleep(10);
            }
        }

        /// <summary>
        ///     Processes queues.
        /// </summary>
        public void Action()
        {

        }
    }
}