//--------------------------------------------------------
// <copyright file="Alliance.cs" company="company">
//        Copyright (c) company. All rights reserved.
// </copyright>
// <author>Muhammed Emir Özçevik</author>
//--------------------------------------------------------

using System.Collections.Generic;

namespace TravianBot.Data
{
    /// <summary>
    ///     Holds the information for alliance.
    /// </summary>
    public class Alliance
    {
        /// <summary>
        ///     Initializes a new instance of the Alliance class.
        /// </summary>
        /// <param name="id">Alliance id.</param>
        public Alliance(int id)
        {
            ID = id;
            Players = new List<Player>();
        }

        /// <summary>
        ///     Gets or sets id.
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        ///     Gets alliance players.
        /// </summary>
        public List<Player> Players { get; private set; }

        /// <summary>
        ///     Gets or sets alliance name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets alliance short name.
        /// </summary>
        public string ShortName { get; set; }

        /// <summary>
        ///     Gets or sets alliance rank.
        /// </summary>
        public int Rank { get; set; }

        /// <summary>
        ///     Gets or sets alliance score.
        /// </summary>
        public int Score { get; set; }

        /// <summary>
        ///     Fires when a new player added to alliance.
        /// </summary>
        public event PlayerEventHandler OnPlayerAdded;

        /// <summary>
        ///     Adds a new player to alliance.
        ///     Fires a new player added event.
        /// </summary>
        /// <param name="player">Player to add.</param>
        public void AddPlayer(Player player)
        {
            Players.Add(player);

            if (OnPlayerAdded != null)
            {
                OnPlayerAdded.Invoke(player);
            }
        }

        public override string ToString()
        {
            return string.IsNullOrEmpty(Name) ? string.Empty : Name;
        }
    }
}