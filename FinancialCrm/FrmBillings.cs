using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FinancialCrm.Models;

namespace FinancialCrm
{
    public partial class FrmBillings : Form
    {
        private Users currentUser;

        FinancialCrmDbEntities db = new FinancialCrmDbEntities();
        public FrmBillings(Users user)
        {
            InitializeComponent();
            currentUser = user;
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

        private void button1_Click(object sender, EventArgs e)
        {
            FrmCategories frm = new FrmCategories(currentUser);
            frm.Show();
            this.Hide();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            FrmBanks frm = new FrmBanks(currentUser);
            frm.Show();
            this.Hide();
        }

        private void billList_Click_1(object sender, EventArgs e)
        {
            var values = db.Bills.ToList();
            dataGridView1.DataSource = values;
        }

        private void btnCreateBill_Click_1(object sender, EventArgs e)
        {
            string title = txtBillTitle.Text;
            decimal amount = decimal.Parse(txtBillAmount.Text);
            string period = txtBillPeriod.Text;

            Bills bill = new Bills();
            bill.BillTitle = title;
            bill.BillAmount = amount;
            bill.BillPeriod = period;
            db.Bills.Add(bill);
            db.SaveChanges();
            MessageBox.Show("Başarılı Şekilde Eklendi");

            var values = db.Bills.ToList();
            dataGridView1.DataSource = values;
        }

        private void btnUpdateBill_Click_1(object sender, EventArgs e)
        {
            int id = int.Parse(txtBillId.Text);
            string title = txtBillTitle.Text;
            decimal amount = decimal.Parse(txtBillAmount.Text);
            string period = txtBillPeriod.Text;

            var values = db.Bills.Find(id);

            values.BillTitle = title;
            values.BillAmount = amount;
            values.BillPeriod = period;
            db.SaveChanges();
            MessageBox.Show("Başarılı Şekilde Güncellendi");

            var values2 = db.Bills.ToList();
            dataGridView1.DataSource = values2;
        }

        private void btnRemoveBill_Click_1(object sender, EventArgs e)
        {
            int id = int.Parse(txtBillId.Text);
            var value = db.Bills.Find(id);
            db.Bills.Remove(value);
            db.SaveChanges();
            MessageBox.Show("Silme İşlemi Başarılı");

            var values = db.Bills.ToList();
            dataGridView1.DataSource = values;
        }

        private void FrmBillings_Load(object sender, EventArgs e)
        {
            var values = db.Bills.ToList();
            dataGridView1.DataSource = values;
        }

    }
}
