using Android.Gms.Extensions;
using Firebase.Auth;
using XamarinAuth.Droid;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Dependency(typeof(FirebaseAuthentication))]
namespace XamarinAuth.Droid
{
    public class FirebaseAuthentication : IFirebaseAuthentication
    {
        public async Task<string> Login(string email, string password)
        {
            var user = await FirebaseAuth.Instance.SignInWithEmailAndPasswordAsync(email, password);
            var token = await user.User.GetIdToken(false).AsAsync<GetTokenResult>();
            return token.Token;
        }

        public async Task<string> Register(string email, string password)
        {
            var user = await FirebaseAuth.Instance.CreateUserWithEmailAndPasswordAsync(email, password);
            var token = await user.User.GetIdToken(false).AsAsync<GetTokenResult>();
            return token.Token;
        }

        public void Logout()
        {
            FirebaseAuth.Instance.SignOut();
        }

        public bool IsUserLoggedIn()
        {
            var user = FirebaseAuth.Instance.CurrentUser;
            if(user == null)
            {
                return false;
            } else
            {
                return true;
            }
        }
    }
}