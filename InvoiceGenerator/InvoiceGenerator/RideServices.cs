using CabInvoiceGenerator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabInvoiceGenerator
{
    public class RideServices
    {
        public Dictionary<string, List<Ride>> rideServices;
        public RideServices()
        {
            rideServices = new Dictionary<string, List<Ride>>();
        }
        ///<summary>
        ///Adds to ride repository.
        ///</summary>
        ///<param name="userId">The user identifier.</param>
        ///<param name="ride"> The ride.</param>
        public void AddRideRespository(string userId, Ride ride)
        {
            if (rideServices.ContainsKey(userId))
            {
                rideServices[userId].Add(ride);
            }
            else
            {
                rideServices.Add(userId, new List<Ride>());
                rideServices[userId].Add(ride);
            }
        }
        ///<summary>
        ///Returns the List by user Identifier.
        ///</summary>
        ///<param name="userId">The user identifier</param>
        public List<Ride> returnListByUserId(string userId)
        {
            if (rideServices.ContainsKey(userId))
            {
                return rideServices[userId];
            }
            else
                throw new InvoiceGeneratorException(InvoiceGeneratorException.ExceptionType.INVALID_USER_ID, "Invalid userId");
        }
    }
}