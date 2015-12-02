//--------------------------------------------------------
// <copyright file="VillageManager.cs" company="company">
//        Copyright (c) company. All rights reserved.
// </copyright>
// <author>Muhammed Emir Özçevik</author>
//--------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using TravianBot.Data;
using TravianBot.Utilities;

namespace TravianBot
{
    public class VillageManager
    {
        /// <summary>
        ///     Logger for logging.
        /// </summary>
        private static NLog.Logger Logger =
            NLog.LogManager.GetCurrentClassLogger();

        /// <summary>
        ///     Initializes a new instance of the VillageManager class.
        /// </summary>
        /// <param name="s"></param>
        public VillageManager(Server server)
        {
            Villages = new Dictionary<int, Village>();
            Server = server;
        }

        /// <summary>
        ///     Gets managing server.
        /// </summary>
        public Server Server { get; private set; }

        /// <summary>
        ///     Gets the villages.
        /// </summary>
        public IDictionary<int, Village> Villages { get; private set; }

        /// <summary>
        ///     Fires when a new village is added.
        /// </summary>
        public event VillageEventHandler VillageAdded;

        /// <summary>
        ///     Creates a new village and gives it to a player.
        /// </summary>
        /// <param name="id">Village id.</param>
        /// <param name="isMyVillage">MyVillage or not.</param>
        /// <returns>Returns the created village.</returns>
        public Village CreateVillage(
            int id,
            bool isMyVillage = false)
        {
            Village v = GetVillage(id);

            if (v != null)
            {
                return v;
            }

            if (isMyVillage)
            {
                Logger.Trace("Creating a myvillage id:{0}", id);
                v = new MyVillage(id);
            }
            else
            {
                Logger.Trace("Creating a village id:{0}", id);
                v = new Village(id);
            }

            Villages.Add(id, v);

            if (VillageAdded != null)
            {
                VillageAdded.Invoke(v);
            }

            return v;
        }

        /// <summary>
        ///     Gets village with given id.
        /// </summary>
        /// <param name="id">Village id to look up.</param>
        /// <returns>Village or null.</returns>
        public Village GetVillage(int id)
        {
            if (Villages.ContainsKey(id))
            {
                return Villages[id];
            }
            return null;
        }

        /// <summary>
        ///     Gets villages with given name.
        /// </summary>
        /// <param name="name">Village name to search.</param>
        /// <returns>Found villages.</returns>
        public IList<Village> GetVillages(string name)
        {
            return Villages
                .Select(i => i.Value)
                .Where(i => i.Name.EqualsIgnoreCase(name))
                .ToList();
        }

        /// <summary>
        ///     Adds new villages to server.
        /// </summary>
        /// <param name="villages">Villages data.</param>
        public void OnNewVillageData(params VillageData[] villages)
        {
            foreach (var vd in villages)
            {
                Player p = Server.PlayerManager.GetPlayer(vd.OwnerName);
                Village v = CreateVillage(vd.Id, p is MyPlayer);
                v.Name = vd.Name;
                v.IsCentral = vd.Central;
                v.Population = vd.Pop;
                p.AddVillage(v);
            }
        }
    }
}