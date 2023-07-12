using AppModels;
using AppStore;

namespace AppStore
{
    public interface IStore
    {
        void SetUser(Users user, string status);
        void AddStateChangedAction(Action? _action);
        void BroadcastChange();
        void SetEditingValue(int index, string value);
        void RemoveStateChangedAction(Action? _action);
        void AddCustomers(List<Users> users);
        void ShowLoginDialog(bool show);
        void ChangeNoticationCount(int count);
        Task<bool> AddBookingDataToDatabase(BookingData data);
        Task<List<BookingData>> ReadAllBookingData();
        State State();
    }
}