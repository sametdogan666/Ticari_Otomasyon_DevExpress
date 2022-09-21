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
    public partial class FrmStokDetay : Form
    {
        public FrmStokDetay()
        {
            InitializeComponent();
        }

        public string ad;
        private SqlBaglantisi bgl = new SqlBaglantisi();

        private void FrmStokDetay_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter adapter =
                new SqlDataAdapter("Select * From TBL_URUNLER where URUNAD='" + ad +"'", bgl.baglanti());
            adapter.Fill(dt);
            gridControl1.DataSource = dt;
        }
    }
}
