using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace OfferOtomation
{
    public partial class Form5 : Form
    {
        SqlConnection con = new SqlConnection("Server=DESKTOP-C3380A2\\SQLEXPRESS01; Database = OfferOtomation;Trusted_Connection = True; MultipleActiveResultSets = true");
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
                    var row = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex];
                    cmd = new SqlCommand("update Teklifler set count = count-1 where name = @name and price = @price and currency = @currency", con);
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (row.Cells[1].FormattedValue.ToString() == dr.ItemArray[1].ToString() && row.Cells[2].FormattedValue.ToString() == dr.ItemArray[2].ToString() && row.Cells[4].FormattedValue.ToString() == dr.ItemArray[3].ToString())
                        {
                            cmd.Parameters.AddWithValue("@name", dr["name"].ToString());
                            cmd.Parameters.AddWithValue("@price", dr["price"].ToString());
                            cmd.Parameters.AddWithValue("@currency", dr["currency"].ToString());
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                            MessageBox.Show("Satın Alım Gerçekleştirildi.");
                            Hide();
                            Form2 form2 = new Form2(a);
                            form2.Show();
                        }
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
