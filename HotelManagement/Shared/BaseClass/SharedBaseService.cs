using System.Data;
using System.Data.SqlClient;

namespace HotelManagement.Shared.BaseClass
{
    public class SharedBaseService
    {
        public SqlConnection GetConn()
        {
            return GetOpenDataConnection("LAPTOP-K2EH8V3O", "HotelManagement", "sa", "coventry");
        }

        private SqlConnection GetOpenDataConnection(string server, string database, string user, string password)
        {
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-K2EH8V3O;Initial Catalog=HotelManagement; User ID = sa; Password = coventry;");
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * from GstTableGuests;", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            //dataGridForm.ItemsSource = dt.DefaultView;

            var builder = new SqlConnectionStringBuilder()
            {
                DataSource = server,
                InitialCatalog = database,
                UserID = user,
                Password = password
            };

            var connection = new SqlConnection(builder.ToString());
            connection.Open();
            return connection;
        }

    }
}
