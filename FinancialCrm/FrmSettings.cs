using FinancialCrm.Models;
using System;
using System.Windows.Forms;

namespace FinancialCrm
{
    public partial class FrmSettings : Form
    {
        private Users currentUser;

        FinancialCrmDbEntities db = new FinancialCrmDbEntities();

        public FrmSettings(Users user)
        {
            InitializeComponent();
            currentUser = user;
        }

        private void FrmSettings_Load(object sender, EventArgs e)
        {
            txtUsername.Text = currentUser.Username;
            txtPassword.Text = currentUser.Password;
            textBox1.Text = currentUser.UserId.ToString();

            txtPassword.UseSystemPasswordChar = true;
            textBox1.ReadOnly = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmCategories frm = new FrmCategories(currentUser);
            frm.Show();
            this.Hide();
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Uygulamayı kapatmak istediğinize emin misiniz?", "Çıkış Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Question); if (dialogResult == DialogResult.Yes) { Application.Exit(); }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            FrmBanks frm = new FrmBanks(currentUser);
            frm.Show();
            this.Hide();
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            FrmBillings frm = new FrmBillings(currentUser);
            frm.Show();
            this.Hide();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            FrmSpendings frm = new FrmSpendings(currentUser);
            frm.Show();
            this.Hide();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            FrmBankProcesses frm = new FrmBankProcesses(currentUser);
            frm.Show();
            this.Hide();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            FrmDashboards frm = new FrmDashboards(currentUser);
            frm.Show();
            this.Hide();
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            FrmSettings frm = new FrmSettings(currentUser);
            frm.Show();
            this.Hide();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string name = txtUsername.Text;
            string password = txtPassword.Text;

            var userToUpdate = db.Users.Find(currentUser.UserId);

            if (userToUpdate != null)
            {
                userToUpdate.Username = name;
                userToUpdate.Password = password;

                db.SaveChanges();
                MessageBox.Show("Kullanıcı bilgileri başarıyla güncellendi.");
                FrmCategories frmBank = new FrmCategories(currentUser);
                frmBank.Show();
                this.Close();

            }
            else
            {
                MessageBox.Show("Kullanıcı bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
