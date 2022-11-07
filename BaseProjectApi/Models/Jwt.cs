using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseProjectApi.Models
{
    public class Jwt
    {
        public string Token { get; set; }
        public DateTime Exp { get; set; }
    }
}
