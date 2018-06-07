using System.IO;
using Final.Interfaces.SQLite;
using Final.UWP.Services.SQLite;
using Windows.Storage;
using Xamarin.Forms;

[assembly: Dependency(typeof(FicConfigSQLiteUWP))]
namespace Final.UWP.Services.SQLite
{
    class FicConfigSQLiteUWP : IFicConfigSQLiteNETStd
    {
        public string FicGetDatabasePath()
        {
            return Path.Combine(ApplicationData.Current.LocalFolder.Path, AppSettings.ficDatabaseName);
        }
    }
}