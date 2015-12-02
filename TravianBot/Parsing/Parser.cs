//--------------------------------------------------------
// <copyright file="Parser.cs" company="company">
//        Copyright (c) company. All rights reserved.
// </copyright>
// <author>Muhammed Emir Özçevik</author>
//--------------------------------------------------------

using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using NLog;
using TravianBot.Enums;
using TravianBot.Structs;
using TravianBot.Utilities;

namespace TravianBot.Parsing
{
    /// <summary>
    ///     Extracts data from web pages.
    /// </summary>
    public static class Parser
    {
        /// <summary>
        ///     Logger for logging.
        /// </summary>
        private static readonly Logger Logger =
            LogManager.GetCurrentClassLogger();

        /// <summary>
        ///     Loaded regex data.
        /// </summary>
        private static Dictionary<string, string> Patterns { get; set; }

        /// <summary>
        ///     Reads regex file and loads it's contents to patterns.
        /// </summary>
        public static void SetRegex(string filePath)
        {
            FileStream fs = File.OpenRead(filePath);

            Patterns = new Dictionary<string, string>();
            using (var sr = new StreamReader(fs))
            {
                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine();
                    if (!line.Equals(""))
                    {
                        var key = line.Split(':')[0];
                        var val = line.Substring(line.IndexOf(':') + 2);
                        key = key.TrimEnd();
                        Patterns.Add(key, val);
                    }
                }
            }

            fs.Close();
        }

        /// <summary>
        /// Extracts village's name.
        /// </summary>
        /// <param name="content">Content to extract.</param>
        /// <returns>Village's name.</returns>
        public static string VillageName(string content)
        {
            var m = GetMatch(content, "village name");
            return m.Value;
        }

        /// <summary>
        /// Gets a value indicating whether village is central or not.
        /// </summary>
        /// <param name="content">Content to extract.</param>
        /// <returns>Village is central or not boolean.</returns>
        public static bool IsVillageCentral(string content)
        {
            return GetMatch(content, "village is central").Success;
        }

        /// <summary>
        /// Extracts village's type.
        /// </summary>
        /// <param name="content">Content to extract.</param>
        /// <returns>Village type.</returns>
        public static int VillageType(string content)
        {
            var m = GetMatch(content, "village type");
            return m.Value.AsInt();
        }

        /// <summary>
        /// Extracts active village's id.
        /// </summary>
        /// <param name="content">Content to extract.</param>
        /// <returns>Active village's id.</returns>
        public static int ActiveVillage(string content)
        {
            var m = GetMatch(content, "active village");
            return m.Groups["id"].Value.AsInt();
        }

        /// <summary>
        /// Extracts fields.
        /// </summary>
        /// <param name="content">Content to extract.</param>
        /// <returns>Extracted field data.</returns>
        public static BuildingData[] Fields(string content)
        {
            var mc = GetMatches(content, "f*");
            var data = new BuildingData[mc.Count];

            for (int i = 0; i < mc.Count; i++)
            {
                int id = mc[i].Groups["id"].Value.AsInt();
                int level = mc[i].Groups["level"].Value.AsInt();
                BuildingType type = BuildingType.UNKNOWN;

                string typeStr = mc[i].Groups["type"].Value;

                switch (typeStr)
                {
                    case "Orman":
                        type = BuildingType.WOODCUTTER;
                        break;
                    case "Tuğla":
                        type = BuildingType.CLAY_PIT;
                        break;
                    case "Demir":
                        type = BuildingType.IRON_MINE;
                        break;
                    case "Tarla":
                        type = BuildingType.CROPLAND;
                        break;
                }

                data[i] = new BuildingData(id, type, level);
            }

            return data;
        }

        /// <summary>
        /// Extracts buildings.
        /// </summary>
        /// <param name="content">Content to extract.</param>
        /// <returns>Extracted building data.</returns>
        public static BuildingData[] Buildings(string content)
        {
            var mc = GetMatches(content, "b*");
            var data = new BuildingData[mc.Count];

            for (int i = 0; i < mc.Count; i++)
            {
                int id = mc[i].Groups["id"].Value.AsInt() + 18;
                var type = BuildingType.EMPTY;
                int level = 0;

                if (mc[i].Groups["full"].Success)
                {
                    type = (BuildingType)mc[i].Groups["type"].Value.AsInt();
                    level = mc[i].Groups["level"].Value.AsInt();
                }

                data[i] = new BuildingData(id, type, level);
            }

            return data;
        }

        /// <summary>
        /// Extracts random key.
        /// </summary>
        /// <param name="content">Content to extract.</param>
        /// <returns>Extracted random key.</returns>
        public static string RandomKey(string content)
        {
            var m = GetMatch(content, "random key");
            return m.Value;
        }

        /// <summary>
        /// Extracts new report's count.
        /// </summary>
        /// <param name="content">Content to extract.</param>
        /// <returns>New report's count.</returns>
        public static int ReportsCount(string content)
        {
            Match m = GetMatch(content, "report count");

            if (m.Groups["newreport"].Success)
            {
                return m.Groups["count"].Value.AsInt();
            }
            return 0;
        }

        /// <summary>
        /// Extracts new report's ids.
        /// </summary>
        /// <param name="content">Content to extract.</param>
        /// <returns>New report's ids.</returns>
        public static int[] ReportsIds(string content)
        {
            MatchCollection mc = GetMatches(content, "reports ids");
            int[] ids = new int[mc.Count];

            for (int i = 0; i < mc.Count; i++)
            {
                ids[i] = mc[i].Groups["id"].Value.AsInt();
            }

            return ids;
        }

        public static Report[] Report(string content)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Extracts players.
        /// </summary>
        /// <param name="content">Content to extract.</param>
        /// <returns>Extracted player data.</returns>
        public static PlayerData[] Players(string content)
        {
            var mc = GetMatches(content, "p*");
            var data = new PlayerData[mc.Count];

            for (int i = 0; i < mc.Count; i++)
            {
                int id = mc[i].Groups["id"].Value.AsInt();
                string name = mc[i].Groups["name"].Value;
                int ally = 0;

                if (mc[i].Groups["isally"].Success)
                {
                    ally = mc[i].Groups["allyid"].Value.AsInt();
                }

                data[i] = new PlayerData(id, name, ally);
            }

            return data;
        }

        /// <summary>
        /// Extracts villages.
        /// </summary>
        /// <param name="content">Content to extract.</param>
        /// <returns>Extracted village data.</returns>
        public static VillageData[] Villages(string content)
        {
            string ownerName = GetMatch(content, "v owner name")
                .Groups["name"].Value;
            
            var mc = GetMatches(content, "v*");
            var data = new VillageData[mc.Count];

            for (int i = 0; i < mc.Count; i++)
            {
                var id = mc[i].Groups["id"].Value.AsInt();
                var name = mc[i].Groups["name"].Value;
                var pop = mc[i].Groups["pop"].Value.AsInt();
                bool central = mc[i].Groups["central"].Success;

                data[i++] = new VillageData(id, name, pop, ownerName, central); 
            }

            return data;
        }

        private static MatchCollection GetMatches(string content, string regKey)
        {
            string reg;
            if (Patterns.TryGetValue(regKey, out reg))
            {
                return Regex.Matches(content, reg);
            }
            return null;
        }

        private static Match GetMatch(string content, string regKey)
        {
            string reg;
            if (Patterns.TryGetValue(regKey, out reg))
            {
                return Regex.Match(content, reg);
            }
            return null;
        }
    }
}