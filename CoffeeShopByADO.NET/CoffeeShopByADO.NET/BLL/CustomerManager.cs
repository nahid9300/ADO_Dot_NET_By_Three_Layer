using CoffeeShopByADO.NET.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShopByADO.NET.BLL
{
    public class CustomerManager
    {
        CustomerRepository _customerRepository = new CustomerRepository();

        public bool Insert(string customerName, string cell, string address)
        {
            return _customerRepository.Insert(customerName, cell, address);
        }

        public bool Update(string customerName, string cell, string address, int id)
        {
            return _customerRepository.Update(customerName, cell, address, id);
        }

        public bool Delete(string id)
        {
            return _customerRepository.Delete(id);
        }

        public DataTable Show()
        {
            return _customerRepository.Show();
        }
        public DataTable Search(string name)
        {
            return _customerRepository.Search(name);
        }
        public bool IsNameExists(string name)
        {
            return _customerRepository.IsNameExists(name);

        }
    }
}
