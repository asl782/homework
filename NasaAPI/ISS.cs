using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NasaAPI
{
    public class ISS
    {
        public int SatelliteId { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string Line1 { get; set; }
        public string Line2 { get; set; }
    }
}
