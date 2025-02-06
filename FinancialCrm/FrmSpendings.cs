using FinancialCrm.Models;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace FinancialCrm
{
    public partial class FrmSpendings : Form
    {

        private Users currentUser;

        FinancialCrmDbEntities db = new FinancialCrmDbEntities();

        public FrmSpendings(Users user)
        {
            InitializeComponent();
            currentUser = user;
        }

        private void FrmSpendings_Load(object sender, EventArgs e)
        {
            var values = db.Spendings
                            .GroupBy(s => s.SpendingTitle)
                            .Select(group => new
                            {
                                SpendingTitle = group.Key,
                                Count = group.Count()
                            })
                            .OrderByDescending(x => x.Count)
                            .ToList();

            chart1.Series.Clear();

            var series = chart1.Series.Add("Spendings");
            series.ChartType = SeriesChartType.Doughnut;

            foreach (var item in values)
            {
                series.Points.AddXY(item.SpendingTitle, item.Count);
            }

            var maxSpending = db.Spendings.Max(s => s.SpendingAmount);

            var totalSpending = db.Spendings.Sum(s => s.SpendingAmount);

            var mostSpentCategory = db.Spendings
                                      .GroupBy(s => s.CategoryId)
                                      .OrderByDescending(g => g.Sum(s => s.SpendingAmount))
                                      .Select(g => new
                                      {
                                          CategoryId = g.Key,
                                          TotalAmount = g.Sum(s => s.SpendingAmount)
                                      })
                                      .FirstOrDefault(); 

            var categoryName = db.Categories
                                 .Where(c => c.CategoryId == mostSpentCategory.CategoryId)
                                 .Select(c => c.CategoryName)
                                 .FirstOrDefault();

            d.Text = $"{maxSpending} ₺";
            f.Text = $"{totalSpending} ₺";

            if (mostSpentCategory != null && categoryName != null)
            {
                a.Text = $"{categoryName}";
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Uygulamayı kapatmak istediğinize emin misiniz?", "Çıkış Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Question); if (dialogResult == DialogResult.Yes) { Application.Exit(); }
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
        private void button1_Click(object sender, EventArgs e)
        {
            FrmCategories frm = new FrmCategories(currentUser);
            frm.Show();
            this.Hide();
        }
    }
}
