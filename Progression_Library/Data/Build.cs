
using System.Collections.Generic;

namespace Progression_Library.Data
{
    public class Build
    {
        private string buildName;
        private List<SocketGroup> gems;
        private bool hasPob;
        private string? pobLink;
        private bool isValid;
        private readonly CharacterInfo M_CharacterInfo = new CharacterInfo();

        public Build(string buildName, string className, string ascendencyName)
        {
            this.buildName = buildName;
            M_CharacterInfo.SetClassName(className);
            M_CharacterInfo.SetAscendency(ascendencyName);
            gems = new List<SocketGroup>();
            M_CharacterInfo.SetLevel(-1);
            M_CharacterInfo.SetCharName("");
        }

        public void SetCharacterInfo(CharacterInfo charInfo)
        {
            // TODO don't overwrite ascendency in the Build
            M_CharacterInfo.SetCharName(charInfo.GetCharacterName());
            M_CharacterInfo.SetLevel(charInfo.GetLevel());
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
            return M_CharacterInfo.GetCharacterName();
        }

        public void SetCharacterName(string newCharacterName)
        {
            M_CharacterInfo.SetCharName(newCharacterName);
        }

        public int GetCharacterLevel()
        {
            return M_CharacterInfo.GetLevel();
        }

        public void SetCharacterLevel(int newLevel)
        {
            M_CharacterInfo.SetLevel(newLevel);
        }

        public string GetClassName()
        {
            return M_CharacterInfo.GetClassType();
        }

        public string GetAsc()
        {
            return M_CharacterInfo.GetAscendency();
        }

        public void SetSocketGroups(List<SocketGroup> newList)
        {
            gems = newList;
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
                    if (sg.IsReplaceGroup())
                    {
                        if (sg.GetSocketGroupReplace().GetActiveGem() == null)
                        {
                            //System.out.println(">>>>Socket group -"+sg.getActiveGem().getGemName()+" replaces with a socket group that doesn't have a valid main gem.");
                            return false;
                        }
                        if (sg.GetSocketGroupReplace().GetFromGroupLevel() != sg.GetUntilGroupLevel())
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
                        if (g.GetReplaced())
                        {
                            if (g.GetReplacedWith() == null)
                            {
                                //  System.out.println(">>>>Gem -"+g.getGemName()+" replacement has not been set.");
                                return false;
                            }
                            if (g.GetReplacedWith().GetLevelAdded() <= g.GetLevelAdded())
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

        public string Validate_failed_string()
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
                    if (sg.IsReplaceGroup())
                    {
                        if (sg.GetSocketGroupReplace().GetActiveGem() == null)
                        {
                            //  System.out.println(">>>>Socket group -"+sg.getActiveGem().getGemName()+" replaces with a socket group that doesn't have a valid main gem.");
                            error += ">>>>Socket group -" + sg.GetActiveGem().GetGemName() + " replaces with a socket group that doesn't have a valid main gem.\n";
                            return error;
                        }
                        if (sg.GetSocketGroupReplace().GetFromGroupLevel() != sg.GetUntilGroupLevel())
                        {
                            // System.out.println(">>>>Socket group -"+sg.getActiveGem().getGemName()+"- replaces with -"
                            //      +sg.getGroupReplaced().getActiveGem().getGemName()+"- and group levels don't match.");
                            error += ">>>>Socket group -" + sg.GetActiveGem().GetGemName() + "- replaces with -"
                                    + sg.GetSocketGroupReplace().GetActiveGem().GetGemName() + "- and group levels don't match.\n";
                            return error;
                        }
                        // System.out.println("- Replace at level: "+sg.untilGroupLevel);
                        error += "- Replace at level: " + sg.GetUntilGroupLevel() + "\n";
                        // System.out.println("- Replace with : -"+sg.getGroupReplaced().getActiveGem().getGemName()+"- .");
                        error += "- Replace with : -" + sg.GetSocketGroupReplace().GetActiveGem().GetGemName() + "- .\n";
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
                        if (g.GetReplaced())
                        {
                            if (g.GetReplacedWith() == null)
                            {
                                // System.out.println(">>>>Gem -"+g.getGemName()+" replacement has not been set.");
                                error += ">>>>Gem -" + g.GetGemName() + " replacement has not been set.\n";
                                return error;
                            }
                            if (g.GetReplacedWith().GetLevelAdded() <= g.GetLevelAdded())
                            {
                                //  System.out.println(">>>>Gem -"+g.getGemName()+"- replaces with -"
                                //    +g.replacedWith.getGemName()+"- and change level don't match.");
                                error += ">>>>Gem -" + g.GetGemName() + "- replaces with -"
                                        + g.GetReplacedWith().GetGemName() + "- and change level don't match.\n";
                                return error;
                            }
                            // System.out.println("--- Replace at level: "+g.replacedWith.getLevelAdded());
                            error += "--- Replace at level: " + g.GetReplacedWith().GetLevelAdded() + "\n";
                            // System.out.println("--- Replace with : -"+g.replacedWith.getGemName()+"- .");
                            error += "--- Replace with : -" + g.GetReplacedWith().GetGemName() + "- .\n";
                        }
                    }
                }
            }
            return error;
        }

        public void Patch_Missing_Socket_Groups()
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
                            if (g.GetIsActive())
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
