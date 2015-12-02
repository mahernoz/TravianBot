//--------------------------------------------------------
// <copyright file="Oasis.cs" company="company">
//        Copyright (c) company. All rights reserved.
// </copyright>
// <author>Muhammed Emir Özçevik</author>
//--------------------------------------------------------

namespace TravianBot.Data
{
    /// <summary>
    ///     Oasis class.
    /// </summary>
    public class Oasis : MapItem
    {
        /// <summary>
        ///     Initializes a new instance of the Oasis class.
        /// </summary>
        /// <param name="id">Oasis id.</param>
        /// <param name="type">Oasis type.</param>
        public Oasis(int id,
            OasisType oasisType)
            : base(id)
        {
            OasisType = oasisType;
        }

        /// <summary>
        ///     Gets the type of oasis.
        /// </summary>
        public OasisType OasisType { get; private set; }
    }
}