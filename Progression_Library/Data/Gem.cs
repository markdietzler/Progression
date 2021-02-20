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

        #region variables

        //gem fields

        private int id;
        private string? gemName;
        private string? availableAfterThisQuest;
        private string? sellingVendor;
        private int actFirstAvailable;
        private int required_lvl;
        private int level_added;
        private bool isVaalGem;
        private List<String>? classCanBuy;
        private string? townCanBuyIn;
        private string? gemColor;
        private string? iconPath;
        private string? iconDirPath;
        private bool replaced;
        private Gem? replacedWith;
        private bool replaces;
        private Gem? replacesGem;

        //IDS FOR JSON CONVERTION
        private int id_replaced;
        private int id_replaces;

        //quest reward fields
        private bool isQuestReward;
        private RewardData? rewardSpecifics;
        private List<RewardData>? buyFromQuestReward;

        private bool isActive;
        private bool isSupport;
        private HashSet<string>? tags;
        private HashSet<string>? alt_name = null;

        //gem image fields
        //TODO figure out how to store gem image in class
        //public transient Image gemIcon;
        //public transient Image smallGemIcon;
        //public transient Label cacheLabel
        private Bitmap gemIcon;
        private Bitmap smallGemIcon;

        #endregion
        
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



        #region setters
        public void SetGemID(int newID)
        {
            id = newID;
        }

        private void SetGemName(string newName)
        {
            gemName = newName;
        }

        private void SetAvailableAfterThisQuest(string quest)
        {
            availableAfterThisQuest = quest;
        }

        private void SetSellingVendor(string vendor)
        {
            sellingVendor = vendor;
        }

        public void SetActAvailable(int act)
        {
            if(act < 1 || act > 10)
            {
                throw new ArgumentOutOfRangeException("There are only acts 1 thru 10, you can't set the act this gem becomes available to one that does not exist!");
            } else
            {
                actFirstAvailable = act;
            }            
        }

        public void SetRequiredLevel(int level)
        {
            if(level < 1 || level > 38)
            {
                throw new ArgumentOutOfRangeException("Valid required gem level range is 1 - 38, you tried to set the required level to: " + level);
            } else
            {
                required_lvl = level;
            }
        }

        public void SetLevelAdded(int add)
        {
            level_added = add;
        }

        public void SetIsVaalGem()
        {
            isVaalGem = true;
        }

        public void SetIsNotVaalGem()
        {
            isVaalGem = false;
        }        

        public void SetTownCanBuyIn(string town)
        {
            townCanBuyIn = town;
        }

        public void SetGemColor(string color)
        {
            gemColor = color;
        }

        public void SetIconPath(string icon)
        {
            iconPath = icon;
        }

        public void SetIconDirPath(string icon)
        {
            iconDirPath = icon;
        }

        public void SetReplacedTrue()
        {
            replaced = true;
        }

        public void SetReplacedFalse()
        {
            replaced = false;
        }        
        
        public void SetGemReplaces()
        {
            replaces = true;
        }

        public void SetGemDoesntReplaces()
        {
            replaces = false;
        }        

        public void SetGemIsQuestReward()
        {
            isQuestReward = true;
        }

        public void SetGemISNOTQuestReward()
        {
            isQuestReward = false;
        }

        #endregion

        #region getters

        public List<string>? GetClassesCanBuy()
        {
            return classCanBuy;
        }

        public int GetGemID()
        {
            return id;
        }

        public string? GetGemName()
        {
            return gemName;
        }

        public string? GetQuestIsAvailableAfter()
        {
            return availableAfterThisQuest;
        }

        public string? GetSellingVendor()
        {
            return sellingVendor;
        }

        public int GetLevelAdded()
        {
            if (level_added != -1)
            {
                return level_added;
            }
            else
            {
                return required_lvl;
            }
        }

        public string? GetGemColor()
        {
            return gemColor;
        }

        public bool GetReplaced()
        {
            return replaced;
        }

        public bool GetIsActive()
        {
            return isActive;
        }       

        public Bitmap GetIcon()
        {
            return gemIcon;
        }

        public Bitmap GetSmallIcon()
        {
            return smallGemIcon;
        }        

        public Gem DupeGem()
        {
            return new Gem(this);
        }

        public Gem? GetReplacedWith()
        {
            return replacedWith;
        }       

        #endregion

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

        public void PutNewClassCanBuy(string newClassCanBuy)
        {
            classCanBuy.Add(newClassCanBuy);
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

        public bool IsBoughtFromQuestReward()
        {
            if (buyFromQuestReward.Count < 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #region utility methods

        public void AddAltNamesFromJSON(IEnumerable<Object> jsonArrayIterator)
        {
            //TODO figure out what alt_name is used for in path of levelling
        }

        #endregion
    }
}
