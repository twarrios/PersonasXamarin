using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Final.Models.Personas;

namespace Final.Interfaces.Personas
{
   public interface IFicSrvRhCatDirWeb
    {
        Task<IList<rh_cat_dir_web>> FicMetGetListRhCatDirWeb();
        Task FicMetInsertNewRhCatDirWeb(rh_cat_dir_web FicPazt_rh_cat_dir_web_Item);
        Task FicMetRemoveRhCatDirWeb(rh_cat_dir_web FicPaZt_rh_cat_dir_web_Item);
        Task<IList<rh_cat_dir_web>> FicSearchRhCatDirWeb(String search);
    }
}
