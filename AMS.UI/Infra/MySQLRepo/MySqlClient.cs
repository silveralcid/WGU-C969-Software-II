using AMS.UI.Domain.Interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace AMS.UI.Infra.MySQLRepo
{
    public class MySqlClient : IDbClient
    {
        static readonly string connectionString = "server=localhost; database=client_schedule; uid=sqlUser; pwd=Passw0rd!";

        public bool CreateRecord(string[] queries)
        {
            try
            {
                bool isCreated = ExecuteNonQueries(queries);

                return isCreated;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"ERROR: Unable to create record with exception:\n{ex.Message}");
                return false;
            }
        }

        public int CreateScaler(string query)
        {
            int id = -1;
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string withLastInsertedId = $"{query} SELECT LAST_INSERT_ID();";

                MySqlCommand command = new MySqlCommand(withLastInsertedId, connection);

                id = Convert.ToInt32(command.ExecuteScalar());
            }

            return id;
        }

        public bool DeleteRecord(string[] queries)
        {
            try
            {
                bool isDeleted = ExecuteNonQueries(queries);

                return isDeleted;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"ERROR: Unable to delete record with exception:\n{ex.Message}");
                return false;
            }
        }

        public DataTable ReadRecord(string query)
        {
            DataTable datatable = new DataTable();
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(query, connection);

                datatable.Load(command.ExecuteReader());
            }

            return datatable;
        }

        public bool UpdateRecord(string[] queries)
        {
            try
            {
                bool isUpdated = ExecuteNonQueries(queries);

                return isUpdated;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"ERROR: Unable to update record with exception:\n{ex.Message}");
                return false;
            }
        }

        #region PrivateMethods

        private bool ExecuteNonQueries(string[] queries)
        {
            int affectedRows = 0;
            
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                using (MySqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        foreach (var query in queries)
                        {
                            MySqlCommand command = new MySqlCommand(query, connection);
                            affectedRows += command.ExecuteNonQuery();
                        }

                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }

            return affectedRows > 0;
        }

        #endregion
    }
}
