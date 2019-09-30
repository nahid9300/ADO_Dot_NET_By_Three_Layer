using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeShopByADO.NET.Repository;


namespace CoffeeShopByADO.BLL
{
    public class ItemManager
    {
        ItemRepository _itemObject=new ItemRepository();
        public bool Insert(string name, int price)
        {
            return _itemObject.Insert(name,price);
        }

        public bool Delete(int id)
        {
            return _itemObject.Delete(id);
        }

        public DataTable Show()
        {
           return _itemObject.Show();
        }

        public bool Update(string name, int price, string id)
        {
            return _itemObject.Update(name,price,id);
        }

        public DataTable Search(string name)
        {
            return _itemObject.Search(name);
        }

        public bool IsNameExists(string name)
        {
            return _itemObject.IsNameExists(name);
        }
    }
}
