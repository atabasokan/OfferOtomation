using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace OfferOtomation
{
    public partial class Form1 : Form
    {
        // İlk olarak Sql bağlantımızı SQL kütüphanesindeki connection sınıfı ile oluşturuyoruz.
        SqlConnection con = new SqlConnection("Server=DESKTOP-C3380A2\\SQLEXPRESS01; Database = OfferOtomation;Trusted_Connection = True; MultipleActiveResultSets = true");
        // Sql tarafındaki verileri düzenlemek ve görmek için Command sınıfından bir boş command oluşturuyoruz.
        SqlCommand cmd;
        // Sql'den dönen datayı okumak için DataReader sınıfından okuyucu oluşturuyoruz
        SqlDataReader dr;
        public Form1()
        {
            InitializeComponent();
        }

        public void button1_Click(object sender, EventArgs e)
        {

            // button1 (Giriş Yap) tıklandığında Sql'den kayıtlı kullanıcıları çekiyoruz ve girilen kullanıcı kayıtlı mı diye kontrol ediyoruz
            cmd = new SqlCommand("select * from Sirketler where username = @username and userpass = @userpass", con);
            // yazdığımız command'e veri eklemek için cmd parametrelerine değer atıyoruz
            cmd.Parameters.AddWithValue("@username", textBox1.Text);
            cmd.Parameters.AddWithValue("@userpass", textBox2.Text);
            // bağlantımızı açıyoruz
            con.Open();
            // datareader a dönen veriyi okutuyoruz
            dr = cmd.ExecuteReader();
            // datareader a dönen bir veri var mı diye kontrol ediyoruz
            if (dr.HasRows)
            {
                // veri döndü ise bağlantıyı kapatıp giriş yapıyoruz
                con.Close();
                Hide();
                // giriş yapan kullanıcının şirket adını form2 ye gönderiyoruz
                Form2 form2 = new Form2(textBox1.Text);
                form2.Show();
            }
            else
            {
                // veri dönmedi ise kullanıcı kayıtlı değildir.
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
            // şifre kısmının yanındaki checkbox değiştikçe textbox'ın şifre görünümünu değiştiriyoruz
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
