using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Services
{
    public class CustomersService
    {
        public IEnumerable<Customers> GetAll()
        {
            using (var context = new Context())
            {
                return context.Customers.ToList();
            }
        }

        public Customers GetCustomer(string customerID)
        {
            using (var context = new Context())
            {
                return context.Customers.Find(customerID);
            }
        }

        public void AddCustomer(Customers customer)
        {
            using (var context = new Context())
            {
                context.Customers.Add(customer);
                context.SaveChanges();
            }
        }

        public void UpdateCustomer(Customers customer)
        {
            using (var context = new Context())
            {
                var customerDb = context.Customers.Find(customer.CustomerID);
                customerDb.CompanyName = customer.CompanyName;
                customerDb.ContactName = customer.ContactName;

                context.SaveChanges();
            }
        }

        public void DeleteCustomer(string customerID)
        {
            using (var context = new Context())
            {
                var customerDb = context.Customers.Find(customerID);

                context.Customers.Remove(customerDb);
                context.SaveChanges();
            }
        }
    }
}
