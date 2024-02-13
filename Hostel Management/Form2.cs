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
    public partial class Form2 : Form
    {
        MySqlCommand cmd1,cmd2;
        string q1,q2,cs;
        MySqlConnection c1;
        string fn="";
        int balance,total,paid;
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            cs = "server=localhost;database=hostel;uid=root;pwd=root";
            c1 = new MySqlConnection(cs);
            //MessageBox.Show("database connected successfully");
            loadID();
            loadrec();
            button2.Visible = false;
        }
        void loadID()
        {
            c1.Open();
            try
            {
                q1 = " select max(sid) from addmission";
                cmd1 = new MySqlCommand(q1, c1);
                int s = Convert.ToInt32(cmd1.ExecuteScalar());
                textBox5.Text = (s + 1).ToString();
                /*q = " select max(rec) from addmission";
                cmd = new MySqlCommand(q, c1);
                int s1 = Convert.ToInt32(cmd.ExecuteScalar());
                textBox5.Text = (s1 + 1).ToString();*/

            }
            catch(Exception ex)
            {
                textBox5.Text = " 1";
                //textBox5.Text = " 100";
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
                
                q1 = " select max(rec) from fees";
                cmd1 = new MySqlCommand(q1, c1);
                int s1 = Convert.ToInt32(cmd1.ExecuteScalar());
                textBox1.Text = (s1 + 1).ToString();

            }
            catch (Exception ex)
            {
                
                textBox1.Text = " 100";
            }
            finally
            {
                if (c1.State == ConnectionState.Open)
                {
                    c1.Close();
                }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                MessageBox.Show(" Enter Student name ");
            }
            else if (comboBox1.Text == "")
            {
                MessageBox.Show(" select degree ");
            }
            else if (comboBox2.Text == "")
            {
                MessageBox.Show(" select year ");
            }
            else if (comboBox3.Text == "")
            {
                MessageBox.Show(" select branch");
            }
            else if (textBox6.Text == "" )
            {
                MessageBox.Show(" enter email id ");

            }
            else if (textBox7.Text == "")
            {
                MessageBox.Show(" enter mobile no ");
            }
            else if (textBox8.Text == "")
            {
                MessageBox.Show(" enter parents mobile no ");
            }
            else if (textBox10.Text == "")
            {
                MessageBox.Show(" enter permanent address");
            }
            else if (textBox4.Text == "")
            {
                MessageBox.Show(" enter fees paid ");
            }
            else
            {
                c1.Open();
                try
                {
                    total = Convert.ToInt32(textBox3.Text);
                    paid = Convert.ToInt32(textBox4.Text);
                    balance = total - paid;
                    
                    q2=" insert into addmission values(@sid,@sname,@addmission_date,@degree,@year,@branch,@mail_id,@mobile_no,@parents_no,@permanent_address,@Total_fees,@fees_paid,@balance_fees,@photo)";    
                    cmd2 = new MySqlCommand(q2, c1);
                    cmd2.Parameters.AddWithValue("@sid", textBox5.Text);
                    cmd2.Parameters.AddWithValue("@sname", textBox2.Text);
                    cmd2.Parameters.AddWithValue("@addmission_date",dateTimePicker1.Value.Date);
                    cmd2.Parameters.AddWithValue("@degree", comboBox1.Text);
                    cmd2.Parameters.AddWithValue("@year", comboBox2.Text);
                    cmd2.Parameters.AddWithValue("@branch", comboBox3.SelectedItem);
                    cmd2.Parameters.AddWithValue("@mail_id", textBox6.Text);
                    cmd2.Parameters.AddWithValue("@mobile_no", textBox7.Text);
                    cmd2.Parameters.AddWithValue("@parents_no", textBox8.Text);
                    cmd2.Parameters.AddWithValue("@permanent_address", textBox10.Text);
                    cmd2.Parameters.AddWithValue("@Total_fees", textBox3.Text);
                    cmd2.Parameters.AddWithValue("@fees_paid", textBox4.Text);
                    cmd2.Parameters.AddWithValue("@balance_fees", balance);
                    cmd2.Parameters.AddWithValue("@photo",fn);
                    q1 = " insert into fees values(@rec,@sid,@sname,@Total_fees,@fees_paid,@balance_fees,@recent_payment,@rdate)";
                    cmd1 = new MySqlCommand(q1, c1);
                    cmd1.Parameters.AddWithValue("@rec", textBox1.Text);
                    cmd1.Parameters.AddWithValue("@sid", textBox5.Text);
                    cmd1.Parameters.AddWithValue("@sname", textBox2.Text);
                    cmd1.Parameters.AddWithValue("@Total_fees", textBox3.Text);
                    cmd1.Parameters.AddWithValue("@fees_paid", textBox4.Text);
                    cmd1.Parameters.AddWithValue("@balance_fees", balance);
                    cmd1.Parameters.AddWithValue("@recent_payment", textBox4.Text);
                    cmd1.Parameters.AddWithValue("@rdate", dateTimePicker1.Value.Date);

                    int r = cmd2.ExecuteNonQuery();
                    if (r > 0)
                    {
                        MessageBox.Show("Student data saved successfully");
                    }
                    else
                    {
                        MessageBox.Show(" data not saved");
                    }
                    int r1 = cmd1.ExecuteNonQuery();
                    if (r1 > 0)
                    {
                        MessageBox.Show("Student data saved successfully");
                        Form2 f = new Form2();
                        f.Show();
                        this.Hide();
                     
                    }
                    else
                    {
                        MessageBox.Show(" data not saved");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(" Data insert exception " + ex);
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

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog a1 = new OpenFileDialog();
            a1.Filter = " image files(*.jpeg; *.jpg; *.png; *.bmp )|*.jpeg; *.jpg; *.png; *.bmp";
            if (a1.ShowDialog() == DialogResult.OK) 
            {
                pictureBox1.Image = new Bitmap(a1.FileName);
                fn = a1.FileName;
                MessageBox.Show("image location: " + fn);
                button2.Visible = true;
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                textBox3.Text = "15000";
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                textBox3.Text = "13000";
            }
            else
            {
                textBox3.Text = "11000";
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.Hide();
        }

        

       

        
    }
}
