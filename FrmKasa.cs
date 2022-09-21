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
    public partial class FrmKasa : Form
    {
        public FrmKasa()
        {
            InitializeComponent();
        }

        private SqlBaglantisi bgl = new SqlBaglantisi();

        void musteriHareket()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter("Execute musteriHareketler",bgl.baglanti());
            adapter.Fill(dt);
            gridControl1.DataSource = dt;
        }

        void firmaHareket()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter("Execute FirmaHareketler", bgl.baglanti());
            adapter.Fill(dt);
            gridControl3.DataSource = dt;
        }

        private void FrmKasa_Load(object sender, EventArgs e)
        {
            musteriHareket();
            firmaHareket();

            //Toplam Tutar Hesaplama
            SqlCommand cmd = new SqlCommand("Select Sum(TUTAR) From TBL_FATURADETAY", bgl.baglanti());
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                lblKasaToplam.Text = dr[0].ToString() + " ₺";
            }
            bgl.baglanti().Close();

            //Son Ay Faturalar
            SqlCommand cmd2 =
                new SqlCommand(
                    "Select (ELEKTRIK + SU + DOGALGAZ + INTERNET + EKSTRA) From TBL_GIDERLER order by ID asc",
                    bgl.baglanti());
            SqlDataReader dr2 = cmd2.ExecuteReader();
            while (dr2.Read())
            {
                lblOdemeler.Text = dr2[0].ToString() + " ₺"; 
            }
            bgl.baglanti().Close();

            //Son Ay Personel Maaslari
            SqlCommand cmd3 = new SqlCommand("Select MAASLAR From TBL_GIDERLER",bgl.baglanti());
            SqlDataReader dr3 = cmd3.ExecuteReader();
            while (dr3.Read())
            {
                lblPersonelMaaslari.Text = dr3[0].ToString() + " ₺";
            }
            bgl.baglanti().Close();

            //Toplam Musteri Sayisi
            SqlCommand cmd4 = new SqlCommand("Select Count(*) From TBL_MUSTERILER", bgl.baglanti());
            SqlDataReader dr4 = cmd4.ExecuteReader();
            while (dr4.Read())
            {
                lblMusteriSayisi.Text = dr4[0].ToString();
            }
            bgl.baglanti().Close();

            //Toplam Firma Sayisi
            SqlCommand cmd5 = new SqlCommand("Select Count(*) From TBL_FIRMALAR", bgl.baglanti());
            SqlDataReader dr5 = cmd5.ExecuteReader();
            while (dr5.Read())
            {
                lblFirmaSayisi.Text = dr5[0].ToString();
            }
            bgl.baglanti().Close();

            //Toplam Firma Sehir Sayisi
            SqlCommand cmd6 = new SqlCommand("Select Count(Distinct(IL)) From TBL_FIRMALAR", bgl.baglanti());
            SqlDataReader dr6 = cmd6.ExecuteReader();
            while (dr6.Read())
            {
                lblFirmaSehirSayisi.Text = dr6[0].ToString();
            }
            bgl.baglanti().Close();

            //Toplam Musteri Sehir Sayisi
            SqlCommand cmd7 = new SqlCommand("Select Count(Distinct(IL)) From TBL_MUSTERILER", bgl.baglanti());
            SqlDataReader dr7 = cmd7.ExecuteReader();
            while (dr7.Read())
            {
                lblMusteriSehirSayisi.Text = dr7[0].ToString();
            }
            bgl.baglanti().Close();

            //Toplam Personel Sayisi
            SqlCommand cmd8 = new SqlCommand("Select Count(*) From TBL_PERSONELLER", bgl.baglanti());
            SqlDataReader dr8 = cmd8.ExecuteReader();
            while (dr8.Read())
            {
                lblPersonelSayisi.Text = dr8[0].ToString();
            }
            bgl.baglanti().Close();

            //Toplam Urun Sayisi
            SqlCommand cmd9 = new SqlCommand("Select Sum(ADET) From TBL_URUNLER", bgl.baglanti());
            SqlDataReader dr9 = cmd9.ExecuteReader();
            while (dr9.Read())
            {
                lblStokSayisi.Text = dr9[0].ToString();
            }
            bgl.baglanti().Close();

            //Maaslar
            groupControl10.Text = "MAAŞLAR";
            SqlCommand cmd11 = new SqlCommand("Select top 4 AY, MAASLAR From TBL_GIDERLER order by ID Desc", bgl.baglanti());
            SqlDataReader dr11 = cmd11.ExecuteReader();
            while (dr11.Read())
            {
                chartControl2.Series["AYLAR"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr11[0], dr11[1]));
            }
            bgl.baglanti().Close();


        }

        private int sayac = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            sayac++;
            //Elektrik
            if (sayac>0 && sayac <= 5)
            {
                chartControl1.Series["AYLAR"].Points.Clear();
                groupControl9.Text = "ELEKTRİK";
                SqlCommand cmd10 = new SqlCommand("Select top 4 AY, ELEKTRIK From TBL_GIDERLER order by ID Desc", bgl.baglanti());
                SqlDataReader dr10 = cmd10.ExecuteReader();
                while (dr10.Read())
                {
                    chartControl1.Series["AYLAR"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr10[0], dr10[1]));
                }
                bgl.baglanti().Close();
            }
            //Su
            if (sayac > 5 && sayac <= 10)
            {
                groupControl9.Text = "SU";
                chartControl1.Series["AYLAR"].Points.Clear();
                SqlCommand cmd11 = new SqlCommand("Select top 4 AY, SU From TBL_GIDERLER order by ID Desc", bgl.baglanti());
                SqlDataReader dr11 = cmd11.ExecuteReader();
                while (dr11.Read())
                {
                    chartControl1.Series["AYLAR"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr11[0], dr11[1]));
                }
                bgl.baglanti().Close();
            }
            //Dogalgaz
            if (sayac > 10 && sayac <= 15)
            {
                groupControl9.Text = "DOĞALGAZ";
                chartControl1.Series["AYLAR"].Points.Clear();
                SqlCommand cmd11 = new SqlCommand("Select top 4 AY, DOGALGAZ From TBL_GIDERLER order by ID Desc", bgl.baglanti());
                SqlDataReader dr11 = cmd11.ExecuteReader();
                while (dr11.Read())
                {
                    chartControl1.Series["AYLAR"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr11[0], dr11[1]));
                }
                bgl.baglanti().Close();
            }
            //Internet
            if (sayac > 15 && sayac <= 20)
            {
                groupControl9.Text = "İNTERNET";
                chartControl1.Series["AYLAR"].Points.Clear();
                SqlCommand cmd11 = new SqlCommand("Select top 4 AY, INTERNET From TBL_GIDERLER order by ID Desc", bgl.baglanti());
                SqlDataReader dr11 = cmd11.ExecuteReader();
                while (dr11.Read())
                {
                    chartControl1.Series["AYLAR"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr11[0], dr11[1]));
                }
                bgl.baglanti().Close();
            }
            //Ekstra
            if (sayac > 20 && sayac <= 25)
            {
                groupControl9.Text = "EKSTRA";
                chartControl1.Series["AYLAR"].Points.Clear();
                SqlCommand cmd11 = new SqlCommand("Select top 4 AY, EKSTRA From TBL_GIDERLER order by ID Desc", bgl.baglanti());
                SqlDataReader dr11 = cmd11.ExecuteReader();
                while (dr11.Read())
                {
                    chartControl1.Series["AYLAR"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr11[0], dr11[1]));
                }
                bgl.baglanti().Close();
            }

            if (sayac == 26)
            {
                sayac = 0;
            }
        }
    }
}
