using FinancialCrm.Models;
using System;
using System.Linq;
using System.Windows.Forms;

namespace FinancialCrm
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        FinancialCrmDbEntities db = new FinancialCrmDbEntities();

        private void btnLogin_Click_1(object sender, EventArgs e)
        {
            string name = txtUsername.Text;
            string password = txtPassword.Text;

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(password))
            {
                label1.Text = "Lütfen tüm alanları doldurun.";
            }
            else
            {
                var control = db.Users.FirstOrDefault(x => x.Username == name && x.Password == password);

                if (control != null)
                {
                    FrmSettings settingsForm = new FrmSettings(control);
                    settingsForm.Hide();

                    FrmDashboards frmDashboards = new FrmDashboards(control);
                    frmDashboards.Hide();

                    FrmBanks banksForm = new FrmBanks(control);
                    banksForm.Hide();

                    FrmBillings billingsForm = new FrmBillings(control);
                    billingsForm.Hide();

                    FrmSpendings spendingsForm = new FrmSpendings(control);
                    spendingsForm.Hide();


                    FrmBankProcesses bankProcessesForm = new FrmBankProcesses(control);
                    bankProcessesForm.Hide();


                    FrmCategories categoriesForm = new FrmCategories(control);
                    categoriesForm.Show();

                    this.Hide();
                }
                else
                {
                    label1.Text = "Kullanıcı adı veya şifre hatalı.";
                }
            }
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = true;
        }

    }
}
