using System;
using System.Net.Http;
using System.Threading.Tasks;
using TravianBot.Enums;

namespace TravianBot
{
    public class ActivityNewBuilding : Activity
    {
        public ActivityNewBuilding(int id, BuildingType type)
        {
            Id = id;
            Type = type;
        }

        public BuildingType Type { get; set; }

        public int Id { get; set; }

        public override Task<HttpResponseMessage> ActWith(IClient client)
        {
            throw new NotImplementedException();
        }
    }
}