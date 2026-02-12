//using MySqlConnector;
using MySql.Data.MySqlClient;
using System.Data;


namespace d2027last
{
    public partial class Form1 : Form
    {
        string connStr = "server=172.16.2.26;user id=ito;password=mari21215926;database=ito";



        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        public void LoadNotesTable()
        {
            using (var conn = new MySqlConnection(connStr))
            {
                try
                {
                    conn.Open();
                    var sql = $"select*from notesAlt;";
                    //MySqlCommand cmd = new(sql, conn);
                    MySqlDataAdapter adp = new(sql, conn);
                    DataTable table = new();
                    adp.Fill(table);
                    dataGridView1.DataSource = table;
                    conn.Close();


                    //using (var reader = cmd.ExecuteReader())
                    //{

                    //    if (reader.Read())
                    //    {
                    //        var r = Convert.ToInt32(reader["id"]);


                    //    }
                    //}
                }
                catch
                {

                }
            }
        }
        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(textBox2.Text, out int id)) return;

            using (var conn = new MySqlConnection(connStr))
            {
                try
                {
                    conn.Open();
                    var sql = $"delete from notesAlt where id={id}";
                    //MySqlCommand cmd = new(sql, conn);
                    //cmd.ExecuteNonQuery();
                    MySqlDataAdapter adapter = new(sql, conn);
                    DataTable table = new();
                    adapter.Fill(table);
                    LoadNotesTable();
                }
                catch
                {

                }
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            var text = textBox1.Text;

            using (var conn = new MySqlConnection(connStr))
            {
                try
                {
                    conn.Open();
                    var sql = $"insert into notesAlt(text)values('{text}');";
                    //MySqlCommand cmd = new();
                    //cmd.ExecuteNonQuery();
                    MySqlDataAdapter adp = new(sql, conn);
                    DataTable table = new();
                    adp.Fill(table);

                    LoadNotesTable();
                    textBox1.Clear();
                }
                catch
                {

                }
            }

        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            LoadNotesTable();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
