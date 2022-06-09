using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabInvoiceGenerator
{
    public class InvoiceGeneratorException : Exception
    {
        public ExceptionType type;
        public enum ExceptionType
        {
            INVALID_DISTANCE, INVALID_TIME, INVALID_USER_ID
        }
        public InvoiceGeneratorException(ExceptionType type, string message) : base(message)
        {
            this.type = type;
        }
    }
}
