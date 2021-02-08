using System;
using System.Collections.Generic;
using System.Text;

namespace Progression_Library.Data
{
    ///
    /// @author Mark Dietzler
    /// 
    public class SkillGem
    {
        public class Info
        {
            public string? quest_name;
            public string? npc;
            public int act;
            public string? town;
            public List<string>? available_to;
        }

        public int id;

        private string? name;
        public string? quest_name;
        public string? npc;
        public int act;
        public int required_lvl;
        public int level_added;
        public bool? isVaal;
        public List<String>? available_to;
        public string? town;
        public string? color;
        public string? iconPath;
        public string? iconDirPath;
        public bool? replaced;
        public SkillGem? replacedWith;
        public bool? replaces;
        public SkillGem? replacesGem;

        //IDS FOR JSON CONVERTION
        public int id_replaced;
        public int id_replaces;

        public bool? isRewarded;
        public Info? reward;
        public List<Info>? buy;

        public bool? isActive;
        public bool? isSupport;
        public HashSet<string>? tags;
        public HashSet<string>? alt_name = null;

        public bool IsBought()
        {
            return buy.Count > 0 ? true : false;
        }

        public SkillGem(string gemName)
        {
            name = gemName;
            available_to = new List<string>();
            level_added = -1;
            replaced = false;
            replacedWith = null;
            replaces = false;
            replacesGem = null;
            id = -1;
            id_replaced = -1;
            id_replaces = -1;
            tags = new HashSet<string>();
        }

        public void AddAltNamesFromJSON(IEnumerable<Object> jsonArrayIterator)
        {
            //TODO figure out what alt_name is used for in path of levelling
        }

        public SkillGem(SkillGem dupe)
        {
            available_to = new List<string>();
            level_added = -1;
            replaced = false;
            replacedWith = null;
            replaces = false;
            replacesGem = null;
            id = -1;
            id_replaced = -1;
            id_replaces = -1;
            //this.gemIcon = dupe.getIcon();
            //this.smallGemIcon = dupe.getSmallIcon();
            this.name = dupe.GetGemName();
            //more
            this.id = dupe.id;
            this.quest_name = dupe.quest_name;
            this.npc = dupe.npc;
            this.act = dupe.act;
            this.required_lvl = dupe.required_lvl;
            this.isVaal = dupe.isVaal;
            this.available_to = new List<string>(dupe.available_to);
            this.town = dupe.town;
            this.color = dupe.color;
            this.iconPath = dupe.iconPath;
            //this.cachedLabel = dupe.cachedLabel;
            this.iconDirPath = dupe.iconDirPath;
            this.isRewarded = dupe.isRewarded;
            this.tags = new HashSet<string>(dupe.tags);
            this.isActive = dupe.isActive;
            this.isSupport = dupe.isSupport;

            if (dupe.alt_name != null)
            {
                this.alt_name = new HashSet<string>(dupe.alt_name);
            }
        }

        public int GetLevelAdded()
        {
            if(level_added!=-1)
            {
                return level_added;
            } else
            {
                return required_lvl;
            }
        }

        public string? GetGemName()
        {
            return name;
        }

        public bool IsSameGemNameOrOlder(string gemNameFromImport)
        {
            if(name.Equals(gemNameFromImport,StringComparison.InvariantCultureIgnoreCase))
            {
                return true;
            } else
            {
                if(alt_name != null && alt_name.Contains(gemNameFromImport))
                {
                    Console.WriteLine("**** Found old gem name: " + gemNameFromImport + " should be " + name + " now.");
                    return true;
                }
                return false;
            }            
        }

        public SkillGem DupeGem()
        {
            return new SkillGem(this);
        }

        public List<string>? GetChar()
        {
            return available_to;
        }

        public void PutChar(string z)
        {
            available_to.Add(z);
        }

        public string GetGemColor()
        {
            return color;
        }

        //public Label GetLabel()


    }
}
