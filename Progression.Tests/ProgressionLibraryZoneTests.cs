using Microsoft.VisualStudio.TestTools.UnitTesting;
using Progression_Library.Data;
using System.Collections.Generic;

namespace Progression.Tests
{
    [TestClass]
    public class ProgressionLibraryZoneTests
    {
        [TestMethod]
        public void ProgressionDataZone_CanCreate()
        {
            //Arrange
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
            Zone zone = null;


            //Act
            imageList.Add(jewelOne);
            zone = new Zone(zoneName, zoneLevel, imageList, altImage,note,noPassive,hasNoTrial,quest,notQuestReward,actName,actID);
            //Assert
            Assert.AreEqual<string>("note", note);
        }
    }
}
