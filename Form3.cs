using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OfferOtomation
{
    public partial class Form3 : Form
    {
        SqlConnection con = new SqlConnection("Server=DESKTOP-C3380A2\\SQLEXPRESS01; Database = TeklifOto;Trusted_Connection = True; MultipleActiveResultSets = true");
        SqlCommand cmd;
        public Form3()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

            if (checkBox1.Checked)
            {
                textBox2.UseSystemPasswordChar = false;
            }
            else
            {
                textBox2.UseSystemPasswordChar = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            cmd = new SqlCommand("insert into Sirketler(username,userpass,tel) values (@username,@userpass,@tel)", con);
            cmd.Parameters.AddWithValue("@username", textBox1.Text);
            cmd.Parameters.AddWithValue("@userpass", textBox2.Text);
            cmd.Parameters.AddWithValue("@tel", textBox3.Text);

            con.Open();

            cmd.ExecuteNonQuery();

            con.Close();
            Hide();
            Form1 form1 = new Form1();
            form1.Show();
        }
    }
}
