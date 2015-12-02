//--------------------------------------------------------
// <copyright file="MapItem.cs" company="company">
//        Copyright (c) company. All rights reserved.
// </copyright>
// <author>Muhammed Emir Özçevik</author>
//--------------------------------------------------------

using System;

namespace TravianBot.Data
{
    /// <summary>
    ///     Base class to hold basic map item information.
    /// </summary>
    [Serializable]
    public abstract class MapItem
    {
        /// <summary>
        ///     Initializes a new instance of the MapItem class.
        /// </summary>
        /// <param name="id">Id value.</param>
        protected MapItem(int id)
        {
            Id = id;
        }

        /// <summary>
        ///     Gets the id.
        /// </summary>
        public int Id { get; private set; }

        /// <summary>
        ///     Gets the coordinate-x value.
        /// </summary>
        public int X
        {
            get { return Id/400; }
        }

        /// <summary>
        ///     Gets the coordinate-y value.
        /// </summary>
        public int Y
        {
            get { return Id%400 + 1; }
        }

        /// <summary>
        ///     Gets or sets the owner player of this item.
        /// </summary>
        public Player Player { get; set; }

        /// <summary>
        ///     Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets the type.
        /// </summary>
        public int Type { get; protected set; }
    }
}