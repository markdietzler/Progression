using System.Collections.Generic;
using System;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Linq;

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

        public static List<string> GetEquipmentSlot(string attribut_type, string attributeName, string placeToLook)
        {
            List<string> returnMe = new List<string>();

            using (XmlReader _Reader = XmlReader.Create(new FileStream(placeToLook, FileMode.Open), new XmlReaderSettings() { CloseInput = true } ))
            {
                while(_Reader.Read())
                {
                    if((_Reader.NodeType == XmlNodeType.Element) && (_Reader.Name == attribut_type))
                    {
                        if(_Reader.HasAttributes)
                        {
                            returnMe.Add(_Reader.GetAttribute(attributeName));
                        }

                    }
                }
            }


            return returnMe;
        }
    }
}
