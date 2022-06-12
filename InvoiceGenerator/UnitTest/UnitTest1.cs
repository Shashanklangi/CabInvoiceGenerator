using NUnit.Framework;
using System.Collections.Generic;
using CabInvoiceGenerator;


namespace UnitTest
{
    public class Tests
    {
        InvoiceGenerator invoiceGeneratorNormalRide;
        RideServices rideServices;

        [SetUp]
        public void Setup()
        {
            invoiceGeneratorNormalRide = new InvoiceGenerator();
            rideServices = new RideServices();
        }
        /// <summary>
        /// UC1:Calculate the normal ride fare
        /// </summary>
        /// <param name="distance"></param>
        /// <param name="time"></param>
        /// <param name="output"></param>

        [Test]
        [TestCase(5, 3)]
        public void GivenTimeAndDistance_CalculateFare(double distance, double time)
        {
            Ride ride = new Ride(distance, time);
            int excepted = 53;
            Assert.AreEqual(excepted, invoiceGeneratorNormalRide.TotalFareForSingleRiderreturn(ride));
        }
        //1.1: Check for invalid distance
        [Test]
        public void GivenInvalidDistance_ThrowException()
        {
            Ride ride = new Ride(-1, 1);
            InvoiceGeneratorException invoiceGeneratorException = Assert.Throws<InvoiceGeneratorException>(() => invoiceGeneratorNormalRide.TotalFareForSingleRiderreturn(ride));
            Assert.AreEqual(invoiceGeneratorException.type, InvoiceGeneratorException.ExceptionType.INVALID_DISTANCE);
        }
        //TC1.2: Check for invalid time
        [Test]
        public void GivenInvalidTime_ThrowException()
        {
            Ride ride = new Ride(1, -1);
            InvoiceGeneratorException invoiceGeneratorException2 = Assert.Throws<InvoiceGeneratorException>(() => invoiceGeneratorNormalRide.TotalFareForSingleRiderreturn(ride));
            Assert.AreEqual(invoiceGeneratorException2.type, InvoiceGeneratorException.ExceptionType.INVALID_TIME);
        }
        //<summary>
        //UC2: Checking for multiple rides and aggregate fare
        //</summary>
        [Test]
        public void GivenListOfRides_CalculateFareForMultipleRides()
        {
            Ride ride1 = new Ride(2, 2);
            Ride ride2 = new Ride(2, 1);

            List<Ride> rides = new List<Ride>();
            rides.Add(ride1);
            rides.Add(ride2);
            Assert.AreEqual(43.0d, invoiceGeneratorNormalRide.TotalFareForMultipleRideReturn(rides));
        }
        //<summary>
        //UC3: Enhanced the fare by finding average fare, totalfare, number of rides
        //</summary>
        [Test]
        public void GivenListOfRides_GenerateInvoice()
        {
            Ride ride1 = new Ride(2, 2);
            Ride ride2 = new Ride(2, 1);

            List<Ride> rides = new List<Ride>();
            rides.Add(ride1);
            rides.Add(ride2);
            Assert.AreEqual(43.0d, invoiceGeneratorNormalRide.TotalFareForMultipleRideReturn(rides));
            Assert.AreEqual(21.5d, invoiceGeneratorNormalRide.averagePerRide);
            Assert.AreEqual(2, invoiceGeneratorNormalRide.numOfRides);
        }
        ///<summary>
        ///UC4: Checking fare of user with valid UserId
        ///</summary>
        [Test]
        public void GivenValidUser_GenerateInvoice()
        {
            Ride ride1 = new Ride(2, 2);
            Ride ride2 = new Ride(2, 1);
            rideServices.AddRideRespository("RT", ride1);
            rideServices.AddRideRespository("RT", ride2);

            Assert.AreEqual(43.0d, invoiceGeneratorNormalRide.TotalFareForMultipleRideReturn(rideServices.returnListByUserId("RT")));
            Assert.AreEqual(21.5d, invoiceGeneratorNormalRide.averagePerRide);
            Assert.AreEqual(2, invoiceGeneratorNormalRide.numOfRides);
        }
        ///<summary>
        ///TC4.1: Checking fare of user with Invalid UserId
        ///</summary>
        [Test]
        public void GivenInValidUser_GenerateInvoice()
        {
            Ride ride1 = new Ride(2, 2);
            Ride ride2 = new Ride(2, 1);
            rideServices.AddRideRespository("RT", ride1);
            rideServices.AddRideRespository("RT", ride2);

            var Exception = Assert.Throws<InvoiceGeneratorException>(() => invoiceGeneratorNormalRide.TotalFareForMultipleRideReturn(rideServices.returnListByUserId("TR")));
            Assert.AreEqual(Exception.type, InvoiceGeneratorException.ExceptionType.INVALID_USER_ID);
        }
    }
}