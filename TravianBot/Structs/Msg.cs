using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravianBot.Structs
{
    public struct Msg
    {
        int _from;
        int _to;
        string _topic;
        string _msg;

        public Msg(int from, int to, string topic, string msg)
        {
            _from = from;
            _to = to;
            _topic = topic;
            _msg = msg;
        }
    }
}
