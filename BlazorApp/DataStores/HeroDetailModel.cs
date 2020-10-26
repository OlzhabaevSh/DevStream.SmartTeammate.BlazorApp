using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.DataStores
{
    public class HeroDetailModel
    {
        public string Name { get; set; }

        public string Bio { get; set; }

        public string Atk { get; set; }

        public string[] Roles { get; set; }
    }
}
