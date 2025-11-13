using System.Configuration;
using System.Data.SqlClient;

namespace VeterinariaRemaster.Data
{
    public static class DbHelper
    {
        private static readonly string connectionString =
            ConfigurationManager.ConnectionStrings["VetDB"].ConnectionString;

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
