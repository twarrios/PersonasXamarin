using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Final.Models.Personas;

namespace Final.Interfaces.Personas
{
    public interface IFicSrvRhCatTelefonos
    {
        Task<IList<rh_cat_telefonos>> FicMetGetListRhCatTelefonos();
        Task FicMetInsertNewRhCatTelefonos(rh_cat_telefonos FicPazt_rh_cat_telefonos_Item);
        Task FicMetRemoveRhCatTelefonos(rh_cat_telefonos FicPaZt_rh_cat_telefonos_Item);
        Task<IList<rh_cat_telefonos>> FicSearchRhCatTelefonos(String search);
    }
}
