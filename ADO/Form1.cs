using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace ADO
{
    public partial class dgvCustomer : Form
    {
        public dgvCustomer()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=QYS\\SYQUYS;Database=sale; Integrated Security=SSPI");
            conn.Open();
            SqlCommand cmd = new SqlCommand("insert into customer values(3,'Ho Si Quy')", conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=QYS\\SYQUYS;Database=sale; Integrated Security=SSPI");
            conn.Open();
            SqlCommand cmd = new SqlCommand("delete from customer where id = 3", conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=QYS\\SYQUYS;Database=sale; Integrated Security=SSPI");
            conn.Open();
            SqlCommand cmd = new SqlCommand("update customer set name = 'HoSiQuy' where id = 3", conn);
            cmd.ExecuteNonQuery();
            conn.Close();

        }
        private void button4_Click(object sender, EventArgs e)
        {

            dgvCustomers.Rows.Clear();
            
            SqlConnection conn = new SqlConnection("Data Source=QYS\\SYQUYS;Database=sale; Integrated Security=SSPI");
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from customer", conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                dgvCustomers.Rows.Add(reader.GetInt32(0), reader.GetString(1));
            }
            conn.Close();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
