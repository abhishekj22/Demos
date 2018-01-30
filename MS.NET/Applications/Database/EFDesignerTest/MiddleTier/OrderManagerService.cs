using System;

namespace MiddleTier
{
    using Sales;
    using System.ServiceModel;

    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class OrderManagerService : IOrderManager
    {
        [OperationBehavior(TransactionScopeRequired = true)]
        public int AcceptOrder(string customerId, int productNo, int quantity)
        {
            using (var shop = new ShopEntities())
            {
                Counter ctr = shop.Counters.Find("order");
                OrderDetail entry = new OrderDetail
                {
                    OrderNo = ++ctr.CurrentValue + 1000,
                    OrderDate = DateTime.Today,
                    CustomerId = customerId,
                    ProductNo = productNo,
                    Quantity = quantity
                };

                shop.OrderDetails.Add(entry);
                shop.SaveChanges();

                return entry.OrderNo;
            }
        }

        [OperationBehavior(TransactionScopeRequired = true)]
        public decimal DispatchOrder(int orderNo)
        {
            using (var shop = new ShopEntities())
            {
                OrderDetail order = shop.OrderDetails.Find(orderNo);
                Product product = shop.Products.Find(order.ProductNo);

                product.Stock -= order.Quantity;
                shop.SaveChanges();

                return order.Quantity * product.Price;
            }
        }
    }
}
