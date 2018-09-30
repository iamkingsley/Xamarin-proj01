using System;
using System.IO;
using SQLite;
using Xamarin.Forms;

[assembly: Dependency(typeof(myApp.iOS.Persistence.SQLiteDb))]

namespace myApp.iOS.Persistence
{
    class SQLiteDb : myApp.Persistence.ISQLiteDb
    {
        public SQLiteAsyncConnection GetConnection()
        {
            var documentPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var path = Path.Combine(documentPath, "MySQLite.db3");

            return new SQLiteAsyncConnection(path);
        }
    }
}