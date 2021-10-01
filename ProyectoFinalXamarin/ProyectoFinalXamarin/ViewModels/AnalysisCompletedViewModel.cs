using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace ProyectoFinalXamarin.ViewModels
{
    public class AnalysisCompletedViewModel : BaseViewModel
    {
        public ICommand NavigateResultCommand { get; }
        public ICommand NavigateRecommendationCommand { get; }
        public AnalysisCompletedViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            NavigateResultCommand = new DelegateCommand(OnNavigationResults);
            NavigateRecommendationCommand = new DelegateCommand(OnNavigationRecommendations);
        }

        private async void OnNavigationRecommendations() => await _navigationService.NavigateAsync("RecommendTestPage");


        private async void OnNavigationResults() => await _navigationService.NavigateAsync("ResultsPage");

        INavigationService _navigationService;
    }
}
