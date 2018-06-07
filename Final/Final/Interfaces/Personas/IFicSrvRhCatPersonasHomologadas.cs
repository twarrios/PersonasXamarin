using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Final.Models.Personas;

namespace Final.Interfaces.Personas
{
   public interface IFicSrvRhCatPersonasHomologadas
    {
        Task<IList<rh_cat_personas_homologadas>> FicMetGetListRhCatPersonasHomologadas();
        Task FicMetInsertNewRhCatPersonasHomologadas(rh_cat_personas_homologadas FicPazt_rh_cat_personas_homologadas_Item);
        Task FicMetRemoveRhCatPersonasHomologadas(rh_cat_personas_homologadas FicPaZt_rh_cat_personas_homologadas_Item);
        Task<IList<rh_cat_personas_homologadas>> FicSearchRhCatPersonasHomologadas(String search);
    }
}
