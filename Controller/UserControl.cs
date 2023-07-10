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
    public class UserControl : IUserControl
    {
        private readonly IDatabase database;
        public UserControl(IDatabase db)
        {
            database = db;
        }
        public async Task<bool> Create(Users user)
        {
            string id = JsonConvert.SerializeObject(user.Id);
            string value = JsonConvert.SerializeObject(user);
            var isCreated = await database.Create("Users", id, value);
            return isCreated;
        }
        public async Task<Users> Read(string key)
        {
            string id = JsonConvert.SerializeObject(key);
            var data = await database.Read("Users", id);
            if (data.Value != "")
            {
                var user = JsonConvert.DeserializeObject<Users>(data.Value);
                return user ?? new Users();
            }
            return new Users();
        }
        public async Task<List<Users>> ReadAll()
        {
            List<Users> userList = new List<Users>();
            var data = await database.ReadAll("Users");
            if (data.Count() > 0)
            {
                foreach (var d in data)
                {
                    var user = JsonConvert.DeserializeObject<Users>(d.Value);
                    if (user != null)
                    {
                        userList.Add(user);
                    }
                }
            }
            return userList;
        }
        public void LogUser(Users user)
        {
            //use linq any to find out if email is registered
            //compare this parameters to state customer users
        }
        public bool IsEmailRegistered()
        {
            return false;
        }
    }
}
