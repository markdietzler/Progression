using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PastebinAPI.paste
{
    public class PasteExpire
    {       
        private string _Value;

        PasteExpire(string new_value)
        {
            this._Value = new_value;
        }

        public static string FromValue(string find_Value)
        {
            switch (find_Value)
            {
                case "N": return "Never";
                case "10M": return "TenMinutes";
                case "1H": return "OneHour";
                case "1D": return "OneDay";
                case "1W": return "OneWeek";
                case "2W": return "TwoWeek";
                case "1M": return "OneMonth";
            }

            throw new NotSupportedException("PasteExpire " + find_Value + " is not supported yet");
        }
    }
    }
}
