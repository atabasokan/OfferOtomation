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
    public partial class Form5 : Form
    {
        SqlConnection con = new SqlConnection("Server=DESKTOP-C3380A2\\SQLEXPRESS01; Database = TeklifOto;Trusted_Connection = True; MultipleActiveResultSets = true");
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
                foreach (var item in dr)
                {
                    Controls.Add(listBox1);
                    listBox1.Items.Add(item);
                }
            }
            else
            {
                MessageBox.Show("Girilen Kullanıcı Bulunmamakta.Lütfen Kayıt Olun");
            }
        }
    }
}
