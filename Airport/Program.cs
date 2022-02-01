using System;
using System.Threading;

namespace Airport
{
    //Lotnisko: napisz program, który będzie symulatorem lotniska.
    //Mamy 20 samolotów, jeden pas na którym może lądować lub startować tylko jeden samolot(sekcja krytyczna).
    //Na sam początek mamy 15 samolotów w powietrzu, a 5 na ziemi, każdy samolot może dowolnie startować lądować.

    class Program
    {
        static void Main(string[] args)
        {
            const int numberOfPlanes = 20;
            const int planesInTheAir = 5;

            var planes = new Plane[numberOfPlanes];
            var runway = new Runway();

            for(int i = 0; i < numberOfPlanes; i++)
            {
                if(i < planesInTheAir)
                    planes[i] = new Plane(i + 1, Plane.FlightMode.inTheAir, runway);
                else
                    planes[i] = new Plane(i + 1, Plane.FlightMode.onTheGround, runway);
            }

            var threads = new Thread[numberOfPlanes];

            for(int i = 0; i < numberOfPlanes; i++)
            {
                threads[i] = new Thread(new ThreadStart(planes[i].FlightLoop));
                threads[i].Start();
            }
        }
    }
}
