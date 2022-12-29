using System;
using System.Windows.Forms;

namespace OfferOtomation
{
    public partial class Form2 : Form
    {
        string sirket;
        public Form2(string a)
        {
            // form1'den gelen şirket adı verisini bu formda tanımlı olan bir string değere atıyoruz
            sirket = a;
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // form2 yüklendiğinde üst başlığa şirketin adını yazdırıyoruz
            label1.Text = sirket;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            // ÇIKIŞ YAP
            Hide();
            Form1 form1 = new Form1();
            form1.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            // TEKLİF OLUŞTURMA
            Hide();
            Form4 form4 = new Form4(sirket);
            form4.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // TEKLİFLER
            Hide();
            Form5 form5 = new Form5(sirket);
            form5.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // GÜNCEL KUR
            Hide();
            Form6 form6 = new Form6(sirket);
            form6.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // TEKLİFLERİM
            Hide();
            Form7 form7 = new Form7(sirket);
            form7.Show();
        }
    }
}
