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
               

        #region getters

        public int GetActID()
        {
            return actID;
        }

        public string GetActName()
        {
            return actName;
        }

        public List<Zone> GetZones()
        {
            return zonesInAct;
        }

        #endregion

        #region Setters

        public void PutActName(string newName)
        {
            actName = newName;
        }

        #endregion

        #region class methods

        public void PutZone(Zone zoneToPut)
        {
            zonesInAct.Add(zoneToPut);
        }

        public Zone GetZoneID(int zoneIndex)
        {
            return zonesInAct[zoneIndex];
        }

        public void PutActID(int newID)
        {
            if (newID < 1 || newID > 10)
            {
                throw new ArgumentOutOfRangeException();
            }
            else
            {
                actID = newID;
            }
        }

        #endregion

    }
}
