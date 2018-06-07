using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Final.Helpers;
using Final.Interfaces.Personas;
using Final.Interfaces.SQLite;
using Final.Models.Personas;
using SQLite;
using System.Threading.Tasks;

namespace Final.Services.Personas
{
   public class FicSrvRhCatPersonasPerfilesList : IFicSrvRhCatPersonasPerfiles
    {
        private static readonly FicAsyncLock ficMutex = new FicAsyncLock();
        private SQLiteAsyncConnection ficSQLiteConnection;

        //FIC: Constructor
        public FicSrvRhCatPersonasPerfilesList()
        {
            var ficDataBasePath = DependencyService.Get<IFicConfigSQLiteNETStd>().FicGetDatabasePath();
            //var ficDataBasePath = "Data Source" = " + Server.MapPath(~/data/dbSQLite/";
            //SQLiteConnection sqlite_conn = new SQLiteConnection("Data Source=" + Server.MapPath("~/db/test_database2.db") + ";Version=3;New=True;Compress=True;");
            ficSQLiteConnection = new SQLiteAsyncConnection(ficDataBasePath);
            //FIC: Se manda llamar funcion local para verificar
            //si no existen las tablas crearlas de forma local en el dispositivo
            FicLoMetCreateDataBaseAsync();
        }

        //FIC: Metodo para crear las tablas si no existen localmente en el dispositivo
        public async void FicLoMetCreateDataBaseAsync()
        {

            using (await ficMutex.LockAsync().ConfigureAwait(false))
            {
                await ficSQLiteConnection.CreateTableAsync<cat_personas>(CreateFlags.None).ConfigureAwait(false);
                await ficSQLiteConnection.CreateTableAsync<rh_cat_dir_web>(CreateFlags.None).ConfigureAwait(false);
                await ficSQLiteConnection.CreateTableAsync<rh_cat_domicilios>(CreateFlags.None).ConfigureAwait(false);
                await ficSQLiteConnection.CreateTableAsync<rh_cat_telefonos>(CreateFlags.None).ConfigureAwait(false);
                await ficSQLiteConnection.CreateTableAsync<rh_cat_personas_datos_adicionales>(CreateFlags.None).ConfigureAwait(false);
                await ficSQLiteConnection.CreateTableAsync<rh_cat_personas_homologadas>(CreateFlags.None).ConfigureAwait(false);
                await ficSQLiteConnection.CreateTableAsync<rh_cat_personas_perfiles>(CreateFlags.None).ConfigureAwait(false);
                await ficSQLiteConnection.CreateTableAsync<rh_personas_perfil_estatus>(CreateFlags.None).ConfigureAwait(false);

            }
        }

        #region rh_cat_personas_perfiles

        public async Task<IList<rh_cat_personas_perfiles>> FicMetGetListRhCatPersonasPerfiles()
        {
            var items = new List<rh_cat_personas_perfiles>();
            using (await ficMutex.LockAsync().ConfigureAwait(false))
            {
                items = await ficSQLiteConnection.Table<rh_cat_personas_perfiles>().ToListAsync().ConfigureAwait(false);
            }

            return items;
        }

        public async Task FicMetInsertNewRhCatPersonasPerfiles(rh_cat_personas_perfiles FicPazt_rh_cat_personas_perfiles_Item)
        {
            using (await ficMutex.LockAsync().ConfigureAwait(false))
            {
                var FicExistingInventarioItem = await ficSQLiteConnection.Table<rh_cat_personas_perfiles>()
                        .Where(x => x.IdPersona == FicPazt_rh_cat_personas_perfiles_Item.IdPersona)
                        .FirstOrDefaultAsync();

                DateTime dta = DateTime.Now.ToLocalTime();
                string dta_string = dta.ToString("yyyy-MM-dd");
                //string user = Environment.UserName;
                string user = "FIBARRAC";

                if (FicExistingInventarioItem == null)
                {
                    FicPazt_rh_cat_personas_perfiles_Item.FechaReg = dta_string;
                    FicPazt_rh_cat_personas_perfiles_Item.FechaUltMod = dta_string;
                    FicPazt_rh_cat_personas_perfiles_Item.UsuarioReg = user;
                    FicPazt_rh_cat_personas_perfiles_Item.UsuarioMod = user;

                    await ficSQLiteConnection.InsertAsync(FicPazt_rh_cat_personas_perfiles_Item).ConfigureAwait(false);
                }
                else
                {
                    FicPazt_rh_cat_personas_perfiles_Item.IdPersona = FicExistingInventarioItem.IdPersona;
                    FicPazt_rh_cat_personas_perfiles_Item.FechaUltMod = dta_string;
                    FicPazt_rh_cat_personas_perfiles_Item.UsuarioMod = user;
                    await ficSQLiteConnection.UpdateAsync(FicPazt_rh_cat_personas_perfiles_Item).ConfigureAwait(false);
                }

            }
        }

        public async Task FicMetRemoveRhCatPersonasPerfiles(rh_cat_personas_perfiles FicPaZt_rh_cat_personas_perfiles_Item)
        {
            await ficSQLiteConnection.DeleteAsync(FicPaZt_rh_cat_personas_perfiles_Item);
        }

        public async Task<IList<rh_cat_personas_perfiles>> FicSearchRhCatPersonasPerfiles(String search)
        {
            var items = new List<rh_cat_personas_perfiles>();
            using (await ficMutex.LockAsync().ConfigureAwait(false))
            {
                items = await ficSQLiteConnection.Table<rh_cat_personas_perfiles>().Where(s =>
                s.UsuarioReg == search || s.UsuarioMod == search || s.FechaReg == search).ToListAsync().ConfigureAwait(false);


            }

            return items;
        }

        #endregion
    }
}
