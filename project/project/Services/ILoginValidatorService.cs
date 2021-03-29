using project.Models.Login.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace project.Services
{
    public interface ILoginValidatorService
    {
        bool ValidateUser(ILoginModel user);
    }
}
