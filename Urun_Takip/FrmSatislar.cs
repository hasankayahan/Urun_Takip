using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Urun_Takip
{
    public partial class FrmSatislar : Form
    {
        public FrmSatislar()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=HASANS\SQLEXPRESS;Initial Catalog=DbUrun;Integrated Security=True");


        DataSet1TableAdapters.TblSatislarTableAdapter ds = new DataSet1TableAdapters.TblSatislarTableAdapter();

        private void BtnListele_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Execute SatisListesi", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

        }

        private void FrmSatislar_Load(object sender, EventArgs e)
        {

            SqlCommand komut2 = new SqlCommand("select * from TblUrunler", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut2);
            DataTable dt2 = new DataTable();
            da.Fill(dt2);
            comboBox1.ValueMember = "UrunId";
            comboBox1.DisplayMember = "UrunAd";
            comboBox1.DataSource = dt2;


            dataGridView1.DataSource = ds.SatisListesi();


        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            ds.SatisEkle(int.Parse(comboBox1.SelectedValue.ToString()), int.Parse(TxtMusteri.Text), byte.Parse(TxtAdet.Text), decimal.Parse(TxtFiyat.Text), decimal.Parse(TxtToplam.Text), DateTime.Parse(MskTarih.Text));
            MessageBox.Show("Satış Başarıyla Kaydedildi");


         }

        private void BtnHesapla_Click(object sender, EventArgs e)
        {
            double adet, fiyat, toplam;
            adet = Convert.ToDouble(TxtAdet.Text);  
            fiyat = Convert.ToDouble(TxtFiyat.Text);
            toplam = adet * fiyat;
            TxtToplam.Text = toplam.ToString();
        }

        private void BtnGüncelle_Click(object sender, EventArgs e)
        {
            ds.SatisGuncelle(int.Parse(comboBox1.SelectedValue.ToString()), int.Parse(TxtMusteri.Text), byte.Parse(TxtAdet.Text), decimal.Parse(TxtFiyat.Text), decimal.Parse(TxtToplam.Text), DateTime.Parse(MskTarih.Text),int.Parse(TxtID.Text));
            MessageBox.Show("Ürün Güncelleme Başarılı");
        }
    }
}
    