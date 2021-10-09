﻿using Prism.Commands;
using Prism.Navigation;
using ProyectoFinalXamarin.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Essentials;

namespace ProyectoFinalXamarin.ViewModels
{
    public class TermsAndConditionsViewModel: BaseViewModel
    {
        public TermsAndConditionsViewModel(INavigationService navigationService, IMedicalApiService medicalApiService) : base(navigationService)
        {
            _medicalApiService = medicalApiService;
            UrlTapCommand = new DelegateCommand<string>(OnUrlTap);
            SignInCommand = new DelegateCommand(OnSignIn);
        }

        public ICommand UrlTapCommand { get; }
        public ICommand SignInCommand { get; }

        private async void OnSignIn()
        {
            if (Connectivity.NetworkAccess == NetworkAccess.Internet)
            {
                var session = await _medicalApiService.GetSessionAsync();
                var termsAndConditions = await _medicalApiService.PostTermsConditionsAsync();
                if (session && termsAndConditions)
                {
                    await NavigationService.NavigateAsync(NavigationConstants.Paths.HomeNavigation);
                }
                else
                {
                    await Prism.PrismApplicationBase.Current.MainPage.DisplayAlert("Alert", "There was a problem with the connection to the API", "OK");
                }
            }
            else 
            {
                await Prism.PrismApplicationBase.Current.MainPage.DisplayAlert("Alert", "There was a problem with the connection to the internet", "OK");
            }
        }

        private async void OnUrlTap(string url)
        {
            await Launcher.OpenAsync(url);
        }

        readonly IMedicalApiService _medicalApiService;
    }
}