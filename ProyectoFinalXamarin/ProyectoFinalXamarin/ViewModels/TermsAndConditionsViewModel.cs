using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using Prism.Services.Dialogs;
using ProyectoFinalXamarin.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;

namespace ProyectoFinalXamarin.ViewModels
{
    public class TermsAndConditionsViewModel: BaseViewModel
    {
        public TermsAndConditionsViewModel(INavigationService navigationService, IMedicalApiService medicalApiService, IPageDialogService pageDialogService) : base(navigationService)
        {
            _medicalApiService = medicalApiService;
            UrlTapCommand = new DelegateCommand<string>(OnUrlTap);
            SignInCommand = new DelegateCommand(OnSignIn);
            _pageDialogService = pageDialogService;

        }
        private IPageDialogService _pageDialogService;
        public ICommand UrlTapCommand { get; }
        public ICommand SignInCommand { get; }
        public bool CheckBoxIsChecked { get; set; } = false;
        public bool IsRunning { get; set; } = false;
        public bool CheckBoxIsEnabled { get; set; } = true;

        private async void OnSignIn()
        {
            SecureStorage.RemoveAll();
            string token = await SecureStorage.GetAsync("token");


            if (Connectivity.NetworkAccess == NetworkAccess.Internet)
            {
                if (string.IsNullOrEmpty(token))
                {
                    try
                    {
                        await _medicalApiService.LoginAsync();
                        token = await SecureStorage.GetAsync("token");
                        if (!string.IsNullOrEmpty(token))
                        {
                            await NavigationService.NavigateAsync(NavigationConstants.Paths.HomeTabbed);
                        }
                        else
                        {
                            await _pageDialogService.DisplayAlertAsync("Alert","There was a problem connecting to the API", "OK");
                        }
                    }

                    catch (Exception e)
                    {
                        await _pageDialogService.DisplayAlertAsync("Error", e.Message, "OK");
                    }
                }
                else 
                {
                    await NavigationService.NavigateAsync(NavigationConstants.Paths.HomeTabbed);
                }
            }
            else 
            {
                await _pageDialogService.DisplayAlertAsync("Alert","There was a problem with the connection to the internet", "OK");
            }
        }

        private async void OnUrlTap(string url)
        {
            await Launcher.OpenAsync(url);
        }

        readonly IMedicalApiService _medicalApiService;
    }
}
