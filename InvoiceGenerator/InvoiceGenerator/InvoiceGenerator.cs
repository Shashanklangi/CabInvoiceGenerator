using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabInvoiceGenerator
{
    public class InvoiceGenerator
    {
        readonly int pricePerKilometer;
        readonly int pricePerMinute;
        readonly int minimumFare;
        public double totalFare;
        public InvoiceGenerator()
        {
            this.pricePerKilometer = 10;
            this.pricePerMinute = 1;
            this.minimumFare = 5;
        }

        public double TotalFareForSingleRiderreturn(Ride ride)
        {
            if (ride.distance < 0)
            {
                throw new InvoiceGeneratorException(InvoiceGeneratorException.ExceptionType.INVALID_DISTANCE, "Invalid Distance encounter");
            }
            if (ride.time < 0)
            {
                throw new InvoiceGeneratorException(InvoiceGeneratorException.ExceptionType.INVALID_TIME, "Invalid Time encounter");
            }
            return Math.Max(minimumFare, ride.distance * pricePerKilometer + ride.time * pricePerMinute);
        }
    }
}
