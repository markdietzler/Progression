using Microsoft.VisualStudio.TestTools.UnitTesting;
using Progression_Library.Data;
using System.Collections.Generic;

namespace Progression.Tests
{
    [TestClass]
    public class ProgressionLibraryCharacterInfoTests
    {        
        //test class fields
        private int _classType = 2; //2 = ranger
        private string _ClassName = "Ranger";
        private string _ascendancyName = "Raider";
        private string _characterName = "Testing";
        private string _league = "Heist";

        //these are not used in the CharacterInfo constructor
        //private int _level = -1;
        //private long _experience = -1;
        //private bool _loadedFromPOEAPI = false;

        //string test fields
        string _compare_string = @"CharacterInfo{" +
            "className='" + "Ranger" + '\'' +
            ", ascendancyName='" + "Raider" + '\'' +
            ", characterName='" + "Testing" + '\'' +
            ", level=" + "-1" +
            ", loadedFromPOEAPI=" + "False" +
            ", experience=" + "-1" +
            ", league='" + "Heist" + '\'' +
            '}';

        [TestMethod]
        public void ProgressionData_Characterinfo_CanCreste_NotNull()
        {
            //arrange
            CharacterInfo test_Char = null;
            //act
            test_Char = new CharacterInfo(_classType,_ascendancyName,_characterName,_league);
            //assert
            Assert.AreNotEqual(test_Char, null);
        }

        [TestMethod]
        public void ProgressionData_Characterinfo_CanCreste()
        {
            //arrange
            CharacterInfo test_Char = null;
            //act
            test_Char = new CharacterInfo(_classType, _ascendancyName, _characterName, _league);
            //assert
            Assert.AreEqual(test_Char.ToString(), _compare_string);
        }

        [TestMethod]

        public void ProgressionData_Characterinfo_CanCopyCharacter()
        {
            //arrange
            CharacterInfo test_Char1 = new CharacterInfo();
            CharacterInfo test_Char2 = null;
            //act
            test_Char2 = new CharacterInfo(_classType, _ascendancyName, _characterName, _league);
            test_Char1.CopyCharacter(test_Char2);
            //assert
            Assert.AreEqual(test_Char2.ToString(), _compare_string);
        }
    }
}
