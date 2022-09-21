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
    public partial class FrmAyarlar : Form
    {
        public FrmAyarlar()
        {
            InitializeComponent();
        }

        private SqlBaglantisi bgl = new SqlBaglantisi();

        void Listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter("Select * From TBL_ADMIN", bgl.baglanti());
            adapter.Fill(dt);
            gridControl1.DataSource = dt;
        }

        void Temizle()
        {
            txtKullaniciAdi.Text = "";
            txtSifre.Text = "";
        }

        private void FrmAyarlar_Load(object sender, EventArgs e)
        {
            Listele();
        }

        private void btnIslem_Click(object sender, EventArgs e)
        {
            if (btnIslem.Text == "KAYDET")
            {
                SqlCommand cmd = new SqlCommand("Insert Into TBL_ADMIN (KULLANICIADI, SIFRE) values (@p1, @p2)", bgl.baglanti());
                cmd.Parameters.AddWithValue("@p1", txtKullaniciAdi.Text);
                cmd.Parameters.AddWithValue("@p2", txtSifre.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Yeni kullanıcı sisteme kaydedildi", "Bilgi", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                Temizle();
                Listele();
                bgl.baglanti().Close();
            }

            if (btnIslem.Text == "GÜNCELLE")
            {
                SqlCommand cmd = new SqlCommand("Update TBL_ADMIN set KULLANICIAD = @p1, SIFRE = @p2 where ID = @p3",
                    bgl.baglanti());
                cmd.Parameters.AddWithValue("@p1", txtKullaniciAdi.Text);
                cmd.Parameters.AddWithValue("@p2", txtSifre.Text);
                cmd.Parameters.AddWithValue("@p3", txtId.Text);
                cmd.ExecuteNonQuery();
                
                bgl.baglanti().Close();

                MessageBox.Show("Kullanıcı bilgileri güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Temizle();
                Listele();
            }

        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);

            if (dr != null)
            {
                txtId.Text = dr["ID"].ToString();
                txtKullaniciAdi.Text = dr["KULLANICIADI"].ToString();
                txtSifre.Text = dr["SIFRE"].ToString();
            }
        }

        private void txtKullaniciAdi_TextChanged(object sender, EventArgs e)
        {
            if (txtKullaniciAdi.Text != "")
            {
                btnIslem.Text = "GÜNCELLE";
                btnIslem.BackColor = Color.AliceBlue;
            }
            else
            {
                btnIslem.Text = "KAYDET";
                btnIslem.BackColor = Color.Wheat;
            }
        }
    }
}
