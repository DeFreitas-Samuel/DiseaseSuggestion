using Prism.Navigation;
using ProyectoFinalXamarin.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ProyectoFinalXamarin.ViewModels
{
    public class ResultsViewModel : BaseViewModel, INavigatedAware
    {
        public ObservableCollection<Diagnostic> Diagnostics { get; set; }
        public ResultsViewModel(INavigationService navigationService) : base(navigationService)
        {

        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {

        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            Diagnostics = (ObservableCollection<Diagnostic>)parameters["Diagnostics"];
        }
    }
}
