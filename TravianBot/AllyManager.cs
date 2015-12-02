//--------------------------------------------------------
// <copyright file="AllyManager.cs" company="company">
//        Copyright (c) company. All rights reserved.
// </copyright>
// <author>Muhammed Emir Özçevik</author>
//--------------------------------------------------------

using System.Collections.Generic;
using NLog;
using TravianBot.Data;

namespace TravianBot
{
    public class AllyManager
    {
        /// <summary>
        ///     Logger for logging.
        /// </summary>
        private static Logger Logger =
            LogManager.GetCurrentClassLogger();

        public AllyManager(Server server)
        {
            Alliances = new Dictionary<int, Alliance>();
            Server = server;
        }

        /// <summary>
        ///     Gets managing server.
        /// </summary>
        public Server Server { get; private set; }

        /// <summary>
        ///     Gets alliances.
        /// </summary>
        public Dictionary<int, Alliance> Alliances { get; private set; }

        /// <summary>
        ///     Fires when a new alliance is added.
        /// </summary>
        public event AllyEventHandler OnNewAlliance;

        /// <summary>
        ///     Creates or gets a alliance.
        /// </summary>
        /// <param name="id">Alliance id.</param>
        /// <returns>Created or found alliance.</returns>
        public Alliance CreateAlliance(int id)
        {
            if (Alliances.ContainsKey(id))
            {
                return Alliances[id];
            }

            var a = new Alliance(id);
            Alliances.Add(id, a);

            if (OnNewAlliance != null)
            {
                OnNewAlliance.Invoke(a);
            }

            return a;
        }
    }
}