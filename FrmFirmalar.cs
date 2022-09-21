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
    public partial class FrmFirmalar : Form
    {
        public FrmFirmalar()
        {
            InitializeComponent();
        }

        SqlBaglantisi bgl = new SqlBaglantisi();

        void FirmaListele()
        {
            SqlDataAdapter dataAdapter = new SqlDataAdapter("Select * From TBL_FIRMALAR",bgl.baglanti());
            DataTable dt = new DataTable();
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

        void Temizle()
        {
            txtAd.Text = "";
            TxtId.Text = "";
            txtYetkiliGorev.Text = "";
            txtYetkili.Text = "";
            mskYetkiliTcNo.Text = "";
            txtSektor.Text = "";
            mskTelefon1.Text = "";
            mskTelefon2.Text = "";
            mskTelefon3.Text = "";
            txtMail.Text = "";
            mskFax.Text = "";
            cmbIl.Text = "";
            cmbIlce.Text = "";
            txtVergiDaire.Text = "";
            rchAdres.Text = "";
            txtKod1.Text = "";
            txtKod2.Text = "";
            txtKod3.Text = "";
            txtAd.Focus();
        }

        void CariKodAciklamalar()
        {
            SqlCommand cmd = new SqlCommand("Select FIRMAKOD1 From TBL_KODLAR", bgl.baglanti());
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                rchKod1.Text = dr[0].ToString();
            }
            bgl.baglanti().Close();
        } 

        private void FrmFirmalar_Load(object sender, EventArgs e)
        {
            FirmaListele();
            SehirListele();
            CariKodAciklamalar();
            Temizle();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand(
                "Insert Into TBL_FIRMALAR (AD, YETKILISTATU, YETKILIADSOYAD, YETKILITC, SEKTOR, TELEFON, TELEFON2, TELEFON3, MAIL, FAX, IL, ILCE, VERGIDAIRE, ADRES, OZELKOD1, OZELKOD2, OZELKOD3) VALUES (@p1, @p2, @p3, @p4, @p5, @p6, @p7, @p8, @p9, @p10, @p11, @p12, @p13, @p14, @p15, @p16, @p17)",
                bgl.baglanti());

            cmd.Parameters.AddWithValue("@p1", txtAd.Text);
            cmd.Parameters.AddWithValue("@p2", txtYetkiliGorev.Text);
            cmd.Parameters.AddWithValue("@p3", txtYetkili.Text);
            cmd.Parameters.AddWithValue("@p4", mskYetkiliTcNo.Text);
            cmd.Parameters.AddWithValue("@p5", txtSektor.Text);
            cmd.Parameters.AddWithValue("@p6", mskTelefon1.Text);
            cmd.Parameters.AddWithValue("@p7", mskTelefon2.Text);
            cmd.Parameters.AddWithValue("@p8", mskTelefon3.Text);
            cmd.Parameters.AddWithValue("@p9", txtMail.Text);
            cmd.Parameters.AddWithValue("@p10", mskFax.Text);
            cmd.Parameters.AddWithValue("@p11", cmbIl.Text);
            cmd.Parameters.AddWithValue("@p12", cmbIlce.Text);
            cmd.Parameters.AddWithValue("@p13", txtVergiDaire.Text);
            cmd.Parameters.AddWithValue("@p14", rchAdres.Text);
            cmd.Parameters.AddWithValue("@p15", txtKod1.Text);
            cmd.Parameters.AddWithValue("@p16", txtKod2.Text);
            cmd.Parameters.AddWithValue("@p17", txtKod3.Text);

            cmd.ExecuteNonQuery();
            bgl.baglanti().Close();
            
            MessageBox.Show("Firma sisteme eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            FirmaListele();
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
            SqlCommand cmd = new SqlCommand("Delete From TBL_FIRMALAR where ID=@p1",bgl.baglanti());
            cmd.Parameters.AddWithValue("@p1", TxtId.Text);
            cmd.ExecuteNonQuery();
            bgl.baglanti().Close();
            FirmaListele();
            MessageBox.Show("Firma listeden silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            Temizle();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand(
                "Update TBL_FIRMALAR set AD=@p1, YETKILISTATU=@p2, YETKILIADSOYAD=@p3, YETKILITC=@p4, SEKTOR=@p5, TELEFON=@p6, TELEFON2=@p7, TELEFON3=@p8, MAIL=@p9, FAX=@p10, IL=@p11, ILCE=@p12, VERGIDAIRE=@p13, ADRES=@p14, OZELKOD1=@p15, OZELKOD2=@p16, OZELKOD3=@p17 Where ID=@p18",
                bgl.baglanti());
            cmd.Parameters.AddWithValue("@p1", txtAd.Text);
            cmd.Parameters.AddWithValue("@p2", txtYetkiliGorev.Text);
            cmd.Parameters.AddWithValue("@p3", txtYetkili.Text);
            cmd.Parameters.AddWithValue("@p4", mskYetkiliTcNo.Text);
            cmd.Parameters.AddWithValue("@p5", txtSektor.Text);
            cmd.Parameters.AddWithValue("@p6", mskTelefon1.Text);
            cmd.Parameters.AddWithValue("@p7", mskTelefon2.Text);
            cmd.Parameters.AddWithValue("@p8", mskTelefon3.Text);
            cmd.Parameters.AddWithValue("@p9", txtMail.Text);
            cmd.Parameters.AddWithValue("@p10", mskFax.Text);
            cmd.Parameters.AddWithValue("@p11", cmbIl.Text);
            cmd.Parameters.AddWithValue("@p12", cmbIlce.Text);
            cmd.Parameters.AddWithValue("@p13", txtVergiDaire.Text);
            cmd.Parameters.AddWithValue("@p14", rchAdres.Text);
            cmd.Parameters.AddWithValue("@p15", txtKod1.Text);
            cmd.Parameters.AddWithValue("@p16", txtKod2.Text);
            cmd.Parameters.AddWithValue("@p17", txtKod3.Text);
            cmd.Parameters.AddWithValue("@p18", TxtId.Text);
            cmd.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Firma bilgiler güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            FirmaListele();
            Temizle();

        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            DataRow dataRow = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dataRow != null)
            {
                TxtId.Text = dataRow["ID"].ToString();
                txtAd.Text = dataRow["AD"].ToString();
                txtYetkiliGorev.Text = dataRow["YETKILISTATU"].ToString();
                txtYetkili.Text = dataRow["YETKILIADSOYAD"].ToString();
                mskYetkiliTcNo.Text = dataRow["YETKILITC"].ToString();
                txtSektor.Text = dataRow["SEKTOR"].ToString();
                mskTelefon1.Text = dataRow["TELEFON"].ToString();
                mskTelefon2.Text = dataRow["TELEFON2"].ToString();
                mskTelefon3.Text = dataRow["TELEFON3"].ToString();
                txtMail.Text = dataRow["MAIL"].ToString();
                mskFax.Text = dataRow["FAX"].ToString();
                cmbIl.Text = dataRow["IL"].ToString();
                cmbIlce.Text = dataRow["ILCE"].ToString();
                txtVergiDaire.Text = dataRow["VERGIDAIRE"].ToString();
                rchAdres.Text = dataRow["ADRES"].ToString();
                txtKod1.Text = dataRow["OZELKOD1"].ToString();
                txtKod2.Text = dataRow["OZELKOD2"].ToString();
                txtKod3.Text = dataRow["OZELKOD3"].ToString();
            }
        }
    }
}
