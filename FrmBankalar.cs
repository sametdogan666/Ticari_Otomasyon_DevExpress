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
    public partial class FrmBankalar : Form
    {
        public FrmBankalar()
        {
            InitializeComponent();
        }

        void Listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter("EXECUTE BANKABILGILERI", bgl.baglanti());
            adapter.Fill(dt);
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

        void FirmaListele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter("Select ID, AD From TBL_FIRMALAR", bgl.baglanti());
            adapter.Fill(dt);
            lookUpFirma.Properties.ValueMember = "ID";
            lookUpFirma.Properties.DisplayMember = "AD";
            lookUpFirma.Properties.DataSource = dt;
        }

        void Temizle()
        {
            TxtId.Text = "";
            lookUpFirma.Text = "";
            txtBankaAd.Text = "";
            cmbIl.Text = "";
            cmbIlce.Text = "";
            txtSube.Text = "";
            mskIban.Text = "";
            mskHesapNo.Text = "";
            txtYetkili.Text = "";
            mskTelefon.Text = "";
            mskTarih.Text = "";
            txtHesapTuru.Text = "";
        }

        SqlBaglantisi bgl = new SqlBaglantisi();
        private void FrmBankalar_Load(object sender, EventArgs e)
        {
            Listele();
            SehirListele();
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

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Insert Into TBL_BANKALAR (FIRMAID, BANKAADI, IL, ILCE, SUBE, IBAN, HESAPNO, YETKILI, TELEFON, TARIH, HESAPTURU) values (@p1, @p2, @p3, @p4, @p5, @p6, @p7, @p8, @p9, @p10, @p11)", bgl.baglanti());
            cmd.Parameters.AddWithValue("@p1", lookUpFirma.EditValue);
            cmd.Parameters.AddWithValue("@p2", txtBankaAd.Text);
            cmd.Parameters.AddWithValue("@p3", cmbIl.Text);
            cmd.Parameters.AddWithValue("@p4", cmbIlce.Text);
            cmd.Parameters.AddWithValue("@p5", txtSube.Text);
            cmd.Parameters.AddWithValue("@p6", mskIban.Text);
            cmd.Parameters.AddWithValue("@p7", mskHesapNo.Text);
            cmd.Parameters.AddWithValue("@p8", txtYetkili.Text);
            cmd.Parameters.AddWithValue("@p9", mskTelefon.Text);
            cmd.Parameters.AddWithValue("@p10", mskTarih.Text);
            cmd.Parameters.AddWithValue("@p11", txtHesapTuru.Text);
            cmd.ExecuteNonQuery();

            bgl.baglanti().Close();
            MessageBox.Show("Banka bilgisi sisteme eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Listele();
            Temizle();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            DataRow dataRow = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dataRow != null)
            {
                TxtId.Text = dataRow["ID"].ToString();
                //TxtId.Text = dataRow["FIRMAID"].ToString();
                txtBankaAd.Text = dataRow["BANKAADI"].ToString();
                cmbIl.Text = dataRow["IL"].ToString();
                cmbIlce.Text = dataRow["ILCE"].ToString();
                txtSube.Text = dataRow["SUBE"].ToString();
                mskIban.Text = dataRow["IBAN"].ToString();
                mskHesapNo.Text = dataRow["HESAPNO"].ToString();
                txtYetkili.Text = dataRow["YETKILI"].ToString();
                mskTelefon.Text = dataRow["TELEFON"].ToString();
                mskTarih.Text = dataRow["TARIH"].ToString();
                txtHesapTuru.Text = dataRow["HESAPTURU"].ToString();
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Delete From TBL_BANKALAR where ID=@p1", bgl.baglanti());
            cmd.Parameters.AddWithValue("@p1", TxtId.Text);
            cmd.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Banka bilgisi sistemden silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            Temizle();
            Listele();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand cmd =
                new SqlCommand(
                    "Update TBL_BANKALAR set FIRMAID=@p1, BANKAADI=@p2, IL=@p3, ILCE=@p4, SUBE=@p5, IBAN=@p6, HESAPNO=@p7, YETKILI=@p8, TELEFON=@p9, TARIH=@p10, HESAPTURU=@p11 Where ID=@p12",
                    bgl.baglanti());
            cmd.Parameters.AddWithValue("@p1", lookUpFirma.EditValue);
            cmd.Parameters.AddWithValue("@p2", txtBankaAd.Text);
            cmd.Parameters.AddWithValue("@p3", cmbIl.Text);
            cmd.Parameters.AddWithValue("@p4", cmbIlce.Text);
            cmd.Parameters.AddWithValue("@p5", txtSube.Text);
            cmd.Parameters.AddWithValue("@p6", mskIban.Text);
            cmd.Parameters.AddWithValue("@p7", mskHesapNo.Text);
            cmd.Parameters.AddWithValue("@p8", txtYetkili.Text);
            cmd.Parameters.AddWithValue("@p9", mskTelefon.Text);
            cmd.Parameters.AddWithValue("@p10", mskTarih.Text);
            cmd.Parameters.AddWithValue("@p11", txtHesapTuru.Text);
            cmd.Parameters.AddWithValue("@p12", TxtId.Text);
            cmd.ExecuteNonQuery();

            bgl.baglanti().Close();
            MessageBox.Show("Banka bilgisi güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            Listele();
            Temizle();
        }
    }
}
