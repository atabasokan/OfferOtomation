using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace OfferOtomation
{
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection("Server=DESKTOP-C3380A2\\SQLEXPRESS01; Database = OfferOtomation;Trusted_Connection = True; MultipleActiveResultSets = true");
        SqlCommand cmd;
        SqlDataReader dr;
        public Form1()
        {
            InitializeComponent();
        }

        public void button1_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("select * from Sirketler where username = @username and userpass = @userpass", con);
            cmd.Parameters.AddWithValue("@username", textBox1.Text);
            cmd.Parameters.AddWithValue("@userpass", textBox2.Text);

            con.Open();

            dr = cmd.ExecuteReader();

            if (dr.HasRows)
            {
                con.Close();
                Hide();
                Form2 form2 = new Form2(textBox1.Text);
                form2.Show();
            }
            else
            {
                MessageBox.Show("Girilen Kullanıcı Bulunmamakta.Lütfen Kayıt Olun");
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

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

        private void button2_Click(object sender, EventArgs e)
        {

            Hide();
            Form3 form3 = new Form3();
            form3.Show();
        }
    }
}
