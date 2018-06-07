using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Final.Models.Personas;

namespace Final.Interfaces.Personas
{
    public interface IFicSrvRhCatPersonasDatosAdicionales
    {
        Task<IList<rh_cat_personas_datos_adicionales>> FicMetGetListRhCatPersonasDatosAdicionales();
        Task FicMetInsertNewRhCatPersonasDatosAdicionales(rh_cat_personas_datos_adicionales FicPazt_rh_cat_personoas_datos_adicionales_Item);
        Task FicMetRemoveRhCatPersonasDatosAdicionales(rh_cat_personas_datos_adicionales FicPaZt_rh_cat_personoas_datos_adicionales_Item);
        Task<IList<rh_cat_personas_datos_adicionales>> FicSearchRhCatPersonasDatosAdicionales(String search);
    }
}
