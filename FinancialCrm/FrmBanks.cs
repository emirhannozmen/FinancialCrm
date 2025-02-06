using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using FinancialCrm.Models;

namespace FinancialCrm
{
    public partial class FrmBanks : Form
    {
        private Users currentUser;

        FinancialCrmDbEntities db = new FinancialCrmDbEntities();

        public FrmBanks(Users user)
        {
            InitializeComponent();
            currentUser = user;
        }

        private void FrmBanks_Load_1(object sender, EventArgs e)
        {
            var ziraatBankBalance = db.Banks.Where(x => x.BankTitle == "Ziraat Bankası").Select(y => y.BankBalance).FirstOrDefault();
            var vakifBankBalance = db.Banks.Where(x => x.BankTitle == "VakıfBank").Select(y => y.BankBalance).FirstOrDefault();
            var isBankBalance = db.Banks.Where(x => x.BankTitle == "İş Bankası").Select(y => y.BankBalance).FirstOrDefault();

            lblZiraatBankBalance.Text = ziraatBankBalance.ToString() + " ₺";
            lblVakifBankBalance.Text = vakifBankBalance.ToString() + " ₺";
            lblİsBankBalance.Text = isBankBalance.ToString() + " ₺";

            var bankProcesses1 = db.BankProcesses.OrderByDescending(x => x.ProcessDate).Take(1).FirstOrDefault();
            lblbankProcesses1.Text = bankProcesses1.Description + " - " + bankProcesses1.ProcessDate?.ToString("dd.MM.yyyy") + " - " + bankProcesses1.Amount + " ₺";

            var bankProcesses2 = db.BankProcesses.OrderByDescending(x => x.ProcessDate).Skip(1).Take(2).FirstOrDefault();
            lblbankProcesses2.Text = bankProcesses2.Description + " - " + bankProcesses2.ProcessDate?.ToString("dd.MM.yyyy") + " - " + bankProcesses2.Amount + " ₺";

            var bankProcesses3 = db.BankProcesses.OrderByDescending(x => x.ProcessDate).Skip(2).Take(3).FirstOrDefault();
            lblbankProcesses3.Text = bankProcesses3.Description + " - " + bankProcesses3.ProcessDate?.ToString("dd.MM.yyyy") + " - " + bankProcesses3.Amount + " ₺";

            var bankProcesses4 = db.BankProcesses.OrderByDescending(x => x.ProcessDate).Skip(3).Take(4).FirstOrDefault();
            lblbankProcesses4.Text = bankProcesses4.Description + " - " + bankProcesses4.ProcessDate?.ToString("dd.MM.yyyy") + " - " + bankProcesses4.Amount + " ₺";

            var bankProcesses5 = db.BankProcesses.OrderByDescending(x => x.ProcessDate).Skip(4).Take(5).FirstOrDefault();
            lblbankProcesses5.Text = bankProcesses5.Description + " - " + bankProcesses5.ProcessDate?.ToString("dd.MM.yyyy") + " - " + bankProcesses5.Amount + " ₺";
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
        private void button1_Click(object sender, EventArgs e)
        {
            FrmCategories frm = new FrmCategories(currentUser);
            frm.Show();
            this.Hide();
        }

    }
}