using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Progression_Library.Data
{
    public class CharacterInfo
    {
        //private readonly
        private string className = "";
        private string ascendancyName = "";
        private string characterName = "";
        private string league = "";
        private int level = -1;
        private long experience = -1;
        private bool loadedFromPOEAPI = false;

        public CharacterInfo()
        {

        }

        public CharacterInfo(int classType, string plannedAscendency, string charName, string setLeague)
        {
            this.SetClassNameFromInt(classType);
            this.ascendancyName = plannedAscendency;
            this.characterName = charName;
            this.league = setLeague;
        }

        #region setters

        public void SetClassName(string newClassName)
        {
            className = newClassName;
        }

        public void SetAscendency(string newAscendency)
        {
            this.ascendancyName = newAscendency;
        }

        public void SetCharName(string newName)
        {
            characterName = newName;
        }

        public void ChooseLeague(string designateLeague)
        {
            league = designateLeague;
        }

        public void SetLevel(int newLevel)
        {
            level = newLevel;
        }

        public void SetExperience(long newExperience)
        {
            experience = newExperience;
        }

        #endregion

        #region getters

        public string GetClassType()
        {
            return className;
        }

        public string GetAscendency()
        {
            return ascendancyName;
        }

        public string GetCharacterName()
        {
            return characterName;
        }

        public string GetLeague()
        {
            return league;
        }

        public int GetLevel()
        {
            return level;
        }

        public long GetExperience()
        {
            return experience;
        }

        public bool GetLoadedFromAPI()
        {
            return loadedFromPOEAPI;
        }

        #endregion

        public void FlipLoadFromAPIBit()
        {
            if(!loadedFromPOEAPI)
            {
                loadedFromPOEAPI = true;
            } else
            {
                loadedFromPOEAPI = false;
            }
        }

        public void CopyCharacter(CharacterInfo charInfo)
        {
            string before = "";

            if(charInfo is CharacterInfo)
            {
                before = ToString();
            }
            this.className = charInfo.GetClassType();
            this.ascendancyName = charInfo.GetAscendency();
            this.characterName = charInfo.GetCharacterName();
            this.level = charInfo.GetLevel();
            this.loadedFromPOEAPI = charInfo.GetLoadedFromAPI();
            this.experience = charInfo.GetExperience();
            this.league = charInfo.GetLeague();
            if (before != null)
            {
                //m_logger.info("CharacterInfo changed from: " + before);
                //m_logger.info("To: " + toString());
            }
        }

        public override string ToString()
        {
            return "CharacterInfo{" +
            "className='" + className + '\'' +
            ", ascendancyName='" + ascendancyName + '\'' +
            ", characterName='" + characterName + '\'' +
            ", level=" + level +
            ", loadedFromPOEAPI=" + loadedFromPOEAPI +
            ", experience=" + experience +
            ", league='" + league + '\'' +
            '}';
        }

        public void SetClassNameFromInt(int classIDFromAPI)
        {
            switch (classIDFromAPI)
            {
                case 0:
                    className = "Scion";
                    break;
                case 1:
                    className = "Marauder";
                    break;
                case 2:
                    className = "Ranger";
                    break;
                case 3:
                    className = "Witch";
                    break;
                case 4:
                    className = "Duelist";
                    break;
                case 5:
                    className = "Templar";
                    break;
                case 6:
                    className = "Shadow";
                    break;
                default:
                    className = "Unknown";
                    break;
            }
        }

        public override bool Equals(object? that)
        {
            if (this == that) return true;
            var test = that as CharacterInfo;
            if (that == null) return false;
            return level == test.level &&
                loadedFromPOEAPI == test.loadedFromPOEAPI &&
                experience == test.experience

                //TODO add equals comparisons for 4 string variables
                ;
        }       

        public bool Equals(CharacterInfo charInf)
        {
            return charInf != null;
        }
    }
}
