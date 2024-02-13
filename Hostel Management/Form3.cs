using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Hostel_Management
{
    public partial class Form3 : Form
    {
        string q, cs;
        MySqlCommand cmd;
        MySqlConnection c1;
        MySqlDataReader d;
        MySqlDataAdapter da;
        DataTable t;

        public Form3()
        {
            InitializeComponent();
        }

        
        private void Form3_Load(object sender, EventArgs e)
        {
            cs = "server=localhost;database=hostel;uid=root;pwd=root";
            c1 = new MySqlConnection(cs);
            c1.Open();
            try
            {
                q = "select sid from addmission";
                cmd = new MySqlCommand(q, c1);
                d = cmd.ExecuteReader();
                while (d.Read())
                {
                    comboBox1.Items.Add(d["sid"].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Data Fetch error:"+ex);
            }
            finally
            {
                if(c1.State==ConnectionState.Open)
                {
                    c1.Close();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = true;
            if (comboBox1.Text == "")
            {
                MessageBox.Show("please select student id: ");
            }
            else
            {
                c1.Open();
                try
                {
                    int n = Convert.ToInt32(comboBox1.Text);
                    q = "select * from addmission where sid=" + n;
                    cmd = new MySqlCommand(q, c1);
                    d = cmd.ExecuteReader();

                    if (d.Read())
                    {
                        textBox1.Text = d["sname"].ToString();
                        dateTimePicker1.Text = d["addmission_date"].ToString();
                        textBox2.Text = d["degree"].ToString();
                        textBox3.Text = d["year"].ToString();
                        textBox4.Text = d["branch"].ToString();
                        textBox5.Text = d["Total_fees"].ToString();
                        textBox6.Text = d["fees_paid"].ToString();
                        textBox7.Text = d["balance_fees"].ToString();


                    }
                    else
                    {
                        MessageBox.Show("Invalid uid");

                    }

                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show("data insert exception" + ex);
                }
                finally
                {
                    if (c1.State == ConnectionState.Open)
                        c1.Close();
                }

                c1.Open();
                try
                {
                    int n = Convert.ToInt32(comboBox1.Text);
                    q = "select rec,Total_fees,fees_paid,balance_fees,rdate from fees where sid=" + n;
                    da = new MySqlDataAdapter(q, c1);
                    t = new DataTable();
                    da.Fill(t);
                    dataGridView1.DataSource = t;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("data insert exception" + ex);
                }
                finally
                {
                    if (c1.State == ConnectionState.Open)
                        c1.Close();
                }


            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "")
            {
                MessageBox.Show("Enter Student id");
            }
            else
            {
                Form4 f = new Form4(comboBox1.Text,textBox1.Text,textBox5.Text,textBox6.Text,textBox7.Text);
                f.Show();
                this.Hide();

            }

             
        }
        

        
    }
}
