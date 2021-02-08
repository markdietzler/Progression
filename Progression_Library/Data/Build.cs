
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

        public void setCharacterName(string newCharacterName)
        {
            M_CharacterInfo.characterName = newCharacterName;
        }

        public int getCharacterLevel()
        {
            return M_CharacterInfo.level;
        }

        public void setCharacterLevel(int newLevel)
        {
            M_CharacterInfo.level = newLevel;
        }

        public string getClassName()
        {
            return M_CharacterInfo.className;
        }

        public string getAsc()
        {
            return M_CharacterInfo.ascendancyName;
        }

        public List<SocketGroup> getSocketGroup()
        {
            return gems;
        }

        public bool validate()
        {
            //System.out.println(">>>>Validating build :" + this.buildName + "... <<<<");
            foreach (SocketGroup sg in getSocketGroup())
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
                    List<SkillGem> sorted = new List<SkillGem>(sg.GetGems());
                    //sorted.sort(Comparator.comparing(Gem::getLevelAdded));
                    foreach (SkillGem g in sorted)
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
            if (getSocketGroup().Count == 0)
            {
                //System.out.println(">>>>This build has no socket groups created.<<<<");
                return false;
            }
            //isValid = true;
            return true;
        }

        public String validate_failed_string()
        {
            String error = ">>>>Validating build :" + this.buildName + "... <<<<\n";
            //System.out.println(error);
            if (getSocketGroup().isEmpty())
            {
                // System.out.println(">>>>This build has no socket groups created.<<<<");
                error += ">>>>This build has no socket groups created.<<<<";
                return error;
            }
            for (SocketGroup sg : getSocketGroup())
            {
                if (sg.getActiveGem() == null)
                {
                    //   System.out.println(">>>>A socket group doesn't have a valid main gem.<<<<");
                    error += ">>>>A socket group doesn't have a valid main gem.<<<<";
                    return error;
                }
                else
                {
                    // System.out.println("SocketGroup # "+sg.getActiveGem().getGemName());
                    error += "SocketGroup # " + sg.getActiveGem().getGemName() + "\n";
                    // System.out.println("- Use at level: "+sg.fromGroupLevel);
                    error += "- Use at level: " + sg.fromGroupLevel + "\n";
                    if (sg.replaceGroup())
                    {
                        if (sg.getGroupReplaced().getActiveGem() == null)
                        {
                            //  System.out.println(">>>>Socket group -"+sg.getActiveGem().getGemName()+" replaces with a socket group that doesn't have a valid main gem.");
                            error += ">>>>Socket group -" + sg.getActiveGem().getGemName() + " replaces with a socket group that doesn't have a valid main gem.\n";
                            return error;
                        }
                        if (sg.getGroupReplaced().getFromGroupLevel() != sg.getUntilGroupLevel())
                        {
                            // System.out.println(">>>>Socket group -"+sg.getActiveGem().getGemName()+"- replaces with -"
                            //      +sg.getGroupReplaced().getActiveGem().getGemName()+"- and group levels don't match.");
                            error += ">>>>Socket group -" + sg.getActiveGem().getGemName() + "- replaces with -"
                                    + sg.getGroupReplaced().getActiveGem().getGemName() + "- and group levels don't match.\n";
                            return error;
                        }
                        // System.out.println("- Replace at level: "+sg.untilGroupLevel);
                        error += "- Replace at level: " + sg.untilGroupLevel + "\n";
                        // System.out.println("- Replace with : -"+sg.getGroupReplaced().getActiveGem().getGemName()+"- .");
                        error += "- Replace with : -" + sg.getGroupReplaced().getActiveGem().getGemName() + "- .\n";
                    }

                    //inner loop
                    ArrayList<Gem> sorted = new ArrayList<>(sg.getGems());
                    sorted.sort(Comparator.comparing(Gem::getLevelAdded));
                    for (Gem g : sorted)
                    {
                        if (g.getGemName().equals("<empty group>"))
                        {
                            // System.out.println(">>>>A gem in this socket group is not set.<<<<");
                            error += ">>>>A gem in this socket group is not set.<<<<\n";
                            return error;
                        }
                        //  System.out.println("--Gem # "+g.getGemName());
                        error += "--Gem # " + g.getGemName() + "\n";
                        // System.out.println("--- Use at level: "+g.getLevelAdded());
                        error += "--- Use at level: " + g.getLevelAdded() + "\n";
                        if (g.replaced)
                        {
                            if (g.replacedWith == null)
                            {
                                // System.out.println(">>>>Gem -"+g.getGemName()+" replacement has not been set.");
                                error += ">>>>Gem -" + g.getGemName() + " replacement has not been set.\n";
                                return error;
                            }
                            if (g.replacedWith.getLevelAdded() <= g.getLevelAdded())
                            {
                                //  System.out.println(">>>>Gem -"+g.getGemName()+"- replaces with -"
                                //    +g.replacedWith.getGemName()+"- and change level don't match.");
                                error += ">>>>Gem -" + g.getGemName() + "- replaces with -"
                                        + g.replacedWith.getGemName() + "- and change level don't match.\n";
                                return error;
                            }
                            // System.out.println("--- Replace at level: "+g.replacedWith.getLevelAdded());
                            error += "--- Replace at level: " + g.replacedWith.getLevelAdded() + "\n";
                            // System.out.println("--- Replace with : -"+g.replacedWith.getGemName()+"- .");
                            error += "--- Replace with : -" + g.replacedWith.getGemName() + "- .\n";
                        }
                    }
                }
            }
            return error;
        }

        public void patch_missing_sgroups()
        {
            ArrayList<SocketGroup> deleted = new ArrayList<>();
            for (SocketGroup sg : getSocketGroup())
            {
                if (sg.getActiveGem() == null)
                {
                    System.out.println("patching>>>>A socket group doesn't have a valid main gem.<<<<");
                    if (sg.getGems() == null || sg.getGems().isEmpty())
                    {
                        System.out.println("patching>>>>Deleting empty socket group<<<<");
                        deleted.add(sg);
                    }
                    else
                    {
                        System.out.println("patching>>>>Trying to set an active gem for the group<<<<");
                        for (Gem g : sg.getGems())
                        {
                            if (g.isActive)
                            {
                                sg.setActiveGem(g);
                                System.out.println("patching>>>>Managed to set an active gem for the group<<<<");
                            }
                        }
                        if (sg.getActiveGem() == null)
                        {
                            System.out.println("patching>>>>No actives gems were available.<<<<");
                            sg.setActiveGem(sg.getGems().get(0));
                            System.out.println("patching>>>>Set the first gem in the socket group as main gem.<<<<");
                        }
                    }
                }
            }
        }

    }
}
