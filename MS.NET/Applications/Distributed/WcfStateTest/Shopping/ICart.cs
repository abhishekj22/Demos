﻿namespace Shopping
{
    using System.ServiceModel;

    [ServiceContract(SessionMode = SessionMode.Required)]
    public interface ICart
    {
        [OperationContract]
        [FaultContract(typeof(MissingItem))]
        void AddItem(string item);

        [OperationContract(IsTerminating = true)]
        double Checkout();
    }
}
