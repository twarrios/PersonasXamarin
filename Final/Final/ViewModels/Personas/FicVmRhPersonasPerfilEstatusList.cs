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
    public class FicVmRhPersonasPerfilEstatusList : FicViewModelBase
    {
        private ObservableCollection<rh_personas_perfil_estatus> FicOcZt_rh_personas_perfil_estatus_Items;
        private rh_personas_perfil_estatus FicZt_rh_personas_perfil_estatus_SelectedItem;
        private string _busqueda;

        private ICommand ficAddCommand;
        private ICommand ficSearch;

        private IFicSrvNavigationCatPersonas FicLoSrvNavigationCatPersonas;
        private IFicSrvRhPersonasPerfilEstatus FicLoSrvCatPersonas;

        //FIC: Constructor
        public FicVmRhPersonasPerfilEstatusList(
            IFicSrvNavigationCatPersonas ficPaSrvNavigationCatPersonas,
            IFicSrvRhPersonasPerfilEstatus ficPaSrvCatPersonas)
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
        public ObservableCollection<rh_personas_perfil_estatus> FicMetZt_rh_personas_perfil_estatus_Items
        {
            get { return FicOcZt_rh_personas_perfil_estatus_Items; }
            set
            {
                FicOcZt_rh_personas_perfil_estatus_Items = value;
                RaisePropertyChanged();
            }
        }

        //FIC: Metodo para tomar solo un registro de la lista de registros de inventarios
        public rh_personas_perfil_estatus FicMetZt_rh_personas_perfil_estatus_SelectedItem
        {
            get { return FicZt_rh_personas_perfil_estatus_SelectedItem; }
            set
            {
                FicZt_rh_personas_perfil_estatus_SelectedItem = value;
                FicLoSrvNavigationCatPersonas.FicMetNavigateTo<FicVmRhPersonasPerfilEstatusDetalle>(FicZt_rh_personas_perfil_estatus_SelectedItem);
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
            var result = await FicLoSrvCatPersonas.FicMetGetListRhPersonasPerfilEstatus();

            FicMetZt_rh_personas_perfil_estatus_Items = new ObservableCollection<rh_personas_perfil_estatus>();
            foreach (var ficPaItem in result)
            {
                FicMetZt_rh_personas_perfil_estatus_Items.Add(ficPaItem);
            }
        }

        private void AddCommandExecute()
        {
            var ficZt_cat_productos = new rh_personas_perfil_estatus();
            FicLoSrvNavigationCatPersonas.FicMetNavigateTo<FicVmRhPersonasPerfilEstatusItem>(ficZt_cat_productos);
        }

        private async void Find()
        {



            if (busqueda.Equals(""))
            {
                var result1 = await FicLoSrvCatPersonas.FicMetGetListRhPersonasPerfilEstatus();
                FicMetZt_rh_personas_perfil_estatus_Items = new ObservableCollection<rh_personas_perfil_estatus>();
                foreach (var ficPaItem in result1)
                {
                    FicMetZt_rh_personas_perfil_estatus_Items.Add(ficPaItem);
                }

            }
            else
            {
                var result = await FicLoSrvCatPersonas.FicSearchRhPersonasPerfilEstatus(busqueda);

                FicMetZt_rh_personas_perfil_estatus_Items = new ObservableCollection<rh_personas_perfil_estatus>();

                if (FicMetZt_rh_personas_perfil_estatus_Items == null) { return; }
                else
                {
                    foreach (var ficPaItem in result)
                    {
                        FicMetZt_rh_personas_perfil_estatus_Items.Add(ficPaItem);
                    }
                }
            }
        }
    }
}
