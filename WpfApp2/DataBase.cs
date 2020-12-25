using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2
{
    class DataBase
    {
        MySqlConnection connection = new MySqlConnection("server=127.0.0.1;port=3306;username=root;password=I5EPebrqPsJBVM7lPoa2;database=danya"); /*I5EPebrqPsJBVM7lPoa2*/ /*Qwe123456*/
        public void openConnection()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
                connection.Open();
        }
        public void closeConnection()
        {
            if (connection.State == System.Data.ConnectionState.Open)
                connection.Close();
        }

        public MySqlConnection GetConnection()
        {
            return connection;
        }
    }
}
