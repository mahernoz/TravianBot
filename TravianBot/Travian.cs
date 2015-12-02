//--------------------------------------------------------
// <copyright file="Travian.cs" company="company">
//        Copyright (c) company. All rights reserved.
// </copyright>
// <author>Muhammed Emir Özçevik</author>
//--------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Xml;
using TravianBot.Data;
using TravianBot.Enums;

namespace TravianBot
{
    /// <summary>
    ///     Singleton travian class.
    /// </summary>
    public class Travian
    {
        /// <summary>
        ///     Instance of this class.
        /// </summary>
        private static Travian _instance;

        /// <summary>
        ///     Initializes a new _instance of the Travian class.
        /// </summary>
        public Travian(GameVersion version)
        {
            Version = version;
            AI = new AI();
            Servers = new List<Server>();
            StructureData = new XmlDocument();
            //StructureData.Load("structures.xml");
        }

        /// <summary>
        ///     Gets the _instance of this class.
        /// </summary>
        public static Travian Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Travian(GameVersion.VERSION_GER);
                }
                return _instance;
            }
        }

        /// <summary>
        ///     Gets the game version.
        /// </summary>
        public GameVersion Version { get; private set; }

        /// <summary>
        ///     Gets the AI.
        /// </summary>
        public AI AI { get; private set; }

        /// <summary>
        ///     Gets the list of servers.
        /// </summary>
        public List<Server> Servers { get; private set; }

        /// <summary>
        ///     Gets village profiles.
        /// </summary>
        public List<VillageProfile> Profiles { get; private set; }

        /// <summary>
        ///     Gets or sets the structure data.
        /// </summary>
        private XmlDocument StructureData { get; set; }

        /// <summary>
        ///     Fires when a new server is added.
        /// </summary>
        public event ServerEventHandler OnNewServerAdded;

        /// <summary>
        ///     Adds a new server to the server.
        /// </summary>
        /// <param name="host">Host address.</param>
        /// <param name="realm">Server domain.</param>
        /// <param name="speed">Server speed.</param>
        /// <param name="name">Server name.</param>
        /// <returns>Created server.</returns>
        public Server CreateServer(
            string host,
            string realm,
            int speed,
            string name = "default")
        {
            var fullAddress = string.Format("{0}/{1}/", host, realm);
            var s = new Server(name, speed, fullAddress);
            Servers.Add(s);

            if (OnNewServerAdded != null)
            {
                OnNewServerAdded.Invoke(s);
            }

            return s;
        }

        /// <summary>
        ///     Gets the time required to upgrade a structure.
        /// </summary>
        /// <param name="type">Structure type.</param>
        /// <param name="level">Structure level.</param>
        /// <returns>Upgrade time.</returns>
        public TimeSpan GetUpgradeTime(
            BuildingType type,
            int level)
        {
            var xpath = string.Format(
                "/Structures/Structure[@id='{0}']/Lvl[@value='{1}']",
                (int) type,
                level);

            var sNode = StructureData.SelectSingleNode(xpath);
            var upNode = sNode.SelectSingleNode("UpgTime");

            var time = upNode.InnerText.Split(':');

            var hours = int.Parse(time[0]);
            var minutes = int.Parse(time[1]);
            var seconds = int.Parse(time[2]);

            return new TimeSpan(hours, minutes, seconds);
        }
    }
}