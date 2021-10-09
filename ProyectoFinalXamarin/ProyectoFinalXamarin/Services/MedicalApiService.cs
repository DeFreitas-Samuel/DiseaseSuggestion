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
        IJsonSerializerService serializer = new JsonSerializerService();
        private Config config = new Config();


        public MedicalApiService()
        {
            config = new Config();

        }
        //Get Suggestions Task
        public async Task<Suggest> GetSuggestAsync()
        {
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.GetAsync(config.GetSuggestionsURL);

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
            var response = await httpClient.GetAsync(config.GetOutcomesURL);
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
            var api = RestService.For<IMedicalApiService>(config.GetDiseasesURL);
            var response = await api.GetDiseasesAsync();
            return response;
        }

        public async Task<bool> GetSessionAsync()
        {
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.GetAsync(config.GetSessionURL);

            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                var suggestResponse = serializer.Deserialize<InitializeSession>(responseString);
                config.SessionId = suggestResponse.SessionID;
                return true;
            }

            return false;
        }

        public async Task<bool> PostTermsConditionsAsync()
        {
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.PostAsync(config.TermsAndConditionsURL1 + config.SessionId + config.TermsAndConditionsURL2, null);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }
    }
}
