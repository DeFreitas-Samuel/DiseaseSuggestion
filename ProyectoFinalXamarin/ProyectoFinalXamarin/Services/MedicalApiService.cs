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
        

        public MedicalApiService(IJsonSerializerService serializer)
        {
            _serializer = serializer;
        }

        public async Task LoginAsync()
        {

            string api_key = Config.ApiKey;
            string secret_key = Config.SecretKey;

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

        public async Task<ObservableCollection<Diagnostic>> DiagnosticsAsync(string symptomList, string gender, string year, string token)
        {
            var api = RestService.For<IMedicalApiService>(Config.BaseUrl);
            var response = await api.DiagnosticsAsync(symptomList, gender, year, token);
            return response;
        }

        public async Task<ObservableCollection<Issue>> GetIssuesAsync(string token)
        {
            var api = RestService.For<IMedicalApiService>(Config.BaseUrl);
            var response = await api.GetIssuesAsync(token);
            return response;
        }

        public async Task<Issue> GetIssueAsync(string token, int id)
        {
            var api = RestService.For<IMedicalApiService>(Config.BaseUrl);
            var response = await api.GetIssueAsync(token, id);
            return response;
        }
    }
}
