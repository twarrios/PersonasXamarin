using System.IO;
using Xamarin.Forms;
using Final.Interfaces.SQLite;
using Final.Droid.Services.SQLite;

[assembly: Dependency(typeof(ficConfigSQLiteDROID))]
namespace Final.Droid.Services.SQLite
{
    public class ficConfigSQLiteDROID : IFicConfigSQLiteNETStd

    {
        public string FicGetDatabasePath()
        {
            string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            return Path.Combine(path, AppSettings.ficDatabaseName);
        }
    }
}