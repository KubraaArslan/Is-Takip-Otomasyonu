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
    public partial class FrmAnaForm : Form
    {
        public FrmAnaForm()
        {
            InitializeComponent();
        }
        İsTakipEntities db = new İsTakipEntities();
        private void FrmAnaForm_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = (from x in db.Tbl_Gorevler
                                       select new
                                       {
                                           x.Aciklama,
                                          adSoyad= x.Tbl_Personel.Ad +" " + x.Tbl_Personel.Soyad
                                           
                                       }).ToList();
        }

        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
