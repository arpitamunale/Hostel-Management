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
    public partial class Form4 : Form
    {
        private string p;

        MySqlCommand cmd;
        string q, cs;
        MySqlConnection c1;
        private string p_2;
        private string p_3;
        private string p_4;
        private string p_5;
        
        public Form4()
        {
            
        }

        public Form4(string p)
        {
           
            // TODO: Complete member initialization
          //  this.p = p;
        }

        public Form4(string p, string p_2, string p_3, string p_4, string p_5)
        {
            InitializeComponent();
            // TODO: Complete member initialization
            this.p = p;
            this.p_2 = p_2;
            this.p_3 = p_3;
            this.p_4 = p_4;
            this.p_5 = p_5;
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            //MessageBox.Show("Sid=" + p);
            cs = "server=localhost;database=hostel;uid=root;pwd=root";
            c1 = new MySqlConnection(cs);
            loadrec();
            c1.Open();
            try
            {
                
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("loading exception" + ex);
            }
            finally
            {
                if (c1.State == ConnectionState.Open)
                {
                    c1.Close();
                }
            }
        }
        void loadrec()
        {
            c1.Open();
            try
            {
                textBox1.Text = p;
                q = " select max(rec) from fees ";
                cmd = new MySqlCommand(q, c1);
                int s1 = Convert.ToInt32(cmd.ExecuteScalar());
                textBox5.Text = (s1 + 1).ToString();

                

            }
            catch (Exception ex)
            {

                textBox5.Text = " 100";
            }
            finally
            {
                if (c1.State == ConnectionState.Open)
                {
                    c1.Close();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            
                if (textBox2.Text == "")
                {
                    MessageBox.Show("Enter the payment");
                }

                else
                {
                    c1.Open();
                    try
                    {
                        q = "insert into fees values(@rec,@sid,@sname,@Total_fees,@fees_paid,@balance_fees,@recent_payment,@rdate)";
                        cmd = new MySqlCommand(q, c1);
                        cmd.Parameters.AddWithValue("@rec", textBox5.Text);
                        cmd.Parameters.AddWithValue("@sid", textBox1.Text);
                        cmd.Parameters.AddWithValue("@sname", p_2);
                        cmd.Parameters.AddWithValue("@Total_fees", p_3);
                        cmd.Parameters.AddWithValue("@fees_paid", p_4);
                        cmd.Parameters.AddWithValue("@balance_fees",p_5);
                        cmd.Parameters.AddWithValue("@recent_payment",textBox2.Text );
                        cmd.Parameters.AddWithValue("@rdate", dateTimePicker1.Value.Date);
                        int r = cmd.ExecuteNonQuery();
                        if (r > 0)
                        {
                            
                            double n = Convert.ToDouble(textBox2.Text) + Convert.ToDouble(p_4);
                            double n2 = Convert.ToDouble(p_3) - n;
                            q = "update addmission set fees_paid = " + n + ",balance_fees=" + n2 + " where sid =" + textBox1.Text;
                            cmd = new MySqlCommand(q, c1);
                            r = cmd.ExecuteNonQuery();
                            if (r > 0)
                            {
                                MessageBox.Show(" fees updated successfully");
                                Form1 f = new Form1();
                                f.Show();
                                this.Hide();
                            }
                            else
                            {
                                MessageBox.Show(" updation unsuccessfull");
                            }


                        }
                        else
                        {
                            MessageBox.Show("NO");
                        }
                    
                }
            
            catch (Exception ex)
            {
                MessageBox.Show("Data insert exception" + ex);
            }
            finally
            {
                if (c1.State == ConnectionState.Open)
                {
                    c1.Close();
                }
            }
        }
        }
    }
}
