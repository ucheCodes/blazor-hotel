namespace AppStore
{
    using Newtonsoft.Json;
    using AppStore;
    using AppStore.StateVariables;
    using System.Collections.Generic;
    using System.Linq;
    using AppModels;
    using System.IO;
    using AppDatabase;
    using static System.Formats.Asn1.AsnWriter;
    using System.Net.Http;
    using System.Reflection;
    using System.Text;

    public class Store : IStore
    {
        private State state = new State();
        private readonly IDatabase database;
        public Store(IDatabase database)
        {
            this.database = database;
        }
        public State State()
        {
            return state;
        }
        #region Store methods
        //Why did I define this methods here in store instead of room control?
        public async Task<bool> AddBookingDataToDatabase(BookingData data)
        {
           string id = JsonConvert.SerializeObject(data.Id);
            string value = JsonConvert.SerializeObject(data);
            var isCreated = await database.Create("BookingData", id, value);
            return isCreated;
        }
        public async Task<List<BookingData>> ReadAllBookingData()
        {
            List<BookingData> bd = new();
            var data = await database.ReadAll("BookingData");
            if (data.Count() > 0)
            {
                foreach (var d in data)
                {
                    var _bd = JsonConvert.DeserializeObject<BookingData>(d.Value);
                    if (_bd != null)
                    {
                        bd.Add(_bd);
                    }
                }
            }
            return bd;
        }
        #endregion
        #region Mutations
        public void SetEditingValue(int index, string serializedValue)
        {
            state.EditValue = new EditValue(new KeyValuePair<int, string>(index, serializedValue));
            BroadcastChange();
        }
        public void SetUser(Users user, string status)
        {
            state.ActiveUser = new(user);
            if (status == "super")
            {
                state.IsAdmin = new(true, true);
            }
            else if(status == "admin")
            { state.IsAdmin = new(true, false); }
            BroadcastChange();
        }
        public void AddCustomers(List<Users> users)
        {
            state.Customers = new Customers(users);
            BroadcastChange();
        }
        public void ShowLoginDialog(bool show)
        {
            state.ShowLogin = new ShowLoginDialog(show);
            BroadcastChange();
        }
        public void ChangeNoticationCount(int count)
        {
            state.Counter = new NotificationCount(count);
            BroadcastChange();
        }

        #endregion

        #region Observer Patterns
        private Action? action;

        public void AddStateChangedAction(Action? _action)
        {
            action += _action;
        }
        public void RemoveStateChangedAction(Action? _action)
        {
            action -= _action;
        }
        public void BroadcastChange()
        {
            action?.Invoke();
        }
        #endregion
    }
}