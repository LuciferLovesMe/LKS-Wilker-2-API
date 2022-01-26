using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PC_05_API.Models
{
    public class LoginModel
    {
        public string noHp { set; get; }
        public string nik { set; get; }
        public string nama { set; get; }
        public string tempat_lahir { set; get; }
        public string tanggal_lahir { set; get; }
        public string alamat { set; get; }

    }

    public class Connection
    {
        public static string conn = @"Data Source=DESKTOP-00EPOSJ;Initial Catalog=PC_05;Integrated Security=True";
    }

    public class Model
    {
        public string nik { set; get; }
    }
}