using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using FinancialCrm.Models;

namespace FinancialCrm
{
    public partial class FrmBankProcesses : Form
    {
        private Users currentUser; 

        FinancialCrmDbEntities db = new FinancialCrmDbEntities();

        public FrmBankProcesses(Users user)
        {
            InitializeComponent();
            currentUser = user;
        }

        private void FrmBankProcesses_Load(object sender, EventArgs e)
        {
            var banks = db.Banks
                    .Select(b => new { b.BankId, b.BankTitle })
                    .ToList();

            comboBox1.DataSource = banks;
            comboBox1.DisplayMember = "BankTitle"; 
            comboBox1.ValueMember = "BankId"; 
        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            if (comboBox1.SelectedValue != null)
            {
                int selectedBankId = Convert.ToInt32(comboBox1.SelectedValue);

                var bankProcesses = db.BankProcesses
                                          .Where(bp => bp.BankId == selectedBankId)
                                          .Select(bp => new
                                          {
                                              bp.Description,
                                              bp.ProcessDate,
                                              bp.ProcessType,
                                              bp.Amount
                                          })
                                          .ToList();

                dataGridView1.DataSource = bankProcesses;

            }
            else
            {
                MessageBox.Show("Lütfen bir banka seçiniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmCategories frm = new FrmCategories(currentUser);
            frm.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FrmBanks frm = new FrmBanks(currentUser);
            frm.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            FrmBillings frm = new FrmBillings(currentUser);
            frm.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FrmSpendings frm = new FrmSpendings(currentUser);
            frm.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FrmBankProcesses frm = new FrmBankProcesses(currentUser);
            frm.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmDashboards frm = new FrmDashboards(currentUser);
            frm.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            FrmSettings frm = new FrmSettings(currentUser);
            frm.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}
