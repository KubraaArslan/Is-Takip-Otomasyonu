using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using is_takip_proje.Entity;

namespace is_takip_proje.Formlar
{
    public partial class FrmPersoneller : Form
    {
        public FrmPersoneller()
        {
            InitializeComponent();
        }
        İsTakipEntities db = new İsTakipEntities();
        void personeller()
        {
            var degerler = from x in db.Tbl_Personel
                           select new
                           {
                               x.ID,
                               x.Ad,
                               x.Soyad,
                               x.Mail,
                               Departman=x.Tbl_Departmanlar.Ad,
                               x.Durum

                           };
            gridControl1.DataSource = degerler.Where(x => x.Durum == true).ToList();
        }
    

        private void FrmPersoneller_Load(object sender, EventArgs e)
        {
            personeller();

            var departmanlar = (from x in db.Tbl_Departmanlar //yanındaki systemli durumlar gelmedi
                                select new
                               { x.ID,
                                 x.Ad

                               }).ToList();
            lookUpEdit1.Properties.ValueMember = "ID";// seçim aracımızın arkadsında çalışacak değerler
            lookUpEdit1.Properties.DisplayMember = "Ad";// görünecek olan 
            lookUpEdit1.Properties.DataSource = departmanlar;
        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            personeller();
        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            Tbl_Personel t = new Tbl_Personel();
            t.Ad = TxtAd.Text;
            t.Soyad = TxtSoyad.Text;
            t.Mail = TxtMail.Text;
            t.Gorsel = TxtGörsel.Text;
            t.Departman = int.Parse(lookUpEdit1.EditValue.ToString());
            db.Tbl_Personel.Add(t);//atamalardan sonra tablonun içine dahil etme
            db.SaveChanges();

            XtraMessageBox.Show("Yeni personel kaydı başarılı bir şekilde gerçekleşti.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            personeller();


        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            var x = int.Parse(TxtID.Text);
            var deger = db.Tbl_Personel.Find(x);
            deger.Durum = false;
            db.SaveChanges();
            XtraMessageBox.Show("Personel başarılı bir şekilde silindi,silinen personeller listesinden tüm silinmiş personel bilgilerine ulaşabilirsiniz.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
      
            personeller();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            TxtID.Text = gridView1.GetFocusedRowCellValue("ID").ToString();
            TxtAd.Text = gridView1.GetFocusedRowCellValue("Ad").ToString();
            TxtSoyad.Text = gridView1.GetFocusedRowCellValue("Soyad").ToString();
            TxtMail.Text = gridView1.GetFocusedRowCellValue("Mail").ToString();
           //TxtGorsel.Text = gridView1.GetFocusedRowCellValue("Gorsel").ToString();
            lookUpEdit1.Text= gridView1.GetFocusedRowCellValue("Departman").ToString();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            int x = int.Parse(TxtID.Text);
            var deger = db.Tbl_Personel.Find(x);
            deger.Ad = TxtAd.Text;
            deger.Soyad = TxtSoyad.Text;
            deger.Mail = TxtMail.Text;
            deger.Gorsel = TxtGorsel.Text;
            deger.Departman = int.Parse(lookUpEdit1.EditValue.ToString());
            db.SaveChanges();
            XtraMessageBox.Show("Personel başarılı bir şekilde güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            personeller();
        }

        private void labelControl1_Click(object sender, EventArgs e)
        {

        }
    }
}
