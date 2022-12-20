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
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection("Server=DESKTOP-C3380A2\\SQLEXPRESS01; Database = TeklifOto;Trusted_Connection = True; MultipleActiveResultSets = true");
        SqlCommand cmd;
        SqlDataReader dr;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("select * from Sirketler where username = @username and userpass = @userpass", con);
            cmd.Parameters.AddWithValue("@username", textBox1.Text);
            cmd.Parameters.AddWithValue("@userpass", textBox2.Text);

            con.Open();

            dr= cmd.ExecuteReader();

            if(dr.HasRows)
            {
                Hide();
                Form2 form2 = new Form2();
                 form2.Show();
            }
            else
            {
                MessageBox.Show("Girilen Kullanıcı Bulunmamakta.Lütfen Kayıt Olun");
            }
        }
    }
}
