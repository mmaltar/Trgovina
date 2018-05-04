using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Windows.Forms;
using System.Data;

namespace Trgovina
{
    static class Database
    {
        private static string mDbPath = Application.StartupPath + "/database.db";
        public static SQLiteConnection mConn;
        

        static Database()
        {
            mConn = new SQLiteConnection("Data Source=" + mDbPath);
        }

    }
}
