using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySqlConnector;

namespace formapp
{
    public partial class Form1 : Form
    {
        string connStr = "server=172.16.2.26;uid=fran;password=franfranfran;database=db_fran";

        private void LoadProducts()
        {
            dataGridView1.Rows.Clear();
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                try
                {
                    conn.Open();
                    string sql = "select * from product";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = Convert.ToInt32(reader["id"]);
                            string name = Convert.ToString(reader["name"]);
                            int price = Convert.ToInt32(reader["price"]);
                            this.dataGridView1.Rows.Add(id, name, price);
                        }
                    }
                }
                catch (Exception err)
                {
                    Console.WriteLine(err);
                }
            }
        }

        public void AddProduct(string name, string price)
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                try
                {
                    conn.Open();
                    string sql = $"insert into product (name, price) values ('{name}', {price})";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception err)
                {
                    Console.WriteLine(err);
                }
            }
        }

        public void DeleteProduct(string id)
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                try
                {
                    conn.Open();
                    string sql = $"delete from product where id = {id}";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception err)
                {
                    Console.WriteLine(err);
                }
            }
        }

        public Form1()
        {
            InitializeComponent();
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.ReadOnly = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadProducts();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            string price = textBox2.Text;

            AddProduct(name, price);
            LoadProducts();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
            if (selectedRow is null)
            {
                return;
            }

            string id = selectedRow.Cells["id"].Value.ToString();

            DeleteProduct(id);
            LoadProducts();
        }
    }
}
