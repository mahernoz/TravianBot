//--------------------------------------------------------
// <copyright file="Building.cs" company="company">
//        Copyright (c) company. All rights reserved.
// </copyright>
// <author>Muhammed Emir Özçevik</author>
//--------------------------------------------------------

using System;
using NLog;
using TravianBot.Enums;
using TravianBot.Utilities;

namespace TravianBot.Data
{
    /// <summary>
    ///     Represents a travian building.
    /// </summary>
    [Serializable]
    public class Building
    {
        /// <summary>
        ///     Logger for loggin.
        /// </summary>
        [NonSerialized]
        private static readonly Logger Logger =
            LogManager.GetCurrentClassLogger();

        /// <summary>
        ///     Stores level value.
        /// </summary>
        private int _level;

        /// <summary>
        ///     Initializes a new instance of the
        ///     <see cref="Building" /> class.
        /// </summary>
        /// <param name="id">Building id.</param>
        /// <param name="type">Building type.</param>
        /// <param name="level">Building level.</param>
        public Building(
            int id,
            BuildingType type = BuildingType.UNKNOWN,
            int level = 0)
        {
            Id = id;
            Type = type;
            Level = level;
        }

        /// <summary>
        ///     Gets the id value.
        /// </summary>
        public int Id { get; private set; }

        /// <summary>
        ///     Gets or sets the name string.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets the level.
        /// </summary>
        public int Level
        {
            get { return _level; }
            set
            {
                if (value > _level)
                {
                    _level = value;
                    Logger.Info("{0} upgraded.", this);
                    if (Upgrade != null)
                    {
                        Upgrade.Invoke(this);
                    }
                }
                else if ((value < _level))
                {
                    _level = value;
                    Logger.Info("{0} downgraded.", this);
                    if (Downgrade != null)
                    {
                        Downgrade.Invoke(this);
                    }
                }

                if ((Level == 0) && (Demolish != null))
                {
                    Demolish.Invoke(this);
                    if (!((int) Type).IsIn(1, 2, 3, 4))
                    {
                        Type = BuildingType.EMPTY;
                    }
                }
            }
        }

        /// <summary>
        ///     Gets or sets the maximum level.
        /// </summary>
        public int MaxLevel { get; set; }

        /// <summary>
        ///     Gets or sets the structure type.
        /// </summary>
        public BuildingType Type { get; set; }

        /// <summary>
        ///     Gets the time required to upgrade.
        /// </summary>
        public TimeSpan UpgradeTime { get; set; }

        /// <summary>
        ///     Fires when structure upgraded.
        /// </summary>
        public event BuildingEventHandler Upgrade;

        /// <summary>
        ///     Fires when structure downgraded.
        /// </summary>
        public event BuildingEventHandler Downgrade;

        /// <summary>
        ///     Fires when structure level is zeroed.
        /// </summary>
        public event BuildingEventHandler Demolish;

        /// <summary>
        ///     Gets the string representation of this object.
        /// </summary>
        /// <returns>Object's string representation.</returns>
        public override string ToString()
        {
            return string.Format(
                "Id:{0} Type:{1} Level:{2}",
                Id,
                Type,
                Level);
        }
    }
}