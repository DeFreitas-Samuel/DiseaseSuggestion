using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
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
        public ICommand SelectCommand { get; }
        public ICommand NavigateCommand { get; }
        public ICommand AnalizeCommand { get; }
        public ICommand DeleteCommand { get; }
        public ObservableCollection<Symptom> Symptoms { get; set; }
        public ObservableCollection<Symptom> UserSymptoms { get; set; } = new ObservableCollection<Symptom>();
        public List<int> SymptomsToSend { get; set; } = new List<int>();
        public ObservableCollection<string> GenderList { get; set; } 
        public string SelectedGender { get; set; }
        public Symptom SelectedSymptom { get; set; }
        public string Year { get; set; }
        private IJsonSerializerService _serializer;
        private IMedicalApiService _medicalApiService;
        private IPageDialogService _pageDialogService;
        public HomeViewModel(INavigationService navigationService, IMedicalApiService medicalApiService, IPageDialogService pageDialogService, IJsonSerializerService jsonSerializerService): base(navigationService)
        {
            NavigateCommand = new DelegateCommand(OnNavigation);
            SelectCommand = new DelegateCommand(OnSelect);
            AnalizeCommand = new DelegateCommand(OnAnalize);
            DeleteCommand = new DelegateCommand<Symptom>(OnDelete);
            _medicalApiService = medicalApiService;
            _pageDialogService = pageDialogService;
            _serializer = jsonSerializerService;
            GenderList = new ObservableCollection<string>
            {
                "Male",
                "Female"
            };
            GetSymptoms();           
        }

        private void OnDelete(Symptom symptom)
        {
            UserSymptoms.Remove(symptom);
            SymptomsToSend.Remove(symptom.Id);
        }

        private async void OnAnalize()
        {
            string listOfSymptoms = _serializer.Serialize(SymptomsToSend);
            var diagnosticResponse =  await _medicalApiService.DiagnosticsAsync(listOfSymptoms, SelectedGender,Year,await SecureStorage.GetAsync("token"));
            var parameter = new NavigationParameters();
            parameter.Add("Diagnostics", diagnosticResponse);
            await NavigationService.NavigateAsync(NavigationConstants.Paths.Results, parameter);
            
        }

        private void OnSelect()
        {
            if (SelectedSymptom != null)
            {
                if (!UserSymptoms.Contains(SelectedSymptom)) 
                {
                    UserSymptoms.Add(SelectedSymptom);
                }
                if (!SymptomsToSend.Contains(SelectedSymptom.Id))
                {
                    SymptomsToSend.Add(SelectedSymptom.Id);
                }
                SelectedSymptom = null;
            }
            else 
            {
                _pageDialogService.DisplayAlertAsync("Alert", "Please select a symptom", "ok");
            }
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
