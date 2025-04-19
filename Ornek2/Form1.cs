using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ornek2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        OkulEntities ef = new OkulEntities();
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            Ogrenci yOgr = new Ogrenci();
            yOgr.ogrenciNo = txtOgrenciNo.Text;
            yOgr.adSoyad = txtAdSoyad.Text;
            yOgr.Adres = txtAdres.Text;

            ef.Ogrenci.Add(yOgr);
            ef.SaveChanges();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ef.Ogrenci.ToList();
            foreach (var item in ef.Ogrenci.ToList())
            {
                cmbxOgrenciNo.Items.Add(item.ogrenciNo);
            }
                    
        }
        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            string ogrNo;
            ogrNo = cmbxOgrenciNo.SelectedItem.ToString();

            var guncellenecek = ef.Ogrenci.Where(x => x.ogrenciNo == ogrNo).FirstOrDefault();

            guncellenecek.adSoyad = txtAdSoyad.Text;
            guncellenecek.Adres = txtAdres.Text;

            ef.SaveChanges();
            dataGridView1.DataSource = ef.Ogrenci.ToList();

        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            string ogrNo;
            ogrNo = cmbxOgrenciNo.SelectedItem.ToString();

            var silinecek = ef.Ogrenci.Where(x => x.ogrenciNo == ogrNo).FirstOrDefault();
            ef.Ogrenci.Remove(silinecek);
            ef.SaveChanges();
        }
    }
}
