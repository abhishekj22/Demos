namespace Shopping
{
    using System.ServiceModel;

    [ServiceContract]
    public interface IShopKeeper
    {
        [OperationContract]
        float GetBulkDiscount(int quantity);

        [OperationContract]
        ItemInfo GetItemInfo(string item);
    }
}
