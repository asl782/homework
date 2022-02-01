using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport
{
    public class Runway
    {
        public enum RunwayMode {busy, free};
        
        public RunwayMode runwayStatus { get; private set; }

        public Runway()
        {
            runwayStatus = RunwayMode.free;
        }

        private readonly Object runwayLock = new Object();

        public bool GivePermission()
        {
            lock (runwayLock)
            {
                if (runwayStatus == RunwayMode.free)
                {
                    runwayStatus = RunwayMode.busy;
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public void ReleaseRunway()
        {
            runwayStatus = RunwayMode.free;
        }
    }
}
