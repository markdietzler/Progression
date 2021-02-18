using Microsoft.VisualStudio.TestTools.UnitTesting;
using Progression_Library.Data;
using System.Collections.Generic;

namespace Progression.Tests
{
    [TestClass]
    public class ProgressionLibraryZoneTests
    {
        string zoneName = "Lioneye";
        int zoneLevel = 12;
        string jewelOne = "Flammabilty";
        string altImage = "Flammability";
        string note = "note";
        bool noPassive = false;
        bool hasNoTrial = false;
        string quest = "The Caged Brute";
        bool notQuestReward = false;
        string actName = "Act Three";
        int actID = 555;
        List<string> imageList = new List<string>();

        [TestMethod]
        public void ProgressionDataZone_CanCreate()
        {
            //Arrange            
            Zone zone = null;

            //Act
            imageList.Add(jewelOne);
            //                
            zone = new Zone(zoneName, zoneLevel, imageList, altImage, note, noPassive, hasNoTrial, quest, notQuestReward, actName, actID);

            //Assert
            Assert.AreNotEqual<Zone>(zone, null);
        }

        [TestMethod]
        public void Progression_Data_Zone_CanFlipZoneRecipieBit_True()
        {
            //Arrange
            Zone zone = null;

            //Act
            zone = new Zone(zoneName, zoneLevel, imageList, altImage, note, noPassive, hasNoTrial, quest, notQuestReward, actName, actID);
            zone.FlipZoneRecipieBit();
            //Assert
            Assert.AreEqual(zone.DoesZoneHaveRecipie(), true);
        }

        [TestMethod]
        public void Progression_Data_Zone_CanFlipZoneRecipieBitTwice_False()
        {
            //Arrange
            Zone zone = null;

            //Act
            zone = new Zone(zoneName, zoneLevel, imageList, altImage, note, noPassive, hasNoTrial, quest, notQuestReward, actName, actID);
            zone.FlipZoneRecipieBit();
            zone.FlipZoneRecipieBit();
            //Assert
            Assert.AreEqual(zone.DoesZoneHaveRecipie(), false);
        }
    }
}
