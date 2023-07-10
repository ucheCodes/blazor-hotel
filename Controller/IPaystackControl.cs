using AppModels;

namespace AppController
{
    public interface IPaystackControl
    {
        Task<bool> AddPaystackTransaction(PaystackTransaction transaction);
        Task<bool> AddTransactionInfoToDatabase(TransactionInfo info);
        Task<dynamic> Checkout(string customerEmail, int amount, string publicKey, string secretKey);
        Task<bool> DeletePaystackTransaction(string id);
        Task<bool> DeleteTransactionInfo(string reference);
        Task<List<PaystackTransaction>> GetPaystackTransactions();
        Task<List<TransactionInfo>> GetAllTransactionInfo();
    }
}