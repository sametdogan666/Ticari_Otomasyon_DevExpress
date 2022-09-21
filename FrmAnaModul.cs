using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ticari_Otomasyon
{
    public partial class FrmAnaModul : Form
    {
        public FrmAnaModul()
        {
            InitializeComponent();
        }

        private FrmUrunler _frmUrunler;
        private void btnUrunler_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (_frmUrunler == null)
            {
                _frmUrunler = new FrmUrunler();
                _frmUrunler.MdiParent = this;
                _frmUrunler.Show();
            }

        }

        private FrmMusteriler _frmMusteriler;
        private void btnMusteriler_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            if (_frmMusteriler == null)
            {
                _frmMusteriler = new FrmMusteriler();
                _frmMusteriler.MdiParent = this;
                _frmMusteriler.Show();
            }
        }

        private FrmFirmalar _frmFirmalar;
        private void btnFirmalar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (_frmFirmalar == null)
            {
                _frmFirmalar = new FrmFirmalar();
                _frmFirmalar.MdiParent = this;
                _frmFirmalar.Show();
            }
        }

        private FrmPersoneller _frmPersoneller;
        private void btnPersoneller_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (_frmPersoneller == null)
            {
                _frmPersoneller = new FrmPersoneller();
                _frmPersoneller.MdiParent = this;
                _frmPersoneller.Show();
            }
        }

        private FrmRehber _frmRehber;
        private void btnRehber_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (_frmRehber == null)
            {
                _frmRehber = new FrmRehber();
                _frmRehber.MdiParent = this;
                _frmRehber.Show();
            }
        }

        private FrmGiderler _frmGiderler;
        private void btnGiderler_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (_frmGiderler == null)
            {
                _frmGiderler = new FrmGiderler();
                _frmGiderler.MdiParent = this;
                _frmGiderler.Show();
            }
        }

        private FrmBankalar _frmBankalar;
        private void btnBankalar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (_frmBankalar == null)
            {
                _frmBankalar = new FrmBankalar();
                _frmBankalar.MdiParent = this;
                _frmBankalar.Show();
            }
        }

        private FrmFaturalar _frmFaturalar;
        private void btnFaturalar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (_frmFaturalar == null)
            {
                _frmFaturalar = new FrmFaturalar();
                _frmFaturalar.MdiParent = this;
                _frmFaturalar.Show();
            }
        }

        private FrmNotlar _frmNotlar;
        private void btnNotlar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (_frmNotlar == null)
            {
                _frmNotlar = new FrmNotlar();
                _frmNotlar.MdiParent = this;
                _frmNotlar.Show();
            }
        }

        private FrmHareketler _frmHareketler;
        private void btnHareketler_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (_frmHareketler == null)
            {
                _frmHareketler = new FrmHareketler();
                _frmHareketler.MdiParent = this;
                _frmHareketler.Show();
            }
        }

        private FrmRaporlar _frmRaporlar;
        private void btnRaporlar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (_frmRaporlar == null)
            {
                _frmRaporlar = new FrmRaporlar();
                _frmRaporlar.MdiParent = this;
                _frmRaporlar.Show();
            }
        }

        private FrmStoklar _frmStoklar;
        private void btnStoklar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (_frmStoklar == null)
            {
                _frmStoklar = new FrmStoklar();
                _frmStoklar.MdiParent = this;
                _frmStoklar.Show();
            }
        }

        private FrmAyarlar _frmAyarlar;
        private void btnAyarlar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (_frmAyarlar == null)
            {
                _frmAyarlar = new FrmAyarlar();
                _frmAyarlar.Show();
            }
        }

        private FrmKasa _frmKasa;
        private void btnKasa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (_frmKasa == null)
            {
                _frmKasa = new FrmKasa();
                _frmKasa.MdiParent = this;
                _frmKasa.Show();
            }
        }

        private FrmAnaSayfa _frmAnaSayfa;
        private void btnAnaSayfa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (_frmAnaSayfa == null)
            {
                _frmAnaSayfa = new FrmAnaSayfa();
                _frmAnaSayfa.MdiParent = this;
                _frmAnaSayfa.Show();
            }
        }

        private void FrmAnaModul_Load(object sender, EventArgs e)
        {
            if (_frmAnaSayfa == null)
            {
                _frmAnaSayfa = new FrmAnaSayfa();
                _frmAnaSayfa.MdiParent = this;
                _frmAnaSayfa.Show();
            }
        }
    }
}
