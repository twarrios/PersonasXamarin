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
   public class FicSrvRhCatDomiciliosList: IFicSrvRhCatDomicilios
    {
        private static readonly FicAsyncLock ficMutex = new FicAsyncLock();
        private SQLiteAsyncConnection ficSQLiteConnection;

        //FIC: Constructor
        public FicSrvRhCatDomiciliosList()
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

        #region rh_cat_domicilios

        public async Task<IList<rh_cat_domicilios>> FicMetGetListRhCatDomicilios()
        {
            var items = new List<rh_cat_domicilios>();
            using (await ficMutex.LockAsync().ConfigureAwait(false))
            {
                items = await ficSQLiteConnection.Table<rh_cat_domicilios>().ToListAsync().ConfigureAwait(false);
            }

            return items;
        }

        public async Task FicMetInsertNewRhCatDomicilios(rh_cat_domicilios FicPazt_rh_cat_domicilios_Item)
        {
            using (await ficMutex.LockAsync().ConfigureAwait(false))
            {
                var FicExistingInventarioItem = await ficSQLiteConnection.Table<rh_cat_domicilios>()
                        .Where(x => x.IdDomicilio == FicPazt_rh_cat_domicilios_Item.IdDomicilio)
                        .FirstOrDefaultAsync();

                DateTime dta = DateTime.Now.ToLocalTime();
                string dta_string = dta.ToString("yyyy-MM-dd");
                //string user = Environment.UserName;
                string user = "FIBARRAC";

                if (FicExistingInventarioItem == null)
                {
                    FicPazt_rh_cat_domicilios_Item.FechaReg = dta_string;
                    FicPazt_rh_cat_domicilios_Item.FechaUltMod = dta_string;
                    FicPazt_rh_cat_domicilios_Item.UsuarioReg = user;
                    FicPazt_rh_cat_domicilios_Item.UsuarioMod = user;

                    await ficSQLiteConnection.InsertAsync(FicPazt_rh_cat_domicilios_Item).ConfigureAwait(false);
                }
                else
                {
                    FicPazt_rh_cat_domicilios_Item.IdDomicilio = FicExistingInventarioItem.IdDomicilio;
                    FicPazt_rh_cat_domicilios_Item.FechaUltMod = dta_string;
                    FicPazt_rh_cat_domicilios_Item.UsuarioMod = user;
                    await ficSQLiteConnection.UpdateAsync(FicPazt_rh_cat_domicilios_Item).ConfigureAwait(false);
                }

            }
        }

        public async Task FicMetRemoveRhCatDomicilios(rh_cat_domicilios FicPaZt_rh_cat_domicilios_Item)
        {
            await ficSQLiteConnection.DeleteAsync(FicPaZt_rh_cat_domicilios_Item);
        }

        public async Task<IList<rh_cat_domicilios>> FicSearchRhCatDomicilios(String search)
        {
            var items = new List<rh_cat_domicilios>();
            using (await ficMutex.LockAsync().ConfigureAwait(false))
            {
                items = await ficSQLiteConnection.Table<rh_cat_domicilios>().Where(s =>
                s.Estado == search || s.Pais == search || s.Municipio == search).ToListAsync().ConfigureAwait(false);


            }

            return items;
        }

        #endregion
    }
}
