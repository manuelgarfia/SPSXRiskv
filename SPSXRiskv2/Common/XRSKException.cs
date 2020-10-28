using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace SPSXRiskv2.Common
{
    public class XRSKException : Exception
    {
        public XRSKException() { }
        public XRSKException(string message) : base(message) { }
        public XRSKException(string message, Exception inner) : base(message, inner) { }
        protected XRSKException(
          SerializationInfo info,
          StreamingContext context) : base(info, context) { }

        public override string StackTrace
        {
            get { return "Message instead stacktrace"; }
        }
    }
}
