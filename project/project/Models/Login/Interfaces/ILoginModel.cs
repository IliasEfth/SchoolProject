using System;
using System.Collections.Generic;
using System.Text;

namespace project.Models.Login.Interfaces
{
    public interface ILoginModel
    {
        IValidatedEntry UserName { get; set; }
        IValidatedEntry PassWord { get; set; }
    }
}
