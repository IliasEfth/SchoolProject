using project.Models;
using project.Models.Login.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace project.Services
{
    public class LoginValidatorService : ILoginValidatorService
    {
        private string username = "test";
        private string password = "testerakos123";
        public bool ValidateUser(ILoginModel user)
        {
            if(!(string.IsNullOrWhiteSpace(user.UserName.Value) && string.IsNullOrWhiteSpace(user.PassWord.Value))
                && user.UserName.Value.Equals(this.username) 
                && user.PassWord.Value.Equals(this.password))
            {
                return true;
            }
            return false;
        }
    }
}
