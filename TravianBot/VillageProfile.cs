using System;
using System.Collections.Generic;
using System.Linq;
using TravianBot.Data;
using TravianBot.Enums;
using TravianBot.Structs;

namespace TravianBot
{
    /// <summary>
    ///     Specifies which buildings, upgrades, researches and such things
    ///     will be or have to be made to a village.
    /// </summary>
    [Serializable]
    public class VillageProfile
    {
        /// <summary>
        ///     Initializes a new instance of
        ///     the <see cref="VillageProfile" /> class.
        /// </summary>
        public VillageProfile(string name)
        {
            Name = name;
            BuildingRequirements = new List<BuildingData>();
            ResearchRequirements = new List<Research>();
        }

        /// <summary>
        ///     Gets or sets the profile name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     Gets building requirements.
        /// </summary>
        public IList<BuildingData> BuildingRequirements { get; private set; }

        /// <summary>
        ///     Gets research requirements.
        /// </summary>
        public IList<Research> ResearchRequirements { get; private set; }

        /// <summary>
        ///     Gets or sets a value indicating whether
        ///     this village profile requires villages to be
        ///     central village or does not.
        /// </summary>
        public bool Central { get; set; }

        /// <summary>
        ///     Gets missing buildings for given village.
        /// </summary>
        /// <param name="mv">My village object.</param>
        /// <returns>Missing buildings list.</returns>
        public IList<BuildingData> MissingBuildings(MyVillage mv)
        {
            var missingBuildings = new List<BuildingData>();

            foreach (BuildingData req in BuildingRequirements)
            {
                Building b = mv.Buildings
                    .FirstOrDefault(i => i.Type == req.Type);
                if ((b == null) || (b.Level != req.Level))
                {
                    missingBuildings.Add(req);
                }
            }

            return missingBuildings;
        }

        /// <summary>
        ///     Gets missing researches for given village.
        /// </summary>
        /// <param name="mv">My village object.</param>
        /// <returns>Missing researches list.</returns>
        public IList<Research> MissingResearches(MyVillage mv)
        {
            var missingResearches = new List<Research>();

            foreach (Research req in ResearchRequirements)
            {
                if (mv.Researches.ContainsKey(req.TroopType))
                {
                    Research r = mv.Researches[req.TroopType];

                    if ((r.Armoury != req.Armoury) ||
                        (r.Blacksmith != req.Blacksmith))
                    {
                        missingResearches.Add(req);
                    }
                }
                else
                {
                    missingResearches.Add(req);
                }
            }

            return missingResearches;
        }

        /// <summary>
        ///     Adds a new building requirement to profile.
        /// </summary>
        /// <param name="type">Structure type.</param>                         
        /// <param name="level">Structure level.</param>
        /// <param name="id">Id value.</param>
        /// <returns></returns>
        public BuildingData AddBuildingRequirement(
            BuildingType type,
            int level,
            int id = 0)
        {
            if (BuildingRequirements.Any(i => i.Type == type))
            {
                return BuildingRequirements.First(i => i.Type == type);
            }

            var br = new BuildingData(id, type, level);
            BuildingRequirements.Add(br);
            return br;
        }
    }
}