using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PythonSucks.ViewModels
{
    public class ErrorData
    {
        public int StatusCode { get; private set; }
        public string Message { get; private set; }
        public List<string> Errors { get; private set; }

        public ErrorData(int statusCode, string message, List<string> errors)
        {
            StatusCode = statusCode;
            Message = message;
            Errors = errors;
        }
        
    }
}
