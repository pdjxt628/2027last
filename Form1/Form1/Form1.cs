using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace Form1
{
    public partial class Form1 : Form
    {
        string connectionString =
       "Server=172.16.2.26;Database=shenal;Uid=shenal;Pwd=ae21215926;";
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection(conStr);
            con.Open();

            string sql = "INSERT INTO memo (content) VALUES ('" + txtMemo.Text + "')";
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.ExecuteNonQuery();

            con.Close();

            MessageBox.Show("í«â¡ÇµÇ‹ÇµÇΩ");
        }


        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);

                MySqlConnection con = new MySqlConnection(conStr);
                con.Open();

                string sql = "DELETE FROM memo WHERE id=" + id;
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.ExecuteNonQuery();

                con.Close();

                MessageBox.Show("çÌèúÇµÇ‹ÇµÇΩ");
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            MySqlConnection con = new MySqlConnection(conStr);
            con.Open();

            string sql = "SELECT * FROM memo";
            MySqlDataAdapter da = new MySqlDataAdapter(sql, con);

            DataTable dt = new DataTable();
            da.Fill(dt);

            dataGridView1.DataSource = dt;

            con.Close();
        }
    }
}
