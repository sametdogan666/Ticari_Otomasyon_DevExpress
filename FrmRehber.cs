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
    public partial class FrmRehber : Form
    {
        public FrmRehber()
        {
            InitializeComponent();
        }

        private SqlBaglantisi bgl = new SqlBaglantisi();

        private void FrmRehber_Load(object sender, EventArgs e)
        {
            // Musteri Bilgileri
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter("Select AD, SOYAD, TELEFON, TELEFON2, MAIL From TBL_MUSTERILER", bgl.baglanti());
            adapter.Fill(dt);
            gridControl1.DataSource = dt;

            // Firma Bilgileri
            DataTable dt2 = new DataTable();
            SqlDataAdapter adapter2 = new SqlDataAdapter("Select AD, YETKILIADSOYAD, TELEFON, TELEFON2, TELEFON3, MAIL, FAX From TBL_FIRMALAR", bgl.baglanti());
            adapter2.Fill(dt2);
            gridControl2.DataSource = dt2;

        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            FrmMail frmMail = new FrmMail();
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);

            if (dr != null)
            {
                frmMail.Mail = dr["MAIL"].ToString();
            }
            frmMail.Show();
        }

        private void gridView2_DoubleClick(object sender, EventArgs e)
        {
            FrmMail frmMail = new FrmMail();
            DataRow dr = gridView2.GetDataRow(gridView2.FocusedRowHandle);

            if (dr != null)
            {
                frmMail.Mail = dr["MAIL"].ToString();
            }
            frmMail.Show();

        }
    }
}
