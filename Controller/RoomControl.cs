using AppDatabase;
using AppModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppController
{
    public class RoomControl : IRoomControl
    {
        private readonly IDatabase database;
        public RoomControl(IDatabase database)
        {
            this.database = database;
        }
        public async Task<bool> Create(Room room)
        {
            string id = JsonConvert.SerializeObject(room.Id);
            string value = JsonConvert.SerializeObject(room);
            var isCreated = await database.Create("Rooms", id, value);
            return isCreated;
        }
        public async Task<Room> Read(string key)
        {
            string id = JsonConvert.SerializeObject(key);
            var data = await database.Read("Rooms", id);
            if (data.Value != "")
            {
                var room = JsonConvert.DeserializeObject<Room>(data.Value);
                return room ?? new Room();
            }
            return new Room();
        }
        public async Task<List<Room>> ReadAll()
        {
            List<Room> roomList = new();
            var data = await database.ReadAll("Rooms");
            if (data.Count() > 0)
            {
                foreach (var d in data)
                {
                    var rooms = JsonConvert.DeserializeObject<Room>(d.Value);
                    if (rooms != null)
                    {
                        roomList.Add(rooms);
                    }
                }
            }
            return roomList;
        }
        public async Task<bool> AddBookedRooms(string roomId, bool isBooked)
        {
            string id = JsonConvert.SerializeObject(roomId);
            string value = JsonConvert.SerializeObject(isBooked);
            var isAdded = await database.Create("BookedRooms", id, value);
            return isAdded;
        }
        public async Task<List<string>> GetBookedRooms()
        {
            List<string> bookedRooms = new();
            var data = await database.ReadAll("BookedRooms");
            if (data.Count() > 0)
            {
                foreach (var d in data)
                {
                    var roomId = JsonConvert.DeserializeObject<string>(d.Key);
                    var isBooked = JsonConvert.DeserializeObject<bool>(d.Value);
                    if (!string.IsNullOrWhiteSpace(roomId) && isBooked)
                    {
                        bookedRooms.Add(roomId);
                    }
                }
            }
            return bookedRooms;
        }
        public async Task<bool> AddCategory(string category, int price)
        {
            string cat = JsonConvert.SerializeObject(category);
            string value = JsonConvert.SerializeObject(price);
            var isAdded = await database.Create("Category", cat, value);
            return isAdded;
        }
        public async Task<bool> DeleteCategory(string key)
        {
            string id = JsonConvert.SerializeObject(key);
            var isDeleted = await database.Delete("Category", id);
            return isDeleted;
        }
        public async Task<List<KeyValuePair<string,int>>> ReadAllCategory()
        {
            List<KeyValuePair<string, int>> categoryList = new();
            var data = await database.ReadAll("Category");
            if (data.Count() > 0)
            {
                foreach (var d in data)
                {
                    var cat = JsonConvert.DeserializeObject<string>(d.Key);
                    int price = JsonConvert.DeserializeObject<int>(d.Value);
                    if (!string.IsNullOrEmpty(cat))
                    {
                        categoryList.Add(new KeyValuePair<string, int>(cat,price));
                    }
                }
            }
            return categoryList;
        }
        public async Task<bool> Delete(string key)
        {
            string id = JsonConvert.SerializeObject(key);
            var isDeleted = await database.Delete("Rooms", id);
            return isDeleted;
        }
    }
}
