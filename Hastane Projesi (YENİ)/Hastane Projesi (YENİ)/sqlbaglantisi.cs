﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Hastane_Projesi__YENİ_
{
    internal class sqlbaglantisi
    {
        public SqlConnection baglanti()
        {
            SqlConnection baglan = new SqlConnection("Data Source=DESKTOP-NKAUUHC\\SQLEXPRESS;Initial Catalog=HastanProjeYeni;Integrated Security=True");
            baglan.Open();  
            return baglan;
        }
    }
}
