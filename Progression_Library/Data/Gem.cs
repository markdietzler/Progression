using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Progression_Library.Data
{
    ///
    /// @author Mark Dietzler
    /// 
    public class Gem
    {
        public class RewardData
        {
            public string? availableAfterThisQuest;
            public string? sellingVendor;
            public int actFirstAvailable;
            public string? townCanBuyIn;
            public List<string>? classCanBuy;
        }

        //gem fields
        
        public int id;
        private string? gemName;
        public string? availableAfterThisQuest;
        public string? sellingVendor;
        public int actFirstAvailable;
        public int required_lvl;
        public int level_added;
        public bool? isVaalGem;
        public List<String>? classCanBuy;
        public string? townCanBuyIn;
        public string? gemColor;
        public string? iconPath;
        public string? iconDirPath;
        public bool replaced;
        public Gem? replacedWith;
        public bool replaces;
        public Gem? replacesGem;

        //IDS FOR JSON CONVERTION
        public int id_replaced;
        public int id_replaces;

        //quest reward fields
        public bool isQuestReward;
        public RewardData? rewardSpecifics;
        public List<RewardData>? buyFromQuestReward;

        public bool isActive;
        public bool isSupport;
        public HashSet<string>? tags;
        public HashSet<string>? alt_name = null;

        //gem image fields
        //TODO figure out how to store gem image in class
        //public transient Image gemIcon;
        //public transient Image smallGemIcon;
        //public transient Label cacheLabel
        public Bitmap gemIcon;
        public Bitmap smallGemIcon;

        public bool IsBoughtFromQuestReward()
        {
            if (buyFromQuestReward.Count < 0)
            {
                return true;
            } else
            {
                return false;
            }
        }

        //constructor
        public Gem(string gemName)
        {
            this.gemName = gemName;
            classCanBuy = new List<string>();
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

        public Gem(Gem dupe)
        {
            classCanBuy = new List<string>();
            level_added = -1;
            replaced = false;
            replacedWith = null;
            replaces = false;
            replacesGem = null;
            id = -1;
            id_replaced = -1;
            id_replaces = -1;
            this.gemIcon = dupe.GetIcon();
            this.smallGemIcon = dupe.GetSmallIcon();
            this.gemName = dupe.GetGemName();
            //more
            this.id = dupe.id;
            this.availableAfterThisQuest = dupe.availableAfterThisQuest;
            this.sellingVendor = dupe.sellingVendor;
            this.actFirstAvailable = dupe.actFirstAvailable;
            this.required_lvl = dupe.required_lvl;
            this.isVaalGem = dupe.isVaalGem;
            this.classCanBuy = new List<string>(dupe.classCanBuy);
            this.townCanBuyIn = dupe.townCanBuyIn;
            this.gemColor = dupe.gemColor;
            this.iconPath = dupe.iconPath;
            //this.cachedLabel = dupe.cachedLabel;
            this.iconDirPath = dupe.iconDirPath;
            this.isQuestReward = dupe.isQuestReward;
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
            if (level_added != -1)
            {
                return level_added;
            } else
            {
                return required_lvl;
            }
        }

        public Bitmap GetIcon()
        {
            return gemIcon;
        }

        public Bitmap GetSmallIcon()
        {
            return smallGemIcon;
        }

        public string? GetGemName()
        {
            return gemName;
        }

        public bool IsSameGemNameOrOlder(string gemNameFromImport)
        {
            if (gemName.Equals(gemNameFromImport, StringComparison.InvariantCultureIgnoreCase))
            {
                return true;
            } else
            {
                if (alt_name != null && alt_name.Contains(gemNameFromImport))
                {
                    //Console.WriteLine("**** Found old gem name: " + gemNameFromImport + " should be " + gemName + " now.");
                    return true;
                }
                return false;
            }
        }

        public Gem DupeGem()
        {
            return new Gem(this);
        }

        public List<string>? GetClassesCanBuy()
        {
            return classCanBuy;
        }

        public void PutNewClassCanBuy(string newClassCanBuy)
        {
            classCanBuy.Add(newClassCanBuy);
        }

        public string GetGemColor()
        {
            return gemColor;
        }

        /*public Label GetLabel() {
            cacheLabel = new Label();
            cacheLabel.setTest(name);
            cacheLabel.setGraphic(new ImageView(gemIcon));
            return cacheLabel;
        }*/

        public void ResizeImage()
        {
            //get size of gem image
            int w = gemIcon.Width;
            int h = gemIcon.Height;
            // Create small gem image of the proper size
            int w2 = (int)(w * 0.7);
            int h2 = (int)(h * 0.7);
            smallGemIcon = new Bitmap(gemIcon, new Size(w2,h2));            
        }

    }
}
