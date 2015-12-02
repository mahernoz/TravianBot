using TravianBot.Data;
using TravianBot.Enums;

namespace TravianBot
{
    public static class BuildingFactory
    {
        /// <summary>
        /// Logger for logging.
        /// </summary>
        private static NLog.Logger Logger =
            NLog.LogManager.GetCurrentClassLogger();

        public static Building[] GetBuildings(int villagetype)
        {
            var buildings = new Building[41];

            int[] crops = null;
            int[] woods = null;
            int[] clays = null;
            int[] irons = null;

            int[] stdCrops = { 2, 8, 9, 12, 13, 15 };
            int[] stdWoods = { 1, 3, 14, 17 };
            int[] stdClays = { 5, 6, 16, 18 };
            int[] stdIrons = { 4, 7, 10, 11 };

            Logger.Trace("Creating buildings for type:{0}", villagetype);

            switch (villagetype)
            {
                case 1:
                    crops = new[] { 1, 2, 4, 5, 8, 9, 12, 13, 15 };
                    woods = new[] { 3, 14, 17 };
                    clays = new[] { 6, 16, 18 };
                    irons = new[] { 7, 10, 11 };
                    break;
                case 2:
                    crops = new[] { 2, 8, 9, 12, 13, 15 };
                    woods = new[] { 3, 14, 17 };
                    clays = stdClays;
                    irons = new[] { 1, 4, 7, 10, 11 };
                    break;
                case 3:
                    crops = stdCrops;
                    woods = stdWoods;
                    clays = stdClays;
                    irons = stdIrons;
                    break;
                case 4:
                    crops = stdCrops;
                    woods = stdWoods;
                    clays = new[] { 4, 5, 6, 16, 18 };
                    irons = new[] { 7, 10, 11 };
                    break;
                case 5:
                    crops = stdCrops;
                    woods = new[] { 1, 3, 5, 14, 17 };
                    clays = new[] { 6, 16, 18 };
                    irons = stdIrons;
                    break;
                case 6:
                    crops = new[] { 1, 2, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 17, 18 };
                    woods = new[] { 3 };
                    clays = new[] { 16 };
                    irons = new[] { 4 };
                    break;
                case 7:
                    crops = new[] { 2, 3, 8, 9, 12, 13, 15 };
                    woods = new[] { 1, 4, 14, 17 };
                    clays = stdClays;
                    irons = new[] { 7, 10, 11 };
                    break;
                case 8:
                    crops = new[] { 2, 3, 8, 9, 12, 13, 15 };
                    woods = new[] { 4, 14, 17 };
                    clays = stdClays;
                    irons = new[] { 1, 7, 10, 11 };
                    break;
                case 9:
                    crops = new[] { 2, 3, 8, 9, 12, 13, 15 };
                    woods = new[] { 4, 5, 14, 17 };
                    clays = new[] { 6, 16, 18 };
                    irons = new[] { 1, 7, 10, 11 };
                    break;
                case 10:
                    crops = stdCrops;
                    woods = new[] { 3, 14, 17 };
                    clays = new[] { 4, 5, 6, 16, 18 };
                    irons = new[] { 1, 7, 10, 11 };
                    break;
                case 11:
                    crops = new[] { 6, 7, 14, 15, 17, 18 };
                    woods = new[] { 2, 3, 5, 13 };
                    clays = new[] { 10, 11, 16 };
                    irons = new[] { 1, 4, 8, 9, 12 };
                    break;
                case 12:
                    crops = stdCrops;
                    woods = new[] { 1, 3, 4, 14, 17 };
                    clays = stdClays;
                    irons = new[] { 7, 10, 11 };
                    break;
            }

            foreach (var i in crops)
                buildings[i] = new Building(i, BuildingType.CROPLAND);
            foreach (var i in woods)
                buildings[i] = new Building(i, BuildingType.WOODCUTTER);
            foreach (var i in clays)
                buildings[i] = new Building(i, BuildingType.CLAY_PIT);
            foreach (var i in irons)
                buildings[i] = new Building(i, BuildingType.IRON_MINE);

            for (int i = 19; i < 41; i++)
            {
                buildings[i] = new Building(i);
            }

            buildings[0] = buildings[1];
            return buildings;
        }
    }
}