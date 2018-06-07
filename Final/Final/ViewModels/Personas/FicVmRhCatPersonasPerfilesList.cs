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
    public class FicVmRhCatPersonasPerfilesList : FicViewModelBase
    {
        private ObservableCollection<rh_cat_personas_perfiles> FicOcZt_rh_cat_personas_perfiles_Items;
        private rh_cat_personas_perfiles FicZt_rh_cat_personas_perfiles_SelectedItem;
        private string _busqueda;

        private ICommand ficAddCommand;
        private ICommand ficSearch;

        private IFicSrvNavigationCatPersonas FicLoSrvNavigationCatPersonas;
        private IFicSrvRhCatPersonasPerfiles FicLoSrvCatPersonas;

        //FIC: Constructor
        public FicVmRhCatPersonasPerfilesList(
            IFicSrvNavigationCatPersonas ficPaSrvNavigationCatPersonas,
            IFicSrvRhCatPersonasPerfiles ficPaSrvCatPersonas)
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
        public ObservableCollection<rh_cat_personas_perfiles> FicMetZt_rh_cat_personas_perfiles_Items
        {
            get { return FicOcZt_rh_cat_personas_perfiles_Items; }
            set
            {
                FicOcZt_rh_cat_personas_perfiles_Items = value;
                RaisePropertyChanged();
            }
        }

        //FIC: Metodo para tomar solo un registro de la lista de registros de inventarios
        public rh_cat_personas_perfiles FicMetZt_rh_cat_personas_perfiles_SelectedItem
        {
            get { return FicZt_rh_cat_personas_perfiles_SelectedItem; }
            set
            {
                FicZt_rh_cat_personas_perfiles_SelectedItem = value;
                FicLoSrvNavigationCatPersonas.FicMetNavigateTo<FicVmRhCatPersonasPerfilesDetalle>(FicZt_rh_cat_personas_perfiles_SelectedItem);
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
            var result = await FicLoSrvCatPersonas.FicMetGetListRhCatPersonasPerfiles();

            FicMetZt_rh_cat_personas_perfiles_Items = new ObservableCollection<rh_cat_personas_perfiles>();
            foreach (var ficPaItem in result)
            {
                FicMetZt_rh_cat_personas_perfiles_Items.Add(ficPaItem);
            }
        }

        private void AddCommandExecute()
        {
            var ficZt_cat_productos = new rh_cat_personas_perfiles();
            FicLoSrvNavigationCatPersonas.FicMetNavigateTo<FicVmRhCatPersonasPerfilesItem>(ficZt_cat_productos);
        }

        private async void Find()
        {



            if (busqueda.Equals(""))
            {
                var result1 = await FicLoSrvCatPersonas.FicMetGetListRhCatPersonasPerfiles();
                FicMetZt_rh_cat_personas_perfiles_Items = new ObservableCollection<rh_cat_personas_perfiles>();
                foreach (var ficPaItem in result1)
                {
                    FicMetZt_rh_cat_personas_perfiles_Items.Add(ficPaItem);
                }

            }
            else
            {
                var result = await FicLoSrvCatPersonas.FicSearchRhCatPersonasPerfiles(busqueda);

                FicMetZt_rh_cat_personas_perfiles_Items = new ObservableCollection<rh_cat_personas_perfiles>();

                if (FicMetZt_rh_cat_personas_perfiles_Items == null) { return; }
                else
                {
                    foreach (var ficPaItem in result)
                    {
                        FicMetZt_rh_cat_personas_perfiles_Items.Add(ficPaItem);
                    }
                }
            }
        }
    }
}
