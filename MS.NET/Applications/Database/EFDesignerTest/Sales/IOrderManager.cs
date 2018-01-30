namespace Sales
{
    using System.ServiceModel;

    [ServiceContract]
    public interface IOrderManager
    {
        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        int AcceptOrder(string customerId, int productNo, int quantity);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        decimal DispatchOrder(int orderNo);
    }
}
