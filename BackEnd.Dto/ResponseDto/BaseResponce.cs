using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace BackEnd.Dto
{
    public class BaseResponce
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public HttpStatusCode StatusCode { get; set; }
    }
}
