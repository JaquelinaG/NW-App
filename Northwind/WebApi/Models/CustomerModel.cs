using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class CustomerModel
    {
        public CustomerModel(Customers customer)
        {
            this.CustomerID = customer.CustomerID;
            this.CompanyName = customer.CompanyName;
            this.ContactName = customer.ContactName;
        }

        [Key]
        public string CustomerID { get; set; }
                
        public string CompanyName { get; set; }
                
        public string ContactName { get; set; }
    }
}