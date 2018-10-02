using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public interface ICustomersLogic
    {
        IEnumerable<Customers> GetAll();

        Customers GetCustomer(string customerID);

        void AddCustomer(Customers customer);

        void UpdateCustomer(Customers customer);

        void DeleteCustomer(string customerID);
    }
}
