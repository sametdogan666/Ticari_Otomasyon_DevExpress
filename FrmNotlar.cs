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
    public partial class FrmNotlar : Form
    {
        public FrmNotlar()
        {
            InitializeComponent();
        }

        SqlBaglantisi bgl = new SqlBaglantisi();

        void Listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter("Select * From TBL_NOTLAR", bgl.baglanti());
            adapter.Fill(dt);
            gridControl1.DataSource = dt;
        }

        void Temizle()
        {
            TxtId.Text = "";
            MskTarih.Text = "";
            mskSaat.Text = "";
            txtBaslik.Text = "";
            rchDetay.Text = "";
            txtOlusturan.Text = "";
            txtHitap.Text = "";
        }

        private void FrmNotlar_Load(object sender, EventArgs e)
        {
            Listele();
            Temizle();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Insert Into TBL_NOTLAR (TARIH, SAAT, BASLIK, DETAY, OLUSTURAN, HITAP) values (@p1, @p2, @p3, @p4, @p5, @p6)", bgl.baglanti());
            cmd.Parameters.AddWithValue("@p1", MskTarih.Text);
            cmd.Parameters.AddWithValue("@p2", mskSaat.Text);
            cmd.Parameters.AddWithValue("@p3", txtBaslik.Text);
            cmd.Parameters.AddWithValue("@p4", rchDetay.Text);
            cmd.Parameters.AddWithValue("@p5", txtOlusturan.Text);
            cmd.Parameters.AddWithValue("@p6", txtHitap.Text);
            cmd.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Not bilgisi sisteme eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Listele();
            Temizle();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);

            if (dr != null)
            {
                TxtId.Text = dr["ID"].ToString();
                MskTarih.Text = dr["TARIH"].ToString();
                mskSaat.Text = dr["SAAT"].ToString();
                txtBaslik.Text = dr["BASLIK"].ToString();
                rchDetay.Text = dr["DETAY"].ToString();
                txtOlusturan.Text = dr["OLUSTURAN"].ToString();
                txtHitap.Text = dr["HITAP"].ToString();
            }
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Delete From TBL_NOTLAR Where ID=@p1", bgl.baglanti());
            cmd.Parameters.AddWithValue("@p1", TxtId.Text);
            cmd.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Not bilgisi sistemden silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            Listele();
            Temizle();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Update TBL_NOTLAR set TARIH=@p1, SAAT=@p2, BASLIK=@p3, DETAY=@p4, OLUSTURAN=@p5, HITAP=@p6 where ID=@p7", bgl.baglanti());
            cmd.Parameters.AddWithValue("@p1", MskTarih.Text);
            cmd.Parameters.AddWithValue("@p2", mskSaat.Text);
            cmd.Parameters.AddWithValue("@p3", txtBaslik.Text);
            cmd.Parameters.AddWithValue("@p4", rchDetay.Text);
            cmd.Parameters.AddWithValue("@p5", txtOlusturan.Text);
            cmd.Parameters.AddWithValue("@p6", txtHitap.Text);
            cmd.Parameters.AddWithValue("@p7", TxtId.Text);
            cmd.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Not bilgisi güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            Listele();
            Temizle();
        }

        private void gridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                FrmNotDetay frmNotDetay = new FrmNotDetay();
                DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);

                if (dr != null)
                {
                    frmNotDetay.metin = dr["DETAY"].ToString();
                }
                frmNotDetay.Show();
            }
        }
    }
}
