using System.Collections.Generic;
using System;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Linq;

using Progression_Library.Slots;

namespace Progression_Library.FileHandling.XML.Read
{
    public class ReadXML
    {

        public static bool ValidPOB(string filePath, string fileName, string section)
        {
            return false;
        }

        public static bool ValidProgression(string filePath, string fileName)
        {
            return false;
        }

        public static GearSlot GetGear(string fileToRead, string fileLocation, bool[] slots)
        {

            GearSlot tempGear = new GearSlot(slots);

            return tempGear;
            
        }

        private void GetXMLGear()
        {

        }

        public bool[] GetEquipped()
        {
            bool[] temp = new bool[9];

            //skill/skill slot=""

            return temp;
        }

        // 1    2     3      4     5  6  7     8     9   10
        //helm chest gloves boots mh oh ring1 ring2 2h?

        public static List<string> GetEquipmentSlot(string equipmentToGet, string placeToLook, string fileToRead)
        {
            List<string> returnMe = new List<string>();


            return returnMe;
        }
    }
}
