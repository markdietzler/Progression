
using System.Collections.Generic;

namespace Progression_Library.Data
{
    public class Build
    {
        public string buildName;
        List<SocketGroup> gems;
        public bool hasPob;
        public string pobLink;
        public bool isValid;
        private readonly CharacterInfo M_CharacterInfo = new CharacterInfo();

        public Build(string buildName, string className, string ascendencyName)
        {
            this.buildName = buildName;
            M_CharacterInfo.className = className;
            M_CharacterInfo.ascendancyName = ascendencyName;
            gems = new List<SocketGroup>();
            M_CharacterInfo.level = -1;
            M_CharacterInfo.characterName = "";
        }

        public void SetCharacterInfo(CharacterInfo charInfo)
        {
            // TODO don't overwrite ascendency in the Build
            M_CharacterInfo.characterName = charInfo.characterName;
            M_CharacterInfo.level = charInfo.level;
        }

        public CharacterInfo GetCharacterInfo()
        {
            return M_CharacterInfo;
        }

        public string GetName()
        {
            return buildName;
        }

        public string GetCharacterName()
        {
            return M_CharacterInfo.characterName;
        }

        public void SetCharacterName(string newCharacterName)
        {
            M_CharacterInfo.characterName = newCharacterName;
        }

        public int GetCharacterLevel()
        {
            return M_CharacterInfo.level;
        }

        public void SetCharacterLevel(int newLevel)
        {
            M_CharacterInfo.level = newLevel;
        }

        public string GetClassName()
        {
            return M_CharacterInfo.className;
        }

        public string GetAsc()
        {
            return M_CharacterInfo.ascendancyName;
        }

        public List<SocketGroup> GetSocketGroup()
        {
            return gems;
        }

        public bool Validate()
        {
            //System.out.println(">>>>Validating build :" + this.buildName + "... <<<<");
            foreach (SocketGroup sg in GetSocketGroup())
            {
                if (sg.GetActiveGem() == null)
                {
                    //System.out.println(">>>>A socket group doesn't have a valid main gem.<<<<");
                    return false;
                }
                else
                {
                    //System.out.println("SocketGroup # "+sg.getActiveGem().getGemName());
                    //System.out.println("- Use at level: "+sg.fromGroupLevel);
                    if (sg.ReplaceGroup())
                    {
                        if (sg.GetGroupReplaced().GetActiveGem() == null)
                        {
                            //System.out.println(">>>>Socket group -"+sg.getActiveGem().getGemName()+" replaces with a socket group that doesn't have a valid main gem.");
                            return false;
                        }
                        if (sg.GetGroupReplaced().GetFromGroupLevel() != sg.GetUntilGroupLevel())
                        {
                            //System.out.println(">>>>Socket group -"+sg.getActiveGem().getGemName()+"- replaces with -"
                            // +sg.getGroupReplaced().getActiveGem().getGemName()+"- and group levels don't match.");
                            return false;
                        }
                        //System.out.println("- Replace at level: "+sg.untilGroupLevel);
                        //System.out.println("- Replace with : -"+sg.getGroupReplaced().getActiveGem().getGemName()+"- .");
                    }

                    //inner loop
                    List<Gem> sorted = new List<Gem>(sg.GetGems());
                    //sorted.sort(Comparator.comparing(Gem::getLevelAdded));
                    foreach (Gem g in sorted)
                    {
                        if (g.GetGemName().Equals("<empty group>"))
                        {
                            //System.out.println(">>>>A gem in this socket group is not set.<<<<");
                            return false;
                        }
                        //System.out.println("--Gem # "+g.getGemName());
                        //System.out.println("--- Use at level: "+g.getLevelAdded());
                        if (g.replaced)
                        {
                            if (g.replacedWith == null)
                            {
                                //  System.out.println(">>>>Gem -"+g.getGemName()+" replacement has not been set.");
                                return false;
                            }
                            if (g.replacedWith.GetLevelAdded() <= g.GetLevelAdded())
                            {
                                //  System.out.println(">>>>Gem -"+g.getGemName()+"- replaces with -"
                                //      +g.replacedWith.getGemName()+"- and change level don't match.");
                                return false;
                            }
                            // System.out.println("--- Replace at level: "+g.replacedWith.getLevelAdded());
                            //System.out.println("--- Replace with : -"+g.replacedWith.getGemName()+"- .");
                        }
                    }
                }
            }
            if (GetSocketGroup().Count == 0)
            {
                //System.out.println(">>>>This build has no socket groups created.<<<<");
                return false;
            }
            //isValid = true;
            return true;
        }

