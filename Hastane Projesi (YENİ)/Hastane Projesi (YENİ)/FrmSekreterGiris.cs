using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Hastane_Projesi__YENİ_
{
    public partial class FrmSekreterGiris : Form
    {
        public FrmSekreterGiris()
        {
            InitializeComponent();
        }
            sqlbaglantisi bgl = new sqlbaglantisi();
        private void btngirisyap_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Select * From Tbl_Sekreter where SekreterTC = @p1 and SekreterSifre = @p2 " , bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", msktc.Text);
            komut.Parameters.AddWithValue("@p2", txtsifre.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())    //burada while yerine if kullanmalıyız çünkü sorgulama yapıyoruz. (okuma işleminin doğru olup olmadığını kontrol ediyor.)
            {
                FrmSekreterDetay frs = new FrmSekreterDetay();
                frs.TCnumara = msktc.Text;
                frs.Show();
                this.Hide();

            }
            else
            {
                MessageBox.Show("Hatalı Tc & Şifre");
            }
            bgl.baglanti().Close(); 
        }

        private void FrmSekreterGiris_Load(object sender, EventArgs e)
        {

        }
    }
}
