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
    public partial class Form1 : Form
    {
        OleDbConnection baglanti = new OleDbConnection("Provider = Microsoft.Jet.OLEDB.4.0; Data Source = Sınavv.mdb");
        public static string tcno, adi, soyadi, yetki;

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            sorgu = new OleDbCommand("select * from  sinav", baglanti);
            OleDbDataReader kayitoku = sorgu.ExecuteReader();
            while (kayitoku.Read())
            {
                if (radioButton1.Checked==true)
                {
                    if (kayitoku["kullaniciadi"].ToString()==textBox1.Text&& kayitoku["parola"].ToString() == textBox2.Text&& kayitoku["yetki"].ToString() =="Yönetici")
                    {
                        this.Hide();
                        Form2 frm2 = new Form2();
                        frm2.Show();
                        break;
                    }
                }
                if (radioButton2.Checked==true)
                {
                    if (kayitoku["kullaniciadi"].ToString() == textBox1.Text && kayitoku["parola"].ToString() == textBox2.Text && kayitoku["yetki"].ToString() == "Kullanıcı")
                    {
                        this.Hide();
                        Form3 frm3 = new Form3();
                        frm3.Show();
                        break;
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        OleDbCommand sorgu;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "Kullanıcı Girişi";
            this.AcceptButton = button1;
            this.CancelButton = button2;
            radioButton1.Checked = true;
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
        }
    }
}
