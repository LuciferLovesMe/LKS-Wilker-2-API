using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PC_05_API.Models
{
    public class Command
    {
        public static DataTable getdata (string com)
        {
            SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-00EPOSJ;Initial Catalog=PC_05;Integrated Security=True");
            SqlDataAdapter adapter = new SqlDataAdapter(com, connection);
            DataTable table = new DataTable();
            adapter.Fill(table);

            return table;
        }
    }
}