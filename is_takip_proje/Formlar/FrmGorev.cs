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
    public partial class FrmGorev : Form
    {
        public FrmGorev()
        {
            InitializeComponent();
        }

        private void BtnVazgec_Click(object sender, EventArgs e)
        {
            this.Close(); //formu kapat
        }
        İsTakipEntities db = new İsTakipEntities();
        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            Tbl_Gorevler t = new Tbl_Gorevler();
            t.Aciklama = TxtAciklama.Text;
            t.Durum = true;
            t.GorevAlan = int.Parse(lookUpEdit1.EditValue.ToString());
            t.GorevVeren = int.Parse(TxtGorevVeren.Text);
            t.Tarih = DateTime.Parse(TxtTarih.Text);
            db.Tbl_Gorevler.Add(t);
            db.SaveChanges();
            XtraMessageBox.Show("Görev başarılı bir şekilde tanımlandı", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        
        }

        private void FrmGorev_Load(object sender, EventArgs e)
        {
            var degerler = (from x in db.Tbl_Personel //yanındaki systemli durumlar gelmedi
                                select new
                                {
                                    x.ID,
                                    adSoyad= x.Ad +" "+ x.Soyad

                                }).ToList();
            lookUpEdit1.Properties.ValueMember = "ID";// seçim aracımızın arkadsında çalışacak değerler
            lookUpEdit1.Properties.DisplayMember = "adSoyad";// görünecek olan 
            lookUpEdit1.Properties.DataSource = degerler;
        }
    }
}
