using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ticari_Otomasyon
{
    public partial class FrmMail : Form
    {
        public FrmMail()
        {
            InitializeComponent();
        }

        public string Mail;
        private void FrmMail_Load(object sender, EventArgs e)
        {
            txtMailAdres.Text = Mail;
        }

        private void btnGonder_Click(object sender, EventArgs e)
        {
            MailMessage mesajim = new MailMessage();
            SmtpClient client = new SmtpClient();
            client.Credentials = new NetworkCredential("Mail","Şifre");
            client.Port = 587;
            client.Host = "smtp@gmail.com";
            client.EnableSsl = true;
            mesajim.To.Add(rchMesaj.Text);
            mesajim.From = new MailAddress("Mail");
            mesajim.Subject = txtKonu.Text;
            mesajim.Body = rchMesaj.Text;
            client.Send(mesajim);
        }
    }
}
