using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.DataStores
{
    public class HeroModel
    {
        public string Key { get; set; }
        public string Name { get; set; }
        public string Bio { get; set; }
        public string Atk { get; set; }
        public string[] Roles { get; set; }
    }
}
