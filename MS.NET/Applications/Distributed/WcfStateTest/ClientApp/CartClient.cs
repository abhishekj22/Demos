﻿using System.Threading.Tasks;

namespace ClientApp
{
    using Shopping;
    using System.ServiceModel;

    public class CartClient : ClientBase<ICart>
    {
        public CartClient() : base("CartHttp")
        {
        }

        public Task AddItemAsync(string item)
        {
            return Task.Run(() => Channel.AddItem(item));
        }

        public Task<double> CheckoutAsync()
        {
            return Task<double>.Run(() => Channel.Checkout());
        }
    }
}
