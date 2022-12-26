using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace OfferOtomation
{
    public partial class Form6 : Form
    {
            string user;
        public Form6(string a)
        {
            user = a;
            InitializeComponent();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            

            string bugün = "http://www.tcmb.gov.tr/kurlar/today.xml";
            var xmldoc = new XmlDocument();
            xmldoc.Load(bugün);
            DateTime tarih = Convert.ToDateTime(xmldoc.SelectSingleNode("//Tarih_Date").Attributes["Tarih"].Value);
            string USD = xmldoc.SelectSingleNode("Tarih_Date/Currency [@Kod='USD']/ForexSelling").InnerXml;
            string EUR = xmldoc.SelectSingleNode("Tarih_Date/Currency [@Kod='EUR']/ForexSelling").InnerXml;
            string GBP = xmldoc.SelectSingleNode("Tarih_Date/Currency [@Kod='GBP']/ForexSelling").InnerXml;
            string CHF = xmldoc.SelectSingleNode("Tarih_Date/Currency [@Kod='CHF']/ForexSelling").InnerXml;
            string CNY = xmldoc.SelectSingleNode("Tarih_Date/Currency [@Kod='CNY']/ForexSelling").InnerXml;
            string AUD = xmldoc.SelectSingleNode("Tarih_Date/Currency [@Kod='AUD']/ForexSelling").InnerXml;
            string AZN = xmldoc.SelectSingleNode("Tarih_Date/Currency [@Kod='AZN']/ForexSelling").InnerXml;
            this.dataGridView1.Rows.Add(tarih.ToShortDateString(), "USD", USD);
            this.dataGridView1.Rows.Add(tarih.ToShortDateString(), "EUR", EUR);
            this.dataGridView1.Rows.Add(tarih.ToShortDateString(), "GBP", GBP);
            this.dataGridView1.Rows.Add(tarih.ToShortDateString(), "CHF", CHF);
            this.dataGridView1.Rows.Add(tarih.ToShortDateString(), "CNY", CNY);
            this.dataGridView1.Rows.Add(tarih.ToShortDateString(), "AUD", AUD);
            this.dataGridView1.Rows.Add(tarih.ToShortDateString(), "AZN", AZN);
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            Form2 form2 = new Form2(user);
            form2.Show();
        }
    }
}
