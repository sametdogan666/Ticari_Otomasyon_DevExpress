using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ticari_Otomasyon
{
    public partial class FrmGiderler : Form
    {
        public FrmGiderler()
        {
            InitializeComponent();
        }

        private SqlBaglantisi bgl = new SqlBaglantisi();

        void Listele()
        {
            SqlDataAdapter dataAdapter = new SqlDataAdapter("Select * From TBL_GIDERLER", bgl.baglanti());
            DataTable dt = new DataTable();
            dataAdapter.Fill(dt);
            gridControl1.DataSource = dt;
        }

        void Temizle()
        {
            TxtId.Text = "";
            cmbAy.Text = "";
            cmbYil.Text = "";
            txtElektrik.Text = "";
            txtSu.Text = "";
            txtDogalgaz.Text = "";
            txtInternet.Text = "";
            txtMaaslar.Text = "";
            txtEkstra.Text = "";
            rchNotlar.Text = "";
        }

        private void FrmGiderler_Load(object sender, EventArgs e)
        {
            Listele();
            Temizle();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Insert Into TBL_GIDERLER (AY, YIL, ELEKTRIK, SU, DOGALGAZ, INTERNET, MAASLAR, EKSTRA, NOTLAR) values (@p1, @p2, @p3, @p4, @p5, @p6, @p7, @p8, @p9)", bgl.baglanti());
            cmd.Parameters.AddWithValue("@p1", cmbAy.Text);
            cmd.Parameters.AddWithValue("@p2", cmbYil.Text);
            cmd.Parameters.AddWithValue("@p3", decimal.Parse(txtElektrik.Text));
            cmd.Parameters.AddWithValue("@p4", decimal.Parse(txtSu.Text));
            cmd.Parameters.AddWithValue("@p5", decimal.Parse(txtDogalgaz.Text));
            cmd.Parameters.AddWithValue("@p6", decimal.Parse(txtInternet.Text));
            cmd.Parameters.AddWithValue("@p7", decimal.Parse(txtMaaslar.Text));
            cmd.Parameters.AddWithValue("@p8", decimal.Parse(txtEkstra.Text));
            cmd.Parameters.AddWithValue("@p9", rchNotlar.Text);
            cmd.ExecuteNonQuery();

            bgl.baglanti().Close();

            MessageBox.Show("Gider tabloya eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Listele();
            Temizle();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            DataRow dataRow = gridView1.GetDataRow(gridView1.FocusedRowHandle);

            if (dataRow != null)
            {
                TxtId.Text = dataRow["ID"].ToString();
                cmbAy.Text = dataRow["AY"].ToString();
                cmbYil.Text = dataRow["YIL"].ToString();
                txtElektrik.Text = dataRow["ELEKTRIK"].ToString();
                txtSu.Text = dataRow["SU"].ToString();
                txtDogalgaz.Text = dataRow["DOGALGAZ"].ToString();
                txtInternet.Text = dataRow["INTERNET"].ToString();
                txtMaaslar.Text = dataRow["MAASLAR"].ToString();
                txtEkstra.Text = dataRow["EKSTRA"].ToString();
                rchNotlar.Text = dataRow["NOTLAR"].ToString();
            }
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Delete From TBL_GIDERLER where ID=@p1",bgl.baglanti());
            cmd.Parameters.AddWithValue("@p1", TxtId.Text);
            cmd.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Gider listeden silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            Listele();
            Temizle();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand cmd =
                new SqlCommand(
                    "Update TBL_GIDERLER set AY=@p1, YIL=@p2, ELEKTRIK=@p3, SU=@p4, DOGALGAZ=@p5, INTERNET=@p6, MAASLAR=@p7, EKSTRA=@p8, NOTLAR=@p9 where ID=@p10",
                    bgl.baglanti());
            
            cmd.Parameters.AddWithValue("@p1", cmbAy.Text);
            cmd.Parameters.AddWithValue("@p2", cmbYil.Text);
            cmd.Parameters.AddWithValue("@p3", decimal.Parse(txtElektrik.Text));
            cmd.Parameters.AddWithValue("@p4", decimal.Parse(txtSu.Text));
            cmd.Parameters.AddWithValue("@p5", decimal.Parse(txtDogalgaz.Text));
            cmd.Parameters.AddWithValue("@p6", decimal.Parse(txtInternet.Text));
            cmd.Parameters.AddWithValue("@p7", decimal.Parse(txtMaaslar.Text));
            cmd.Parameters.AddWithValue("@p8", decimal.Parse(txtEkstra.Text));
            cmd.Parameters.AddWithValue("@p9", rchNotlar.Text);
            cmd.Parameters.AddWithValue("@p10", TxtId.Text);
            cmd.ExecuteNonQuery();

            bgl.baglanti().Close();

            MessageBox.Show("Gider bilgisi güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            Listele();
            Temizle();
        }
    }
}
