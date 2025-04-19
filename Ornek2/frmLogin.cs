using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ornek2
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        OkulEntities ef = new OkulEntities();

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool kullaniciBulundu = false; // Kullanıcının bulunup bulunmadığını takip etmek için bir bayrak

            var liste = ef.Users.ToList();

            foreach (var item in liste)
            {
                if (item.Email == txtEmail.Text && item.Sifre == txtSifre.Text)
                {
                    kullaniciBulundu = true; // Kullanıcı bulundu
                    Form1 frm = new Form1();
                    this.Hide();
                    frm.Show();
                    break; // Doğru kullanıcı bulunduğunda döngüden çık
                }
            }

            if (!kullaniciBulundu)
            {
                MessageBox.Show("Kullanıcı adı veya şifre yanlış!");
            }
        }
    }
}
