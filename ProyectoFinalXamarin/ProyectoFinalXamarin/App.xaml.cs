using Prism;
using Prism.Ioc;
using Prism.Unity;
using ProyectoFinalXamarin.Services;
using ProyectoFinalXamarin.ViewModels;
using ProyectoFinalXamarin.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProyectoFinalXamarin
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer platformInitializer) : base(platformInitializer)
        {
            
        }

        protected override void OnInitialized()
        {
            InitializeComponent();
            NavigationService.NavigateAsync(NavigationConstants.Paths.TermsAndConditions);

        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<HomeTabbedPage>();
            containerRegistry.RegisterForNavigation<HomePage, HomeViewModel>();
            containerRegistry.RegisterForNavigation<GetIssuesPage, GetIssuesViewModel>();
            containerRegistry.RegisterForNavigation<ResultsPage, ResultsViewModel>();
            containerRegistry.RegisterForNavigation<TermsAndConditionsPage, TermsAndConditionsViewModel>();
            containerRegistry.Register<IMedicalApiService, MedicalApiService>();
            containerRegistry.Register<IJsonSerializerService, JsonSerializerService>();
        }
    }
}
