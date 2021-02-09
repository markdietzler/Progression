using System.Collections.Generic;

namespace Progression_Library.Data
{
    public class SocketGroup
    {
        List<Gem> listOfGems;
        Gem active;
        //settings
        int fromGroupLevel;
        int untilGroupLevel;

        bool replaceGroup;
        bool replacesGroup;
        SocketGroup socketGroupReplace;
        SocketGroup socketGroupThatReplaces;
        //int indexOfReplaceGroup;
        
        Dictionary<int, int> linkerToListIndex;
        public int id;
        // IDS FOR JSON CONVERTION
        public int id_replace;
        public int id_replaces;
        public int active_id;

        private string note;

        public void AddNote(string note)
        {
            this.note = note;
        }

        public string GetNote()
        {
            return note;
        }

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

        public SocketGroup Dupe(HashSet<int> s_id, HashSet<int> g_id)
        {
            SocketGroup duped = new SocketGroup();
            Gem old_active = this.active;
            duped.id = Sign(s_id);
            duped.fromGroupLevel = this.fromGroupLevel;
            duped.untilGroupLevel = this.untilGroupLevel;
            duped.AddNote(this.note);
            foreach (Gem g in listOfGems)
            {
                Gem duped_gem = g.DupeGem();
                duped_gem.level_added = g.level_added;
                duped_gem.id = Sign(g_id);
                duped.GetGems().Add(duped_gem);
                if (g.Equals(old_active))
                {
                    duped.active = duped_gem;
                    duped.active_id = duped_gem.id;
                }
            }
            return duped;
        }

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
            //indexOfReplaceGroup= -1;
            linkerToListIndex = new Dictionary<int, int>();
            id = -1;
            id_replace = -1;
            id_replaces = -1;
            active_id = -1;
        }

        int switche;

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
        //gets called on load from json
        public void LinkGem(Gem gem, int id)
        {
            linkerToListIndex.Add(id, listOfGems.IndexOf(gem));
        }

        public int DoubleCheck()
        {

            return switche;
        }

        public void RemoveGem(Gem gem, int id)
        {

        }

        public Gem GetActiveGem()
        {
            return active;
        }

        public void SetActiveGem(Gem g)
        {
            active = g;
        }

        public List<Gem> GetGems()
        {
            return listOfGems;
        }

        public int GetFromGroupLevel()
        {
            return fromGroupLevel;
        }

        public void SetFromGroupLevel(int a)
        {
            fromGroupLevel = a;
        }

        public int GetUntilGroupLevel()
        {
            return untilGroupLevel;
        }

        public void SetUntilGroupLevel(int a)
        {
            untilGroupLevel = a;
        }

        public bool ReplaceGroup()
        {
            return replaceGroup;
        }

        public void SetReplaceGroup(bool a)
        {
            replaceGroup = a;
            if (a == false)
            {
                socketGroupReplace = null;
            }
        }

        public SocketGroup GetGroupReplaced()
        {
            return socketGroupReplace;
        }

        public void SetGroupReplaced(SocketGroup a)
        {
            socketGroupReplace = a;
        }

        public bool ReplacesGroup()
        {
            return replacesGroup;
        }

        public void SetReplacesGroup(bool a)
        {
            replacesGroup = a;
            if (a == false)
            {
                socketGroupThatReplaces = null;
            }
        }

        public SocketGroup GetGroupThatReplaces()
        {
            return socketGroupThatReplaces;
        }

        public void SsetGroupThatReplaces(SocketGroup a)
        {
            socketGroupThatReplaces = a;
        }

    }
}
