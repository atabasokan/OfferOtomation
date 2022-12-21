using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace OfferOtomation
{
    public partial class Form5 : Form
    {
        SqlConnection con = new SqlConnection("Server=Okan\\Okan; Database = OfferOtomation;Trusted_Connection = True; MultipleActiveResultSets = true");
        SqlCommand cmd;
        SqlDataReader dr;
        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {

            cmd = new SqlCommand("select * from Teklifler", con);

            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            { 

            }
            else
            {
                MessageBox.Show("Girilen Kullanıcı Bulunmamakta.Lütfen Kayıt Olun");
            }
        }
    }
}
