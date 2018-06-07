using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Final.Models.Personas;

namespace Final.Interfaces.Personas
{
    public interface IFicSrvRhCatDomicilios
    {
        Task<IList<rh_cat_domicilios>> FicMetGetListRhCatDomicilios();
        Task FicMetInsertNewRhCatDomicilios(rh_cat_domicilios FicPazt_rh_cat_domicilios_Item);
        Task FicMetRemoveRhCatDomicilios(rh_cat_domicilios FicPaZt_rh_cat_domicilios_Item);
        Task<IList<rh_cat_domicilios>> FicSearchRhCatDomicilios(String search);
    }
}
