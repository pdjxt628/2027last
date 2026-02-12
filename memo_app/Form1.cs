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
    public partial class Form1 : Form
    {
        private string connStr = "server=172.16.2.26;user id=ichiru;password=GAMEshitai_5293;database=ichiru";

        string inputText;

        public Form1()
        {
            InitializeComponent();
            Load_Memos();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "") {
                create_memo(textBox1.Text);
                Load_Memos();
            }
            textBox1.Text = "";
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "") {
                Form2.currentMemo = textBox1.Text;
                var form2 = new Form2();
                form2.Show();
                this.Hide();
            }
            textBox1.Text = "";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }


        void create_memo(string name)
        {
            MySqlConnection conn = new MySqlConnection(connStr);
            try {
                conn.Open();
                DataTable tbl = new DataTable();
                MySqlDataAdapter dataAdp = new MySqlDataAdapter($"insert into 2027last_memoapp(name, content) values (\"{name}\", \"\")", conn);
                dataAdp.Fill(tbl);
                conn.Close();
                var textTemp = "";
                foreach (DataRow dr in tbl.Rows) {
                    textTemp += dr["name"].ToString();
                    textTemp += Environment.NewLine;
                }
                textBox2.Text = textTemp;
            }
            catch (MySqlException mse) {
                MessageBox.Show(mse.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void Load_Memos()
        {
            MySqlConnection conn = new MySqlConnection(connStr);
            try {
                conn.Open();
                DataTable tbl = new DataTable();
                MySqlDataAdapter dataAdp = new MySqlDataAdapter($"select name from 2027last_memoapp", conn);
                dataAdp.Fill(tbl);
                conn.Close();
                var textTemp = "";
                foreach (DataRow dr in tbl.Rows) {
                    textTemp += dr["name"].ToString();
                    textTemp += Environment.NewLine;
                }
                textBox2.Text = textTemp;
            }
            catch (MySqlException mse) {
                MessageBox.Show(mse.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
