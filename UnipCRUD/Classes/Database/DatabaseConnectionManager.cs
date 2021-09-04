using System;
using System.Configuration;
using System.Data.Common;
using System.Data.SqlClient;
using UnipCRUD.Classes.Exceptions;

namespace UnipCRUD.Database
{
    public class DatabaseConnectionManager
    {
        private readonly string ConnectionString = ConfigurationManager.ConnectionStrings["MainDB"].ConnectionString;
        private readonly SqlConnection CurrentConnection = new SqlConnection();

        public readonly MainDBContext Context;

        public DatabaseConnectionManager()
        {
            CurrentConnection.ConnectionString = ConnectionString;
            Context = new MainDBContext(CurrentConnection);
            Context.Database.CreateIfNotExists(); // TODO: Remove this & Create a migration project
        }

        public DbConnection GetConnection()
        {
            return Context.Database.Connection;
        }

        public void Disconnect()
        {
            try
            {
                Context.Dispose();
                if (Context.Database.Connection != null && Context.Database.Connection.State == System.Data.ConnectionState.Open)
                    CurrentConnection.Close();
            }
            catch (Exception ex)
            {
                new MessageBoxException(ex);
            }
        }
    }
}
