using System.Net.Http;
using System.Threading.Tasks;

namespace TravianBot
{
    public abstract class Activity
    {
        public string Description { get; set; }

        public abstract Task<HttpResponseMessage> ActWith(IClient client);
    }
}