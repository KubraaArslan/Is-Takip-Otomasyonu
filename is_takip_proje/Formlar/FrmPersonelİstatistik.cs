using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using is_takip_proje.Entity;

namespace is_takip_proje.Formlar
{
    public partial class FrmPersonelİstatistik : Form
    {
        public FrmPersonelİstatistik()
        {
            InitializeComponent();
        }

        private void labelControl2_Click(object sender, EventArgs e)
        {

        }

        private void labelControl3_Click(object sender, EventArgs e)
        {

        }

        private void labelControl4_Click(object sender, EventArgs e)
        {

        }

        private void labelControl16_Click(object sender, EventArgs e)
        {

        }

        private void labelControl18_Click(object sender, EventArgs e)
        {

        }
        İsTakipEntities db = new İsTakipEntities();
        private void FrmPersonelİstatistik_Load(object sender, EventArgs e)
        {
            LblToplamDepartman.Text = db.Tbl_Departmanlar.Count().ToString();//departman sayısını bulduruyoruz.
            LblToplamFirma.Text = db.Tbl_Firmalar.Count().ToString();
            LblToplamPersonel.Text = db.Tbl_Personel.Count().ToString();
            LblAktifİs.Text = db.Tbl_Gorevler.Count(x => x.Durum == true).ToString();
            LblPasifİs.Text = db.Tbl_Gorevler.Count(x => x.Durum == false).ToString();
            LblSonGörev.Text = db.Tbl_Gorevler.OrderByDescending(x => x.ID).Select(x => x.Aciklama).FirstOrDefault(); //son görevi tersten yazıyoruz.
            LblSonGorevDetay.Text= db.Tbl_Gorevler.OrderByDescending(x => x.ID).Select(x => x.Tarih).FirstOrDefault().ToString();
            LblSehirSayisi.Text = db.Tbl_Firmalar.Select(x => x.İl).Distinct().Count().ToString(); // her ili tek say 
            LblSektörSayisi.Text = db.Tbl_Firmalar.Select(x => x.Sektör).Distinct().Count().ToString();
            DateTime bugun = DateTime.Today;//bugünün değerini tutacak
            LblBugunAcilanGorevler.Text = db.Tbl_Gorevler.Count(x => x.Tarih == bugun).ToString();

            var d1 = db.Tbl_Gorevler.GroupBy(x => x.GorevAlan).OrderByDescending(z => z.Count()).Select(y => y.Key).FirstOrDefault();//key ID
            LblAyinPersoneli.Text = db.Tbl_Personel.Where(x => x.ID==d1).Select(y => y.Ad + " " + y.Soyad).FirstOrDefault().ToString();
            LblAyinDepartmani.Text = db.Tbl_Departmanlar.Where(x => x.ID == db.Tbl_Personel.Where(t => t.ID == d1).Select(z => z.Departman).FirstOrDefault()).Select(y => y.Ad).FirstOrDefault().ToString();
            //ilk sorgu: personel tablosu içerisinde IDsi d1 olan departman bilgisi
        }

        private void labelControl1_Click(object sender, EventArgs e)
        {

        }

        private void LblToplamDepartman_Click(object sender, EventArgs e)
        {

        }

        private void LblToplamFirma_Click(object sender, EventArgs e)
        {

        }
    }
}
