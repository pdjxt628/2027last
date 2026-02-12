using MySql.Data.MySqlClient; 
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace memo
{
    public partial class Form1 : Form
    {
    
        string s = "Server=172.16.2.26;Database=okada;Uid=okada;Pwd=05120200m;";

        public Form1()
        {
            InitializeComponent();
            LoadData(); 
        }

  
        void LoadData()
        {
            listBox1.Items.Clear();
            using (var cn = new MySqlConnection(s))
            {
                cn.Open();
                var rd = new MySqlCommand("SELECT content FROM memo", cn).ExecuteReader();
                while (rd.Read()) listBox1.Items.Add(rd[0]);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            using (var cn = new MySqlConnection(s))
            {
                cn.Open();
                new MySqlCommand($"INSERT INTO memo(content)VALUES('{textBox1.Text}')", cn).ExecuteNonQuery();
            }
            LoadData();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
         
            if (listBox1.SelectedItem == null) return;
            using (var cn = new MySqlConnection(s))
            {
                cn.Open();
                new MySqlCommand($"DELETE FROM memo WHERE content='{listBox1.SelectedItem}'", cn).ExecuteNonQuery();
            }
            LoadData();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}