using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.DataStores
{
    public class DataSourceValue<TModel>
    {
        public DateTime LastUpdateAt { get; set; }

        public TModel Data { get; set; }
    }
}
