using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using is_takip_proje.Entity;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace is_takip_proje.Formlar
{
    public partial class FrmDepartmanlar : Form
    {
        public FrmDepartmanlar()
        {
            InitializeComponent();
        }

        //private void button1_Click(object sender, EventArgs e)
        //{

        //}
        //crud---> create read update delete
        //tolist tüm değerleri getirir.
        İsTakipEntities db = new İsTakipEntities(); // nesne türettik--- hepsine erişim için(buraya)
        void Listele()   //farklı yerlerde çalıştıracağımız için metot 
        {
            
            var degerler = (from x in db.Tbl_Departmanlar
                           select new
                           {
                               x.ID,
                               x.Ad

                          }).ToList(); // istenilen değerleri sınırlamak için kullandık bu kod dizisini 
            gridControl1.DataSource= degerler; //gridCont veri kaynağı=özelliğin listelenmesi
        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            Listele();
        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            //text edite atama yapmak amacımız--> departman adı

            Tbl_Departmanlar t = new Tbl_Departmanlar(); //departmanlar içindeki özelliklere değer ataması gerçekleşir.
            t.Ad = TxtAd.Text;
            db.Tbl_Departmanlar.Add(t);//tden gelenleri  ekleme
            db.SaveChanges();//değişiklikleri veritabanına yansıtmak için
            XtraMessageBox.Show("Departman başarılı bir şekilde sisteme kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information); //içerik,başlık,mesaj kutusu buton,mesaj kutusu buton
            Listele();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            int x = int.Parse(TxtID.Text); //texte ıdden gelen değeri atadık
            var deger = db.Tbl_Departmanlar.Find(x);//x'ten göndermiş olduğumuz değeri bulacak
            db.Tbl_Departmanlar.Remove(deger);//kaldır
            db.SaveChanges();
            XtraMessageBox.Show("Departman silme işlemi başarılı bir şekilde gerçekleşti.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            Listele();

    
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            TxtID.Text = gridView1.GetFocusedRowCellValue("ID").ToString();//imlecin hareketine göre  tıklandığında
            TxtAd.Text = gridView1.GetFocusedRowCellValue("Ad").ToString();
            //herhangi bir departman hücresine tıkladığımız zaman hücre bilgilerini textboxlara aktarma işlemi
            
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            int x = int.Parse(TxtID.Text); //texte ıdden gelen değeri atadık
            var deger = db.Tbl_Departmanlar.Find(x);//x'ten göndermiş olduğumuz değeri bulacak
            deger.Ad = TxtAd.Text;
            db.SaveChanges();
            XtraMessageBox.Show("Departman güncelleme işlemi başarılı bir şekilde gerçekleşti.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            Listele();



        }

        private void FrmDepartmanlar_Load(object sender, EventArgs e)
        {

        }
    }
}