        public string validate_failed_string()
        {
            string error = ">>>>Validating build :" + this.buildName + "... <<<<\n";
            //System.out.println(error);
            if (GetSocketGroup().Count == 0)
            {
                // System.out.println(">>>>This build has no socket groups created.<<<<");
                error += ">>>>This build has no socket groups created.<<<<";
                return error;
            }
            foreach (SocketGroup sg in GetSocketGroup())
            {
                if (sg.GetActiveGem() == null)
                {
                    //   System.out.println(">>>>A socket group doesn't have a valid main gem.<<<<");
                    error += ">>>>A socket group doesn't have a valid main gem.<<<<";
                    return error;
                }
                else
                {
                    // System.out.println("SocketGroup # "+sg.getActiveGem().getGemName());
                    error += "SocketGroup # " + sg.GetActiveGem().GetGemName() + "\n";
                    // System.out.println("- Use at level: "+sg.fromGroupLevel);
                    error += "- Use at level: " + sg.GetFromGroupLevel() + "\n";
                    if (sg.ReplaceGroup())
                    {
                        if (sg.GetGroupReplaced().GetActiveGem() == null)
                        {
                            //  System.out.println(">>>>Socket group -"+sg.getActiveGem().getGemName()+" replaces with a socket group that doesn't have a valid main gem.");
                            error += ">>>>Socket group -" + sg.GetActiveGem().GetGemName() + " replaces with a socket group that doesn't have a valid main gem.\n";
                            return error;
                        }
                        if (sg.GetGroupReplaced().GetFromGroupLevel() != sg.GetUntilGroupLevel())
                        {
                            // System.out.println(">>>>Socket group -"+sg.getActiveGem().getGemName()+"- replaces with -"
                            //      +sg.getGroupReplaced().getActiveGem().getGemName()+"- and group levels don't match.");
                            error += ">>>>Socket group -" + sg.GetActiveGem().GetGemName() + "- replaces with -"
                                    + sg.GetGroupReplaced().GetActiveGem().GetGemName() + "- and group levels don't match.\n";
                            return error;
                        }
                        // System.out.println("- Replace at level: "+sg.untilGroupLevel);
                        error += "- Replace at level: " + sg.GetUntilGroupLevel() + "\n";
                        // System.out.println("- Replace with : -"+sg.getGroupReplaced().getActiveGem().getGemName()+"- .");
                        error += "- Replace with : -" + sg.GetGroupReplaced().GetActiveGem().GetGemName() + "- .\n";
                    }

                    //inner loop
                    List<Gem> sorted = new List<Gem>(sg.GetGems());
                    //sorted.sort(Comparator.comparing(Gem::getLevelAdded));
                    foreach (Gem g in sorted)
                    {
                        if (g.GetGemName().Equals("<empty group>"))
                        {
                            // System.out.println(">>>>A gem in this socket group is not set.<<<<");
                            error += ">>>>A gem in this socket group is not set.<<<<\n";
                            return error;
                        }
                        //  System.out.println("--Gem # "+g.getGemName());
                        error += "--Gem # " + g.GetGemName() + "\n";
                        // System.out.println("--- Use at level: "+g.getLevelAdded());
                        error += "--- Use at level: " + g.GetLevelAdded() + "\n";
                        if (g.replaced)
                        {
                            if (g.replacedWith == null)
                            {
                                // System.out.println(">>>>Gem -"+g.getGemName()+" replacement has not been set.");
                                error += ">>>>Gem -" + g.GetGemName() + " replacement has not been set.\n";
                                return error;
                            }
                            if (g.replacedWith.GetLevelAdded() <= g.GetLevelAdded())
                            {
                                //  System.out.println(">>>>Gem -"+g.getGemName()+"- replaces with -"
                                //    +g.replacedWith.getGemName()+"- and change level don't match.");
                                error += ">>>>Gem -" + g.GetGemName() + "- replaces with -"
                                        + g.replacedWith.GetGemName() + "- and change level don't match.\n";
                                return error;
                            }
                            // System.out.println("--- Replace at level: "+g.replacedWith.getLevelAdded());
                            error += "--- Replace at level: " + g.replacedWith.GetLevelAdded() + "\n";
                            // System.out.println("--- Replace with : -"+g.replacedWith.getGemName()+"- .");
                            error += "--- Replace with : -" + g.replacedWith.GetGemName() + "- .\n";
                        }
                    }
                }
            }
            return error;
        }

        public void patch_missing_sgroups()
        {
            List<SocketGroup> deleted = new List<SocketGroup>();
            foreach (SocketGroup sg in GetSocketGroup())
            {
                if (sg.GetActiveGem() == null)
                {
                    //System.out.println("patching>>>>A socket group doesn't have a valid main gem.<<<<");
                    if (sg.GetGems() == null || sg.GetGems().Count == 0)
                    {
                        //System.out.println("patching>>>>Deleting empty socket group<<<<");
                        deleted.Add(sg);
                    }
                    else
                    {
                        //System.out.println("patching>>>>Trying to set an active gem for the group<<<<");
                        foreach (Gem g in sg.GetGems())
                        {
                            if (g.isActive)
                            {
                                sg.SetActiveGem(g);
                                //System.out.println("patching>>>>Managed to set an active gem for the group<<<<");
                            }
                        }
                        if (sg.GetActiveGem() == null)
                        {
                            //System.out.println("patching>>>>No actives gems were available.<<<<");
                            sg.SetActiveGem(sg.GetGems()[0]);
                            //System.out.println("patching>>>>Set the first gem in the socket group as main gem.<<<<");
                        }
                    }
                }
            }
        }

    }
}
