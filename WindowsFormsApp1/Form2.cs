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
    public partial class Form2 : Form
    {
        OleDbCommand komut;
        OleDbConnection baglanti;
        OleDbConnection baglanti2;
        OleDbDataAdapter adapter;
        OleDbDataAdapter adapter2;
        DataSet verikumesi;
        DataSet verikumesi2;

        public void tazele()
        {
            baglanti = new OleDbConnection("Provider = Microsoft.Jet.OLEDB.4.0; Data Source = Sınavv.mdb");
            adapter = new OleDbDataAdapter("Select * from sinav", baglanti);
            verikumesi = new DataSet();
            adapter.Fill(verikumesi, "sinav");
            dataGridView1.DataSource = verikumesi.Tables["sinav"];
        }

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            baglanti = new OleDbConnection("Provider = Microsoft.Jet.OLEDB.4.0; Data Source = Sınavv.mdb");
            adapter = new OleDbDataAdapter("Select * from sinav", baglanti);
            verikumesi = new DataSet();
            baglanti.Open();
            adapter.Fill(verikumesi, "sinav");
            dataGridView1.DataSource = verikumesi.Tables["sinav"];
            comboBox1.Items.Add("Amir");
            comboBox1.Items.Add("Memur");
            baglanti.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            baglanti2 = new OleDbConnection("Provider = Microsoft.Jet.OLEDB.4.0; Data Source = Sınavv.mdb");
            if (String.IsNullOrEmpty(textBox1.Text))
            {

            }
            else
            {
                string sorgu = "Select * from sinav where tcno='" + textBox1.Text + "'";
                adapter2 = new OleDbDataAdapter(sorgu, baglanti2);
                verikumesi2 = new DataSet();
                adapter2.Fill(verikumesi2, "sinav");
                dataGridView1.DataSource = verikumesi2.Tables["sinav"];
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            comboBox1.SelectedIndex = -1;
            if (comboBox1.Text=="Memur")
            {
                comboBox1.SelectedIndex = -1;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            komut = new OleDbCommand();
            baglanti.Open();
            komut.Connection = baglanti;
            komut.CommandText = "insert into sinav(tcno,adi,soyadi,cinsiyeti,adres,maas,gorevi,kullaniciadi,parola,yetki) values (@1,@2,@3,@4,@5,@6,@7,@8,@9,@10)";
            komut.Parameters.AddWithValue("@1",textBox1.Text);
            komut.Parameters.AddWithValue("@2",textBox2.Text);
            komut.Parameters.AddWithValue("@3",textBox3.Text);
            komut.Parameters.AddWithValue("@4",textBox4.Text);
            komut.Parameters.AddWithValue("@5",textBox5.Text);
            komut.Parameters.AddWithValue("@6",textBox6.Text);
            komut.Parameters.AddWithValue("@7",comboBox1.Text);
            komut.Parameters.AddWithValue("@8",textBox7.Text);
            komut.Parameters.AddWithValue("@9",textBox8.Text);
            komut.Parameters.AddWithValue("@10",textBox9.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            tazele();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            baglanti = new OleDbConnection("Provider = Microsoft.Jet.OLEDB.4.0; Data Source = Sınavv.mdb");
            adapter = new OleDbDataAdapter("update sinav set tcno = '" + textBox1.Text + "',adi='" + textBox2.Text + "',soyadi='" + textBox3.Text + "',cinsiyeti='" + textBox4.Text + "',adres='" + textBox5.Text + "',maas='"+textBox6.Text+"',gorevi='"+comboBox1.Text+"',kullaniciadi='"+textBox7.Text+"',parola='"+textBox8.Text+"',yetki='"+textBox9.Text+"' where tcno='" + textBox1.Text + "'", baglanti);
            verikumesi = new DataSet();
            adapter.Fill(verikumesi, "sinav");
            dataGridView1.DataSource = verikumesi.Tables["sinav"];
            tazele();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            baglanti = new OleDbConnection("Provider = Microsoft.Jet.OLEDB.4.0; Data Source = Sınavv.mdb");
            adapter = new OleDbDataAdapter("delete  * from sinav where tcno='" + textBox1.Text + "'", baglanti);
            verikumesi = new DataSet();
            adapter.Fill(verikumesi, "sinav");
            dataGridView1.DataSource = verikumesi.Tables["sinav"];
            tazele();
        }
    }
}
