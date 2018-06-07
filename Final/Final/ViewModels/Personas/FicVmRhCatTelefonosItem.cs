using System;
using System.Collections.Generic;
using System.Text;
using Final.ViewModels.Base;
using System.Windows.Input;
using Final.Models.Personas;
using Final.Interfaces.Navigation;
using Final.Interfaces.Personas;

namespace Final.ViewModels.Personas
{
    public class FicVmRhCatTelefonosItem : FicViewModelBase
    {
        private rh_cat_telefonos Fic_Zt_rh_cat_telefonos_Item;

        private ICommand FicSaveCommand;
        private ICommand FicDeleteCommand;
        private ICommand FicCancelCommand;


        private IFicSrvNavigationCatPersonas FicLoSrvNavigationCatPersonas;
        private IFicSrvRhCatTelefonos FicLoSrvCatPersonas;

        public FicVmRhCatTelefonosItem(
           IFicSrvNavigationCatPersonas FicPaSrvNavigationCatPersonas,
           IFicSrvRhCatTelefonos FicPaSrvCatPersonas)
        {
            //FIC: se asigna el objeto que se recibe como parametro de tipo navigation services
            FicLoSrvNavigationCatPersonas = FicPaSrvNavigationCatPersonas;
            //FIC: se asigna el objeto que se recibe como parametro de tipo SqlServices 
            FicLoSrvCatPersonas = FicPaSrvCatPersonas;
        }

        public rh_cat_telefonos Item
        {
            get { return Fic_Zt_rh_cat_telefonos_Item; }
            set
            {
                Fic_Zt_rh_cat_telefonos_Item = value;
                RaisePropertyChanged();
            }
        }


        public ICommand FicMetSaveCommand
        {
            get { return FicSaveCommand = FicSaveCommand ?? new FicVmDelegateCommand(SaveCommandExecute); }
        }

        public ICommand FicMetDeleteCommand
        {
            get { return FicDeleteCommand = FicDeleteCommand ?? new FicVmDelegateCommand(DeleteCommandExecute); }
        }

        public ICommand FicMetCancelCommand
        {
            get { return FicCancelCommand = FicCancelCommand ?? new FicVmDelegateCommand(CancelCommandExecute); }
        }

        public override void OnAppearing(object FicPaNavigationContext)
        {
            var FicLoZt_inventarios = FicPaNavigationContext as rh_cat_telefonos;

            if (FicLoZt_inventarios != null)
            {
                Item = FicLoZt_inventarios;
            }

            base.OnAppearing(FicPaNavigationContext);
        }


        private async void SaveCommandExecute()
        {
            await FicLoSrvCatPersonas.FicMetInsertNewRhCatTelefonos(Item);
            FicLoSrvNavigationCatPersonas.FicMetNavigateBack();
        }

        private async void DeleteCommandExecute()
        {
            await FicLoSrvCatPersonas.FicMetRemoveRhCatTelefonos(Item);
            FicLoSrvNavigationCatPersonas.FicMetNavigateBack();
        }

        private void CancelCommandExecute()
        {
            FicLoSrvNavigationCatPersonas.FicMetNavigateBack();
        }
    }
}
