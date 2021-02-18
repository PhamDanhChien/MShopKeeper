using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.SqlClient;

using MShopkeeper.Models;

namespace MShopkeeper.Controllers
{
    public class CustomerController : ApiController
    {
        // GET: api/Customer            //Get customers
        public List<Customer> Get()
        {
            //Khai báo các đối tượng cần để kết nối
            String connectionString = "Server=DESKTOP-5AKI142;Database=MShopkeeper;Trusted_Connection=True;";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            //Câu lệnh truy vấn
            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            sqlCommand.CommandText = "dbo.Proc_GetCustomers";

            //Mở kết nối đến database
            sqlConnection.Open();

            //Thực thi câu truy vấn
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            //Xử lí dữ liệu trả về
            List<Customer> customerList = new List<Customer>();

            //Đọc từng bản ghi
            while (sqlDataReader.Read())
            {
                Customer cus = new Customer();

                //Đọc từng trường của 1 bản ghi
                for (int i = 0; i < sqlDataReader.FieldCount; i++)
                {
                    //Lấy tên cột và giá trị trong 1 trường của bản ghi
                    var colName = sqlDataReader.GetName(i);
                    var value = sqlDataReader.GetValue(i);

                    //Lấy properti của colName
                    var pro = cus.GetType().GetProperty(colName);

                    //Gán vào giá trị tương ứng
                    if (pro != null)
                    {
                        pro.SetValue(cus, value);
                    }
                }

                customerList.Add(cus);
            }

            //Đóng kết nối đến database
            sqlConnection.Close();

            //Trả về kết quả
            return customerList;
        }

        // GET: api/Customer/5          //Get customer by ID
        public Customer Get(string id)
        {
            //Khai báo các đối tượng cần để kết nối
            String connectionString = "Server=DESKTOP-5AKI142;Database=MShopkeeper;Trusted_Connection=True;";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            //Câu lệnh truy vấn
            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            sqlCommand.CommandText = "dbo.Proc_GetCustomerById";

            //Truyền tham số vào Proc
            sqlCommand.Parameters.AddWithValue("@CustomerId", id);

            //Mở kết nối đến database
            sqlConnection.Open();

            //Thực thi câu truy vấn
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            //Xử lí dữ liệu trả về
            Customer cus = new Customer();

            //Đọc từng bản ghi
            while (sqlDataReader.Read())
            {

                //Đọc từng trường của 1 bản ghi
                for (int i = 0; i < sqlDataReader.FieldCount; i++)
                {
                    //Lấy tên cột và giá trị trong 1 trường của bản ghi
                    var colName = sqlDataReader.GetName(i);
                    var value = sqlDataReader.GetValue(i);

                    //Lấy properti của colName
                    var pro = cus.GetType().GetProperty(colName);

                    //Gán vào giá trị tương ứng
                    if (pro != null)
                    {
                        pro.SetValue(cus, value);
                    }
                }
            }

            //Đóng kết nối đến database
            sqlConnection.Close();

            //Trả về kết quả
            return cus;
        }

        // POST: api/Customer           //Create customer
        public void Post([FromBody]Customer cus)
        {
            //Khai báo các đối tượng cần để kết nối
            String connectionString = "Server=DESKTOP-5AKI142;Database=MShopkeeper;Trusted_Connection=True;";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            //Câu lệnh truy vấn
            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            sqlCommand.CommandText = "dbo.Proc_InsertCustomer";

            //Truyền giá trị vào các biến của Proceduce
            sqlCommand.Parameters.AddWithValue("@CustomerId", cus.CustomerId);
            sqlCommand.Parameters.AddWithValue("@CustomerName", cus.CustomerName);
            sqlCommand.Parameters.AddWithValue("@CustomerPhone", cus.CustomerPhone);
            sqlCommand.Parameters.AddWithValue("@CustomerBirth", cus.CustomerBirth);
            sqlCommand.Parameters.AddWithValue("@CustomerGroup", cus.CustomerGroup);
            sqlCommand.Parameters.AddWithValue("@CustomerNote", cus.CustomerNote);
            sqlCommand.Parameters.AddWithValue("@CustomerState", cus.CustomerState);

            //Mở kết nối đến database
            sqlConnection.Open();

            //Thực thi command
            var result = sqlCommand.ExecuteNonQuery();

            //Đóng kết nối
            sqlConnection.Close();
        }

        // PUT: api/Customer/5          //Edit customer         
        public void Put(Customer cus)
        {
            //Khai báo các đối tượng cần để kết nối
            String connectionString = "Server=DESKTOP-5AKI142;Database=MShopkeeper;Trusted_Connection=True;";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            //Câu lệnh truy vấn
            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            sqlCommand.CommandText = "dbo.Proc_EditCustomer";

            //Truyền giá trị vào các biến của Proceduce
            sqlCommand.Parameters.AddWithValue("@CustomerId", cus.CustomerId);
            sqlCommand.Parameters.AddWithValue("@CustomerName", cus.CustomerName);
            sqlCommand.Parameters.AddWithValue("@CustomerPhone", cus.CustomerPhone);
            sqlCommand.Parameters.AddWithValue("@CustomerBirth", cus.CustomerBirth);
            sqlCommand.Parameters.AddWithValue("@CustomerGroup", cus.CustomerGroup);
            sqlCommand.Parameters.AddWithValue("@CustomerNote", cus.CustomerNote);
            sqlCommand.Parameters.AddWithValue("@CustomerState", cus.CustomerState);

            //Mở kết nối đến database
            sqlConnection.Open();

            //Thực thi command
            var result = sqlCommand.ExecuteNonQuery();

            //Đóng kết nối
            sqlConnection.Close();
        }

        // DELETE: api/Customer/5       // Delete customer
        public void Delete(string id)
        {
            //Khai báo các đối tượng cần để kết nối
            String connectionString = "Server=DESKTOP-5AKI142;Database=MShopkeeper;Trusted_Connection=True;";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            //Câu lệnh truy vấn
            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            sqlCommand.CommandText = "dbo.Proc_DeleteCustomer";

            //Truyền giá trị vào các biến của Proceduce
            sqlCommand.Parameters.AddWithValue("@CustomerId", id);

            //Mở kết nối đến database
            sqlConnection.Open();

            //Thực thi command
            sqlCommand.ExecuteNonQuery();

            //Đóng kết nối
            sqlConnection.Close();
        }
    }
}
