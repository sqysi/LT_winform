using System.Collections.Generic;
using System.Data.SqlClient;

namespace ADO
{
    public class CustomerDAL
    {
        // Hàm t?o k?t n?i dùng chung
        private SqlConnection CreateConnection()
        {
            return new SqlConnection("Data Source=QYS\\SYQUYS;Database=sale; Integrated Security=SSPI");
        }

        // 1. L?y danh sách
        public List<CustomerBEL> ReadCustomer()
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from customer", conn);
            SqlDataReader reader = cmd.ExecuteReader();

            List<CustomerBEL> lstCus = new List<CustomerBEL>();
            while (reader.Read())
            {
                CustomerBEL cus = new CustomerBEL();
                cus.Id = int.Parse(reader["id"].ToString());
                cus.Name = reader["name"].ToString();
                lstCus.Add(cus);
            }
            conn.Close();
            return lstCus;
        }

        // 2. Thêm
        public void AddCustomer(CustomerBEL cus)
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("insert into customer values(@id, @name)", conn);
            cmd.Parameters.Add(new SqlParameter("@id", cus.Id));
            cmd.Parameters.Add(new SqlParameter("@name", cus.Name));
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        // 3. Xóa
        public void DeleteCustomer(CustomerBEL cus)
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("delete from customer where id = @id", conn);
            cmd.Parameters.Add(new SqlParameter("@id", cus.Id));
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        // 4. S?a
        public void EditCustomer(CustomerBEL cus)
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("update customer set name = @name where id = @id", conn);
            cmd.Parameters.Add(new SqlParameter("@id", cus.Id));
            cmd.Parameters.Add(new SqlParameter("@name", cus.Name));
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}