namespace AppController
{
    using AppDatabase;
    using AppModels;
    using AppStore;
    using Newtonsoft.Json;

    public class NotificationControl : INotificationControl
    {
        private readonly IDatabase database;
        public NotificationControl(IDatabase db)
        {
            database = db;
        }
        public async Task<bool> AddNotification(string message, bool is4Admin, string department)
        {
            Notifications notif = new Notifications()
            {
                Date = DateTime.Now,
                Message = message,
                Is4Admin = is4Admin,
                Department = department,
                Id = Guid.NewGuid().ToString()
            };
            var isCreated = await Create(notif);
            return isCreated;
        }
        public async Task<bool> Create(Notifications notif)
        {
            string id = JsonConvert.SerializeObject(notif.Id);
            string value = JsonConvert.SerializeObject(notif);
            var isCreated = await database.Create("Notifications", id, value);
            return isCreated;
        }
        public async Task<List<Notifications>> ReadAll()
        {
            List<Notifications> notifList = new();
            var data = await database.ReadAll("Notifications");
            if (data.Count() > 0)
            {
                foreach (var d in data)
                {
                    var notif = JsonConvert.DeserializeObject<Notifications>(d.Value);
                    if (notif != null)
                    {
                        notifList.Add(notif);
                    }
                }
            }
            return notifList;
        }
    }
}