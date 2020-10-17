
namespace Progression_Library.Gems.Support.Red
{
    public class RedSupportGem
    {
        public int Req_Level { get; }

        public string? Name { get; }

        public int Act { get; }

        public string? Quest_Unlock { get; }

        public string? Vendor { get; }

        public RedSupportGem()
        {
            Req_Level = 38;
            Act = 4;
            Quest_Unlock = "The Eternal Nightmare";
            Vendor = "Petarus and Vanja";
            Name = "Cast When Damage Taken";
        }
    }
}
