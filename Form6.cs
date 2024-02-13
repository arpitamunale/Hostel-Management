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
    public partial class Form6 : Form
    {
        string q, cs;
        MySqlCommand cmd;
        MySqlConnection c1;
        MySqlDataAdapter da;
        DataTable t;
        public Form6()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            c1.Open();
            try
            {

                if (comboBox1.SelectedIndex == 0)
                {
                    q = "select * from addmission where balance_fees= 0 ";
                    da = new MySqlDataAdapter(q, c1);
                    t = new DataTable();
                    da.Fill(t);
                    dataGridView1.DataSource = t;
                }
                else 
                {


                        q = "select * from addmission where balance_fees!= 0 ";
                        da = new MySqlDataAdapter(q, c1);
                        t = new DataTable();
                        da.Fill(t);
                        dataGridView1.DataSource = t;
                    

                    
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
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            cs = "server=localhost;database=hostel;uid=root;pwd=root";
            c1 = new MySqlConnection(cs);
            //MessageBox.Show("database connected successfully");
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form5 f = new Form5();
            f.Show();
            this.Hide();
        }
    }
}
