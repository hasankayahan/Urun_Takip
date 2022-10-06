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
using System.Data.SqlClient;

namespace Urun_Takip
{
    public partial class Frmİstatistik : Form
    {
        public Frmİstatistik()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=HASANS\SQLEXPRESS;Initial Catalog=DbUrun;Integrated Security=True");
        private void Frmİstatistik_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut1 = new SqlCommand("select Count(*) from TblKategori",baglanti);
            SqlDataReader dr = komut1.ExecuteReader();
            while (dr.Read())
            {
                LblToplamKategori.Text = dr[0].ToString();
            }
            baglanti.Close();

            //toplam ürün sayısı
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("select Count(*) from TblUrunler", baglanti);
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                LblToplamUrun.Text = dr2[0].ToString();
            }
            baglanti.Close();

            //Max Stoklu Ürün
            baglanti.Open();
            SqlCommand komut3 = new SqlCommand("select * from TblUrunler where Stok=(Select Max(Stok) from TblUrunler)", baglanti);
            SqlDataReader dr3 = komut3.ExecuteReader();
            while (dr3.Read())
            {
                LblMaxStok.Text = dr3["UrunAd"].ToString();
            }
            baglanti.Close();

            //Min Stoklu
            baglanti.Open();
            SqlCommand komut4 = new SqlCommand("select * from TblUrunler where Stok=(Select Min(Stok) from TblUrunler)", baglanti);
            SqlDataReader dr4 = komut4.ExecuteReader();
            while (dr4.Read())
            {
                LblMinStok.Text = dr4["UrunAd"].ToString();
            }
            baglanti.Close();


            //BeyazEsyaSayısı

            baglanti.Open();
            SqlCommand komut5 = new SqlCommand("select Count(*) from TblUrunler where kategori = (select ID from TblKategori where Ad='Beyaz Eşya')", baglanti);
            SqlDataReader dr5 = komut5.ExecuteReader();
            while (dr5.Read())
            {
                LblBeyazEsya.Text = dr5[0].ToString();
            }
            baglanti.Close();

            //Küçük ev aletleri

            baglanti.Open();
            SqlCommand komut6 = new SqlCommand("select Count(*) from TblUrunler where kategori = (select ID from TblKategori where Ad='Küçük Ev Aletleri')", baglanti);
            SqlDataReader dr6 = komut6.ExecuteReader();
            while (dr6.Read())
            {
                LblKucukEvAletleri.Text = dr6[0].ToString();
            }
            baglanti.Close();


            ///Laptop Toplam Kar 
            baglanti.Open();
            SqlCommand komut7 = new SqlCommand("select Stok*(SatisFiyat-AlisFiyat) from TblUrunler where UrunAd='Laptop'", baglanti);
            SqlDataReader dr7 = komut7.ExecuteReader();
            while (dr7.Read())
            {
                LblLaptopKar.Text = dr7[0].ToString() + "₺";
            }
            baglanti.Close();


            //BeyazEsyaKAr
            baglanti.Open();
            SqlCommand komut8 = new SqlCommand("select sum(Stok*(SatisFiyat-AlisFiyat)) as 'Stoklarla Kar Toplamı' from TblUrunler where Kategori = (select ID from TblKategori where Ad='Beyaz Eşya')\r\n", baglanti);
            SqlDataReader dr8 = komut8.ExecuteReader();
            while (dr8.Read())
            {
                LblBeyazEsyaKar.Text = dr8[0].ToString() + "₺";
            }
            baglanti.Close();

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
} 
