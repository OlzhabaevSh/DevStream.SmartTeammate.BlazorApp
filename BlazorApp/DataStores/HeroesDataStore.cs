using Blazored.LocalStorage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorApp.DataStores
{
    public class HeroesDataStore
    {
        private readonly ILocalStorageService _localStorage;
        private readonly HttpClient _httpClient;

        private string Key => "hero";

        public HeroesDataStore(ILocalStorageService localStorage, HttpClient httpClient) 
        {
            _localStorage = localStorage;
            _httpClient = httpClient;
        }

        public async Task<bool> IsStoreEmpty() 
        {
            return !await _localStorage.ContainKeyAsync(Key);
        }

        public async Task<DataSourceResult<HeroModel[]>> GetFromStore() 
        {
            var data = await _localStorage.GetItemAsync<DataSourceValue<HeroModel[]>>(Key);

            return new DataSourceResult<HeroModel[]>() 
            {
                Key = Key,
                Value = data
            };
        }

        public async Task Write(HeroModel[] model) 
        {
            var dataSourceValue = new DataSourceValue<HeroModel[]>() 
            {
                Data = model,
                LastUpdateAt = DateTime.Now
            };

            await _localStorage.SetItemAsync<DataSourceValue<HeroModel[]>>(Key, dataSourceValue);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="url">sample-data/HeroesList.json</param>
        /// <returns></returns>
        public async Task<HeroModel[]> DownloadFromService(string url) 
        {
            var downloadData = await _httpClient.GetFromJsonAsync<Dictionary<string, HeroDetailModel>>(url);

            return downloadData.Select(x => new HeroModel() 
            {
                Key = x.Key,
                Name = x.Value.Name,
                Bio = x.Value.Bio,
                Atk = x.Value.Atk,
                Roles = x.Value.Roles
            }).ToArray();
        }

    }
}
