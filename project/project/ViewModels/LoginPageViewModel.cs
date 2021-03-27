using Prism.Commands;
using project.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace project.ViewModels
{
    class LoginPageViewModel : BindableObject
    {
        private LoginModel _login;
        public LoginModel Login
        {
            get => _login;
            set
            {
                this._login = value;
                OnPropertyChanged("Login");
            }
        }
        public DelegateCommand Click { get; private set; }
        public LoginPageViewModel()
        {
            Click = new DelegateCommand(loginAction, can)
            .ObservesProperty(() => Login.UserName.Value)
            .ObservesProperty(() => Login.PassWord.Value);
            Login = new LoginModel();
        }

        private async void loginAction()
        {
            //await App.Current.MainPage.DisplayAlert("Next page", string.Format("{0} {1}", Login.UserName.Value, Login.PassWord.Value), "OK");
            await Shell.Current.GoToAsync("//MainPage");
        }
        private bool can()
        {
            return !(string.IsNullOrWhiteSpace(Login.UserName.Value) || string.IsNullOrWhiteSpace(Login.PassWord.Value));
        }
    }
}
