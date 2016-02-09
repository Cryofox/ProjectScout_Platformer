using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
/*
    Custom class for throwing exceptions.

    */

namespace App.Debug
{
    [Serializable]
    class AppException: Exception
    {
        public AppException() 
            : base() { }
        public AppException(string message) 
            : base(message) { }

        public AppException(string format, params object[] args)
            : base(string.Format(format, args)) { }

        public AppException(string message, Exception innerException)
            : base(message, innerException) { }

        public AppException(string format, Exception innerException, params object[] args)
            : base(string.Format(format, args), innerException) { }

        protected AppException(SerializationInfo info, StreamingContext context)
            : base(info, context) { }



    }
}
