using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace TravianBot
{
    public interface IClient
    {
        Task<HttpResponseMessage> Send(
            Page page,
            KeyValuePair<string, string>[] urlParams,
            KeyValuePair<string, string>[] postValues);
    }
}