using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrimeVault.Domain.Abstractions;

public class Error
{
    public Error(string message) => Message = message;

    public Error(string message, string code)
    {
        Message = message;
        Code = code;
    }

    public string Message { get; }
    public string Code { get; }
}

