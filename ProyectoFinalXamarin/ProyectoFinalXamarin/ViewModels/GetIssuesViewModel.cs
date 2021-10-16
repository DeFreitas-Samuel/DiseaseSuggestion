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
    public class GetIssuesViewModel: BaseViewModel
    {
        public ObservableCollection<Issue> Issues { get; set; }
        private INavigationService _navigationService;
        private IMedicalApiService _medicalApiService;
        private IPageDialogService _pageDialogService;
        public ICommand GetIssueCommand { get; }
        public Issue SelectedIssue { get; set; }
        public string Description { get; set; } = null;
        public string DescriptionShort { get; set; } = null;
        public string MedicalCondition { get; set; } = null;
        public string PossibleSymptoms { get; set; } = null;
        public string ProfName { get; set; } = null;
        public string Synonyms { get; set; } = null;
        public string TreatmentDescription { get; set; } = null;

        public GetIssuesViewModel(INavigationService navigationService, IMedicalApiService medicalApiService, IPageDialogService pageDialogService, IJsonSerializerService jsonSerializerService) : base(navigationService)
        {
            _navigationService = navigationService;
            _medicalApiService = medicalApiService;
            _pageDialogService = pageDialogService;
            GetIssueCommand = new DelegateCommand(OnSelect);
            GetIssues();
        }
        private async void GetIssues()
        {
            var issueResponse = await _medicalApiService.GetIssuesAsync(await SecureStorage.GetAsync("token"));
            Issues = issueResponse;
        }
        private async void OnSelect()
        {
            if (SelectedIssue != null)
            {
                var issueResponse = await _medicalApiService.GetIssueAsync(await SecureStorage.GetAsync("token"),SelectedIssue.Id);
                Description = issueResponse.Description;
                DescriptionShort = issueResponse.DescriptionShort;
                MedicalCondition = issueResponse.MedicalCondition;
                PossibleSymptoms = issueResponse.PossibleSymptoms;
                ProfName = issueResponse.ProfName;
                Synonyms = issueResponse.Synonyms;
                TreatmentDescription = issueResponse.TreatmentDescription;
            }
            else
            {
               await  _pageDialogService.DisplayAlertAsync("Alert", "Please select a issue", "ok");
            }
        }
    }
}
