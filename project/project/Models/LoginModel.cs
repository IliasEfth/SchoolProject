using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace project.Models
{
    class LoginModel : BindableObject
    {
        private ValidatedLoginEntrys _username;
        public ValidatedLoginEntrys UserName
        {
            get => this._username;
            set
            {
                this._username = value;
                OnPropertyChanged("UserName");
            }
        }
        private ValidatedLoginEntrys _password;
        public ValidatedLoginEntrys PassWord
        {
            get => _password;
            set
            {
                this._password = value;
                OnPropertyChanged("PassWord");
            }
        }

        public LoginModel()
        {
            this.UserName = new ValidatedLoginEntrys() { Value = "" };
            this.PassWord = new ValidatedLoginEntrys() { Value = "" };
        }
    }

    public class ValidatedLoginEntrys : BindableObject
    {
        public bool IsValid
        {
            get
            {
                return !string.IsNullOrWhiteSpace(this.Value);
            }
        }
        public bool IsInvalid
        {
            get
            {
                return string.IsNullOrWhiteSpace(this.Value);
            }
        }

        private string _value;
        public string Value
        {
            get => this._value;
            set
            {
                this._value = value;
                OnPropertyChanged("Value");
                OnPropertyChanged("IsValid");
                OnPropertyChanged("IsInvalid");
            }
        }
    }
}
