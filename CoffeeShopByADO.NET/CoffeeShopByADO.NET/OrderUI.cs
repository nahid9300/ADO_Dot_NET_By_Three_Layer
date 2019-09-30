using CoffeeShopByADO.NET.BLL;
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
    public partial class OrderUI : Form
    {
        OrderManager _orderManager = new OrderManager();
        public OrderUI()
        {
            InitializeComponent();
            showDataGrid.DataSource = _orderManager.Show();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            _orderManager.Insert(orderNameBox.Text, Convert.ToInt32(quantityBox.Text));
            showDataGrid.DataSource = _orderManager.Show();

        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            _orderManager.update(orderNameBox.Text, Convert.ToInt32(quantityBox.Text), searchTextBox.Text);
            showDataGrid.DataSource = _orderManager.Show();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            _orderManager.Delete(Convert.ToInt32(searchTextBox.Text));
            showDataGrid.DataSource = _orderManager.Show();
        }

        private void showButton_Click(object sender, EventArgs e)
        {
            showDataGrid.DataSource=_orderManager.Show();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            showDataGrid.DataSource=_orderManager.Search(searchTextBox.Text);
        }


        
        
        
        
        

        
    }
}
