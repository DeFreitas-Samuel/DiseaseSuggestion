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
        public AnalysisCompletedViewModel(INavigationService navigationService): base(navigationService)
        {
            NavigateResultCommand = new DelegateCommand(OnNavigationResults);
            NavigateRecommendationCommand = new DelegateCommand(OnNavigationRecommendations);
        }

        private async void OnNavigationRecommendations()
        {
            await NavigationService.NavigateAsync(NavigationConstants.Paths.RecommendTest);
        }

        private async void OnNavigationResults()
        {
            await NavigationService.NavigateAsync(NavigationConstants.Paths.Results);
        }
    }
}
