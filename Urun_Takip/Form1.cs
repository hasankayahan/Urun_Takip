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

namespace Urun_Takip
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut3 = new SqlCommand("delete from TblKategori where ID=@p1", baglanti);
            komut3.Parameters.AddWithValue("@p1", TxtID.Text);
            komut3.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Silme işlemi başarılı");
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=HASANS\SQLEXPRESS;Initial Catalog=DbUrun;Integrated Security=True");
        private void BtnListele_Click(object sender, EventArgs e)
        {
            
            SqlCommand komut = new SqlCommand("select * from TblKategori",baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("insert into TblKategori(Ad) values (@p1)", baglanti);
            komut2.Parameters.AddWithValue("@p1", TxtKategori.Text);
            komut2.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kaydetme işlemi başarılı");

        }

        private void BtnGüncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut4 = new SqlCommand("update TblKategori set Ad=@p1 where ID=@p2", baglanti);
            komut4.Parameters.AddWithValue("@p1",TxtKategori.Text);
            komut4.Parameters.AddWithValue("@p2", TxtID.Text);
            komut4.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Güncelleme İşlemi Başarılı");


        }

        private void BtnAra_Click(object sender, EventArgs e)
        {
            SqlCommand komut5 = new SqlCommand("select * from TblKategori where Ad=@p1", baglanti);
            komut5.Parameters.AddWithValue("@p1", TxtKategori.Text);
            SqlDataAdapter da = new SqlDataAdapter(komut5);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

        }
    }
}

//Data Source=HASANS\SQLEXPRESS;Initial Catalog=DbUrun;Integrated Security=True
