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
    public partial class FrmFaturaDetaylari : Form
    {
        public FrmFaturaDetaylari()
        {
            InitializeComponent();
        }

        public string id;
        private SqlBaglantisi bgl = new SqlBaglantisi();

        void Listele()
        {
            SqlDataAdapter adapter = new SqlDataAdapter("Select * from TBL_FATURADETAY where FATURAID='" + id + "'", bgl.baglanti());
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            gridControl1.DataSource = dt;
        }
        private void FrmFaturaDetaylari_Load(object sender, EventArgs e)
        {
            Listele();
        }

        private void gridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                FrmFaturaDetayDuzenleme faturaDetayDuzenleme = new FrmFaturaDetayDuzenleme();
                DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
                if (dr != null)
                {
                    faturaDetayDuzenleme.urunId = dr["ID"].ToString();
                }
                faturaDetayDuzenleme.Show();
            }
        }
    }
}
