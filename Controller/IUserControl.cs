using AppModels;

namespace AppController
{
    public interface IUserControl
    {
        Task<bool> Create(Users user);
        bool IsEmailRegistered();
        void LogUser(Users user);
        Task<Users> Read(string key);
        Task<List<Users>> ReadAll();
    }
}