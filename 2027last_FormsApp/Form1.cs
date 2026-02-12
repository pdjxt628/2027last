using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace _2027last_FormsApp
{
    public partial class Form1 : Form
    {
        string connStr = "server=172.16.2.26;user id=nemoto;password=feif2015;database=nemoto";


        public Form1()
        {
            InitializeComponent();
        }

        private void Inputbutton_Click(object sender, EventArgs e)
        {
            int id = int.Parse(textBox2.Text);


            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();

            string sql = "INSERT INTO MemoApp(id,text) VALUES ("+ id +",'" + textBox1.Text + "')";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.ExecuteNonQuery();

            conn.Close();

        }

        private void DelateButton_Click(object sender, EventArgs e)
        {
            if (Memo.CurrentCell != null)
            {
                int id = int.Parse(textBox2.Text);

                MySqlConnection conn = new MySqlConnection(connStr);
                conn.Open();

                string sql = "DELETE FROM MemoApp WHERE id=" + id;
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();

                conn.Close();
            }
        }

        private void LoadButton_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        void LoadData()
        {
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();

            string sql = "SELECT * FROM MemoApp";
            MySqlDataAdapter data = new MySqlDataAdapter(sql, conn);

            DataTable dt = new DataTable();
            data.Fill(dt);

            Memo.DataSource = dt;

            conn.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
