using System.Collections.Generic;

namespace Progression_Library.Data
{
    public class SocketGroup
    {
        private List<Gem> listOfGems;
        private Gem? active;
        //settings
        private int fromGroupLevel;
        private int untilGroupLevel;
        private int switche;

        private bool replaceGroup;
        private bool replacesGroup;
        private SocketGroup socketGroupReplace;
        private SocketGroup socketGroupThatReplaces;
        //int indexOfReplaceGroup;
        
        private Dictionary<int, int> linkerToListIndex;
        private int socket_group_id;

        // IDS FOR JSON CONVERTION
        private int id_replacement;
        private int id_to_replace;
        private int active_id;

        private string socketGroupNote;

        #region setters
               

        public void SetGemList(List<Gem> newList)
        {
            listOfGems = newList;
        }

        public void SetActiveGem(Gem newGem)
        {
            active = newGem;
        }

        public void SetFromGroupLevel(int floor)
        {
            fromGroupLevel = floor;
        }

        public void SetUntilGroupLevel( int ceiling)
        {
            untilGroupLevel = ceiling;
        }

        public void SetGroupLevelCeiling(int ceiling)
        {
            untilGroupLevel = ceiling;
        }

        public void SetSocketGroupID(int newGroupID)
        {
            socket_group_id = newGroupID;
        }

        public void SetReplacementID(int newReplacementID)
        {
            id_replacement = newReplacementID;
        }

        public void SetReplacedID(int newReplacedID)
        {
            id_replacement = newReplacedID;
        }
        public void SetActiveID(int newActiveID)
        {
            id_replacement = newActiveID;
        }

        public void SetNote(string newNote)
        {
            this.socketGroupNote = newNote;
        }

        #endregion

        #region getters

        public List<Gem> GetGems()
        {
            return listOfGems;
        }

        public Gem GetActiveGem()
        {
            return active;
        }

        public int GetFromGroupLevel()
        {
            return fromGroupLevel;
        }

        public int GetUntilGroupLevel()
        {
            return untilGroupLevel;
        }

        public int GetSwitche()
        {
            return switche;
        }
        
        public bool IsReplaceGroup()
        {
            return replaceGroup;
        }

        public bool IsReplaceesGroup()
        {
            return replacesGroup;
        }

        public SocketGroup GetSocketGroupReplace()
        {
            return socketGroupReplace;
        }

        public SocketGroup GetSocketGroupThatReplaces()
        {
            return socketGroupThatReplaces;
        }

        public int GetSocketGroupID()
        {
            return socket_group_id;
        }

        public int GetIDToReplace()
        {
            return id_replacement;
        }

        public int GetIDOfReplaced()
        {
            return id_to_replace;
        }

        public int GetActiveID()
        {
            return active_id;
        }

        public string GetSocketGroupNote()
        {
            return socketGroupNote;
        }

        #endregion

        public SocketGroup()
        {
            listOfGems = new List<Gem>();
            active = null;
            //gems.add(GemHolder.getInstance().tossDummie());
            //active.add(GemHolder.getInstance().tossDummie());
            fromGroupLevel = 2;
            untilGroupLevel = 36;
            replaceGroup = false;
            socketGroupReplace = null;
            replacesGroup = false;
            socketGroupThatReplaces = null;
            //indexOfReplaceGroup = -1;
            linkerToListIndex = new Dictionary<int, int>();
            socket_group_id = -1;
            id_replacement = -1;
            id_to_replace = -1;
            active_id = -1;
        }

        #region class methods

        public static int Sign(HashSet<int> randomIDs)
        {
            int ran;
            do
            {
                //generate random trhread safe int between 1 and 99999
                //java code: ran = ThreadLocalRandom.current().nextInt(1,999999);
                ran = 8;
            } while (randomIDs.Contains(ran));
            randomIDs.Add(ran);
            return ran;
        }

        public SocketGroup Dupe(HashSet<int> socket_group_id, HashSet<int> gem_id)
        {
            SocketGroup duped = new SocketGroup();
            Gem old_active = this.active;
            duped.socket_group_id = Sign(socket_group_id);
            duped.SetFromGroupLevel(this.GetFromGroupLevel());
            duped.SetUntilGroupLevel(this.GetUntilGroupLevel());
            duped.SetNote(this.socketGroupNote);
            foreach (Gem g in listOfGems)
            {
                Gem duped_gem = g.DupeGem();
                g.SetLevelAdded(duped_gem.GetLevelAdded());
                duped_gem.SetGemID(Sign(gem_id));
                duped.GetGems().Add(duped_gem);
                if (g.Equals(old_active))
                {
                    duped.active = duped_gem;
                    duped.active_id = duped_gem.GetGemID();
                }
            }
            return duped;
        }

        public Gem PutGem(Gem gem, int id)
        {
            bool switcher = false;
            switche = -1;
            Gem g = null;
            if (linkerToListIndex.ContainsKey(id))
            {

            }
            else
            {
                listOfGems.Add(gem);
                linkerToListIndex.Add(id, listOfGems.Count - 1);
            }
            return g;
        }

        #endregion
    }
}
