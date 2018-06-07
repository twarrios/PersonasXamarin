using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Final.Models.Personas;

namespace Final.Interfaces.Personas
{
    public interface IFicSrvRhCatPersonasPerfiles
    {
        Task<IList<rh_cat_personas_perfiles>> FicMetGetListRhCatPersonasPerfiles();
        Task FicMetInsertNewRhCatPersonasPerfiles(rh_cat_personas_perfiles FicPazt_rh_cat_personas_perfiles_Item);
        Task FicMetRemoveRhCatPersonasPerfiles(rh_cat_personas_perfiles FicPaZt_rh_cat_personas_perfiles_Item);
        Task<IList<rh_cat_personas_perfiles>> FicSearchRhCatPersonasPerfiles(String search);
    }
}
