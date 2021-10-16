using ProyectoFinalXamarin.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace ProyectoFinalXamarin.Services
{
    public interface IMedicalApiService
    {
        Task LoginAsync();

        [Get("/symptoms?token={token}&format=json&language=en-gb")]
        Task<ObservableCollection<Symptom>> GetSymptomsAsync(string token);

        [Get("/diagnosis?symptoms={symptomList}&gender={gender}&year_of_birth={year}&token={token}&format=json&language=en-gb")]
        Task<ObservableCollection<Diagnostic>> DiagnosticsAsync(string symptomList, string gender, string year, string token);

        [Get("/issues?token={token}&format=json&language=en-gb")]
        Task<ObservableCollection<Issue>> GetIssuesAsync(string token);

        [Get("/issues/{id}/info?token={token}&format=json&language=en-gb")]
        Task<Issue> GetIssueAsync(string token,int id);
    }
}
