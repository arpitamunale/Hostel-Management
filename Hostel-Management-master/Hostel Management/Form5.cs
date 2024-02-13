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
    public partial class Form5 : Form
    {
        MySqlCommand cmd;
        string q, cs;
        MySqlConnection c1;
        MySqlDataAdapter da;
        DataTable t;
        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            cs = "server=localhost;database=hostel;uid=root;pwd=root";
            c1 = new MySqlConnection(cs);

            /*c1.Open();
            try
            {
                q = "select * from addmission";
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
            }*/

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.Hide();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //c1.Open();
            //try
            //{

            //    if (comboBox1.SelectedIndex == 0)
            //    {
            //        q = "select * from addmission where year='First year' ";
            //        da = new MySqlDataAdapter(q, c1);
            //        t = new DataTable();
            //        da.Fill(t);
            //        dataGridView1.DataSource = t;
            //    }
            //    else if (comboBox1.SelectedIndex == 1)
            //    {
            //        q = "select * from addmission where year='Second year' ";
            //        da = new MySqlDataAdapter(q, c1);
            //        t = new DataTable();
            //        da.Fill(t);
            //        dataGridView1.DataSource = t;
            //    }
            //    else if (comboBox1.SelectedIndex == 2)
            //    {
            //        q = q = "select * from addmission where year='Third year' "; ;
            //        da = new MySqlDataAdapter(q, c1);
            //        t = new DataTable();
            //        da.Fill(t);
            //        dataGridView1.DataSource = t;
            //    }
            //    else
            //    {
            //        q = "select * from addmission where year='Final year' ";
            //        da = new MySqlDataAdapter(q, c1);
            //        t = new DataTable();
            //        da.Fill(t);
            //        dataGridView1.DataSource = t;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("data insert exception" + ex);
            
            //}
            //finally
            //{

            //    if (c1.State == ConnectionState.Open)
            //        c1.Close();
            //}
        }

        private void button2_Click(object sender, EventArgs e)
        {
            comboBox1.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            comboBox2.Visible = true;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

            //c1.Open();
            //try
            //{

            //    if (comboBox2.SelectedIndex == 0)
            //    {
            //        q = "select * from addmission where degree='Diploma' ";
            //        da = new MySqlDataAdapter(q, c1);
            //        t = new DataTable();
            //        da.Fill(t);
            //        dataGridView1.DataSource = t;
            //    }
            //    else if (comboBox2.SelectedIndex == 1)
            //    {
            //        q = "select * from addmission where degree='B-tech' ";
            //        da = new MySqlDataAdapter(q, c1);
            //        t = new DataTable();
            //        da.Fill(t);
            //        dataGridView1.DataSource = t;
            //    }
            //    else
            //    {
            //        q = "select * from addmission where degree='M-tech' ";
            //        da = new MySqlDataAdapter(q, c1);
            //        t = new DataTable();
            //        da.Fill(t);
            //        dataGridView1.DataSource = t;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("data insert exception" + ex);
            
            //}
            //finally
            //{

            //    if (c1.State == ConnectionState.Open)
            //        c1.Close();
            //}
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        //    c1.Open();
        //    try
        //    {

        //        if (comboBox3.SelectedIndex == 0)
        //        {
        //            q = "select * from addmission where branch='CSE' ";
        //            da = new MySqlDataAdapter(q, c1);
        //            t = new DataTable();
        //            da.Fill(t);
        //            dataGridView1.DataSource = t;
        //        }
        //        else if (comboBox3.SelectedIndex == 1)
        //        {
        //            q = "select * from addmission where branch='EE' ";
        //            da = new MySqlDataAdapter(q, c1);
        //            t = new DataTable();
        //            da.Fill(t);
        //            dataGridView1.DataSource = t;
        //        }
        //        else if (comboBox3.SelectedIndex == 2)
        //        {
        //            q = "select * from addmission where branch='ME' ";
        //            da = new MySqlDataAdapter(q, c1);
        //            t = new DataTable();
        //            da.Fill(t);
        //            dataGridView1.DataSource = t;
        //        }
        //        else if (comboBox3.SelectedIndex == 3)
        //        {
        //            q = "select * from addmission where branch='ENTC' ";
        //            da = new MySqlDataAdapter(q, c1);
        //            t = new DataTable();
        //            da.Fill(t);
        //            dataGridView1.DataSource = t;
        //        }
        //        else if (comboBox3.SelectedIndex == 4)
        //        {
        //            q = "select * from addmission where branch='CIVIL' ";
        //            da = new MySqlDataAdapter(q, c1);
        //            t = new DataTable();
        //            da.Fill(t);
        //            dataGridView1.DataSource = t;
        //        }
        //        else if (comboBox3.SelectedIndex == 5)
        //        {
        //            q = "select * from addmission where branch='INSTRUMENTAL' ";
        //            da = new MySqlDataAdapter(q, c1);
        //            t = new DataTable();
        //            da.Fill(t);
        //            dataGridView1.DataSource = t;
        //        }
        //        else
        //        {
        //            q = "select * from addmission where branch='AERONATIC' ";
        //            da = new MySqlDataAdapter(q, c1);
        //            t = new DataTable();
        //            da.Fill(t);
        //            dataGridView1.DataSource = t;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("data insert exception" + ex);

        //    }
        //    finally
        //    {

        //        if (c1.State == ConnectionState.Open)
        //            c1.Close();
        //    }
        //}

        //private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        //{

        //    c1.Open();
        //    try
        //    {

               
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("data insert exception" + ex);

        //    }
        //    finally
        //    {

        //       if (c1.State == ConnectionState.Open)
        //            c1.Close();
        //    } 
        }

        private void button4_Click(object sender, EventArgs e)
        {
            comboBox3.Visible = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form6 f = new Form6();
            f.Show();
            this.Hide();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            c1.Open();
            try
            {
                q = "select * from addmission where degree='"+comboBox2.Text+"' and year='"+comboBox1.Text+"' and branch='"+comboBox3.Text+"'";
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
}
