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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        FrmUrunler fr;
        public string kullanici;
        private void BtnUrunler_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr == null)
            {
                fr = new FrmUrunler();
                fr.MdiParent = this;
                fr.Show();
            }
        }
        FrmMusteriler frmusteri;
        private void BtnMusteriler_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frmusteri == null)
            {
                frmusteri = new FrmMusteriler();
                frmusteri.MdiParent = this;
                frmusteri.Show();
            }
        }

        FrmFirmalar frfirma;
        private void BtnFirmalar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frfirma == null)
            {
                frfirma = new FrmFirmalar();
                frfirma.MdiParent = this;
                frfirma.Show();
            }

        }
        FrmPersoneller frpersonel;
        private void BtnPersoneller_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frpersonel == null)
            {
                frpersonel = new FrmPersoneller();
                frpersonel.MdiParent = this;
                frpersonel.Show();
            }
        }
        FrmRehber frrehber;
        private void BtnRehber_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frrehber == null)
            {
                frrehber = new FrmRehber();
                frrehber.MdiParent = this;
                frrehber.Show();
            }
        }
        FrmGiderler frgiderler;
        private void BtnGiderler_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frgiderler == null)
            {
                frgiderler = new FrmGiderler();
                frgiderler.MdiParent = this;
                frgiderler.Show();
            }
        }
        FrmBankalar frbankalar;
        private void BtnBankalar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frbankalar == null)
            {
                frbankalar = new FrmBankalar();
                frbankalar.MdiParent = this;
                frbankalar.Show();
            }
        }
        FrmFaturalar frmfaturalar;
        private void BtnFaturalar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frmfaturalar == null)
            {
                frmfaturalar = new FrmFaturalar();
                frmfaturalar.MdiParent = this;
                frmfaturalar.Show();
            }
        }
        FrmNotlar frmnotlar;
        private void BtnNotlar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frmnotlar == null)
            {
                frmnotlar = new FrmNotlar();
                frmnotlar.MdiParent = this;
                frmnotlar.Show();
            }
        }
        FrmHareketler frmhareketler;
        private void btnHareketle_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frmhareketler == null)
            {
                frmhareketler = new FrmHareketler();
                frmhareketler.MdiParent = this;
                frmhareketler.Show();
            }
        }
        FrnRaporlar frmraporlar;
        private void btnRaporlar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frmraporlar == null)
            {
                frmraporlar = new FrnRaporlar();
                frmraporlar.MdiParent = this;
                frmraporlar.Show();

            }
        }
        FrmStoklar frmstok;
        private void BtnStoklar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frmraporlar == null)
            {
                frmstok = new FrmStoklar();
                frmstok.MdiParent = this;
                frmstok.Show();

            }
        }
        FrmAyarlar frmayarlar;
        private void BtnAyarlar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frmayarlar == null)
            {
                frmayarlar = new FrmAyarlar();
                frmayarlar.Show();
            }
        }
        FrmKasa frmkasa;
        private void BtnKasa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frmkasa == null)
            {
                frmkasa = new FrmKasa();
                frmkasa.ad = kullanici;
                frmkasa.MdiParent=this;
                frmkasa.Show();
            }
        }
        FrmAnaSayfa frmanasayfa;
        private void BtnAnaSayfa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frmanasayfa == null)
            {
                frmanasayfa = new FrmAnaSayfa();
                frmanasayfa.MdiParent = this;
                frmanasayfa.Show();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (frmanasayfa == null)
            {
                frmanasayfa = new FrmAnaSayfa();
                frmanasayfa.MdiParent = this;
                frmanasayfa.Show();
            }
        }
    }
}