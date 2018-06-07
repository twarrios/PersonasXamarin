using System;
using System.Collections.Generic;
using System.Text;
using Final.ViewModels.Base;
using System.Windows.Input;
using Final.Models.Personas;
using Final.Interfaces.Navigation;
using Final.Interfaces.Personas;
using Windows.Storage;

namespace Final.ViewModels.Personas
{
    public class FicVmCatPersonasItem : FicViewModelBase
    {
        private cat_personas Fic_Zt_Cat_Personas_Item;

        private ICommand FicSaveCommand;
        private ICommand FicDeleteCommand;
        private ICommand FicCancelCommand;
        private ICommand FicSaveImgCommand;

        private IFicSrvNavigationCatPersonas FicLoSrvNavigationCatPersonas;
        private IFicSrvCatPersonas FicLoSrvCatPersonas;

        public FicVmCatPersonasItem(
           IFicSrvNavigationCatPersonas FicPaSrvNavigationCatPersonas,
           IFicSrvCatPersonas FicPaSrvCatPersonas)
        {
            //FIC: se asigna el objeto que se recibe como parametro de tipo navigation services
            FicLoSrvNavigationCatPersonas = FicPaSrvNavigationCatPersonas;
            //FIC: se asigna el objeto que se recibe como parametro de tipo SqlServices 
            FicLoSrvCatPersonas = FicPaSrvCatPersonas;
        }

        public cat_personas Item
        {
            get { return Fic_Zt_Cat_Personas_Item; }
            set
            {
                Fic_Zt_Cat_Personas_Item = value;
                RaisePropertyChanged();
            }
        }

        public ICommand FicMetSaveImgCommand
        {
            get { return FicSaveImgCommand = FicSaveImgCommand ?? new FicVmDelegateCommand(UploadImg); }
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
            var FicLoZt_inventarios = FicPaNavigationContext as cat_personas;

            if (FicLoZt_inventarios != null)
            {
                Item = FicLoZt_inventarios;
            }

            base.OnAppearing(FicPaNavigationContext);
        }

        private async void UploadImg()
        {
           
        }

        private async void SaveCommandExecute()
        {
            await FicLoSrvCatPersonas.FicMetInsertNewCatPersonas(Item);
            FicLoSrvNavigationCatPersonas.FicMetNavigateBack();
        }

        private async void DeleteCommandExecute()
        {
            await FicLoSrvCatPersonas.FicMetRemoveCatPersonas(Item);
            FicLoSrvNavigationCatPersonas.FicMetNavigateBack();
        }

        private void CancelCommandExecute()
        {
            FicLoSrvNavigationCatPersonas.FicMetNavigateBack();
        }


    }
}
