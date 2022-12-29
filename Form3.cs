using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace OfferOtomation
{
    // KAYIT OL
    public partial class Form3 : Form
    {
        SqlConnection con = new SqlConnection("Server=DESKTOP-C3380A2\\SQLEXPRESS01; Database = OfferOtomation;Trusted_Connection = True; MultipleActiveResultSets = true");
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
            // Kayıt olma sayfasındaki herhangi bir girdi kısmı boş mu diye kontrol ediyoruz
            if (String.IsNullOrEmpty(textBox1.Text) || String.IsNullOrEmpty(textBox2.Text) || String.IsNullOrEmpty(maskedTextBox1.Text))
            {
                // Boş girdi var ise hata döndürüyoruz
                MessageBox.Show("Lütfen Gerekli Bilgileri Doğru Giriniz.");
            }
                // Boş girdi yok ise girilen şirket adında kullanıcı var mı diye kontrol ediyoruz
            else if (dr.Read())
            {
                // Bu şirket adında kullanıcı var ise hata döndürüyoruz
                con.Close();
                MessageBox.Show("Girilen İsimdeki Şirket Zaten Kayıtlı ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            // Eğer tüm koşullar doğru sağlandı ise kayıt işlemini başlatıyoruz
            else
            {
                // Önceden açılan connection bağlantısını kapatıyoruz
                con.Close();
                // İlk oluşturduğumuz command'e gerekli parametre değerlerini atıyoruz
                cmd.Parameters.AddWithValue("@username", textBox1.Text);
                cmd.Parameters.AddWithValue("@userpass", textBox2.Text);
                cmd.Parameters.AddWithValue("@tel", maskedTextBox1.Text);
                // Bağlantıyı tekrar açıyoruz
                con.Open();
                // İlk oluşturduğumuz insert command'ini execute ediyoruz
                cmd.ExecuteNonQuery();
                // bağlantıyı kapatıyoruz
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
