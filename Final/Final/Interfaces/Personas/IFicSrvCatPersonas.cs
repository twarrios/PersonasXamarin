using System;
using System.Collections.Generic;
using System.Text;
using Final.Models.Personas;
using System.Threading.Tasks;

namespace Final.Interfaces.Personas
{
    public interface IFicSrvCatPersonas
    {
        Task<IList<cat_personas>> FicMetGetListCatPersonas();
        Task FicMetInsertNewCatPersonas(cat_personas FicPazt_cat_personas_Item);
        Task FicMetRemoveCatPersonas(cat_personas FicPaZt_cat_personas_Item);
        Task<IList<cat_personas>> FicSearchCatPersonas(String search);
    }
}
