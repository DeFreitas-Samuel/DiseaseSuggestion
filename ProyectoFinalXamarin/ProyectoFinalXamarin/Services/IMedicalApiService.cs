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
    }
}
