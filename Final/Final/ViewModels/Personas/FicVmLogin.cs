using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Final.Models.Personas;
using Final.Interfaces.Navigation;
using Final.Interfaces.Personas;
using Final.ViewModels.Base;
using Xamarin.Forms;
using Final.Views;

namespace Final.ViewModels.Personas
{
    public class FicVmLogin : FicViewModelBase
    {
        // private ObservableCollection<cat_personas> FicOcZt_cat_personas_Items;

        private IFicSrvNavigationCatPersonas FicLoSrvNavigationCatPersonas;
        private IFicSrvCatPersonas FicLoSrvCatPersonas;
        private string _Usuario;
        private string _Contraseña;
        private Boolean _Verdadero;

        private ICommand FicLoginCommand;
        private ICommand FicUserCommand;

        public FicVmLogin(
           IFicSrvNavigationCatPersonas ficPaSrvNavigationCatPersonas,
           IFicSrvCatPersonas ficPaSrvCatPersonas)
        {
            //FIC: se asigna el objeto que se recibe como parametro de tipo navigation services
            FicLoSrvNavigationCatPersonas = ficPaSrvNavigationCatPersonas;
            //FIC: se asigna el objeto que se recibe como parametro de tipo SqlServices 
            FicLoSrvCatPersonas = ficPaSrvCatPersonas;
        }

        public string Usuario
        {
            get { return _Usuario; }
            set { _Usuario = value; }
        }

        public string Contraseña {
            get {return _Contraseña; }
            set { _Contraseña = value; }
        }

        public Boolean Verdadero
        {
            get { return _Verdadero; }
            set { _Verdadero = value; }
        }

        public ICommand FicMetLoginCommand
        {
            get { return FicLoginCommand = FicLoginCommand ?? new FicVmDelegateCommand(Login); }
        }

        public ICommand FicMetUserCommand
        {
            get { return FicUserCommand = FicUserCommand ?? new FicVmDelegateCommand(User); }
        }

        public void User()
        {
            var ficZt_cat_productos = new cat_usuarios();
            FicLoSrvNavigationCatPersonas.FicMetNavigateTo<FicVmRegister>(ficZt_cat_productos);
        }

        public async void Login()
        {
            if (Usuario == "Admin" && Contraseña == "admin")
            {
                var ficZt_cat_productos = new cat_personas();
                FicLoSrvNavigationCatPersonas.FicMetNavigateTo<FicVmCatPersonasList>(ficZt_cat_productos);
            }
            else
            {

                var result = await FicLoSrvCatPersonas.FicMetGetListCatUsuarios(Usuario, Contraseña);

                if (result.Count == 1)
                {
                    Verdadero = true;

                    var usuario = await FicLoSrvCatPersonas.FitMetGetUsuario(Usuario, Contraseña);

                    var ficZt_cat_productos = await FicLoSrvCatPersonas.FitMetGetPersona(usuario);

                    Global.UsuarioReg = usuario.UsuarioReg;
                    FicLoSrvNavigationCatPersonas.FicMetNavigateTo<FicVmCatPersonasDetalle>(ficZt_cat_productos);
                }
                else {
                    var m = new modal();
                    await m.DisplayAlert("Error", "Nombre de Usuario ó Contraseña incorrectos!", "Aceptar");
                    Verdadero = false; }
            }
        }

        private class modal : Page
        {

        }
    }
}
