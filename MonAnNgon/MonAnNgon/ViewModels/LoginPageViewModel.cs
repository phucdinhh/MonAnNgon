
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Net.Http;
using System.Windows.Input;
using MonAnNgon.Models;
using MonAnNgon.Views;
using Newtonsoft.Json;
using Plugin.GoogleClient;
using Plugin.GoogleClient.Shared;
using Xamarin.Forms;

namespace MonAnNgon.ViewModels
{

    public class LoginPageViewModel : BaseViewModel
    {
        public bool _isLoggedIn;

        public bool IsLoggedIn {
            get => _isLoggedIn;
            set => SetProperty(ref _isLoggedIn, value);
        }

        public ICommand LoginCommand { get; set; }
        public ICommand GotoLoginCommand { get; set; }
        public ICommand UseNowCommand { get; set; }
        public ICommand LogoutCommand { get; set; }
        private readonly IGoogleClientManager _googleClientManager;

        public LoginPageViewModel()
        {
            LoginCommand = new Command(LoginAsync);
            UseNowCommand = new Command(UseNow);
            LogoutCommand = new Command(Logout);
            GotoLoginCommand = new Command(GotoLogin);

            _googleClientManager = CrossGoogleClient.Current;


            IsLoggedIn = false;
        }
        
        public async void UseNow()
        {
            await Shell.Current.GoToAsync($"//{nameof(CategoriesPage)}");
        }

        public async void LoginAsync()
        {
            _googleClientManager.OnLogin += OnLoginCompleted;
            try
            {
                await _googleClientManager.LoginAsync();
            }
            catch (GoogleClientSignInNetworkErrorException e)
            {
                await App.Current.MainPage.DisplayAlert("Error", e.Message, "OK");
            }
            catch (GoogleClientSignInCanceledErrorException e)
            {
                await App.Current.MainPage.DisplayAlert("Error", e.Message, "OK");
            }
            catch (GoogleClientSignInInvalidAccountErrorException e)
            {
                await App.Current.MainPage.DisplayAlert("Error", e.Message, "OK");
            }
            catch (GoogleClientSignInInternalErrorException e)
            {
                await App.Current.MainPage.DisplayAlert("Error", e.Message, "OK");
            }
            catch (GoogleClientNotInitializedErrorException e)
            {
                await App.Current.MainPage.DisplayAlert("Error", e.Message, "OK");
            }
            catch (GoogleClientBaseException e)
            {
                await App.Current.MainPage.DisplayAlert("Error", e.Message, "OK");
            }

        }


        private async void OnLoginCompleted(object sender, GoogleClientResultEventArgs<GoogleUser> loginEventArgs)
        {
            if (loginEventArgs.Data != null)
            {
                GoogleUser googleUser = loginEventArgs.Data;

                // Log the current User email
                IsLoggedIn = true;

                var token = CrossGoogleClient.Current.AccessToken;
                var content = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("accessToken", token)
                });
                var httpClient = new HttpClient();
                HttpResponseMessage response = await httpClient.PostAsync("http://52.243.101.54:1337/api/users", content);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                AuthApiResult result = JsonConvert.DeserializeObject<AuthApiResult>(responseBody);
                Database db = new Database();
                Auth auth = new Auth()
                {
                    Id = 1,
                    FullName = result.User.FullName,
                    Token = result.Jwt,
                    IsLoggedIn = true,
                };
                db.AddAuth(auth);
                Services.AppDataStore DataStore = new Services.AppDataStore();
                await DataStore.GetFavoriteAsync(result.Jwt);
                Application.Current.Properties["token"] = token;
                Shell.Current.FlyoutHeader = new FlyoutHeader();
                await Shell.Current.GoToAsync($"//{nameof(CategoriesPage)}");

                
            }
            else
            {
                _ = App.Current.MainPage.DisplayAlert("Error", loginEventArgs.Message, "OK");
            }

            _googleClientManager.OnLogin -= OnLoginCompleted;

        }

        public void Logout()
        {
            _googleClientManager.OnLogout += OnLogoutCompleted;
            _googleClientManager.Logout();
        }

        public async void GotoLogin()
        {
            await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
        }

        private async void OnLogoutCompleted(object sender, EventArgs loginEventArgs)
        {
            IsLoggedIn = false;
            _googleClientManager.OnLogout -= OnLogoutCompleted;
            Database db = new Database();
            db.DeleteAuth();
            await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
            Shell.Current.FlyoutHeader = new FlyoutHeader();
        }
    }
}
