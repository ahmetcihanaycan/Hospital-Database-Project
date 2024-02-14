using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hastane_Projesi__YENİ_
{
    public partial class FrmDoktorBilgiDüzenle : Form
    {
        public FrmDoktorBilgiDüzenle()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
        sqlbaglantisi bgl = new sqlbaglantisi();
        public string tcno;
        private void FrmDoktorBilgiDüzenle_Load(object sender, EventArgs e)
        {
            msktc.Text = tcno;

            SqlCommand komut = new SqlCommand("Select * From Tbl_Doktorlar where DoktorTc=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", msktc.Text); 
            SqlDataReader dr =komut.ExecuteReader();
            while (dr.Read())
            {
                txtad.Text = dr[1].ToString();
                txtsoyad.Text = dr[2].ToString();
                cmbbrans.Text = dr[3].ToString();
                txtsifre.Text = dr[5].ToString();
            }
            bgl.baglanti().Close();
        }

        private void btnbilgigüncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Update Tbl_Doktorlar set  DoktorAd = @p1 , DoktorSoyad = @p2 ,DoktorBrans = @p3 , DoktorSifre=@p4 where DoktorTc=@p5", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1" , txtad.Text);
            komut.Parameters.AddWithValue("@p2" , txtsoyad.Text);
            komut.Parameters.AddWithValue("@p3" , cmbbrans.Text);
            komut.Parameters.AddWithValue("@p4" , txtsifre.Text);
            komut.Parameters.AddWithValue("@p5", msktc.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Kayıt Güncellendi");

        }
    }
