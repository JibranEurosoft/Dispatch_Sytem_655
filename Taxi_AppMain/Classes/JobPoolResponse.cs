using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxi_AppMain
{
   public  class JobPoolResponse
    {
        public bool HasError;
        public string Message;
        public string Data;
    }

    public class RequestResponse<T>
    {
        private T _data;
        private bool _hasError = true;
        private string _message = "Some things went wrong.";

        public RequestResponse()
        {
        }
        public RequestResponse(ref T data)
        {
            _data = data;
        }

        public bool HasError
        {
            get { return _hasError; }
            set { _hasError = value; }
        }

        public string Message
        {
            get { return _message; }
            set { _message = value; }
        }

        public T Data
        {
            get { return _data; }
            set { _data = value; }
        }
    }
}
