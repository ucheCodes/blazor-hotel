using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppController;
using AppDatabase;
using AppModels;
using Newtonsoft.Json;
namespace AppController
{
    public class KitchenControl : IKitchenControl
    {
        private readonly IDatabase database;
        public KitchenControl(IDatabase database)
        {
            this.database = database;
        }
        public async Task<bool> AddKitchenOrder(KitchenOrder order)
        {
            string id = JsonConvert.SerializeObject(order.Id);
            string value = JsonConvert.SerializeObject(order);
            var isCreated = await database.Create("KitchenOrder", id, value);
            return isCreated;
        }
        public async Task<List<KitchenOrder>> ReadAllKitchenOrder()
        {
            List<KitchenOrder> orderList = new();
            var data = await database.ReadAll("KitchenOrder");
            if (data.Count() > 0)
            {
                foreach (var d in data)
                {
                    var order = JsonConvert.DeserializeObject<KitchenOrder>(d.Value);
                    if (order != null)
                    {
                        orderList.Add(order);
                    }
                }
            }
            return orderList;
        }
        public async Task<bool> Create(Food food)
        {
            string id = JsonConvert.SerializeObject(food.Id);
            string value = JsonConvert.SerializeObject(food);
            var isCreated = await database.Create("Food", id, value);
            return isCreated;
        }
        public async Task<Food> Read(string key)
        {
            string id = JsonConvert.SerializeObject(key);
            var data = await database.Read("Food", id);
            if (data.Value != "")
            {
                var food = JsonConvert.DeserializeObject<Food>(data.Value);
                return food ?? new Food();
            }
            return new Food();
        }
        public async Task<List<Food>> ReadAll()
        {
            List<Food> foodList = new ();
            var data = await database.ReadAll("Food");
            if (data.Count() > 0)
            {
                foreach (var d in data)
                {
                    var food = JsonConvert.DeserializeObject<Food>(d.Value);
                    if (food != null)
                    {
                        foodList.Add(food);
                    }
                }
            }
            return foodList;
        }
        public async Task<bool> Delete(string key)
        {
            string id = JsonConvert.SerializeObject(key);
            var isDeleted = await database.Delete("Food", id);
            return isDeleted;
        }
    }
}
