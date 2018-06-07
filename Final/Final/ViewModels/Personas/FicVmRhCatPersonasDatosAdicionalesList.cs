using System;
using System.Collections.Generic;
using System.Text;
using Final.ViewModels.Base;
using System.Windows.Input;
using Final.Models.Personas;
using Final.Interfaces.Navigation;
using Final.Interfaces.Personas;
using System.Collections.ObjectModel;

namespace Final.ViewModels.Personas
{
    public class FicVmRhCatPersonasDatosAdicionalesList : FicViewModelBase
    {
        private ObservableCollection<rh_cat_personas_datos_adicionales> FicOcZt_rh_cat_personas_datos_adicionales_Items;
        private rh_cat_personas_datos_adicionales FicZt_rh_cat_personas_datos_adicionales_SelectedItem;
        private string _busqueda;

        private ICommand ficAddCommand;
        private ICommand ficSearch;

        private IFicSrvNavigationCatPersonas FicLoSrvNavigationCatPersonas;
        private IFicSrvRhCatPersonasDatosAdicionales FicLoSrvCatPersonas;

        //FIC: Constructor
        public FicVmRhCatPersonasDatosAdicionalesList(
            IFicSrvNavigationCatPersonas ficPaSrvNavigationCatPersonas,
            IFicSrvRhCatPersonasDatosAdicionales ficPaSrvCatPersonas)
        {
            //FIC: se asigna el objeto que se recibe como parametro de tipo navigation services
            FicLoSrvNavigationCatPersonas = ficPaSrvNavigationCatPersonas;
            //FIC: se asigna el objeto que se recibe como parametro de tipo SqlServices 
            FicLoSrvCatPersonas = ficPaSrvCatPersonas;
        }
        public string busqueda
        {
            get { return _busqueda; }
            set { _busqueda = value; }
        }

        //FIC: Metodo para obtener la lista de registros de inventarios
        public ObservableCollection<rh_cat_personas_datos_adicionales> FicMetZt_rh_cat_personas_datos_adicionales_Items
        {
            get { return FicOcZt_rh_cat_personas_datos_adicionales_Items; }
            set
            {
                FicOcZt_rh_cat_personas_datos_adicionales_Items = value;
                RaisePropertyChanged();
            }
        }

        //FIC: Metodo para tomar solo un registro de la lista de registros de inventarios
        public rh_cat_personas_datos_adicionales FicMetZt_rh_cat_personas_datos_adicionales_SelectedItem
        {
            get { return FicZt_rh_cat_personas_datos_adicionales_SelectedItem; }
            set
            {
                FicZt_rh_cat_personas_datos_adicionales_SelectedItem = value;
                FicLoSrvNavigationCatPersonas.FicMetNavigateTo<FicVmRhCatPersonasDatosAdicionalesDetalle>(FicZt_rh_cat_personas_datos_adicionales_SelectedItem);
            }
        }

        //FIC: Metodo de tipo comando para agregar un registro 
        public ICommand ficMetAddCommand
        {
            get { return ficAddCommand = ficAddCommand ?? new FicVmDelegateCommand(AddCommandExecute); }
        }

        public ICommand ficMetSearch
        {
            get { return ficSearch = ficSearch ?? new FicVmDelegateCommand(Find); }
        }

        public override async void OnAppearing(object navigationContext)
        {
            base.OnAppearing(navigationContext);

            //FIC: Ejecuto uno de los metodos definidos en los servicios de Interfaz de inventarios
            var result = await FicLoSrvCatPersonas.FicMetGetListRhCatPersonasDatosAdicionales();

            FicMetZt_rh_cat_personas_datos_adicionales_Items = new ObservableCollection<rh_cat_personas_datos_adicionales>();
            foreach (var ficPaItem in result)
            {
                FicMetZt_rh_cat_personas_datos_adicionales_Items.Add(ficPaItem);
            }
        }

        private void AddCommandExecute()
        {
            var ficZt_cat_productos = new rh_cat_personas_datos_adicionales();
            FicLoSrvNavigationCatPersonas.FicMetNavigateTo<FicVmRhCatPersonasDatosAdicionalesItem>(ficZt_cat_productos);
        }

        private async void Find()
        {



            if (busqueda.Equals(""))
            {
                var result1 = await FicLoSrvCatPersonas.FicMetGetListRhCatPersonasDatosAdicionales();
                FicMetZt_rh_cat_personas_datos_adicionales_Items = new ObservableCollection<rh_cat_personas_datos_adicionales>();
                foreach (var ficPaItem in result1)
                {
                    FicMetZt_rh_cat_personas_datos_adicionales_Items.Add(ficPaItem);
                }

            }
            else
            {
                var result = await FicLoSrvCatPersonas.FicSearchRhCatPersonasDatosAdicionales(busqueda);

                FicMetZt_rh_cat_personas_datos_adicionales_Items = new ObservableCollection<rh_cat_personas_datos_adicionales>();

                if (FicMetZt_rh_cat_personas_datos_adicionales_Items == null) { return; }
                else
                {
                    foreach (var ficPaItem in result)
                    {
                        FicMetZt_rh_cat_personas_datos_adicionales_Items.Add(ficPaItem);
                    }
                }
            }
        }
    }
}
