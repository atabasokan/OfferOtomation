using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace OfferOtomation
{
    public partial class Form3 : Form
    {
        SqlConnection con = new SqlConnection("Server=Okan\\Okan; Database = OfferOtomation;Trusted_Connection = True; MultipleActiveResultSets = true");
        SqlCommand cmd;
        SqlCommand cmd2;
        SqlDataReader dr;
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
            cmd2 = new SqlCommand("select * from Sirketler where username='" + textBox1.Text + "'", con);
            con.Open();
            dr = cmd2.ExecuteReader();
            if (String.IsNullOrEmpty(textBox1.Text) || String.IsNullOrEmpty(textBox2.Text) || String.IsNullOrEmpty(maskedTextBox1.Text))
            {
                MessageBox.Show("Lütfen Gerekli Bilgileri Doğru Giriniz.");
            }
            else if (dr.Read())
            {
                con.Close();
                MessageBox.Show("Girilen İsimdeki Şirket Zaten Kayıtlı ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                con.Close();
                cmd.Parameters.AddWithValue("@username", textBox1.Text);
                cmd.Parameters.AddWithValue("@userpass", textBox2.Text);
                cmd.Parameters.AddWithValue("@tel", maskedTextBox1.Text);

                con.Open();
                cmd.ExecuteNonQuery();

                con.Close();
                Hide();
                Form1 form1 = new Form1();
                form1.Show();
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }
    }
}
