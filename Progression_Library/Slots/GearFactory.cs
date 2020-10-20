
namespace Progression_Library.Slots
{
    public class GearFactory
    {

        public static FourSlot MakeFourSlot(string itemType)
        {
            FourSlot returnMe = new FourSlot();
            returnMe.SetLabel(itemType);
            return returnMe;
        }

        public static ThreeSlot MakeThreeSlot(string itemType)
        {
            ThreeSlot returnMe = new ThreeSlot();
            returnMe.SetLabel(itemType);
            return returnMe;
        }

        public static SixSlot MakeSixSlot(string itemType)
        {
            SixSlot returnMe = new SixSlot();
            returnMe.SetType(itemType);
            return returnMe;
        }

        public static OneSlot MakeOneSlot(string itemType)
        {
            OneSlot returnMe = new OneSlot();
            returnMe.SetLabel(itemType);
            return returnMe;
        }
    }
}
