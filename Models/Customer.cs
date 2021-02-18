using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MShopkeeper.Models
{
    public class Customer
    {
        public static List<Customer> customers = new List<Customer>()
        {
            new Customer(){CustomerId = "001", CustomerName = "Phạm Danh Chiến", CustomerPhone = "0329524125", CustomerBirth = "16/11/1999", CustomerGroup = "Khách mới", CustomerNote = "", CustomerState= "Đang theo dõi" },
            new Customer(){CustomerId = "002", CustomerName = "Chu Hoàng Long", CustomerPhone = "0329524125", CustomerBirth = "16/11/1999", CustomerGroup = "Khách mới", CustomerNote = "", CustomerState= "Đang theo dõi" },
            new Customer(){CustomerId = "003", CustomerName = "Phạm Danh Chiến", CustomerPhone = "0329524125", CustomerBirth = "16/11/1999", CustomerGroup = "Khách mới", CustomerNote = "", CustomerState= "Đang theo dõi" },
            new Customer(){CustomerId = "004", CustomerName = "Phạm Danh Chiến", CustomerPhone = "0329524125", CustomerBirth = "16/11/1999", CustomerGroup = "Khách mới", CustomerNote = "", CustomerState= "Đang theo dõi" }
        };

        public string CustomerId { get; set; }

        public string CustomerName { get; set; }

        public string CustomerPhone { get; set; }

        public string CustomerBirth { get; set; }

        public string CustomerGroup { get; set; }

        public string CustomerNote { get; set; }

        public string CustomerState { get; set; }
    }
}