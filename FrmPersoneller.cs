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
    public partial class FrmPersoneller : Form
    {
        public FrmPersoneller()
        {
            InitializeComponent();
        }

        void Temizle()
        {
            TxtId.Text = "";
            txtAd.Text = "";
            txtSoyad.Text = "";
            mskTelefon1.Text = "";
            mskTcNo.Text = "";
            txtMail.Text = "";
            cmbIl.Text = "";
            cmbIlce.Text = "";
            rchAdres.Text = "";
            txtGorev.Text = "";
            txtMaas.Text = "";
        }

        void Listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter dataAdapter = new SqlDataAdapter("Select * From TBL_PERSONELLER", bgl.baglanti());
            dataAdapter.Fill(dt);
            gridControl1.DataSource = dt;
        }

        void SehirListele()
        {
            SqlCommand cmd = new SqlCommand("Select Sehir From TBL_ILLER", bgl.baglanti());
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cmbIl.Properties.Items.Add(dr[0]);
            }
            bgl.baglanti().Close();
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }

        private SqlBaglantisi bgl = new SqlBaglantisi();
        private void FrmPersoneller_Load(object sender, EventArgs e)
        {
            Listele();
            SehirListele();
            Temizle();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            SqlCommand cmd =
                new SqlCommand(
                    "Insert Into TBL_PERSONELLER (AD, SOYAD, TELEFON, TC, MAIL, IL, ILCE, ADRES, GOREV, MAAS) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10)",
                    bgl.baglanti());
            cmd.Parameters.AddWithValue("@p1",txtAd.Text);
            cmd.Parameters.AddWithValue("@p2",txtSoyad.Text);
            cmd.Parameters.AddWithValue("@p3",mskTelefon1.Text);
            cmd.Parameters.AddWithValue("@p4",mskTcNo.Text);
            cmd.Parameters.AddWithValue("@p5",txtMail.Text);
            cmd.Parameters.AddWithValue("@p6",cmbIl.Text);
            cmd.Parameters.AddWithValue("@p7",cmbIlce.Text);
            cmd.Parameters.AddWithValue("@p8",rchAdres.Text);
            cmd.Parameters.AddWithValue("@p9",txtGorev.Text);
            cmd.Parameters.AddWithValue("@p10", txtMaas.Text);
            cmd.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Personel sisteme eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Listele();
            Temizle();

        }

        private void cmbIl_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbIlce.Properties.Items.Clear();
            SqlCommand cmd = new SqlCommand("Select ILCE from TBL_ILCELER where Sehir=@p1", bgl.baglanti());
            cmd.Parameters.AddWithValue("@p1", cmbIl.SelectedIndex + 1);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cmbIlce.Properties.Items.Add(dr[0]);
            }
            bgl.baglanti().Close();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Delete From TBL_PERSONELLER where ID=@p1", bgl.baglanti());
            cmd.Parameters.AddWithValue("@p1", TxtId.Text);
            cmd.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Personel sistemden silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            Listele();
            Temizle();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand cmd =
                new SqlCommand(
                    "Update TBL_PERSONELLER set AD=@p1, SOYAD=@p2, TELEFON=@p3, TC=@p4, MAIL=@p5, IL=@p6, ILCE=@p7, ADRES=@p8, GOREV=@p9 MAAS=@p10 Where ID=@p11",
                    bgl.baglanti());
            cmd.Parameters.AddWithValue("@p1", txtAd.Text);
            cmd.Parameters.AddWithValue("@p2", txtSoyad.Text);
            cmd.Parameters.AddWithValue("@p3", mskTelefon1.Text);
            cmd.Parameters.AddWithValue("@p4", mskTcNo.Text);
            cmd.Parameters.AddWithValue("@p5", txtMail.Text);
            cmd.Parameters.AddWithValue("@p6", cmbIl.Text);
            cmd.Parameters.AddWithValue("@p7", cmbIlce.Text);
            cmd.Parameters.AddWithValue("@p8", rchAdres.Text);
            cmd.Parameters.AddWithValue("@p9", txtGorev.Text);
            cmd.Parameters.AddWithValue("@p10", txtMaas.Text);
            cmd.Parameters.AddWithValue("@p11", TxtId.Text);
            cmd.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Personel bilgileri güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            Listele();
            Temizle();

        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            DataRow dataRow = gridView1.GetDataRow(gridView1.FocusedRowHandle);

            if (dataRow != null)
            {
                TxtId.Text = dataRow["ID"].ToString();
                txtAd.Text = dataRow["AD"].ToString();
                txtSoyad.Text = dataRow["SOYAD"].ToString();
                mskTelefon1.Text = dataRow["TELEFON"].ToString();
                mskTcNo.Text = dataRow["TC"].ToString();
                txtMail.Text = dataRow["MAIL"].ToString();
                cmbIl.Text = dataRow["IL"].ToString();
                cmbIlce.Text = dataRow["ILCE"].ToString();
                rchAdres.Text = dataRow["ADRES"].ToString();
                txtGorev.Text = dataRow["GOREV"].ToString();
                txtMaas.Text = dataRow["MAAS"].ToString();
            }
        }

    
    }
}
