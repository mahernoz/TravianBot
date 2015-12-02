//--------------------------------------------------------
// <copyright file="Village.cs" company="company">
//        Copyright (c) company. All rights reserved.
// </copyright>
// <author>Muhammed Emir Özçevik</author>
//--------------------------------------------------------

using System;
using NLog;

namespace TravianBot.Data
{
    /// <summary>
    ///     Represents a travian village.
    /// </summary>
    [Serializable]
    public class Village : MapItem
    {
        /// <summary>
        ///     Logger for logging.
        /// </summary>
        [NonSerialized]
        private static Logger Logger =
            LogManager.GetCurrentClassLogger();

        /// <summary>
        ///     Initializes a new instance of
        ///     the <see cref="Village" /> class.
        /// </summary>
        /// <param name="id"></param>
        public Village(int id)
            : base(id)
        {
        }

        /// <summary>
        ///     Gets or sets the loyalty of population.
        /// </summary>
        public int Loyalty { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating
        ///     whether village is central or not.
        /// </summary>
        public bool IsCentral { get; set; }

        /// <summary>
        ///     Gets or sets the population value.
        /// </summary>
        public int Population { get; set; }

        /// <summary>
        ///     Gets string representation of object.
        /// </summary>
        /// <returns>String value.</returns>
        public override string ToString()
        {
            return string.Format("{0} {1}", Id, Name);
        }
    }
}