# XamarinAuth
Prototype of mobile application using Firebase as a user authentication mechanism.

## Method declarations
### XamarinAuth
- `IFirebaseAuthentication.cs` - implements an interface utilizing methods declared in `FirebaseAuthentication.cs`
- `IApplicationKiller.cs` - interface utilizing methods declared in `ApplicationKiller.cs`
### XamarinAuth.Android
- `FirebaseAuthentication.cs` - class containing methods responsible for performing async authentication tasks such as Login or Register
- `ApplicationKillier` - class containing methods responsible for killing application process

