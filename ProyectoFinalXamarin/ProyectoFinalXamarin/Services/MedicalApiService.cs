using Prism.Services.Dialogs;
using ProyectoFinalXamarin.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace ProyectoFinalXamarin.Services
{
    class MedicalApiService : IMedicalApiService
    {
        IJsonSerializerService _serializer;
        IDialogService _dialogService;

        public MedicalApiService(IJsonSerializerService serializer, IDialogService dialogService)
        {
            _serializer = serializer;
            _dialogService = dialogService;
        }

        public async Task<Suggest> GetSuggestAsync()
        {
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.GetAsync(Config.GetDiseasesURL);

            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                var suggestResponse = _serializer.Deserialize<Suggest>(responseString);
                return suggestResponse;
            }

            return null;
        }

        //Get Outcomes Task
        public async Task<OutCome> GetOutcomesAsync()
        {
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.GetAsync(Config.GetOutcomesURL);
            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                var outcomeResponse = _serializer.Deserialize<OutCome>(responseString);
                return outcomeResponse;
            }
            return null;
        }

        //Get Diseases Task
        public async Task<Disease> GetDiseasesAsync()
        {
            var api = RestService.For<IMedicalApiService>(Config.GetDiseasesURL);
            var response = await api.GetDiseasesAsync();
            return response;
        }
        public async Task LoginAsync()
        {
            
            string api_key = "defreitas.samuel.99@gmail.com";
            string secret_key = "Aa97Wtc4HQk26Rwm3";
            byte[] secretBytes = Encoding.UTF8.GetBytes(secret_key);
            string computedHashString = "";
            using (HMACMD5 hmac = new HMACMD5(secretBytes))
            {
                byte[] dataBytes = Encoding.UTF8.GetBytes(Config.LoginUrl);
                byte[] computedHash = hmac.ComputeHash(dataBytes);
                computedHashString = Convert.ToBase64String(computedHash);
            }

            using (WebClient client = new WebClient())
            {
                client.Headers["Authorization"] = string.Concat("Bearer ", api_key, ":", computedHashString);
                string responseString = client.UploadString(Config.LoginUrl, "POST", "");
                var tokenAuthResponse = _serializer.Deserialize<TokenAuth>(responseString);
                await SecureStorage.SetAsync("token", tokenAuthResponse.Token);

            }
        }
    }
}
