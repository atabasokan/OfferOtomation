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
        string a;
        public Form5(string user)
        {
            a = user;
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {

            cmd = new SqlCommand("select * from Teklifler", con);

            con.Open();
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            if (da != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    this.dataGridView1.Rows.Add(dr["sirket"].ToString(), dr["name"].ToString(), dr["price"].ToString(), dr["birim"]);
                }
            }

            else
            {
                MessageBox.Show("Girilen Kullanıcı Bulunmamakta.Lütfen Kayıt Olun");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            Form2 form2 = new Form2(a);
            form2.Show();
        }
    }
}
