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
            cmd = new SqlCommand("insert into Teklifler(name,price,birim,sirket) values (@name,@price,@birim,@sirket)", con);
            cmd.Parameters.AddWithValue("@name", textBox1.Text);
            cmd.Parameters.AddWithValue("@price", textBox2.Text);
            cmd.Parameters.AddWithValue("@birim", comboBox1.SelectedItem);
            cmd.Parameters.AddWithValue("@sirket", sirket);

            con.Open();

            cmd.ExecuteNonQuery();

            con.Close();
            Hide();
            Form5 form5 = new Form5();
            form5.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
