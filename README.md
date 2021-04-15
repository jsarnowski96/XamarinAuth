# XamarinAuth
Prototype of mobile application using Firebase as a user authentication mechanism.

## Methods declarations
### XamarinAuth
- `IFirebaseAuthentication.cs` - implements an interface utilizing methods declared in `FirebaseAuthentication.cs`
- `IApplicationKiller.cs` - interface utilizing methods declared in `ApplicationKiller.cs`
### XamarinAuth.Android
- `FirebaseAuthentication.cs` - class containing methods responsible for performing async authentication tasks such as Login or Register
- `ApplicationKiller` - class containing methods responsible for killing application process
<br />

## `FirebaseAuthentication` methods
### Login()
```
public async Task<string> Login(string email, string password)
{
  var user = await FirebaseAuth.Instance.SignInWithEmailAndPasswordAsync(email, password);
  var token = await user.User.GetIdToken(false).AsAsync<GetTokenResult>();
  return token.Token;
}
```

### Register()
```
public async Task<string> Register(string email, string password)
{
  var user = await FirebaseAuth.Instance.CreateUserWithEmailAndPasswordAsync(email, password);
  var token = await user.User.GetIdToken(false).AsAsync<GetTokenResult>();
  return token.Token;
}
```

### Logout()
```
public void Logout()
{
  FirebaseAuth.Instance.SignOut();
}
```<br />
## `IFirebaseAuthentication` interface
```
public interface IFirebaseAuthentication
{
  Task<string> Login(string email, string password);
  Task<string> Register(string email, string password);
  void Logout();
  bool IsUserLoggedIn();
}
```
