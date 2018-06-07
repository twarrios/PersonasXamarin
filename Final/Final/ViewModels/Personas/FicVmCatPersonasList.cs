using System.Collections.ObjectModel;
using System.Windows.Input;
using Final.Models.Personas;
using Final.Interfaces.Navigation;
using Final.Interfaces.Personas;
using Final.ViewModels.Base;

namespace Final.ViewModels.Personas
{
    public class FicVmCatPersonasList: FicViewModelBase
    {
        private ObservableCollection<cat_personas> FicOcZt_cat_personas_Items;
        private cat_personas FicZt_cat_personas_SelectedItem;
        private string _busqueda;

        private ICommand ficAddCommand;
        private ICommand ficSearch;

        private IFicSrvNavigationCatPersonas FicLoSrvNavigationCatPersonas;
        private IFicSrvCatPersonas FicLoSrvCatPersonas;

        //FIC: Constructor
        public FicVmCatPersonasList(
            IFicSrvNavigationCatPersonas ficPaSrvNavigationCatPersonas,
            IFicSrvCatPersonas ficPaSrvCatPersonas)
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
        public ObservableCollection<cat_personas> FicMetZt_cat_personas_Items
        {
            get { return FicOcZt_cat_personas_Items; }
            set
            {
                FicOcZt_cat_personas_Items = value;
                RaisePropertyChanged();
            }
        }

        //FIC: Metodo para tomar solo un registro de la lista de registros de inventarios
        public cat_personas FicMetZt_cat_personas_SelectedItem
        {
            get { return FicZt_cat_personas_SelectedItem; }
            set
            {
                FicZt_cat_personas_SelectedItem = value;
                FicLoSrvNavigationCatPersonas.FicMetNavigateTo<FicVmCatPersonasDetalle>(FicZt_cat_personas_SelectedItem);
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
            var result = await FicLoSrvCatPersonas.FicMetGetListCatPersonas();

            FicMetZt_cat_personas_Items = new ObservableCollection<cat_personas>();
            foreach (var ficPaItem in result)
            {
                FicMetZt_cat_personas_Items.Add(ficPaItem);
            }
        }

        private void AddCommandExecute()
        {
            var ficZt_cat_productos = new cat_personas();
            FicLoSrvNavigationCatPersonas.FicMetNavigateTo<FicVmCatPersonasItem>(ficZt_cat_productos);
        }

        private async void Find()
        {



            if (busqueda.Equals(""))
            {
                var result1 = await FicLoSrvCatPersonas.FicMetGetListCatPersonas();
                FicMetZt_cat_personas_Items = new ObservableCollection<cat_personas>();
                foreach (var ficPaItem in result1)
                {
                    FicMetZt_cat_personas_Items.Add(ficPaItem);
                }

            }
            else
            {
                var result = await FicLoSrvCatPersonas.FicSearchCatPersonas(busqueda);

                FicMetZt_cat_personas_Items = new ObservableCollection<cat_personas>();

                if (FicMetZt_cat_personas_Items == null) { return; }
                else
                {
                    foreach (var ficPaItem in result)
                    {
                        FicMetZt_cat_personas_Items.Add(ficPaItem);
                    }
                }
            }
        }
    }
}
