using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.DataStores
{
    public class DataSourceResult<TModel>
    {
        public string Key { get; set; }

        public DataSourceValue<TModel> Value { get; set; }
    }
}
