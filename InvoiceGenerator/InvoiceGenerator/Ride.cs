using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabInvoiceGenerator
{
    public class Ride
    {
        public double distance;
        public double time;

        public Ride(double distance, double time)
        {
            this.distance = distance;
            this.time = time;
        }
    }
}
