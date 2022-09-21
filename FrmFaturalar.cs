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
    public partial class FrmFaturalar : Form
    {
        public FrmFaturalar()
        {
            InitializeComponent();
        }

        private SqlBaglantisi bgl = new SqlBaglantisi();

        void Listele()
        {
            SqlDataAdapter adapter = new SqlDataAdapter("Select * From TBL_FATURABILGI", bgl.baglanti());
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            gridControl1.DataSource = dt;

        }

        void Temizle()
        {
            TxtId.Text = "";
            txtSeri.Text = "";
            txtSiraNo.Text = "";
            mskTarih.Text = "";
            mskSaat.Text = "";
            txtVergiDaire.Text = "";
            txtAlici.Text = "";
            txtTeslimEden.Text = "";
            txtTeslimAlan.Text = "";
        }

        void DetayTemizle()
        {
            txtUrunId.Text = "";
            txtUrunAdi.Text = "";
            txtMiktar.Text = "";
            txtFiyat.Text = "";
            txtTutar.Text = "";
            txtFaturaId.Text = "";
            txtPersonel.Text = "";
            txtFirma.Text = "";
        }

        private void FrmFaturalar_Load(object sender, EventArgs e)
        {
            Listele();
            Temizle();
        }



        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            DataRow dataRow = gridView1.GetDataRow(gridView1.FocusedRowHandle);

            if (dataRow != null)
            {
                TxtId.Text = dataRow["ID"].ToString();
                txtSeri.Text = dataRow["SERI"].ToString();
                txtSiraNo.Text = dataRow["SIRANO"].ToString();
                mskTarih.Text = dataRow["TARIH"].ToString();
                mskSaat.Text = dataRow["SAAT"].ToString();
                txtVergiDaire.Text = dataRow["VERGIDAIRE"].ToString();
                txtAlici.Text = dataRow["ALICI"].ToString();
                txtTeslimEden.Text = dataRow["TESLIMEDEN"].ToString();
                txtTeslimAlan.Text = dataRow["TESLIMALAN"].ToString();
            }
        }



        private void btnEkle_Click(object sender, EventArgs e)
        {

            SqlCommand cmd =
                new SqlCommand(
                    "Insert Into TBL_FATURABILGI (SERI, SIRANO, TARIH, SAAT, VERGIDAIRE, ALICI, TESLIMEDEN, TESLIMALAN) values (@p1, @p2, @p3, @p4, @p5, @p6, @p7, @p8)",
                    bgl.baglanti());
            cmd.Parameters.AddWithValue("@p1", txtSeri.Text);
            cmd.Parameters.AddWithValue("@p2", txtSiraNo.Text);
            cmd.Parameters.AddWithValue("@p3", mskTarih.Text);
            cmd.Parameters.AddWithValue("@p4", mskSaat.Text);
            cmd.Parameters.AddWithValue("@p5", txtVergiDaire.Text);
            cmd.Parameters.AddWithValue("@p6", txtAlici.Text);
            cmd.Parameters.AddWithValue("@p7", txtTeslimEden.Text);
            cmd.Parameters.AddWithValue("@p8", txtTeslimAlan.Text);
            cmd.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Fatura bilgisi sisteme kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Listele();
            Temizle();
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }

        private void btnDetayEkle_Click(object sender, EventArgs e)
        {
            double miktar, tutar, fiyat;
            fiyat = Convert.ToDouble(txtFiyat.Text);
            miktar = Convert.ToDouble(txtMiktar.Text);
            tutar = miktar * fiyat;
            txtTutar.Text = tutar.ToString();

            SqlCommand cmd =
                new SqlCommand(
                    "Insert Into TBL_FATURADETAY (URUNAD, MIKTAR, FIYAT, TUTAR, FATURAID) values (@p1, @p2, @p3, @p4, @p5)",
                    bgl.baglanti());
            cmd.Parameters.AddWithValue("@p1", txtUrunAdi.Text);
            cmd.Parameters.AddWithValue("@p2", txtMiktar.Text);
            cmd.Parameters.AddWithValue("@p3", decimal.Parse(txtFiyat.Text));
            cmd.Parameters.AddWithValue("@p4", decimal.Parse(txtTutar.Text));
            cmd.Parameters.AddWithValue("@p5", txtFaturaId.Text);
            cmd.ExecuteNonQuery();

            //Hareket Tablosuna Veri Girişi
            SqlCommand cmd2 =
                new SqlCommand(
                    "Insert Into TBL_FIRMAHAREKETLER (URUNID,ADET,PERSONELID,FIRMAID,FIYAT,TOPLAM,FATURAID,TARIH) values (@h1,@h2,@h3,@h4,@h5,@h6,@h7,@h8)",bgl.baglanti());
            cmd2.Parameters.AddWithValue("@h1",txtUrunId.Text);
            cmd2.Parameters.AddWithValue("@h2",txtMiktar.Text);
            cmd2.Parameters.AddWithValue("@h3",txtPersonel.Text);
            cmd2.Parameters.AddWithValue("@h4",txtFirma.Text);
            cmd2.Parameters.AddWithValue("@h5",decimal.Parse(txtFiyat.Text));
            cmd2.Parameters.AddWithValue("@h6",decimal.Parse(txtTutar.Text));
            cmd2.Parameters.AddWithValue("@h7",txtFaturaId.Text);
            cmd2.Parameters.AddWithValue("@h8",mskTarih.Text);
            cmd2.ExecuteNonQuery();
            bgl.baglanti().Close();

            //Stok Sayısını Azaltma
            SqlCommand cmd3 = new SqlCommand("Update TBL_URUNLER Set ADET=ADET-@s1 Where ID=@s2", bgl.baglanti());
            cmd3.Parameters.AddWithValue("@s1", txtMiktar.Text);
            cmd3.Parameters.AddWithValue("@s2", txtUrunId.Text);
            cmd3.ExecuteNonQuery();
            bgl.baglanti().Close();

            MessageBox.Show("Faturaya ait ürün kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Listele();
            DetayTemizle();
        }

        private void btnDetayTemizle_Click(object sender, EventArgs e)
        {
           DetayTemizle();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Delete From TBL_FATURABILGI where ID=@p1", bgl.baglanti());
            cmd.Parameters.AddWithValue("@p1", TxtId.Text);
            cmd.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Fatura silindi", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            Listele();
            Temizle();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Update TBL_FATURABILGI set SERI=@p1, SIRANO=@p2, TARIH=@p3, SAAT=@p4, VERGIDAIRE=@p5, ALICI=@p6, TESLIMEDEN=@p7, TESLIMALAN=@p8 Where ID=@p9",bgl.baglanti());
            cmd.Parameters.AddWithValue("@p1", txtSeri.Text);
            cmd.Parameters.AddWithValue("@p2", txtSiraNo.Text);
            cmd.Parameters.AddWithValue("@p3", mskTarih.Text);
            cmd.Parameters.AddWithValue("@p4", mskSaat.Text);
            cmd.Parameters.AddWithValue("@p5", txtVergiDaire.Text);
            cmd.Parameters.AddWithValue("@p6", txtAlici.Text);
            cmd.Parameters.AddWithValue("@p7", txtTeslimEden.Text);
            cmd.Parameters.AddWithValue("@p8", txtTeslimAlan.Text);
            cmd.Parameters.AddWithValue("@p9", TxtId.Text);
            cmd.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Fatura bilgisi güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            Listele();
            Temizle();
        }

        private void gridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab )
            {
                FrmFaturaDetaylari faturaDetaylari = new FrmFaturaDetaylari();
                DataRow dataRow = gridView1.GetDataRow(gridView1.FocusedRowHandle);

                if (dataRow != null)
                {
                    faturaDetaylari.id = dataRow["ID"].ToString();
                }
                faturaDetaylari.Show();
            }
        }

        private void btnGetir_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Select URUNAD, SATISFIYAT From TBL_URUNLER Where ID=@p1", bgl.baglanti());
            cmd.Parameters.AddWithValue("@p1", txtUrunId.Text);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                txtUrunAdi.Text = reader[0].ToString();
                txtFiyat.Text = reader[1].ToString();
            }
            bgl.baglanti().Close();
        }
    }
}
