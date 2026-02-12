using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace NotebookApp
{
    public partial class Form1 : Form
    {
        
        private const string ConnectionString =
            "Server=172.16.2.26;Database=doroshenko;Uid=root;Pwd=ae21215926;Charset=utf8mb4;SslMode=None;";

        public Form1()
        {
            InitializeComponent();
            LoadNotes();
        }
        private void LoadNotes()
        {
            try
            {
                using (var conn = new MySqlConnection(ConnectionString))
                {
                    conn.Open();
                    var adapter = new MySqlDataAdapter(
                        "SELECT id, title, LEFT(content, 100) AS preview, created_at FROM notes ORDER BY created_at DESC",
                        conn);
                    var table = new DataTable();
                     adapter.Fill(table);
                    dataGridViewNotes.DataSource = table;

                     // Проверяем, что колонки созданы перед настройкой
                    if (dataGridViewNotes.Columns.Contains("id"))
                       dataGridViewNotes.Columns["id"].Visible = false;
                     
                    if (dataGridViewNotes.Columns.Contains("preview"))
                        dataGridViewNotes.Columns["preview"].HeaderText = "Содержание (предпросмотр)";
                        
                    if (dataGridViewNotes.Columns.Contains("created_at"))
                        dataGridViewNotes.Columns["created_at"].HeaderText = "Дата";

                    dataGridViewNotes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки записей:\n{ex.Message}", "Ошибка",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        } 



        private void btnAdd_Click(object sender, EventArgs e)
        {
            string title = txtTitle.Text.Trim();
            string content = txtContent.Text.Trim();

            if (string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(content))
            {
                MessageBox.Show("Заполните заголовок и содержание!", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var conn = new MySqlConnection(ConnectionString))
                {
                    conn.Open();
                    using (var cmd = new MySqlCommand(
                        "INSERT INTO notes (title, content) VALUES (@title, @content)", conn))
                    {
                        cmd.Parameters.AddWithValue("@title", title);
                        cmd.Parameters.AddWithValue("@content", content);
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Запись добавлена!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTitle.Clear();
                txtContent.Clear();
                LoadNotes();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка добавления:\n{ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewNotes.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите запись для удаления!", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Удалить выбранную запись?", "Подтверждение",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            var row = dataGridViewNotes.SelectedRows[0];
            int id = Convert.ToInt32(row.Cells["id"].Value);

            try
            {
                using (var conn = new MySqlConnection(ConnectionString))
                {
                    conn.Open();
                    using (var cmd = new MySqlCommand("DELETE FROM notes WHERE id = @id", conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Запись удалена!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadNotes();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка удаления:\n{ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e) => LoadNotes();
    }
}
