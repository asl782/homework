using Microsoft.VisualStudio.TestTools.UnitTesting;
using Airport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.Tests
{
    [TestClass()]
    public class PlaneTests
    {
        [TestMethod()]
        public void TakeOffStatusTest()
        {
            var runway = new Runway();
            var plane = new Plane(1, Plane.FlightMode.onTheGround, runway);
            var result = plane.TakeOff();

            Assert.AreEqual(Plane.FlightMode.inTheAir, result);
        }

        [TestMethod()]
        public void LandStatusTest()
        {
            var runway = new Runway();
            var plane = new Plane(1, Plane.FlightMode.inTheAir, runway);
            var result = plane.Land();

            Assert.AreEqual(Plane.FlightMode.onTheGround, result);
        }
    }
}