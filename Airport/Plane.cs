using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Airport
{
    public class Plane
    {
        public enum FlightMode {isTakingOff, inTheAir, isLanding, onTheGround};

        public FlightMode FlightStatus { get; private set; }
        public int PlaneID { get; private set; }
        public Runaway Runaway { get; set; }

        public Plane(int planeID, FlightMode status, Runaway runaway)
        {
            PlaneID = planeID;
            FlightStatus = status;
            Runaway = runaway;
        }

        public void FlightLoop()
        {
            const int delay = 4000;

            while(true)
            {
                switch(FlightStatus)
                {
                    case FlightMode.onTheGround:
                        Thread.Sleep(delay);
                        TakeOff();
                        break;

                    case FlightMode.inTheAir:
                        Thread.Sleep(delay);
                        Land();
                        break;

                    default:
                        Thread.Sleep(delay);
                        break;
                }
            }
        }

        public FlightMode TakeOff()
        {
            const int delay = 2000;
           
            if(Runaway.GivePermition())
            {
                Console.WriteLine($"Plane {PlaneID} is taking off");
                FlightStatus = FlightMode.isTakingOff;
                Thread.Sleep(delay);
                FlightStatus = FlightMode.inTheAir;
                Console.WriteLine($"Plane {PlaneID} is in the air");
                Runaway.ReleaseRunway();
            }
            else
            {
                Thread.Sleep(delay);
            }

            return FlightStatus;
        }

        public FlightMode Land()
        {
            int delay = 2000;

            if(Runaway.GivePermition())
            {
                Console.WriteLine($"Plane {PlaneID} is landing");
                FlightStatus = FlightMode.isLanding;
                Thread.Sleep(delay);
                FlightStatus = FlightMode.onTheGround;
                Console.WriteLine($"Plane {PlaneID} is on the ground");
                Runaway.ReleaseRunway();
            }
            else
            {
                Thread.Sleep(delay);
            }

            return FlightStatus;
        }
    }
}
