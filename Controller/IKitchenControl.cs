using AppModels;

namespace AppController
{
    public interface IKitchenControl
    {
        Task<bool> Create(Food food);
        Task<bool> Delete(string key);
        Task<Food> Read(string key);
        Task<bool> AddKitchenOrder(KitchenOrder order);
        Task<List<KitchenOrder>> ReadAllKitchenOrder();
        Task<List<Food>> ReadAll();
    }
}