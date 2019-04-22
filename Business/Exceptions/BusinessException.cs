using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Exceptions
{
    public class BusinessException : Exception
    {
        public Object ReturnObject { get; set; }

        public BusinessException()
        {
        }

        public BusinessException(string message, Object returnObj = null)
            : base(message)
        {
            ReturnObject = returnObj;
        }

        public BusinessException(string message, Exception inner, Object returnObj = null)
            : base(message, inner)
        {
            ReturnObject = returnObj;
        }
    }
}
