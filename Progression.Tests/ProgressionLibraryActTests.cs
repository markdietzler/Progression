using Microsoft.VisualStudio.TestTools.UnitTesting;
using Progression_Library.Data;
using System.Collections.Generic;

namespace Progression.Tests
{
    [TestClass]
    public class ProgressionLibraryActTests
    {
        //test class wide variables        
        string actName = "Act 1";
        string zoneName = "Submerged Passage";
        int actID = 1001;
        int zoneLevel = 2;
        string jewelOne = "Flammabilty";
        string altImage = "Flammability";
        string note = "note";
        bool noPassive = false;
        bool hasNoTrial = false;
        string quest = "The Caged Brute";
        bool notQuestReward = false;        
        List<string> imageList = new List<string>();

        [TestMethod]
        public void Progression_Data_Act_CanCreate()
        {
            //Arrange            
            Act act = null;
            //Zone zone = null;

            //Act            
            act = new Act(actID, actName);

            //Assert
            Assert.AreNotEqual<Act>(act, null);
        }

        [TestMethod]
        public void ProgressionDataAct_CanPutZone()
        {
            //arrange
            string actName = "Lioneye";
            int actID = 12;
            Act act = null;
            Zone zone = null;

            //act
            imageList.Add(jewelOne);
            act = new Act(actID, actName);
            zone = new Zone(zoneName, zoneLevel, imageList, altImage, note, noPassive, hasNoTrial, quest, notQuestReward, actName, actID);
            act.PutZone(zone);
            int zones = act.GetZones().Count;
            //assert
            Assert.AreEqual(zones, 1);
        }

        [TestMethod]
        public void Progression_Data_Act_getActID()
        {
            //Arrange            
            Act act = null;
            //Zone zone = null;

            //Act            
            act = new Act(actID, actName);

            //Assert
            Assert.AreEqual<int>(act.GetActID(), actID);
        }

        [TestMethod]
        public void Progression_Data_Act_GetActName()
        {
            //Arrange            
            Act act = null;
            //Zone zone = null;

            //Act            
            act = new Act(actID, actName);

            //Assert
            Assert.AreEqual<string>(act.GetActName(), actName);
        }
    }
}
