using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace project.Models.Login.Interfaces
{
    public interface ILogin
    {
        ILoginModel Login { get; set; }
        DelegateCommand Click { get; }
        DelegateCommand LoginShowPassword { get; }
        Boolean IsPassWord { get; }
        Boolean LockerImage { get; }
        Boolean UnLockerImage { get; }
    }
}
