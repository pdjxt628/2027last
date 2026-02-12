#nullable disable
using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace MemoApp
{
    public partial class Form1 : Form
    {
        string connStr = "server=172.16.2.26;user=yoshida;password=TcaPG-1983;database=Yoshida";


        public Form1()
        {
            InitializeComponent();
        }

        // SAVE
        private void btnAdd_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();

            MySqlCommand cmd = new MySqlCommand("INSERT INTO notes(text) VALUES(@text)", conn);
            cmd.Parameters.AddWithValue("@text", txtNote.Text);
            cmd.ExecuteNonQuery();

            conn.Close();
            MessageBox.Show("Save");
        }

        // SHOW
        private void btnLoad_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();

            MySqlCommand cmd = new MySqlCommand("SELECT * FROM notes", conn);
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                listBox1.Items.Add(reader["id"] + " : " + reader["text"]);
            }

            conn.Close();
        }

        // DELETE
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == null) return;

            string selected = listBox1.SelectedItem.ToString();
            string id = selected.Split(':')[0];

            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();

            MySqlCommand cmd = new MySqlCommand("DELETE FROM notes WHERE id=@id", conn);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();

            conn.Close();
            MessageBox.Show("Delete");
        }
    }
}
