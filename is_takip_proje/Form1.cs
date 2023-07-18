using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace is_takip_proje
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void BtnDepartmanListesi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //Formlar arası geçiş kodu
            Formlar.FrmDepartmanlar frm = new Formlar.FrmDepartmanlar();
            frm.MdiParent = this; //yeni oluşturduğumuz form mdi üzerinde açıldın diye
            frm.Show();
        }

        private void BtnPersonelListesi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.FrmPersoneller frm2 = new Formlar.FrmPersoneller();
            frm2.MdiParent = this;
            frm2.Show();
        }

        private void barButtonItem8_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) //btnPersonelİstatistik
        {
            Formlar.FrmPersonelİstatistik frm3 = new Formlar.FrmPersonelİstatistik();
            frm3.MdiParent = this;
            frm3.Show();
        }

        Formlar.FrmGorevListesi frm4;
        private void BtnGorevListesi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frm4 == null || frm4.IsDisposed) //formu kapatma ve kapanan formu tekrar açma
            {
                frm4 = new Formlar.FrmGorevListesi();
                frm4.MdiParent = this;
                frm4.Show();
            }

        }

        private void BtnGorevTanimla_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.FrmGorev fr = new Formlar.FrmGorev();
            fr.Show();
        }

        private void BtnGorevDetay_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.FrmGorevDetay fr = new Formlar.FrmGorevDetay();
            fr.Show();
        }
        Formlar.FrmAnaForm frm5;
        private void BtnAnaForm_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frm5 == null || frm5.IsDisposed) //formu kapatma ve kapanan formu tekrar açma
            {
                frm5 = new Formlar.FrmAnaForm();
                frm5.MdiParent = this;
                frm5.Show();
            }
        }
    }
}
