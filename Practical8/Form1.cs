using Microsoft.Data.SqlClient;

namespace Practical8
{
    public partial class Form1 : Form
    {
        SqlConnection connection;

        public Form1()
        {
            string connStr = "Server=localhost;Database=DbP8;Trusted_Connection=True;Encrypt=True;TrustServerCertificate=True;";

            this.connection = new SqlConnection(connStr);
            this.connection.Open();

            SqlCommand cmd = new SqlCommand("SELECT * FROM Students", connection);

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Console.WriteLine(reader[0]);
                }
            }

            this.InitializeComponent();
        }
    }
}
