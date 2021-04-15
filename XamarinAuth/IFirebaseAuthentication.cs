using System.Threading.Tasks;

namespace XamarinAuth
{
    public interface IFirebaseAuthentication
    {
        Task<string> Login(string email, string password);
        Task<string> Register(string email, string password);
        void Logout();
        bool IsUserLoggedIn();
    }
}
