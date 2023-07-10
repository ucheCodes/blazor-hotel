using AppDatabase;
using AppModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AppController
{
    public class PaystackControl : IPaystackControl
    {
        private readonly IDatabase database;
        private HttpClient httpClient;
        public PaystackControl(IDatabase database, HttpClient httpClient)
        {
            this.database = database;
            this.httpClient = httpClient;
        }
        public async Task<bool> AddTransactionInfoToDatabase(TransactionInfo info)
        {
            string id = JsonConvert.SerializeObject(info.Reference);
            string value = JsonConvert.SerializeObject(info);
            var isCreated = await database.Create("TransactionInfo", id, value);
            return isCreated;
        }
        public async Task<List<TransactionInfo>> GetAllTransactionInfo()
        {
            List<TransactionInfo> transactionInfos = new();
            var data = await database.ReadAll("TransactionInfo");
            if (data.Count() > 0)
            {
                foreach (var d in data)
                {
                    var info = JsonConvert.DeserializeObject<TransactionInfo>(d.Value);
                    if (info != null)
                    {
                        transactionInfos.Add(info);
                    }
                }
            }
            return transactionInfos;
        }
        public async Task<bool> DeleteTransactionInfo(string reference)
        {
            string key = JsonConvert.SerializeObject(reference);
            var isDeleted = await database.Delete("TransactionInfo", key);
            return isDeleted;
        }
        //paystack
        public async Task<bool> AddPaystackTransaction(PaystackTransaction transaction)
        {
            var id = JsonConvert.SerializeObject(transaction.Reference);
            var value = JsonConvert.SerializeObject(transaction);
            var isCreated = await database.Create("PaystackTransaction", id, value);
            return isCreated;
        }
        public async Task<List<PaystackTransaction>> GetPaystackTransactions()
        {
            List<PaystackTransaction> pt = new();
            var data = await database.ReadAll("PaystackTransaction");
            if (data.Count() > 0)
            {
                foreach (var d in data)
                {
                    var _pt = JsonConvert.DeserializeObject<PaystackTransaction>(d.Value);
                    if (_pt != null)
                    {
                        pt.Add(_pt);
                    }
                }
            }
            return pt;
        }
        public async Task<bool> DeletePaystackTransaction(string id)
        {
            string key = JsonConvert.SerializeObject(id);
            var isDeleted = await database.Delete("PaystackTransaction", key);
            return isDeleted;
        }
        public async Task<dynamic> Checkout(string customerEmail, int amount, string publicKey, string secretKey)
        {
            //make sure to validate and test that email is valid
            dynamic responseObject = "";
            if (!string.IsNullOrEmpty(secretKey) && !string.IsNullOrWhiteSpace(publicKey))
            {
                var _data = new PaystackData()
                {
                    amount = amount * 100, //in kobo
                    email = customerEmail,
                    key = publicKey
                };
                string data = JsonConvert.SerializeObject(_data);

                // Send POST request to Paystack API with data and header// https://api.paystack.co/transaction/initialize
                string paystackAuthorizationUrl = string.Empty;
                bool isSuccess = false;
                try
                {
                    using (var request = new HttpRequestMessage(HttpMethod.Post, "https://api.paystack.co/transaction/initialize"))
                    {
                        request.Headers.Add("Authorization", $"Bearer {secretKey}");
                        var content = new StringContent(data, Encoding.UTF8, "application/json");
                        request.Content = content;

                        var response = await httpClient.SendAsync(request);
                        isSuccess = response.IsSuccessStatusCode;
                        if (response.IsSuccessStatusCode)
                        {
                            string responseContent = await response.Content.ReadAsStringAsync();
                            if (responseContent != null)
                            {
                                responseObject = JsonConvert.DeserializeObject<dynamic>(responseContent) ?? "";
                                paystackAuthorizationUrl = responseObject.data.authorization_url;
                            }
                        }
                    }
                }
                catch (Exception)
                {

                    responseObject = "";
                }
            }
            return responseObject;
        }
    }
}
