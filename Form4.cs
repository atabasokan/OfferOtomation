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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace OfferOtomation
{
    public partial class Form4 : Form
    {
        SqlConnection con = new SqlConnection("Server=Okan\\Okan; Database = OfferOtomation;Trusted_Connection = True; MultipleActiveResultSets = true");
        SqlCommand cmd;
        string sirket;
        public Form4(string user)
        {
            sirket = user;
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int price, count;
            if (!int.TryParse(textBox2.Text, out price) || !int.TryParse(textBox3.Text, out count) || textBox1.Text == null || textBox2.Text == null || textBox3.Text == null)
            {
                MessageBox.Show("Lütfen Gerekli Bilgileri Doğru Giriniz.");
                return;
            }
            else if(comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Lütfen Para Birimini Seçiniz.");
            }
            else
            {
                cmd = new SqlCommand("insert into Teklifler(name,price,currency,count,comp) values (@name,@price,@currency,@count,@comp)", con);
                cmd.Parameters.AddWithValue("@name", textBox1.Text);
                cmd.Parameters.AddWithValue("@price", textBox2.Text);
                cmd.Parameters.AddWithValue("@currency", comboBox1.SelectedItem);
                cmd.Parameters.AddWithValue("@count", textBox3.Text);
                cmd.Parameters.AddWithValue("@comp", sirket);

                con.Open();

                cmd.ExecuteNonQuery();

                con.Close();
                Hide();
                Form5 form5 = new Form5(sirket);
                form5.Show();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
            Form2 form2 = new Form2(sirket);
            form2.Show();
        }
    }
}
