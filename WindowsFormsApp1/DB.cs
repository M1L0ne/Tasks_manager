using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp1
{
    class DB
    {
        MySqlConnection connection = new MySqlConnection("server=127.0.0.1;port=3306;username=root;password=;database=databasetsygvintsev");

        public void openConnection()
        {
            connection.Open();
        }

        public MySqlConnection getConnection()
        {
            return connection;
        }

        public void closeConnection()
        {
            connection.Close();
        }

    }

}
