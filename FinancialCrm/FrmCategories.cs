using FinancialCrm.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace FinancialCrm
{
    public partial class FrmCategories : Form
    {
        private Users currentUser;

        FinancialCrmDbEntities db = new FinancialCrmDbEntities();

        public FrmCategories(Users user)
        {
            InitializeComponent();
            currentUser = user;
        }

        private void FrmCategories_Load(object sender, EventArgs e)
        {
            LoadCategories();
            label4.Text = $"Hoşgeldiniz, {currentUser.Username}!";
        }

        private void LoadCategories()
        {
            var categories = db.Categories.Select(c => new { c.CategoryId, c.CategoryName }).ToList();
            dataGridView1.DataSource = categories;
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

        private void button1_Click(object sender, EventArgs e)
        {
            FrmCategories frm = new FrmCategories(currentUser);
            frm.Show();
            this.Hide();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            string title = txtName.Text;

            Categories categories = new Categories();
            categories.CategoryName = title;

            db.Categories.Add(categories);
            db.SaveChanges();
            MessageBox.Show("Başarılı Şekilde Eklendi");

            LoadCategories();
           
        }

        private void button10_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text);
            var value = db.Categories.Find(id);
            db.Categories.Remove(value);
            db.SaveChanges();
            MessageBox.Show("Silme İşlemi Başarılı");

            LoadCategories();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text);
            string title = txtName.Text;

            var values = db.Categories.Find(id);

            values.CategoryName = title;
            db.SaveChanges();
            MessageBox.Show("Başarılı Şekilde Güncellendi");

            LoadCategories();
        }

    }
}
