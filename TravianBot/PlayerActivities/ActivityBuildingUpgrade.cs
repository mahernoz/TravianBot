using System.Net.Http;
using System.Threading.Tasks;
using TravianBot.Enums;

namespace TravianBot
{
    /// <summary>
    ///     Represents build and upgrade activities.
    /// </summary>
    public class ActivityBuildingUpgrade : Activity
    {
        /// <summary>
        ///     Creates a new instance of the <see cref="BuildingUpgradeActivity"/> class.
        /// </summary>
        /// <param name="buildingId">Building id.</param>
        public ActivityBuildingUpgrade(int buildingId)
        {
            BuildingId = buildingId;
        }

        public int BuildingId { get; set; }

        public override Task<HttpResponseMessage> ActWith(IClient client)
        {
            throw new System.NotImplementedException();
        }
    }
}