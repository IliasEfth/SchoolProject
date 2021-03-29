using System;
using System.Collections.Generic;
using System.Text;

namespace project.Models
{
    public interface IValidated
    {
        bool IsValid { get; }
        bool IsInvalid { get;}
    }
}
