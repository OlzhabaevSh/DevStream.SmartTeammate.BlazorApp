using Blazored.LocalStorage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.DataStores
{
    public class HeroTeammatesDataSource
    {
        private readonly ILocalStorageService _localStorage;

        private string Key => "heroTeammates";

        public HeroTeammatesDataSource(ILocalStorageService localStorage) 
        {
            _localStorage = localStorage;
        }

        public async Task<bool> IsStoreEmpty() 
        {
            return !await _localStorage.ContainKeyAsync(Key);
        }

        public async Task<DataSourceResult<HeroTeammatesModel[]>> GetFromStore() 
        {
            var data = await _localStorage.GetItemAsync<DataSourceValue<HeroTeammatesModel[]>>(Key);

            return new DataSourceResult<HeroTeammatesModel[]>()
            {
                Key = Key,
                Value = data
            };
        }

        public async Task Write(HeroTeammatesModel[] model) 
        {
            var dataSourceValue = new DataSourceValue<HeroTeammatesModel[]>() 
            {
                Data = model,
                LastUpdateAt = DateTime.Now
            };

            await _localStorage.SetItemAsync(Key, dataSourceValue);
        }



    }
}
