﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DBWebApp.Protected
{
    public partial class Order : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CustomerIdLabel.Text = User.Identity.Name;
        }

        protected void OrderButton_Click(object sender, EventArgs e)
        {
            string customerId = CustomerIdLabel.Text;
            int productNo = int.Parse(ProductNoDropDownList.Text);
            int quantity = int.Parse(QuantityTextBox.Text);
            int? orderNo = 0;

            using (var shop = new Models.ShopDataSetTableAdapters.CustomerSupport())
                shop.SubmitNewOrder(customerId, productNo, quantity, ref orderNo);

            ResultLabel.Text = $"New order number is {orderNo}";
        }
    }
}