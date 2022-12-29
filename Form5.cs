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
        string sirket;
        public Form5(string user)
        {
            sirket = user;
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            // Kendi şirketi dışında geri kalan tüm şirketlerin aktif tekliflerini görmek için command oluşturuyoruz
            cmd = new SqlCommand("select * from Teklifler where comp != @user", con);
            cmd.Parameters.AddWithValue("@user", sirket);
            con.Open();
            cmd.ExecuteNonQuery();
            // Teklifleri yazdırmak için DataTable sınıfından yararlanıyoruz
            DataTable dt = new DataTable();
            // SqlDataAdapter verileri almak ve kaydetmek için ve SQL Server arasında bir DataSet köprü görevi görür
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            con.Close();
            if (da != null)
            {
                // da boş dönmedi ise foreach döngüsüne giriyoruz
                // Bu döngü içerisinde ayrı ayrı Data Satırları oluşturuyoruz
                foreach (DataRow dr in dt.Rows)
                {
                    // Oluşturduğumuz datatabledaki tüm satırlar için aşağıdaki değerleri atıyoruz
                    this.dataGridView1.Rows.Add(dr["comp"].ToString(), dr["name"].ToString(), dr["price"].ToString(), dr["count"].ToString(), dr["currency"]);
                }
            }
        }

        // Tablodaki Satın al butonu tıklanır ise
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Tablodaki tüm satırları dönmek için tekrardan teklifleri döndüren commandi çalıştırıyoruz
            cmd = new SqlCommand("select * from Teklifler where comp != @user", con);
            cmd.Parameters.AddWithValue("@user", sirket);
            con.Open();
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            con.Close();
            // Eğer tabloda tıklanan butonun değeri Al ise if koşuluna giriş yapıyoruz
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Al")
            {
                // Kullanıcı geçerli ürünü satın almak istiyor mu diye tekrardan teyit ediyoruz
                if (MessageBox.Show("Geçerli Teklifi Satın Almak İstediğinize Emin misiniz?", "Mesage", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    // Tıklanan satırın değerlerini oluşturduğumuz variable değişkenine atıyoruz
                    var row = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex];
                    // commandimize yeni bir command atıyoruz
                    cmd = new SqlCommand("update Teklifler set count = count-1 where name = @name and price = @price and currency = @currency", con);
                    foreach (DataRow dr in dt.Rows)
                    {
                        // Şirket adını kontrol etmeyi unuttuğumuz için aynı ürünü aynı fiyattan ve aynı birimden iki farklı şirket oluşturur ise ikisinide bir adet azaltır
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
                            Form2 form2 = new Form2(sirket);
                            form2.Show();
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
