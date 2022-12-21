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
            cmd = new SqlCommand("select * from Teklifler where comp != @user", con);
            cmd.Parameters.AddWithValue("@user", a);
            con.Open();
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            con.Close();
            if (da != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    this.dataGridView1.Rows.Add(dr["comp"].ToString(), dr["name"].ToString(), dr["price"].ToString(), dr["count"].ToString(), dr["currency"]);
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            cmd = new SqlCommand("select * from Teklifler where comp != @user", con);
            cmd.Parameters.AddWithValue("@user", a);
            con.Open();
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            con.Close();
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Al")
            {
                if (MessageBox.Show("Geçerli Teklifi Satın Almak İstediğinize Emin misiniz?", "Mesage", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cmd = new SqlCommand("update Teklifler set count = count-1 where name = @name", con);
                    foreach (DataRow dr in dt.Rows)
                    {
                        cmd.Parameters.AddWithValue("@name", dr["name"].ToString());
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        Hide();
                        Form2 form2 = new Form2(a);
                        form2.Show();
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            Form2 form2 = new Form2(a);
            form2.Show();
        }
    }
}
