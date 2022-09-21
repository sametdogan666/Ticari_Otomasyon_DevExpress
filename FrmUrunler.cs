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
    public partial class FrmUrunler : Form
    {
        public FrmUrunler()
        {
            InitializeComponent();
        }

        SqlBaglantisi bgl = new SqlBaglantisi();

        void Listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter("Select * From TBL_URUNLER", bgl.baglanti());
            adapter.Fill(dt);
            gridControl1.DataSource = dt;
        }

        void Temizle()
        {
            TxtId.Text = "";
            txtAd.Text = "";
            txtMarka.Text = "";
            txtModel.Text = "";
            mskYil.Text = "";
            nudAdet.Value = 0;
            txtAlis.Text = "";
            txtSatis.Text = "";
            rchDetay.Text = "";
        }
        private void FrmUrunler_Load(object sender, EventArgs e)
        {
            Listele();
            Temizle();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            //Verileri Eklmeme
            SqlCommand cmd = new SqlCommand("Insert Into TBL_URUNLER (URUNAD,MARKA,MODEL,YIL,ADET,ALISFIYAT,SATISFIYAT,DETAY) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8)", bgl.baglanti());
            cmd.Parameters.AddWithValue("@p1", txtAd.Text);
            cmd.Parameters.AddWithValue("@p2", txtMarka.Text);
            cmd.Parameters.AddWithValue("@p3", txtModel.Text);
            cmd.Parameters.AddWithValue("@p4", mskYil.Text);
            cmd.Parameters.AddWithValue("@p5", int.Parse((nudAdet.Value).ToString()));
            cmd.Parameters.AddWithValue("@p6", decimal.Parse(txtAlis.Text));
            cmd.Parameters.AddWithValue("@p7", decimal.Parse(txtSatis.Text));
            cmd.Parameters.AddWithValue("@p8", rchDetay.Text);
            cmd.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Ürün sisteme eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Listele();
            Temizle();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Delete From TBL_URUNLER where ID=@p1", bgl.baglanti());
            cmd.Parameters.AddWithValue("@p1", TxtId.Text);
            cmd.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Ürün silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            Listele();
            Temizle();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Update TBL_URUNLER set URUNAD=@p1,MARKA=@p2,MODEL=@p3,YIL=@p4,ADET=@p5,ALISFIYAT=@p6,SATISFIYAT=@p7,DETAY=@p8 where ID=@p9",bgl.baglanti());
            cmd.Parameters.AddWithValue("@p1", txtAd.Text);
            cmd.Parameters.AddWithValue("@p2", txtMarka.Text);
            cmd.Parameters.AddWithValue("@p3", txtModel.Text);
            cmd.Parameters.AddWithValue("@p4", mskYil.Text);
            cmd.Parameters.AddWithValue("@p5", int.Parse((nudAdet.Value).ToString()));
            cmd.Parameters.AddWithValue("@p6", decimal.Parse(txtAlis.Text));
            cmd.Parameters.AddWithValue("@p7", decimal.Parse(txtSatis.Text));
            cmd.Parameters.AddWithValue("@p8", rchDetay.Text);
            cmd.Parameters.AddWithValue("@p9", TxtId.Text);
            cmd.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Ürün bilgisi güncellendi","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            Listele();
            Temizle();
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            DataRow dataRow = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            TxtId.Text = dataRow["ID"].ToString();
            txtAd.Text = dataRow["URUNAD"].ToString();
            txtMarka.Text = dataRow["MARKA"].ToString();
            txtModel.Text = dataRow["MODEL"].ToString();
            mskYil.Text = dataRow["YIL"].ToString();
            nudAdet.Value = int.Parse(dataRow["ADET"].ToString());
            txtAlis.Text = dataRow["ALISFIYAT"].ToString();
            txtSatis.Text = dataRow["SATISFIYAT"].ToString();
            rchDetay.Text = dataRow["DETAY"].ToString();
        }
    }
}
