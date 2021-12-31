using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport
{
    public class Runaway
    {
        public enum RunawayMode {busy, free};
        
        public RunawayMode runawayStatus { get; private set; }

        public Runaway()
        {
            runawayStatus = RunawayMode.free;
        }

        private readonly Object runwayLock = new Object();

        public bool GivePermition()
        {
            lock (runwayLock)
            {
                if (runawayStatus == RunawayMode.free)
                {
                    runawayStatus = RunawayMode.busy;
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
            runawayStatus = RunawayMode.free;
        }
    }
}
