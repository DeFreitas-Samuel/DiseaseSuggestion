using Prism.Commands;
using Prism.Navigation;
using ProyectoFinalXamarin.Models;
using ProyectoFinalXamarin.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Essentials;

namespace ProyectoFinalXamarin.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {

        public ICommand NavigateCommand { get; }
        public ObservableCollection<Symptom> Symptoms { get; set; }

        private IMedicalApiService _medicalApiService;
        public HomeViewModel(INavigationService navigationService, IMedicalApiService medicalApiService): base(navigationService)
        {
            NavigateCommand = new DelegateCommand(OnNavigation);
            _medicalApiService = medicalApiService;
            GetSymptoms();           
        }
        private async void GetSymptoms()
        {
            var symptomResponse = await _medicalApiService.GetSymptomsAsync(await SecureStorage.GetAsync("token"));
            Symptoms = symptomResponse;
        }

        private async void OnNavigation()
        {
            await NavigationService.NavigateAsync(NavigationConstants.Paths.AnalysisCompleted);
        }

    }
}
