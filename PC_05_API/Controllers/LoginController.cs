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
    public class LoginController : ApiController
    {
        PC_05Entities row = new PC_05Entities();
        SqlConnection connection = new SqlConnection(Connection.conn);
        List<LoginModel> models = new List<LoginModel>();
        LoginModel l = new LoginModel();
        [HttpPost]
        public List<LoginModel> m([FromBody] LoginModel model)
        {
            string query = "select * from warga where nik = '" + model.nik + "' and noHp = '" + model.noHp + "'";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            reader.Read();
            if (reader.HasRows)
            {
                models.Add(new LoginModel
                {
                    nik = reader["nik"].ToString(),
                    alamat = reader["alamat"].ToString(),
                    noHp = reader["noHp"].ToString(),
                    nama = reader["nama"].ToString(),
                    tempat_lahir = reader["tempat_lahir"].ToString(),
                    tanggal_lahir = reader["tanggal_lahir"].ToString()
                });

                return models.ToList();
            }

            return null;
        }

        [Route("api/login2")]
        [HttpPost]
        public IHttpActionResult result ([FromBody] LoginModel model)
        {
            string query = "select * from warga where nik = '" + model.nik + "' and noHp = '" + model.noHp + "'";
            var user = row.wargas.SqlQuery(query).FirstOrDefault();
            if(user != null)
            {
                model.nik = user.nik;
                model.alamat = user.alamat;
                model.noHp = user.noHp;
                model.nama = user.nama;
                model.tempat_lahir = user.tempat_lahir;
                model.tanggal_lahir = user.tanggal_lahir.ToString() ;
                return Ok(user);
            }

            return null;
        }
    }
}
