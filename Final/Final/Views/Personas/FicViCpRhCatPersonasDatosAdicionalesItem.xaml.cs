using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Final.ViewModels.Personas;

namespace Final.Views.Personas
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FicViCpRhCatPersonasDatosAdicionalesItem : ContentPage
	{
        private object FicLoParameter { get; set; }
        public FicViCpRhCatPersonasDatosAdicionalesItem(object ficPaParameter)
		{
			InitializeComponent ();

            FicLoParameter = ficPaParameter;

            BindingContext = App.FicMetLocator.FicVmCatPersonasItem;

            var layout = stack;
            var scroll = new ScrollView { Content = layout };
            Content = scroll;

           // img.Source = ImageSource.FromUri(new Uri("https://xamarin.com/content/images/pages/forms/example-app.png"));

        }
        protected override void OnAppearing()
        {
            //FIC: Aqui se declara una variable de tipo ViewModel Item
            var FicViewModel = BindingContext as FicVmCatPersonasItem;
            if (FicViewModel != null) FicViewModel.OnAppearing(FicLoParameter);
        }

        protected override void OnDisappearing()
        {
            var FicViewModel = BindingContext as FicVmCatPersonasItem;
            if (FicViewModel != null) FicViewModel.OnDisappearing();
        }
    }
}