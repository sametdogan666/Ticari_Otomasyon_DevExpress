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
using System.Xml;

namespace Ticari_Otomasyon
{
    public partial class FrmAnaSayfa : Form
    {
        public FrmAnaSayfa()
        {
            InitializeComponent();
        }

        private SqlBaglantisi bgl = new SqlBaglantisi();

        void Stoklar()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter("Select URUNAD, Sum(ADET) as 'ADET' From TBL_URUNLER group by URUNAD having Sum(ADET)<=20 order by Sum(ADET)",bgl.baglanti());
            adapter.Fill(dt);
            gridControlStoklar.DataSource = dt;
        }

        void Ajanda()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter adapter =
                new SqlDataAdapter("Select Top 8 TARIH,SAAT,BASLIK From TBL_NOTLAR Order By ID desc", bgl.baglanti());
            adapter.Fill(dt);
            gridControlAjanda.DataSource = dt;
        }

        void FirmaHareketleri()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter adapter =
                new SqlDataAdapter("Exec FirmaHareketlerAnaSayfa", bgl.baglanti());
            adapter.Fill(dt);
            gridControlHareketler.DataSource = dt;
        }

        void Fihrist()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter("Select AD,TELEFON From TBL_FIRMALAR", bgl.baglanti());
            adapter.Fill(dt);
            gridControlFihrist.DataSource = dt;
        }

        void Haberler()
        {
            XmlTextReader xmlTextReader = new XmlTextReader("https://www.hurriyet.com.tr/rss/anasayfa");
            while (xmlTextReader.Read())
            {
                if (xmlTextReader.Name=="title")
                {
                    listBox1.Items.Add(xmlTextReader.ReadString());
                }
            }
        }

        private void FrmAnaSayfa_Load(object sender, EventArgs e)
        {
            Stoklar();
            Ajanda();
            FirmaHareketleri();
            Fihrist();
            webBrowser1.Navigate("https://www.tcmb.gov.tr/kurlar/today.xml");
            Haberler();
        }
    }
}
