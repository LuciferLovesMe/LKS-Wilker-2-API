using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PC_05_API.Models;

namespace PC_05_API.Controllers
{
    public class VaksinController : ApiController
    {
        SqlConnection connection = new SqlConnection(Connection.conn);
        [HttpPost]
        public DataTable getvaksin([FromBody] Model model)
        {
            string sql = "select * from detail_vaksinasi join vaksinasi on vaksinasi.id = detail_vaksinasi.id_vaksinasi join admin on detail_vaksinasi.id_dokter = admin.id join jenis_vaksin on detail_vaksinasi.id_jenis_vaksin = jenis_vaksin.id where vaksinasi.nik = '"+model.nik+"'";
            DataTable table = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
            adapter.Fill(table);
            return table;
        }
    }
}
