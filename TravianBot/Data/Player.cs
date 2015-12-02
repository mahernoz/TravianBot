//--------------------------------------------------------
// <copyright file="Player.cs" company="company">
//        Copyright (c) company. All rights reserved.
// </copyright>
// <author>Muhammed Emir Özçevik</author>
//--------------------------------------------------------

using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using NLog;

namespace TravianBot.Data
{
    /// <summary>
    ///     Holds all the player data.
    /// </summary>
    public class Player
    {
        /// <summary>
        ///     Logger for logging.
        /// </summary>
        private static Logger Logger =
            LogManager.GetCurrentClassLogger();

        /// <summary>
        ///     Initializes a new instance of the Player class.
        /// </summary>
        /// <param name="id">Player id.</param>
        public Player(int id)
        {
            Id = id;
            Villages = new Dictionary<int, Village>();
            Oases = new List<Oasis>();
        }

        /// <summary>
        ///     Gets the player id.
        /// </summary>
        [DisplayName("ID")]
        public int Id { get; private set; }

        /// <summary>
        ///     Gets or sets the player rank.
        /// </summary>
        [DisplayName("Rank")]
        public int Rank { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether player is
        ///     a member of gold club or not.
        /// </summary>
        [DisplayName("Gold Member")]
        public bool IsGoldClub { get; set; }

        /// <summary>
        ///     Gets or sets the player name.
        /// </summary>
        [DisplayName("Name")]
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets the player profile description text.
        /// </summary>
        [DisplayName("Description")]
        public string Description { get; set; }

        /// <summary>
        ///     Gets or sets the player tribe type.
        /// </summary>
        [DisplayName("Tribe")]
        public Tribe Tribe { get; set; }

        /// <summary>
        ///     Gets or sets player's alliance.
        /// </summary>
        //[System.ComponentModel.ComplexBindingProperties]
        public Alliance Alliance { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether player is admin or not.
        /// </summary>
        public bool IsAdmin { get; set; }

        /// <summary>
        ///     Gets player's villages.
        /// </summary>
        public Dictionary<int, Village> Villages { get; private set; }

        /// <summary>
        ///     Gets the central village of the player.
        /// </summary>
        public Village CentralVillage
        {
            get
            {
                return Villages
                    .Select(i => i.Value)
                    .FirstOrDefault(i => i.IsCentral);
            }
        }

        /// <summary>
        ///     Gets player's oases.
        /// </summary>
        protected List<Oasis> Oases { get; private set; }

        /// <summary>
        ///     Fires when a new village is added.
        /// </summary>
        public event VillageEventHandler VillageAdded;

        /// <summary>
        ///     Fires when a village is removed.
        /// </summary>
        public event VillageEventHandler VillageRemoved;

        /// <summary>
        ///     Gets the village by searching it's id value.
        /// </summary>
        /// <param name="id">Village id.</param>
        /// <returns>Return the village if that village is found with given id value.</returns>
        public Village GetVillage(int id)
        {
            if (Villages.ContainsKey(id))
            {
                return Villages[id];
            }
            return null;
        }

        /// <summary>
        ///     Adds a new village to player's villages.
        ///     Fires a new village added event.
        /// </summary>
        /// <param name="id">Village id.</param>
        public void AddVillage(Village v)
        {
            if (Villages.ContainsKey(v.Id))
            {
                return;
            }

            Villages.Add(v.Id, v);
            Logger.Trace("{0}, new village added to me.", this);

            if (VillageAdded != null)
            {
                VillageAdded.Invoke(v);
            }
        }

        
        /// <summary>
        /// Removes a village.
        /// </summary>
        /// <param name="id">Village id.</param>
        public void RemoveVillage(int id)
        {
            if (!Villages.ContainsKey(id))
            {
                return;
            }

            Village v = Villages[id];
            Villages.Remove(id);

            if (VillageRemoved != null)
            {
                VillageRemoved.Invoke(v);
            }
        }
        

        /// <summary>
        ///     Gets the string representation of object.
        /// </summary>
        /// <returns>String value containing player's name.</returns>
        public override string ToString()
        {
            return Name;
        }
    }
}