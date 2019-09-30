using CoffeeShopByADO.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoffeeShopByADO.NET
{
    public partial class ItemUI : Form
    {
        ItemManager _itemManager = new ItemManager();
        public ItemUI()
        {
            InitializeComponent();
            showDataGrid.DataSource = _itemManager.Show();
        }
        private void addButton_Click(object sender, EventArgs e)
        {
            if (_itemManager.IsNameExists(itemNameBox.Text))
            {
                MessageBox.Show("Item Already Exist");
                
            }
            else
            {
                _itemManager.Insert(itemNameBox.Text, Convert.ToInt32(itemPriceBox.Text));
                showDataGrid.DataSource = _itemManager.Show();
            }
        }
    
    

        private void showButton_Click(object sender, EventArgs e)
        {
            showDataGrid.DataSource = _itemManager.Show();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            _itemManager.Delete(Convert.ToInt32(searchTextBox.Text));
            showDataGrid.DataSource = _itemManager.Show();
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            _itemManager.Update(itemNameBox.Text, Convert.ToInt32(itemPriceBox.Text), searchTextBox.Text);
            showDataGrid.DataSource = _itemManager.Show();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            showDataGrid.DataSource = _itemManager.Search(searchTextBox.Text);

        }


        
        
    }
}
