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
    public class RunawayTests
    {
        [TestMethod()]
        public void GivePermissionStatusTest()
        {
            var runway = new Runway();
            //   var plane1 = new Plane(1, Plane.FlightMode.onTheGround, runway);
            //   var plane2 = new Plane(2, Plane.FlightMode.onTheGround, runway);

            //   plane1.TakeOff();

            Assert.IsTrue(runway.GivePermission());

            Assert.IsFalse(runway.GivePermission());
        }
    }
}