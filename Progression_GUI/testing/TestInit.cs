using Progression_Library.Data;
using System.Collections.Generic;
using System.Text;

namespace Progression_GUI.testing
{
    public class TestInit
    {
        /**
         * Hard coded class that sets up a dummy Ranger Raider for testing the GUI with
         */

        Build ?mTestingBuild = null;

        SocketGroup bow = new SocketGroup();
        SocketGroup chest = new SocketGroup();
        SocketGroup helmet = new SocketGroup();
        SocketGroup gloves = new SocketGroup();
        SocketGroup boots = new SocketGroup();

        public TestInit()
        {
            InitGroups();
        }

        public List<SocketGroup> SetGroupList()
        {
            List<SocketGroup> gemGroups = new List<SocketGroup>
            {
                bow,
                chest,
                helmet,
                gloves,
                boots
            };
            return gemGroups;
        }

        private void SetUpBuild(string buildName, string buildClass, string buildAscendency)
        {
            mTestingBuild = new Build(buildName, buildClass, buildAscendency);
            mTestingBuild.SetSocketGroups(SetGroupList());
        }

        private void InitGroups()
        {
            LoadBow();
            LoadHelmet();
            LoadChest();
            LoadGloves();
            LoadBoots();
            SetUpBuild("Test Ranger Raider","Ranger","Raider");
        }

        private void LoadBow()
        {
            bow.PutGem(new Gem("RainOfSpores"), 1);
            bow.PutGem(new Gem("SupportGemMirageArcher"), 2);
            bow.PutGem(new Gem("SupportPhysicalProjectileAttackDamage"), 3);
            bow.PutGem(new Gem("SupportVoidManipulation"), 4);
            bow.PutGem(new Gem("SupportRapidDecay"), 5);
            bow.PutGem(new Gem("SupportFasterAttack"), 6);
        }

        private void LoadHelmet()
        {
            bow.PutGem(new Gem("XXX"), 7);
            bow.PutGem(new Gem("XXX"), 8);
            bow.PutGem(new Gem("XXX"), 9);
            bow.PutGem(new Gem("XXX"), 10);
        }

        private void LoadGloves()
        {
            bow.PutGem(new Gem("XXX"), 17);
            bow.PutGem(new Gem("XXX"), 18);
            bow.PutGem(new Gem("XXX"), 19);
            bow.PutGem(new Gem("XXX"), 20);
        }

        private void LoadBoots()
        {
            bow.PutGem(new Gem("XXX"), 21);
            bow.PutGem(new Gem("XXX"), 22);
            bow.PutGem(new Gem("XXX"), 23);
            bow.PutGem(new Gem("XXX"), 24);
        }

        private void LoadChest()
        {
            bow.PutGem(new Gem("XXX"), 11);
            bow.PutGem(new Gem("XXX"), 12);
            bow.PutGem(new Gem("XXX"), 13);
            bow.PutGem(new Gem("XXX"), 14);
            bow.PutGem(new Gem("XXX"), 15);
            bow.PutGem(new Gem("XXX"), 16);
        }

    }
}
