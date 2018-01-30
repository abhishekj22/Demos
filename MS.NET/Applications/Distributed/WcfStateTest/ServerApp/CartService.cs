namespace ServerApp
{
    using Shopping;
    using System.ServiceModel;

    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
    public class CartService : ICart
    {
        private double payment;

        public void AddItem(string item)
        {
            int id = Store.Find(item);

            if(id < 0)
            {
                MissingItem mi = new MissingItem();
                mi.ItemName = item;
                mi.IsOutOfStock = false;
                throw new FaultException<MissingItem>(mi);
            }

            payment += 1.06 * Store.PriceOf(id);
        }

        public double Checkout()
        {
            return payment;
        }
    }
}
