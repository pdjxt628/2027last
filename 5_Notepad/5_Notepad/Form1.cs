using MySql.Data.MySqlClient;
using System.Data;

namespace _5_Notepad
{
    public partial class Form1 : Form
    {
        string connect = "server=172.16.2.26; user id=Katsumura; password=TcaPG-1983; database=Katsumura";

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string send0 = "update Notepad set string = '";
            string send1 = textBox1.Text;
            string send2 = "' where id = 0";
            string send = send0 + send1 + send2;

            try
            {
                // init
                MySqlConnection conn = new MySqlConnection(connect);
                conn.Open();

                // set data
                DataTable tbl = new DataTable();
                MySqlDataAdapter dataAdp = new MySqlDataAdapter(send, conn);
                dataAdp.Fill(tbl);

                // end
                conn.Close();
                textBox2.Text = Environment.NewLine + "Send Finish";
            }
            catch
            {
                textBox2.Text = Environment.NewLine + "Send Error";
            }

            ClearMessage();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string load = "select string from Notepad";
            DataTable tbl = new DataTable();

            try
            {
                // init
                MySqlConnection conn = new MySqlConnection(connect);
                conn.Open();

                // get data
                MySqlDataAdapter dataAdp = new MySqlDataAdapter(load, conn);
                dataAdp.Fill(tbl);

                // show string
                textBox1.Text = tbl.Rows[0][0].ToString();

                // end
                conn.Close();
                textBox2.Text = "Load MySql Successful";
            }
            catch
            {
                textBox2.Text = "Error Loading MySql";
            }

            ClearMessage();
        }

        async void ClearMessage()
        {
            await Task.Delay(3000);
            textBox2.Text = string.Empty;
        }
    }
}
