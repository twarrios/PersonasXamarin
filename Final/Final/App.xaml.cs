using System;
using Xamarin.Forms;
using Final.Views;
using Xamarin.Forms.Xaml;
using Final.ViewModels.Base;
using Final.Views.Personas;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace Final
{
    public partial class App : Application
    {

        private static FicViewModelLocator ficVmLocator;
        //FIC: Metodo
        public static FicViewModelLocator FicMetLocator
        {
            get { return ficVmLocator = ficVmLocator ?? new FicViewModelLocator(); }
        }

        public App()
        {
            InitializeComponent();


            MainPage = new NavigationPage(new FicViCpLogin(null));
            //MainPage = new NavigationPage(new FicViCpRhCatDirWebList(null));
            //MainPage = new NavigationPage(new FicViCpRhCatDomiciliosList(null));
            //MainPage = new NavigationPage(new FicViCpRhCatTelefonosList(null));


        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
