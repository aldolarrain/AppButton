using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace App1
{
    public class ApiService
    {
        string urlBase;
        string servicePrefix;
        string controller;
        HttpClient _client;
       

        public ApiService()
        {
            _client = new HttpClient();
        }

        public async Task<CountryData> GetCountryDataAsync(string uri)
        {
            CountryData countryData = null;
            try
            {
                var client = new HttpClient();
                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                //tokenType, accessToken);
                client.BaseAddress = new Uri(urlBase);
                var url = string.Format("{0}{1}", servicePrefix, controller);
                HttpResponseMessage response = await _client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    countryData = JsonConvert.DeserializeObject<CountryData>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\tERROR {0}", ex.Message);
            }

            return countryData;
        }
    }
}
