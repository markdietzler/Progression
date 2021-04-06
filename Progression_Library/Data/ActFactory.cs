using System;
using System.Collections.Generic;
using System.Text;

namespace Progression_Library.Data
{
    public class ActFactory
    {
        private static ActFactory mInstance;

        public static ActFactory GetInstance()
        {
            if(mInstance == null)
            {
                mInstance = new ActFactory();
            }
            return mInstance;
        }

        private List<Act> acts;
        private List<Zone> zonesWithRecipies;
        public Dictionary<Zone, bool> recipieMap;
        private Dictionary<int, List<Zone>> zoneRecipieActMapper;

        public ActFactory()
        {
            acts = new List<Act>();
            zonesWithRecipies = new List<Zone>();
            recipieMap = new Dictionary<Zone, bool>();
            zoneRecipieActMapper = new Dictionary<int, List<Zone>>();
        }

        public void PutAct(Act a)
        {            
            if(a == null)
            {
                throw new ArgumentNullException("Putting a null act into the act factory is not allowed.");
            }
            if (a is Act)
            {
                acts.Add(a);
            } else {
                throw new ArgumentException("new Act is not of type Act!");               
            }
        }

        public List<Act> GetActs()
        {
            return acts;
        }

        public void PutZone(Zone zoneToAdd)
        {          
            if(zoneToAdd == null)
            {
                throw new ArgumentNullException("");
            }

            if (zoneToAdd is Zone) {
                zonesWithRecipies.Add(zoneToAdd);
            } else
            {
                throw new ArgumentException("New zone is not of type Zone!");
            }

            if (zoneRecipieActMapper.ContainsKey(zoneToAdd.GetActID()))
            {
                List<Zone> zones = zoneRecipieActMapper[zoneToAdd.GetActID()];
                zones.Add(zoneToAdd);
            } else
            {
                List<Zone> zones = new List<Zone>();
                zoneRecipieActMapper[zoneToAdd.GetActID()] = zones;
                zones.Add(zoneToAdd);
            }
            
        }

        public List<Zone> GetZonesWithRecipies()
        {
            return zonesWithRecipies;
        }

        public Dictionary<int, List<Zone>> GetZoneRecipieActMapper()
        {
            return zoneRecipieActMapper;
        }
    }
}
