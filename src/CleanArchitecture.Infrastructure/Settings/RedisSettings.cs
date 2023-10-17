using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Settings
{
    public class RedisSetting
    {
        public string Address { get; set; }
        public string Password { get; set; }
        public string Port { get; set; }
        public string Ip { get; set; }
    }
}
