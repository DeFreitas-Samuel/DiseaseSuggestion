using Prism.Services;
using Prism.Services.Dialogs;
using ProyectoFinalXamarin.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        IPageDialogService _pageDialogService;

        public MedicalApiService(IJsonSerializerService serializer, IPageDialogService pageDialogService)
        {
            _serializer = serializer;
            _pageDialogService = pageDialogService;
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

        public async Task<ObservableCollection<Symptom>> GetSymptomsAsync(string token)
        {
            var api = RestService.For<IMedicalApiService>(Config.BaseUrl);
            var response = await api.GetSymptomsAsync(token);
            return response;
        }
    }
}
