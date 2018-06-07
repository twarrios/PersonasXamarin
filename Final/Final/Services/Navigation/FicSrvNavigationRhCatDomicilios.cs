using System;
using System.Collections.Generic;
using System.Text;
using Final.Views.Personas;
using Final.Interfaces.Navigation;
using Final.ViewModels.Personas;
using Xamarin.Forms;

namespace Final.Services.Navigation
{
    public class FicSrvNavigationRhCatDomicilios: IFicSrvNavigationCatPersonas
    {
        private IDictionary<Type, Type> viewModelRouting = new Dictionary<Type, Type>()
        {

            { typeof(FicVmCatPersonasDetalle), typeof(FicViCpCatPersonasDetalle)},
            { typeof(FicVmCatPersonasItem), typeof(FicViCpCatPersonasItem)},
            { typeof(FicVmCatPersonasList), typeof(FicViCpCatPersonasList)}

        };

        public void FicMetNavigateTo<TDestinationViewModel>(object navigationContext = null)
        {
            Type pageType = viewModelRouting[typeof(TDestinationViewModel)];
            var page = Activator.CreateInstance(pageType, navigationContext) as Page;

            if (page != null)
                Application.Current.MainPage.Navigation.PushAsync(page);
        }

        public void FicMetNavigateTo(Type destinationType, object navigationContext = null)
        {
            Type pageType = viewModelRouting[destinationType];
            var page = Activator.CreateInstance(pageType, navigationContext) as Page;

            if (page != null)
                Application.Current.MainPage.Navigation.PushAsync(page);
        }

        public void FicMetNavigateBack()
        {
            Application.Current.MainPage.Navigation.PopAsync();
        }
    }
}
