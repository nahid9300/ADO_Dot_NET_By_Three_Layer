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
    public partial class CustomerUI : Form
    {
        CustomerManager _customerManager = new CustomerManager();
        public CustomerUI()
        {
            InitializeComponent();
            showDataGrid.DataSource = _customerManager.Show();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if (_customerManager.IsNameExists(customerNameBox.Text))
            {
                MessageBox.Show("Customer Already Exist");
            }
            else
            {
                _customerManager.Insert(customerNameBox.Text, cellBox.Text, addressBox.Text);
                showDataGrid.DataSource = _customerManager.Show();
            }
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            _customerManager.Update(customerNameBox.Text, cellBox.Text, addressBox.Text, Convert.ToInt32(searchTextBox.Text));
            showDataGrid.DataSource = _customerManager.Show();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            _customerManager.Delete(searchTextBox.Text);
            showDataGrid.DataSource = _customerManager.Show();
        }

        private void showButton_Click(object sender, EventArgs e)
        {
            showDataGrid.DataSource = _customerManager.Show();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            showDataGrid.DataSource = _customerManager.Search(searchTextBox.Text);
        }


    }
}
