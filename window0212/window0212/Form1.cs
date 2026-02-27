using System;
using System.Text;
using System.Windows.Forms;
using MySqlConnector;

namespace window0212
{
    public partial class Form1 : Form
    {
        private const string ConnStr =
            "Server=172.16.2.26;Port=3306;User ID=XIEYUHAN;Password=ae21215926;Database=XIE;" +
            "SslMode=None;AllowPublicKeyRetrieval=True;CharSet=utf8mb4;";

        private const int ShowLimit = 10;

        public Form1()
        {
            InitializeComponent();

            // button2 = Send, button1 = Delete（你现在的约定）
            button2.Click += button2_Click;
            button1.Click += button1_Click;
            this.Load += Form1_Load;
        }

        // 起動時：テーブル確認→表示
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                EnsureTable();
                ShowLatest();
            }
            catch (Exception ex)
            {
                MessageBox.Show("起動時エラー: " + ex.Message);
            }
        }

        // ===== 登録（Send）=====
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                EnsureTable();

                string content = textBox1.Text.Trim();
                if (string.IsNullOrEmpty(content))
                {
                    MessageBox.Show("送信するテキストがありません。");
                    return;
                }

                // Title は NOT NULL なので固定 or 日時でOK（内容と重複させない）
                string title = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                long newId = InsertMemo(title, content);

                

                MessageBox.Show($"登録OK (Id={newId})");
                ShowLatest();
            }
            catch (Exception ex)
            {
                MessageBox.Show("登録エラー: " + ex.Message);
            }
        }

        // ===== 削除（Delete）：最新1件削除 =====
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                EnsureTable();

                int affected = DeleteLatestOne();
                if (affected == 0)
                {
                    MessageBox.Show("削除するデータがありません。");
                    return;
                }

                MessageBox.Show("最新1件を削除しました。");
                ShowLatest();
            }
            catch (Exception ex)
            {
                MessageBox.Show("削除エラー: " + ex.Message);
            }
        }

        // ===== DB 最小セット =====

        private void EnsureTable()
        {
            using var conn = new MySqlConnection(ConnStr);
            conn.Open();

            const string sql = @"
CREATE TABLE IF NOT EXISTS memos (
  Id INT AUTO_INCREMENT PRIMARY KEY,
  Title VARCHAR(255) NOT NULL,
  Content TEXT,
  CreatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP
) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;";

            using var cmd = new MySqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
        }

        private long InsertMemo(string title, string content)
        {
            using var conn = new MySqlConnection(ConnStr);
            conn.Open();

            const string sql = @"INSERT INTO memos (Title, Content) VALUES (@t, @c);";
            using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@t", title);
            cmd.Parameters.AddWithValue("@c", content);
            cmd.ExecuteNonQuery();

            // MySqlConnector は LastInsertedId が使える
            return cmd.LastInsertedId;
        }

        private int DeleteLatestOne()
        {
            using var conn = new MySqlConnection(ConnStr);
            conn.Open();

            const string sql = @"DELETE FROM memos ORDER BY Id DESC LIMIT 1;";
            using var cmd = new MySqlCommand(sql, conn);
            return cmd.ExecuteNonQuery();
        }

        // 表示：Titleを出さずに Content だけ出す（重複して見えるのを回避）
        private void ShowLatest(int limit = ShowLimit)
        {
            using var conn = new MySqlConnection(ConnStr);
            conn.Open();

            const string sql = @"
SELECT Id, Content, CreatedAt
FROM memos
ORDER BY Id DESC
LIMIT @n;";

            using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@n", limit);

            using var reader = cmd.ExecuteReader();
            var sb = new StringBuilder();
            int count = 0;

            while (reader.Read())
            {
                count++;
                sb.AppendLine($"Id: {reader["Id"]} | {reader["CreatedAt"]}");
                sb.AppendLine(reader["Content"]?.ToString() ?? "");
                sb.AppendLine("------");
            }

            MessageBox.Show(count == 0 ? "（データなし）" : sb.ToString(), $"最新{limit}件");
        }

     

    }
}
