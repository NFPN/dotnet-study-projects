using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace UnipCRUD.Database
{
    public class DBConnection
    {
        private static SqlConnection CurrentConnection;

        static DBConnection() => CurrentConnection = new SqlConnection();

        public SqlConnection CreateConnection()
        {
            try
            {
                var connString = ConfigurationManager.ConnectionStrings["MainDB"].ConnectionString;
                CurrentConnection.ConnectionString = connString;
                CurrentConnection.Open();
                MessageBox.Show(CurrentConnection.State.ToString(), "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return CurrentConnection;
        }

        public void Disconnect()
        {
            try
            {
                CurrentConnection.Close();
                MessageBox.Show(CurrentConnection.State.ToString(), "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
