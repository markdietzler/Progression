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
        public string className = "";
        public string ascendancyName = "";
        public string characterName = "";
        public string league = "";
        public int level = -1;        
        public long experience = -1;
        public bool loadedFromPOEAPI = false;

        public void CopyFrom(CharacterInfo charInfo)
        {
            string before = null;

            if(charInfo is CharacterInfo)
            {
                before = ToString();
            }
            this.className = charInfo.className;
            this.ascendancyName = charInfo.ascendancyName;
            this.characterName = charInfo.characterName;
            this.level = charInfo.level;
            this.loadedFromPOEAPI = charInfo.loadedFromPOEAPI;
            this.experience = charInfo.experience;
            this.league = charInfo.league;
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

        public void setClassNameFromInt(int classIDFromAPI)
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
