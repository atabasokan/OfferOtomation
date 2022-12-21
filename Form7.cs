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
        SqlConnection con = new SqlConnection("Server=Okan\\Okan; Database = OfferOtomation;Trusted_Connection = True; MultipleActiveResultSets = true");
        SqlCommand cmd;
        string user;
        public Form7(string a)
        {
            user = a;
            InitializeComponent();
        }

        private void Form7_Load(object sender, EventArgs e)
        {

            cmd = new SqlCommand("select * from Teklifler where comp = @user", con);
            cmd.Parameters.AddWithValue("@user", user);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
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
            
            cmd = new SqlCommand("select * from Teklifler where comp = @user", con);
            cmd.Parameters.AddWithValue("@user", user);
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
                    this.dataGridView1.Rows.RemoveAt(dataGridView1.CurrentRow.Index);
                    cmd = new SqlCommand("delete from Teklifler where name = @name",con);
                    foreach (DataRow dr in dt.Rows)
                    {
                        cmd.Parameters.AddWithValue("@name", dr["name"].ToString());
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            Form2 form2 = new Form2(user);
            form2.Show();
        }
    }
}
