using AppModels;

namespace AppController
{
    public interface INotificationControl
    {
        Task<bool> Create(Notifications notif);
        Task<List<Notifications>> ReadAll();
        Task<bool> AddNotification(string message, bool is4Admin, string department);
    }
}