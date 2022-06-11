using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace WindowsFormsApp1
{
    public partial class Form3 : Form
    {
        OleDbCommand komut;
        OleDbConnection baglanti;
        OleDbDataAdapter adapter;
        DataSet verikumesi;

        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti = new OleDbConnection("Provider = Microsoft.Jet.OLEDB.4.0; Data Source = Sınavv.mdb");
            if (String.IsNullOrEmpty(textBox1.Text))
            {

            }
            else
            {
                string sorgu = "Select * from sinav where tcno='" + textBox1.Text + "'";
                adapter = new OleDbDataAdapter(sorgu, baglanti);
                verikumesi = new DataSet();
                adapter.Fill(verikumesi, "sinav");
                dataGridView1.DataSource = verikumesi.Tables["sinav"];
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglanti = new OleDbConnection("Provider = Microsoft.Jet.OLEDB.4.0; Data Source = Sınavv.mdb");
            if (String.IsNullOrEmpty(textBox2.Text)||String.IsNullOrEmpty(textBox3.Text))
            {

            }
            else
            {
                string sorgu = "Select * from sinav where adi='" + textBox2.Text + "' and soyadi='" + textBox3.Text + "'";
                adapter = new OleDbDataAdapter(sorgu, baglanti);
                verikumesi = new DataSet();
                adapter.Fill(verikumesi, "sinav");
                dataGridView1.DataSource = verikumesi.Tables["sinav"];
            }
        }
    }
}
