using System;
using Xamarin.Forms;

namespace XamarinAuth
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private string _email = "";
        private string _password = "";
        private bool _isLoggedIn = false;

        private async void OnLoginButtonClicked(object sender, EventArgs e)
        {
            IsBusy = true;

            _email = this.FindByName<Entry>("email").Text;
            _password = this.FindByName<Entry>("password").Text;

            if (String.IsNullOrWhiteSpace(_email))
            {
                await Application.Current.MainPage.DisplayAlert("Błąd walidacji", "Pole z adresem email nie może być puste", "OK");
                return;
            }

            if (String.IsNullOrWhiteSpace(_password))
            {
                await Application.Current.MainPage.DisplayAlert("Błąd walidacji", "Pole z hasłem nie może być puste", "OK");
                return;
            }

            try
            {
                IFirebaseAuthentication auth = DependencyService.Get<IFirebaseAuthentication>();
                string token = await auth.Login(_email, _password);
                await Application.Current.MainPage.DisplayAlert("Sukces logowania", $"Adres email: {_email}\nHasło: {_password}", "Noice");
                _isLoggedIn = auth.IsUserLoggedIn();
                if (_isLoggedIn)
                {
                    this.FindByName<Button>("logoutButton").IsVisible = true;
                }
            } catch(Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Błąd logowania", $"Wystąpił problem podczas logowania: {ex.Message}", "OK");
            }

            ChangeButtonVisibility();

            IsBusy = false;
        }

        private async void OnRegisterButtonClicked(object sender, EventArgs e)
        {
            IsBusy = true;

            _email = this.FindByName<Entry>("email").Text;
            _password = this.FindByName<Entry>("password").Text;

            if (String.IsNullOrWhiteSpace(_email))
            {
                await Application.Current.MainPage.DisplayAlert("Błąd walidacji", "Pole z adresem email nie może być puste", "OK");
                return;
            }

            if (String.IsNullOrWhiteSpace(_password))
            {
                await Application.Current.MainPage.DisplayAlert("Błąd walidacji", "Pole z hasłem nie może być puste", "OK");
                return;
            }

            try
            {
                IFirebaseAuthentication auth = DependencyService.Get<IFirebaseAuthentication>();
                string token = await auth.Register(_email, _password);
                await Application.Current.MainPage.DisplayAlert("Sukces rejestracji", $"Adres email: {_email}\nHasło: {_password}", "Noice");
                _isLoggedIn = auth.IsUserLoggedIn();
            } catch(Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Błąd rejestracji", $"Wystąpił problem podczas rejestracji: {ex.Message}", "OK");
            }

            ChangeButtonVisibility();

            IsBusy = false;
        }

        private void OnLogoutButtonClicked(object sender, EventArgs e)
        {
            IsBusy = true;

            try
            {
                IFirebaseAuthentication auth = DependencyService.Get<IFirebaseAuthentication>();
                auth.Logout();
                _isLoggedIn = false;
                this.FindByName<Entry>("email").Text = "";
                this.FindByName<Entry>("password").Text = "";
                _email = _password = "";
            } catch(Exception ex)
            {
                Application.Current.MainPage.DisplayAlert("Błąd wylogowania", $"Wystąpił problem podczas wylogowania: {ex.Message}", "OK");
            }

            ChangeButtonVisibility();

            IsBusy = false;
        }

        private void OnExitButtonClicked(object sender, EventArgs e)
        {
            IApplicationKiller applicationKiller = DependencyService.Get<IApplicationKiller>();
            applicationKiller.CloseApplication();
        }

        private void ChangeButtonVisibility()
        {
            if(_isLoggedIn)
            {
                this.FindByName<Button>("logoutButton").IsVisible = true;
                this.FindByName<Button>("loginButton").IsVisible = false;
                this.FindByName<Button>("registerButton").IsVisible = false;
            } else
            {
                this.FindByName<Button>("logoutButton").IsVisible = false;
                this.FindByName<Button>("loginButton").IsVisible = true;
                this.FindByName<Button>("registerButton").IsVisible = true;
            }
        }
    }
}
