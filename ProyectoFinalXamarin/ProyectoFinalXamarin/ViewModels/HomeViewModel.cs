using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace ProyectoFinalXamarin.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        public ICommand NavigateCommand { get; }
        public HomeViewModel(INavigationService navigationService)
        {

            _navigationService = navigationService;
            NavigateCommand = new DelegateCommand(OnNavigation);
        }

        private async void OnNavigation() => await _navigationService.NavigateAsync("AnalysisCompletedPage");


        INavigationService _navigationService;
    }
}
