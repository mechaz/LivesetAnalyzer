using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LivesetAnalyzer
{
    public class LivesetVersion
    {
        private DateTime lastWrite;
        private string name;
        private int versionID;

        public LivesetVersion(string name, int versionID, DateTime lastWrite)
        {
            this.name = name;
            this.versionID = versionID;
            this.lastWrite = lastWrite;
        }

        public DateTime getLastWriteTime()
        {
            return this.lastWrite;
        }

        public string getName()
        {
            return this.name;
        }
    }
}
