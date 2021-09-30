using ProyectoFinalXamarin.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalXamarin.Services
{
    class MedicalApiService : IMedicalApiService
    {
        private const string SessionId = "KEY HERE";
        IJsonSerializerService serializer = new JsonSerializerService();

        //Get Suggestions Task
        public async Task<Suggest> GetSuggestAsync()
        {
             
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.GetAsync($"https://api.endlessmedical.com/v1/dx/GetSuggestedSpecializations?SessionID={SessionId}&NumberOfResults=10");

            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                var suggestResponse = serializer.Deserialize<Suggest>(responseString);
                return suggestResponse;
            }

            return null;
        }

        //Get Outcomes Task
        public async Task<OutCome> GetOutcomesAsync()
        {
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.GetAsync("https://api.endlessmedical.com/v1/dx/GetOutcomes");
            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                var outcomeResponse = serializer.Deserialize<OutCome>(responseString);
                return outcomeResponse;
            }
            return null;
        }

        //Get Diseases Task
        public async Task<Disease> GetDiseasesAsync()
        {
            var api = RestService.For<IMedicalApiService>("https://api.endlessmedical.com/");
            var response = await api.GetDiseasesAsync();
            return response;
        }
    }
}
