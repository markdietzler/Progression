using System;
using System.Collections.Generic;

namespace Progression_Library.Data
{
    public class Act
    {
        private int actID;
        private string actName;
        private List<Zone> zonesInAct;

        public Act(int actId, String act)
        {
            this.actID = actId;
            this.zonesInAct = new List<Zone>();
            this.actName = act;
        }

        public List<Zone> getZones()
        {
            return zonesInAct;
        }

        public void PutZone(Zone zoneToPut)
        {
            zonesInAct.Add(zoneToPut);
        }

        public int GetActID()
        {
            return actID;
        }

        public string GetActName()
        {
            return actName;
        }
    }
}
