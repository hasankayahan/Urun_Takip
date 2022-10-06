using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Urun_Takip

{
    public partial class FrmAdmin : Form
    {
        public FrmAdmin()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=HASANS\SQLEXPRESS;Initial Catalog=DbUrun;Integrated Security=True");
        private void BtnGirisYap_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from TblAdmin where Kullanici=@p1 and Sifre = @p2",baglanti);
            komut.Parameters.AddWithValue("@p1", TxtKullanıcı.Text);
            komut.Parameters.AddWithValue("@p2", TxtSifre.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                FrmYonlendirme fr = new FrmYonlendirme();
                fr.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Kullanıcı adı veya şifrenizde hata var. Yeniden deneyin");
            }
            baglanti.Close();

        }
    }
}
