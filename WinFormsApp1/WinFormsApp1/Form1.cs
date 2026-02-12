using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        //string str = "-1.2";
        //double d;


        //int i = 0
        //string s = "100"
        //bool result = int.TryParse(s, out i);

        //int num;
        //bool isNumeric = int.TryParse(input, out result); 
        //string input = "1234";
        //int result;
        //bool isNumeric = int.TryParse(input, out result);

        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string text = textBox1.Text;
            int str;

            if (int.TryParse(text, out str))
            {
                MessageBox.Show("O");
            }
            else
            {
                MessageBox.Show("X");
            }

            //if (textBox1_TextChanged == true)
            //{
            //    if (double.TryParse(str, out d))
            //        {   

            //            Console.WriteLine("O" str, d);
            //        }       
            //    else
            //        {
            //            Console.WriteLine("X", str);
            //        }
            //}

        }
    }
}
