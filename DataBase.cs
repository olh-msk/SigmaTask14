using System;
using System.Data;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;
using System.Linq;

namespace SigmaTask14
{
    class DataBase
    {
        protected SqliteConnection connection;
        public DataBase() { }
        public DataBase(string connectionString)
        {
            if (connectionString == null)
            {
                throw new ArgumentNullException("Connection is null");
            }

            //----------------
            Console.WriteLine(connectionString);
            //--------------

            connection = new SqliteConnection(connectionString);
            connection.Open();
        }

        public void ExecuteSQL(string sql)
        {
            using (connection)
            {
                connection.Open();
                SqliteCommand command = new SqliteCommand();
                command.Connection = connection;
                command.CommandText = sql;
                try
                {
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        public List<T> GetList<T>(string sql, Func<IDataRecord, T> generator)
        {
            var list = new List<T>();
            using (connection)
            {
                connection.Open();
                SqliteCommand command = new SqliteCommand(sql, connection);
                try
                {
                    using (SqliteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(generator(reader));
                        }
                    }
                }
                catch
                {
                    return null;
                }
            }
            return list;
        }
    }
}
