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
        public DelegateCommand LoginShowPassword { get; private set; }

        private bool isPassword;
        public bool IsPassWord {
            get => this.isPassword;
            private set => this.isPassword = value;
        }
        private bool lockerImage;
        public bool LockerImage

        {
            get => this.lockerImage;
            private set => this.lockerImage = value;
        }
        private bool unlockerImage;
        public bool UnLockerImage

        {
            get => this.unlockerImage;
            private set => this.unlockerImage = value;
        }
        public LoginPageViewModel(ILoginValidatorService loginService)
        {
            this.loginService = loginService;
            Click = new DelegateCommand(loginAction, can)
            .ObservesProperty(() => Login.UserName.Value)
            .ObservesProperty(() => Login.PassWord.Value);
            LoginShowPassword = new DelegateCommand(showPassWord);
            Login = new LoginModel();
            IsPassWord = true;
            LockerImage = false;
            UnLockerImage = true;
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
                //my stupid code
                Login.UserName.Value = "";
                Login.PassWord.Value = "";
                await App.Current.MainPage.DisplayAlert("Error", "Wrong Username or Password. Please try again!", "Ok");
            }
        }
        private void showPassWord()
        {
            this.IsPassWord = !this.isPassword;
            if (!this.IsPassWord)
            {
                LockerImage = true;
                UnLockerImage = false;
            }
            else
            {
                LockerImage = false;
                UnLockerImage = true;
            }
            OnPropertyChanged("IsPassWord");
            OnPropertyChanged("LockerImage");
            OnPropertyChanged("UnLockerImage");
        }
        private bool can()
        {
            return !(string.IsNullOrWhiteSpace(Login.UserName.Value) || string.IsNullOrWhiteSpace(Login.PassWord.Value));
        }
    }
}
