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

namespace Ticari_Otomasyon
{
    public partial class FrmAdmin : Form
    {
        public FrmAdmin()
        {
            InitializeComponent();
        }

        private SqlBaglantisi bgl = new SqlBaglantisi();

        private void button1_MouseHover(object sender, EventArgs e)
        {
            btnGirisYap.BackColor = Color.Goldenrod;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            btnGirisYap.BackColor = Color.FloralWhite;
        }

        private void btnGirisYap_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Select * From TBL_ADMIN where KULLANICIADI=@p1 and SIFRE=@p2",
                bgl.baglanti());
            cmd.Parameters.AddWithValue("@p1", txtKullaniciAd.Text);
            cmd.Parameters.AddWithValue("@p2", txtSifre.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                FrmAnaModul frmAnaModul = new FrmAnaModul();
                frmAnaModul.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı kullanıcı adı veya şifre", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtKullaniciAd.Text = "";
                txtSifre.Text = "";
            }
            bgl.baglanti().Close();
        }
    }
}
