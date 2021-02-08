using System;
using System.Collections.Generic;

namespace Progression_Library.Data
{
    public class Act
    {
        int actid;
        string act;
        public List<Zone> zones;

        public Act(int actId, String act)
        {
            this.actid = actId;
            this.zones = new List<Zone>();
            this.act = act;
        }

        public List<Zone> getZones()
        {
            return zones;
        }

        public void putZone(Zone z)
        {
            zones.Add(z);
        }
    }
}
