using System;
using System.Collections.Generic;

namespace Progression_Library.Data
{
    public class Zone
    {
        public static string[] questline = new string[]
        {
            "Enemy at the Gate",
            "Mercy Mission",
            "Breaking Some Eggs",
            "The Caged Brute",
            "The Siren's Cadence",
            "Intruders in Black",
            "Sharp and Cruel",
            "The Root of the Problem",
            "Lost in Love",
            "Sever the Right Hand",
            "A Fixture of Fate",
            "Breaking the Seal",
            "The Eternal Nightmare",
            "Fallen from Grace"
        };

        int level;
        public string name;
        public bool hasPassive;
        public bool hasTrial;
        List<string> image;
        string altimage;
        string note;
        string quest;
        bool questRewardsSkills;
        string actName;
        public int actID;
        public bool hasRecipe;

        public class RecipeInfo
        {
            public string tooltip;
            public List<string> mods;
        }

        public RecipeInfo rInfo;

        public Zone(string zoneName, int zoneLevel, List<string> images, string altimage
            , string note, bool hasPassive, bool hasTrial, string quest, bool questRewardsSkills
            , string actName, int actID)
        {
            this.level = zoneLevel;
            this.name = zoneName;
            this.hasPassive = hasPassive;
            this.hasTrial = hasTrial;
            this.note = note;
            this.altimage = altimage;
            this.image = images; //maybe new list
            this.quest = quest;
            this.questRewardsSkills = questRewardsSkills;
            this.actName = actName;
            this.actID = actID;
            rInfo = new RecipeInfo();
        }

        public int GetZoneLevel()
        {
            return level;
        }

        public string GetZoneQuest()
        {
            return quest;
        }

        public List<string> GetImages()
        {
            return image;
        }

        public string GetActName()
        {
            return actName;
        }

        public string GetZoneNote()
        {
            return note;
        }

        public string AltImage()
        {
            return altimage;
        }        
    }
}
