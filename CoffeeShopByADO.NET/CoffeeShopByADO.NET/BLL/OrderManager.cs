using CoffeeShopByADO.NET.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShopByADO.NET.BLL
{
    public class OrderManager
    {
        OrderRepository _orderRepository = new OrderRepository();

        public bool Insert(string orderedName, int quantity)
        {
            return _orderRepository.Insert(orderedName, quantity);
        }

        public bool update(string orderedName, int quantity, string id)
        {
            return _orderRepository.update(orderedName, quantity, id);
        }

        public bool Delete(int id)
        {
            return _orderRepository.Delete(id);
        }

        public DataTable Show()
        {
            return _orderRepository.Show();
        }

        public DataTable Search(string search)
        {
            return _orderRepository.Search(search);
        }

    }
}
