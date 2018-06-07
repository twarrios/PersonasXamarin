using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Final.Models.Personas;

namespace Final.Interfaces.Personas
{
    public interface IFicSrvRhPersonasPerfilEstatus
    {
        Task<IList<rh_personas_perfil_estatus>> FicMetGetListRhPersonasPerfilEstatus();
        Task FicMetInsertNewRhPersonasPerfilEstatus(rh_personas_perfil_estatus FicPazt_rh_personas_perfil_estatus_Item);
        Task FicMetRemoveRhPersonasPerfilEstatus(rh_personas_perfil_estatus FicPaZt_rh_personas_perfil_estatus_Item);
        Task<IList<rh_personas_perfil_estatus>> FicSearchRhPersonasPerfilEstatus(String search);
    }
}
