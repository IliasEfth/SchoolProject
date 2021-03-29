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
    }
}
