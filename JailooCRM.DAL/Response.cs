﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JailooCRM.DAL
{
    public class Response
    {
        public Response(int statusCode, string message, bool isSuccess)
        {
            StatusCode = statusCode;
            Message = message;
            IsSuccess = isSuccess;
        }

        public int StatusCode { get; set; }
        public string Message { get; set; }
        public bool IsSuccess { get; set; }
    }
}
