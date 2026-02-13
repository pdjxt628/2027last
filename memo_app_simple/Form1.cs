using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace memo_app
{
    public partial class Form1 : Form
    {
        private string connStr = "server=172.16.2.26;user id=ichiru;password=GAMEshitai_5293;database=ichiru";

        string inputText;

        public Form1()
        {
            InitializeComponent();
            Load();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Save(inputText);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            inputText = textBox1.Text;
        }

        void Save(string content)
        {
            MySqlConnection conn = new MySqlConnection(connStr);
            try {
                conn.Open();
                DataTable tbl = new DataTable();
                MySqlDataAdapter dataAdp = new MySqlDataAdapter($"update 2027last_memoapp_simple set content=\"{content}\"", conn);
                dataAdp.Fill(tbl);
                conn.Close();
            }
            catch (MySqlException mse) {
                MessageBox.Show(mse.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void Load()
        {
            MySqlConnection conn = new MySqlConnection(connStr);
            try {
                conn.Open();
                DataTable tbl = new DataTable();
                MySqlDataAdapter dataAdp = new MySqlDataAdapter($"select content from 2027last_memoapp_simple", conn);
                dataAdp.Fill(tbl);
                textBox1.Text = tbl.Rows[0][0];
                conn.Close();
            }
            catch (MySqlException mse) {
                MessageBox.Show(mse.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
