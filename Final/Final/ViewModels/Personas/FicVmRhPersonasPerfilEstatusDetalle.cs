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
    public class FicVmRhPersonasPerfilEstatusDetalle : FicViewModelBase
    {
        private rh_personas_perfil_estatus Fic_rh_personas_perfil_estatus_Item;

        private ICommand FicSaveCommand;
        private ICommand FicDeleteCommand;
        private ICommand FicCancelCommand;

        private IFicSrvNavigationCatPersonas FicLoSrvNavigationCatPersonas;
        private IFicSrvRhPersonasPerfilEstatus FicLoSrvCatPersonas;

        public FicVmRhPersonasPerfilEstatusDetalle(
           IFicSrvNavigationCatPersonas FicPaSrvNavigationCatPersonas,
           IFicSrvRhPersonasPerfilEstatus FicPaSrvCatPersonas)
        {
            //FIC: se asigna el objeto que se recibe como parametro de tipo navigation services
            FicLoSrvNavigationCatPersonas = FicPaSrvNavigationCatPersonas;
            //FIC: se asigna el objeto que se recibe como parametro de tipo SqlServices 
            FicLoSrvCatPersonas = FicPaSrvCatPersonas;
        }

        public rh_personas_perfil_estatus Item
        {
            get { return Fic_rh_personas_perfil_estatus_Item; }
            set
            {
                Fic_rh_personas_perfil_estatus_Item = value;
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
            var FicLoZt_inventarios = FicPaNavigationContext as rh_personas_perfil_estatus;

            if (FicLoZt_inventarios != null)
            {
                Item = FicLoZt_inventarios;
            }

            base.OnAppearing(FicPaNavigationContext);
        }

        private async void SaveCommandExecute()
        {
            await FicLoSrvCatPersonas.FicMetInsertNewRhPersonasPerfilEstatus(Item);
            FicLoSrvNavigationCatPersonas.FicMetNavigateBack();
        }

        private async void DeleteCommandExecute()
        {
            await FicLoSrvCatPersonas.FicMetRemoveRhPersonasPerfilEstatus(Item);
            FicLoSrvNavigationCatPersonas.FicMetNavigateBack();
        }

        private void CancelCommandExecute()
        {
            FicLoSrvNavigationCatPersonas.FicMetNavigateBack();
        }
    }
}
