//--------------------------------------------------------
// <copyright file="Server.cs" company="company">
//        Copyright (c) company. All rights reserved.
// </copyright>
// <author>Muhammed Emir Özçevik</author>
//--------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using NLog;
using TravianBot.Parsing;
using TravianBot.Structs;

namespace TravianBot.Data
{
    public class Server
    {
        /// <summary>
        ///     Logger for logging.
        /// </summary>
        private static Logger Logger =
            LogManager.GetCurrentClassLogger();

        /// <summary>
        ///     Initializes a new instance of the Server class.
        /// </summary>
        /// <param name="name">Server name.</param>
        /// <param name="speed">Server speed.</param>
        /// <param name="address">Server url address.</param>
        public Server(string name, int speed, string address)
        {
            Name = name;
            Speed = speed;
            Address = address;
            ClientManager = new ClientManager(this);
            AccountManager = new AccountManager();
            PlayerManager = new PlayerManager(this);
            VillageManager = new VillageManager(this);
            AllyManager = new AllyManager(this);

            ClientManager.NewClient += OnNewClientCreated;
        }

        #region Properties
        /// <summary>
        ///     Gets or sets the name of the server.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets the speed of the server.
        /// </summary>
        public int Speed { get; set; }

        /// <summary>
        ///     Gets or sets the url address of the server.
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        ///     Gets the client manager.
        /// </summary>
        public ClientManager ClientManager { get; private set; }

        /// <summary>
        ///     Gets the account manager.
        /// </summary>
        public AccountManager AccountManager { get; private set; }

        /// <summary>
        ///     Gets the player manager.
        /// </summary>
        public PlayerManager PlayerManager { get; private set; }

        /// <summary>
        ///     Gets the alliance manager.
        /// </summary>
        public AllyManager AllyManager { get; private set; }

        /// <summary>
        ///     Gets the village manager.
        /// </summary>
        public VillageManager VillageManager { get; private set; }
#endregion

        /// <summary>
        ///     Gets players.
        /// </summary>
        public IList<Player> Players
        {
            get { return PlayerManager.Players.Values.ToList(); }
        }

        /// <summary>
        ///     Gets alliances.
        /// </summary>
        public IList<Alliance> Alliances 
        {
            get { return AllyManager.Alliances.Values.ToList(); } 
        }

        /// <summary>
        ///     Handles new client events.
        /// </summary>
        /// <param name="tc"></param>
        public void OnNewClientCreated(TravianClient tc)
        {
            tc.NewPlayerData += PlayerManager.OnNewPlayerData;
            tc.NewVillageData += VillageManager.OnNewVillageData;
        }

        /// <summary>
        ///     Gets string represetation of object.
        /// </summary>
        /// <returns>String value.</returns>
        public override string ToString()
        {
            return "Server : " + Name;
        }
    }
}