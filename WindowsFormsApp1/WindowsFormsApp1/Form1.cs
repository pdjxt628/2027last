using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //string connStr = "server=172.16.2.26;user id=自分のid;password=自分のパスワード;database=自分のデータベース名";
            string connStr = "server=172.16.2.26;user id=root;password=ae21215926;database=uta";
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                conn.Open();
                DataTable tbl = new DataTable();
                MySqlDataAdapter dataAdp = new MySqlDataAdapter("select * from ITTest", conn);
                dataAdp.Fill(tbl);
                dataGridView1.DataSource = tbl;
                conn.Close();
            }
            catch (MySqlException mse)
            {
                MessageBox.Show(mse.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string str0 = textBox1.Text;
            string str1 = textBox2.Text;
            //int str2 = int.Parse(textBox3.Text);
            string str3 = textBox3.Text;
            string connStr = "server=172.16.2.26;user id=root;password=ae21215926;database=uta";
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                conn.Open();
                DataTable tbl = new DataTable();
                DataTable tbl1 = new DataTable();
                MySqlDataAdapter dataAdp = new MySqlDataAdapter("update ITTest set name=" + str3 + " where id = " + str0, conn);
                MySqlDataAdapter dataAdp2 = new MySqlDataAdapter("update ITTest set name1=" + str1 + " where id = " + str0, conn);
                dataAdp.Fill(tbl);
                MySqlDataAdapter dataAdp1 = new MySqlDataAdapter("select * from ITTest", conn);
                MySqlDataAdapter dataAdp4 = new MySqlDataAdapter("select * from ITTest", conn);
                dataAdp1.Fill(tbl1);
                dataGridView1.DataSource = tbl1;
                conn.Close();
            }
            catch (MySqlException mse)
            {
                MessageBox.Show(mse.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
