using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Notepad
{
    public partial class Notepad : Form
    {
        string connString = "server=172.16.2.26;user=ged;database=tateno;password=4ged";
        TextBox txtNote = new TextBox { Multiline = true, Dock = DockStyle.Fill };

        public Notepad()
        {
            this.Text = "MySQL Notepad";
            this.Width = 450;
            this.Height = 400;

            Controls.Add(txtNote);
            
            FlowLayoutPanel panel = new FlowLayoutPanel { Dock = DockStyle.Bottom, Height = 40 };
            
            Button buttonSave = new Button { Text = "Save" };
            Button buttonLoad = new Button { Text = "Load" };
            Button buttonDel = new Button { Text = "Delete" };

            buttonSave.Click += (s, e) => RunSql("INSERT INTO Notes (Content) VALUES (@c)", true);
            buttonLoad.Click += (s, e) => LoadNote();
            buttonDel.Click += (s, e) => RunSql("DELETE FROM Notes", true);

            panel.Controls.AddRange(new Control[] { buttonSave, buttonLoad, buttonDel });
            Controls.Add(panel);
        }

        private void RunSql(string query, bool showMsg)
        {
            try {
                using (var conn = new MySqlConnection(connString)) {
                    conn.Open();
                    var cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@c", txtNote.Text);
                    cmd.ExecuteNonQuery();
                    if (showMsg) MessageBox.Show("Done!");
                }
            } catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void LoadNote()
        {
            try {
                using (var conn = new MySqlConnection(connString)) {
                    conn.Open();
                    var cmd = new MySqlCommand("SELECT Content FROM Notes ORDER BY Id DESC LIMIT 1", conn);
                    var result = cmd.ExecuteScalar();
                    txtNote.Text = result?.ToString() ?? "No data found.";
                }
            } catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}