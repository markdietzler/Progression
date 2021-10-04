using PastebinAPI.paste;
using PastebinAPI.impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PastebinAPI.impl.xml
{
    public class ParseXmlHandler 
    {

        private const string XML_ROOT_ELEMENT = "paste";
        private const string XML_PASTE_KEY = "paste_key";
        private const string XML_PASTE_DATE = "paste_date";
        private const string XML_PASTE_TITLE = "paste_title";
        private const string XML_PASTE_LANGUAGE = "paste_format_long";
        private const string XML_PASTE_MACHINE_LANGUAGE = "paste_format_short";
        private const string XML_PASTE_HITS = "paste_hits";
        private const string XML_PASTE_PRIVATE = "paste_private";
        private const string XML_PASTE_SIZE = "paste_size";
        private const string XML_EXPIRE_DATE = "paste_expire_date";

        private List<Paste> pastes = new List<Paste>();
        private bool onElement;
        private string value;
        private PasteBuilder info;



    }
}
