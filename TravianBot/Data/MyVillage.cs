//--------------------------------------------------------
// <copyright file="MyVillage.cs" company="company">
//        Copyright (c) company. All rights reserved.
// </copyright>
// <author>Muhammed Emir Özçevik</author>
//--------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using NLog;
using TravianBot.Enums;
using TravianBot.Structs;

namespace TravianBot.Data
{
    [Serializable]
    public class MyVillage : Village
    {
        /// <summary>
        ///     Logger for logging.
        /// </summary>
        [NonSerialized]
        private static Logger Logger =
            LogManager.GetCurrentClassLogger();

        /// <summary>
        ///     Initializes a new instance of
        ///     the <see cref="MyVillage" /> class.
        /// </summary>
        /// <param name="id">Village id.</param>
        public MyVillage(int id)
            : base(id)
        {
            Researches = new Dictionary<TroopType, Research>();
            Resources = new Resources(0, 0, 0, 0);
            Troops = new List<Troop>();
            Supports = new Dictionary<Village, List<Troop>>();
        }

        /// <summary>
        ///     Fires when any building is upgraded.
        /// </summary>
        public event BuildingEventHandler BuildingUpgrade;

        /// <summary>
        ///     Handles building upgrade events.
        /// </summary>
        /// <param name="s">Event building.</param>
        public void OnBuildingUpgrade(Building b)
        {
            if (BuildingUpgrade != null)
            {
                BuildingUpgrade.Invoke(b);
            }
        }

        /// <summary>
        ///     Sets the type of village.
        /// </summary>
        /// <param name="type">Type value.</param>
        public void SetType(int type)
        {
            if (Type == type)
            {
                return;
            }

            Type = type;
        }

        public void SetBuildings(Building[] buildings)
        {
            Buildings = buildings;
        }

        #region Properties

        /// <summary>
        ///     Gets or sets the resource.
        /// </summary>
        public Resources Resources { get; set; }

        /// <summary>
        ///     Gets or sets the troop list.
        /// </summary>
        public IList<Troop> Troops { get; set; }

        /// <summary>
        ///     Gets or sets the support troops.
        /// </summary>
        public IDictionary<Village, List<Troop>> Supports { get; set; }

        /// <summary>
        ///     Gets village buildings.
        /// </summary>
        public Building[] Buildings { get; private set; }

        /// <summary>
        ///     Gets researches.
        /// </summary>
        public IDictionary<TroopType, Research> Researches { get; private set; } 

        /// <summary>
        ///     Gets the main building.
        /// </summary>
        public Building MainBuilding
        {
            get
            {
                return Buildings
                    .FirstOrDefault(i => i.Type == BuildingType.MAIN_BUILDING);
            }
        }

        /// <summary>
        ///     Gets the wall building.
        /// </summary>
        public Building Wall
        {
            get { return Buildings[40]; }
        }

        /// <summary>
        ///     Gets a value indicating whether this
        ///     village's building data is set or not.
        /// </summary>
        public bool IsSet
        {
            get { return Buildings.Any(i => i.Type == BuildingType.UNKNOWN); }
        }

        #endregion
    }
}