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

        private int level;
        private string name;
        private bool hasPassive;
        private bool hasTrial;
        private List<string> image;
        private string altimage;
        private string note;
        private string quest;
        private bool questRewardsSkills;
        private string actName;
        private int actID;
        private bool hasRecipe;

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
            hasRecipe = false;
        }

        public void SetZoneLevel(int newLevel)
        {
            if(newLevel < 1 || newLevel > 82)
            {
                throw new ArgumentException("Zone level outside of in game zone range.");
            }
            level = newLevel;
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
        
        public bool DoesZoneHaveRecipie()
        {
            return hasRecipe;
        }

        public void FlipZoneRecipieBit()
        {
            if(hasRecipe == false)
            {
                hasRecipe = true;
            } else
            {
                hasRecipe = false;
            }
        }

        public void SetZoneRecipie(bool value)
        {
            hasRecipe = value;
        }

        public int GetActID()
        {
            return actID;
        }
    }
}
