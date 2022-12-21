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
using System.Xml;

namespace OfferOtomation
{
    public partial class Form2 : Form
    {
        string user;
        public Form2(string a)
        {
            user = a;
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            Hide();
            Form1 form1 = new Form1();
            form1.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Hide();
            Form4 form4 = new Form4(user);
            form4.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Hide();
            Form5 form5 = new Form5(user);
            form5.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Hide();
            Form6 form6 = new Form6();
            form6.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Hide();
            Form7 form7 = new Form7(user);
            form7.Show();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            label1.BackColor = System.Drawing.Color.Transparent;
            label1.Text = user;
        }
    }
}
