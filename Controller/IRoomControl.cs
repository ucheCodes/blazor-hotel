using AppModels;

namespace AppController
{
    public interface IRoomControl
    {
        Task<bool> Create(Room room);
        Task<bool> Delete(string key);
        Task<Room> Read(string key);
        Task<List<Room>> ReadAll();
        Task<List<KeyValuePair<string, int>>> ReadAllCategory();
        Task<bool> AddCategory(string category, int amount);
        Task<List<string>> GetBookedRooms();
        Task<bool> AddBookedRooms(string roomId, bool isBooked);
    }
}