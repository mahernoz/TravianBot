//--------------------------------------------------------
// <copyright file="PlayerManager.cs" company="company">
//        Copyright (c) company. All rights reserved.
// </copyright>
// <author>Muhammed Emir Özçevik</author>
//--------------------------------------------------------

using System.Collections.Generic;
using System.Linq;
using NLog;
using TravianBot.Data;
using TravianBot.Structs;

namespace TravianBot
{
    public class PlayerManager
    {
        /// <summary>
        ///     Logger for logging.
        /// </summary>
        private static Logger Logger =
            LogManager.GetCurrentClassLogger();

        /// <summary>
        ///     Initializes a new instance of
        ///     the <see cref="PlayerManager" /> class.
        /// </summary>
        public PlayerManager(Server server)
        {
            Players = new Dictionary<int, Player>();
            Server = server;
        }

        /// <summary>
        ///     Gets managing server.
        /// </summary>
        public Server Server { get; private set; }

        /// <summary>
        ///     Gets players.
        /// </summary>
        public IDictionary<int, Player> Players { get; private set; }

        /// <summary>
        ///     Fires when a new player is created.
        /// </summary>
        public event PlayerEventHandler OnNewPlayer;

        /// <summary>
        ///     Creates or gets a player.
        /// </summary>
        /// <param name="id">Player id</param>
        /// <param name="name">Player name.</param>
        /// <returns></returns>
        public Player CreatePlayer(int id, string name)
        {
            if (Players.ContainsKey(id))
            {
                return Players[id];
            }

            Player p;

            Account a = Server.AccountManager.GetAccount(name);

            if (a == null)
            {
                p = new Player(id);
            }
            else
            {
                p = new MyPlayer(id);
                a.SetPlayer(p as MyPlayer);
            }

            p.Name = name;

            Players.Add(id, p);

            if (OnNewPlayer != null)
            {
                OnNewPlayer.Invoke(p);
            }

            return p;
        }

        /// <summary>
        ///     Adds new players to server.
        /// </summary>
        /// <param name="players">Players data.</param>
        public void OnNewPlayerData(params PlayerData[] players)
        {
            foreach (var pd in players)
            {
                Player p = CreatePlayer(pd.Id, pd.Name);
                p.Alliance = Server.AllyManager.CreateAlliance(pd.Ally);
                p.IsGoldClub = pd.IsGold;
                p.IsAdmin = pd.IsAdmin;
            }
        }

        /// <summary>
        ///     Gets player for given id.
        /// </summary>
        /// <param name="id">Player id.</param>
        /// <returns></returns>
        public Player GetPlayer(int id)
        {
            return Players.FirstOrDefault(i => i.Key == id).Value;
        }

        /// <summary>
        ///     Gets player for given name.
        /// </summary>
        /// <param name="name">Player name.</param>
        /// <returns></returns>
        public Player GetPlayer(string name)
        {
            return Players.FirstOrDefault(i => i.Value.Name.Equals(name)).Value;
        }
    }
}