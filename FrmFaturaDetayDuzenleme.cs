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
    public partial class FrmFaturaDetayDuzenleme : Form
    {
        public FrmFaturaDetayDuzenleme()
        {
            InitializeComponent();
        }

        public string urunId;
        SqlBaglantisi bgl = new SqlBaglantisi();

        private void FrmFaturaDetayDuzenleme_Load(object sender, EventArgs e)
        {
            txtUrunId.Text = urunId;
            SqlCommand cmd = new SqlCommand("Select * From TBL_FATURADETAY Where ID=@p1", bgl.baglanti());
            cmd.Parameters.AddWithValue("@p1", urunId);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                txtUrunAdi.Text = dr[1].ToString();
                txtMiktar.Text = dr[2].ToString();
                txtFiyat.Text = dr[3].ToString();
                txtTutar.Text = dr[4].ToString();
                
                bgl.baglanti().Close();
            }
        }

        private void btnDetayGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Update TBL_FATURADETAY set URUNAD=@p1, MIKTAR=@p2, FIYAT=@p3, TUTAR=@p4 Where ID=@p5",bgl.baglanti());
            cmd.Parameters.AddWithValue("@p1", txtUrunAdi.Text);
            cmd.Parameters.AddWithValue("@p2", txtMiktar.Text);
            cmd.Parameters.AddWithValue("@p3", decimal.Parse(txtFiyat.Text));
            cmd.Parameters.AddWithValue("@p4", decimal.Parse(txtTutar.Text));
            cmd.Parameters.AddWithValue("@p5", txtUrunId.Text);
            cmd.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Değişiklikler kaydedildi", "Bilig", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnDetaySil_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Delete From TBL_FATURADETAY Where ID=@p1",bgl.baglanti());
            cmd.Parameters.AddWithValue("@p1",txtUrunId.Text);
            cmd.ExecuteNonQuery();
            bgl.baglanti().Close();

            MessageBox.Show("Ürün silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
    }
}
