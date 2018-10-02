using Entities;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class CustomersLogic : ICustomersLogic
    {
        CustomersService service = new CustomersService();

        public IEnumerable<Customers> GetAll()
        {
            return this.service.GetAll();
        }

        public Customers GetCustomer(string customerID)
        {
            return this.service.GetCustomer(customerID);
        }

        public void AddCustomer(Customers customer)
        {
            this.service.AddCustomer(customer);
        }

        public void UpdateCustomer(Customers customer)
        {
            this.service.UpdateCustomer(customer);
        }

        public void DeleteCustomer(string customerID)
        {
            this.service.DeleteCustomer(customerID);
        }
    }
}
