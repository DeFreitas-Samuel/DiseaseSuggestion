using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Essentials;

namespace ProyectoFinalXamarin.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {

        public ICommand NavigateCommand { get; }

        public HomeViewModel(INavigationService navigationService): base(navigationService)
        {
            NavigateCommand = new DelegateCommand(OnNavigation);

        }

        private async void OnNavigation()
        {
            await NavigationService.NavigateAsync(NavigationConstants.Paths.AnalysisCompleted);
        }



    }
}
