//--------------------------------------------------------
// <copyright file="AI.cs" company="company">
//        Copyright (c) company. All rights reserved.
// </copyright>
// <author>Muhammed Emir Özçevik</author>
//--------------------------------------------------------

using System;
using System.Threading;
using System.Threading.Tasks;
using NLog;
using TravianBot.Data;

namespace TravianBot
{
    public class AI
    {
        /// <summary>
        ///     Logger for logging.
        /// </summary>
        private static Logger Logger =
            LogManager.GetCurrentClassLogger();

        /// <summary>
        ///     Initializes a new instance of the AI class.
        /// </summary>
        public AI()
        {
            
        }

        /// <summary>
        ///     Start working.
        /// </summary>
        public void Run()
        {
            Logger.Trace("Invoking all clients...");

            Travian.Instance.Servers.ForEach(s =>
            {
                foreach (var tc in s.ClientManager.TravianClients.Values)
                {
                    var t = new Thread(() => tc.Run());
                    t.Name = tc.Account.Username;
                    t.Start();
                }
            });

            Logger.Trace("All clients are running.");
        }
    }
}