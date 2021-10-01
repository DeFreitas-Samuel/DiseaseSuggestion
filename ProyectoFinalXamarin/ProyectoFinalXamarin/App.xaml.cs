using Prism;
using Prism.Ioc;
using Prism.Unity;
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
            NavigationService.NavigateAsync("NavigationPage/HomePage");

        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<HomePage, HomeViewModel>();
            containerRegistry.RegisterForNavigation<AnalysisCompletedPage, AnalysisCompletedViewModel>();
            containerRegistry.RegisterForNavigation<RecommendTestPage, RecommendTestViewModel>();
            containerRegistry.RegisterForNavigation<ResultsPage, ResultsViewModel>();
        }
    }
}
