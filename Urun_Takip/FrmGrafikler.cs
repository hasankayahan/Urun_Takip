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
    public partial class FrmGrafikler : Form
    {
        public FrmGrafikler()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=HASANS\SQLEXPRESS;Initial Catalog=DbUrun;Integrated Security=True");
        private void FrmGrafikler_Load(object sender, EventArgs e)
        {
            baglanti.Open();    
            SqlCommand komut = new SqlCommand("select Ad,COUNT(*) from TblUrunler inner join TblKategori on TblUrunler.Kategori = TblKategori.ID group by Ad",baglanti);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                chart2.Series["Kategori"].Points.AddXY(dr[0], dr[1]);
                
            }
            baglanti.Close();
        }
    }
}
