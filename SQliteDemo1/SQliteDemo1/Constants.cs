using System;
using System.IO;

namespace SQliteDemo1
{
    public static class Constants
    {

        //Definimos una constante con el nombre de nuestra base de datos
        private const string DatabaseFileName = "SQLite.db3";

        //Definimos una constante con las banderasd para trabajar con nuestra BD
        public const SQLite.SQLiteOpenFlags Flags =
            SQLite.SQLiteOpenFlags.ReadWrite |
            SQLite.SQLiteOpenFlags.Create | 
            SQLite.SQLiteOpenFlags.SharedCache;

        //Creamos el método para devolver el Path de la Base De Datos
        public static string DatabasePath 
        { 
            get
            {
                var basePath = 
                    Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                return Path.Combine(basePath, DatabaseFileName);
            }
        }
    }
}
