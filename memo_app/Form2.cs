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

namespace memo_app
{
    public partial class Form2 : Form
    {
        private string connStr = "server=172.16.2.26;user id=ichiru;password=GAMEshitai_5293;database=ichiru";

        public static string currentMemo;

        public Form2()
        {
            InitializeComponent();
            Load_Content();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Save();
        }

        void Save()
        {
            MySqlConnection conn = new MySqlConnection(connStr);
            try {
                conn.Open();
                DataTable tbl = new DataTable();
                MySqlDataAdapter dataAdp = new MySqlDataAdapter($"update 2027last_memoapp set content=\"{textBox1.Text}\" where name = \"{currentMemo}\"", conn);
                dataAdp.Fill(tbl);
                conn.Close();
            }
            catch (MySqlException mse) {
                MessageBox.Show(mse.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void Load_Content()
        {
            MySqlConnection conn = new MySqlConnection(connStr);
            try {
                conn.Open();
                DataTable tbl = new DataTable();
                MySqlDataAdapter dataAdp = new MySqlDataAdapter($"select content from 2027last_memoapp where name = \"{currentMemo}\"", conn);
                dataAdp.Fill(tbl);
                textBox1.Text = tbl.Rows[0][0].ToString();
                conn.Close();
            }
            catch (MySqlException mse) {
                MessageBox.Show(mse.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
