using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.DataStores
{
    public class HeroTeammatesModel
    {
        public string HeroKey { get; set; }

        public Dictionary<int, string> TeammateKeys { get; set; }
    }
}
