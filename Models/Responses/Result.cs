using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LicApiTests.Models.Responses
{
    public class Result
    {
        public int Status { get; set; }
        public string? Message { get; set; }
        public string? ValidationErrors { get; set; }        
    }

    public class Result<T> : Result where T : class
    {
        public T? Data { get; set; }

        public Result() : base()
        {
        }

        public Result(T data) : base()
        {
            Data = data;
        }

        public Result(T data, int status)
        {
            Data = data;
            Status = status;
        }

        public Result(T data, string messages) : base()
        {
            Data = data;
            Message = messages;
        }

        public Result(T data, string messages, int status) : base()
        {
            Data = data;
            Message = messages;
            Status = status;
        }

        public Result(string messages, int status) : base()
        {
            Message = messages;
            Status = status;
        }
    }
}
