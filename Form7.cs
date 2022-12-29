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
    public partial class Form7 : Form
    {
        SqlConnection con = new SqlConnection("Server=DESKTOP-C3380A2\\SQLEXPRESS01; Database = OfferOtomation;Trusted_Connection = True; MultipleActiveResultSets = true");
        SqlCommand cmd;
        string sirket;
        public Form7(string a)
        {
            sirket = a;
            InitializeComponent();
        }

        private void Form7_Load(object sender, EventArgs e)
        {

            cmd = new SqlCommand("select * from Teklifler where comp = @user", con);
            cmd.Parameters.AddWithValue("@user", sirket);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    this.dataGridView1.Rows.Add(dr["comp"].ToString(), dr["name"].ToString(), dr["price"].ToString(), dr["currency"], dr["count"].ToString());
                }
            }
            else
            {
                MessageBox.Show("Aktif Teklifiniz Bulunmamakta.");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            cmd = new SqlCommand("select * from Teklifler where comp = @user", con);
            cmd.Parameters.AddWithValue("@user", sirket);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Sil")
            {
                if (MessageBox.Show("Geçerli Teklifi Silmek istediğinize emin misiniz?", "Mesage", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    var row = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex];
                    cmd = new SqlCommand("delete from Teklifler where comp = @comp and name = @name and price = @price and currency = @currency ", con);
                    foreach (DataRow dr  in dt.Rows)
                    {
                        if (row.Cells[0].FormattedValue.ToString() == dr["comp"].ToString() && row.Cells[1].FormattedValue.ToString() == dr["name"].ToString() && row.Cells[2].FormattedValue.ToString() == dr["price"].ToString() && row.Cells[3].FormattedValue.ToString() == dr["currency"].ToString() && row.Cells[4].FormattedValue.ToString() == dr["count"].ToString())
                        {
                            cmd.Parameters.AddWithValue("@comp", dr["comp"].ToString());
                            cmd.Parameters.AddWithValue("@name", dr["name"].ToString());
                            cmd.Parameters.AddWithValue("@price", dr["price"]);
                            cmd.Parameters.AddWithValue("@currency", dr["currency"].ToString());
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                            Hide();
                            Form7 form7 = new Form7(sirket);
                            form7.Show();
                        }
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            Form2 form2 = new Form2(sirket);
            form2.Show();
        }
    }
}
