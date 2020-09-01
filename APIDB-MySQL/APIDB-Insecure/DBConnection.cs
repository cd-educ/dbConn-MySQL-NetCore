using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using MySql.Data.MySqlClient;
using System.Runtime.CompilerServices;
using System.Text;
using System.Data;

namespace APIDB_Insecure
{
    class DBConnection
    {

        private static DBConnection instance = null;
        private string connString;
        MySqlConnection conn;

        private DBConnection() { }

        public static DBConnection getInstance()
        {
            if (instance == null)
            {
                DBConnection.instance = new DBConnection();
            }

            return DBConnection.instance;

        }

        public void connect(string connString)
        {
            this.connString = connString;
            this.conn = new MySqlConnection(connString);
        }

        public IDataReader select(string sql)
        {

            this.conn.Open();
            var command = new MySqlCommand(sql, this.conn);

            var dataReader = command.ExecuteReader();

            // Guarda datos en memoria
            var dt = new DataTable();
            dt.Load(dataReader);

            this.conn.Close();

            return dt.CreateDataReader();

        }
        public void insert(string sql)
        {

            this.conn.Open();
            var command = new MySqlCommand(sql, this.conn);
            command.ExecuteNonQuery();

            this.conn.Close();

        }

        public void delete(string sql)
        {

            this.conn.Open();
            var command = new MySqlCommand(sql, this.conn);
            command.ExecuteNonQuery();

            this.conn.Close();

        }

        public void update(string sql)
        {

            this.conn.Open();
            var command = new MySqlCommand(sql, this.conn);
            command.ExecuteNonQuery();

            this.conn.Close();

        }

    }
}
