using Autofac;
using Final.Services.Navigation;
using Final.Services.Personas;
using Final.Interfaces.Navigation;
using Final.Interfaces.Personas;
using Final.ViewModels.Personas;

namespace Final.ViewModels.Base
{
    public class FicViewModelLocator
    {
        private static IContainer FicContainer;

        public FicViewModelLocator()
        {
            var builder = new ContainerBuilder();
        
           // ViewModels ++++++++++++++++++++++++++++++++++++++++++++
           

            //Catalogo de PERSONAS --------------------------
            builder.RegisterType<FicVmCatPersonasItem>();
            builder.RegisterType<FicVmCatPersonasList>();
            builder.RegisterType<FicVmCatPersonasDetalle>();

     



            // Services ++++++++++++++++++++++++++++++++++++++++++++

            //Catalogo de PERSONAS
            builder.RegisterType<FicSrvNavigationCatPersonas>().As<IFicSrvNavigationCatPersonas>().SingleInstance();
            builder.RegisterType<FicSrvCatPersonasList>().As<IFicSrvCatPersonas>();

            builder.RegisterType<FicSrvNavigationRhCatDirWeb>().As<IFicSrvNavigationCatPersonas>().SingleInstance();
            builder.RegisterType<FicSrvRhCatDirWebList>().As<IFicSrvRhCatDirWeb>();

            builder.RegisterType<FicSrvNavigationRhCatDomicilios>().As<IFicSrvNavigationCatPersonas>().SingleInstance();
            builder.RegisterType<FicSrvRhCatDomiciliosList>().As<IFicSrvRhCatDomicilios>();

            builder.RegisterType<FicSrvNavigationRhCatPersonasDatosAdicionales>().As<IFicSrvNavigationCatPersonas>().SingleInstance();
            builder.RegisterType<FicSrvRhCatPersonasDatosAdicionalesList>().As<IFicSrvRhCatPersonasDatosAdicionales>();

            builder.RegisterType<FicSrvNavigationRhCatPersonasHomologadas>().As<IFicSrvNavigationCatPersonas>().SingleInstance();
            builder.RegisterType<FicSrvRhCatPersonasHomologadasList>().As<IFicSrvRhCatPersonasHomologadas>();

            builder.RegisterType<FicSrvNavigationRhCatPersonasPerfiles>().As<IFicSrvNavigationCatPersonas>().SingleInstance();
            builder.RegisterType<FicSrvRhCatPersonasPerfilesList>().As<IFicSrvRhCatPersonasPerfiles>();

            builder.RegisterType<FicSrvNavigationRhCatTelefonos>().As<IFicSrvNavigationCatPersonas>().SingleInstance();
            builder.RegisterType<FicSrvRhCatTelefonosList>().As<IFicSrvRhCatTelefonos>();

            builder.RegisterType<FicSrvNavigationRhPersonasPerfilEstatus>().As<IFicSrvNavigationCatPersonas>().SingleInstance();
            builder.RegisterType<FicSrvRhPersonasPerfilEstatusList>().As<IFicSrvRhPersonasPerfilEstatus>();

            if (FicContainer != null)
            {
                FicContainer.Dispose();
            }

            FicContainer = builder.Build();
        }

       
        //-------------------- CATALOGO DE PERSONAS ---------------------------
        //FIC: se manda llamar desde el backend de la View de List
        public FicVmCatPersonasItem FicVmCatPersonasItem
        {
            get { return FicContainer.Resolve<FicVmCatPersonasItem>(); }
        }

        public FicVmCatPersonasList FicVmCatPersonasList
        {
            get { return FicContainer.Resolve<FicVmCatPersonasList>(); }
        }

        public FicVmCatPersonasDetalle FicVmCatPersonasDetalle
        {
            get { return FicContainer.Resolve<FicVmCatPersonasDetalle>(); }
        }


    }
}

