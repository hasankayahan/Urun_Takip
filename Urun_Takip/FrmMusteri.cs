using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Urun_Takip
{
    public partial class FrmMusteri : Form
    {
        public FrmMusteri()
        {
            InitializeComponent();
        }
        DataSet1TableAdapters.TblMüsteriTableAdapter tb = new DataSet1TableAdapters.TblMüsteriTableAdapter();
        private void BtnListele_Click(object sender, EventArgs e)
        {
           
            dataGridView1.DataSource = tb.MüsteriListesi();
            //databind web tabanlı projelerde kullan.
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            tb.MüsteriEkle(TxtAd.Text, TxtSoyad.Text, TxtSehir.Text, decimal.Parse(TxtBakiye.Text));
            MessageBox.Show("Müşteri Sisteme Kaydedildi");
        
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            tb.MusteriSilme(int.Parse(TxtID.Text));
            MessageBox.Show("Müşteri Silme İşlemi Başarılı");
        }

        private void FrmMusteri_Click(object sender, EventArgs e)
        {
           
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            TxtID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            TxtAd.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            TxtSoyad.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            TxtSehir.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            TxtBakiye.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
        }

        private void BtnGüncelle_Click(object sender, EventArgs e)
        {
            tb.MusteriGuncelle(TxtAd.Text, TxtSoyad.Text, TxtSehir.Text, decimal.Parse(TxtBakiye.Text), int.Parse(TxtID.Text));
            MessageBox.Show("Müşteri Bilgileri Güncellendi");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(RdbAd.Checked == true)
            {
                dataGridView1.DataSource =  tb.AdaGöreListele(TxtAranacak.Text);
            }
            if(RdbSoyad.Checked == true)
            {
                dataGridView1.DataSource = tb.SoyadaGoreListele(TxtAranacak.Text);
            }
            if(RdbSehir.Checked == true)
            {
                dataGridView1.DataSource = tb.SehireGoreListele(TxtAranacak.Text);
            }
        }
    }
}
