using Prism.Commands;
using project.Models;
using project.Models.Login.Interfaces;
using project.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace project.ViewModels
{
    class LoginPageViewModel : BindableObject, ILogin
    {
        private ILoginValidatorService loginService;
        private ILoginModel _login;
        public ILoginModel Login
        {
            get => _login;
            set
            {
                this._login = value;
                OnPropertyChanged("Login");
            }
        }
        public DelegateCommand Click { get; private set; }
        public LoginPageViewModel(ILoginValidatorService loginService)
        {
            this.loginService = loginService;
            Click = new DelegateCommand(loginAction, can)
            .ObservesProperty(() => Login.UserName.Value)
            .ObservesProperty(() => Login.PassWord.Value);
            Login = new LoginModel();
        }

        private async void loginAction()
        {
            var value = loginService.ValidateUser(Login);
            if (value)
            {
                await Shell.Current.GoToAsync("//MainPage");
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Error", "Wrong Username of Password please try again!", "Ok");
            }
        }
        private bool can()
        {
            return !(string.IsNullOrWhiteSpace(Login.UserName.Value) || string.IsNullOrWhiteSpace(Login.PassWord.Value));
        }
    }
}
