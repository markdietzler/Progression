using Progression_Library.interfaces;
using System;
using System.Collections;
using System.Windows.Documents;

namespace Progression_Library.FileHandling.Logs
{
    class Tail : LoggerListener
    {
        private ArrayList? log { get; set; }

        public Tail()
        {

        }

        public void newLogFileLine(string line)
        {
            throw new NotImplementedException();
        }


    }
}
