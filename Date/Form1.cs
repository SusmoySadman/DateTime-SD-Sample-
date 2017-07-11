using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Date
{
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\SUSMOY\Documents\Visual Studio 2010\Projects\Date\Date\datetime.mdf;Integrated Security=True");
        
        public Form1()
        {
            InitializeComponent();
        }
        public void view()
        {


            con.Open();
            SqlDataAdapter SDA = new SqlDataAdapter("select *from date_time", con);
            DataTable data = new DataTable();
            SDA.Fill(data);

            dataGridView1.DataSource = data;
            con.Close();


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            view();
            textBox1.Text = DateTime.Now.ToLongTimeString();
            textBox2.Visible = false;
        }


        public void Create()
        {
            con.Open();
            SqlDataAdapter SDA = new SqlDataAdapter("insert into date_time (Date,Time) values ('" + dateTimePicker1.Text + "','" + textBox1.Text + "')", con);
            SDA.SelectCommand.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Save successfully");
            view();





        }

        private void button1_Click(object sender, EventArgs e)
        {
            Create();
        }

        public void update()
        {

            con.Open();
            SqlDataAdapter SDA = new SqlDataAdapter("update date_time set Date='" + dateTimePicker1.Text + "',Time='" + textBox1.Text + "' Where Id='" + textBox2.Text + "'", con);
            SDA.SelectCommand.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Updated successfully");
            view();


        }




        private void button2_Click(object sender, EventArgs e)
        {

            update();
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                int idx = dataGridView1.SelectedRows[0].Index;

                textBox2.Text = dataGridView1.Rows[idx].Cells[0].Value.ToString();
               dateTimePicker1.Text = dataGridView1.Rows[idx].Cells[1].Value.ToString();
                textBox1.Text = dataGridView1.Rows[idx].Cells[2].Value.ToString();
               
            }
        }


        public void delete()
        {

            con.Open();
            SqlDataAdapter SDA = new SqlDataAdapter("delete from date_time Where Id='" + textBox2.Text + "'", con);
            SDA.SelectCommand.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Delete successfully");
            view();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            delete();
           
        }
    }
}
