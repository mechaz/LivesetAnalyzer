using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LivesetAnalyzer
{
    class VersionComparer : IComparer<LivesetVersion>
    {
        string memberName = string.Empty; // specifies the member name to be sorted
        SortOrder sortOrder = SortOrder.None; // Specifies the SortOrder.



        public VersionComparer(string strMemberName, SortOrder sortingOrder)
        {
            memberName = strMemberName;
            sortOrder = sortingOrder;
        }



        public int Compare(LivesetVersion v1, LivesetVersion v2)
        {
            int returnValue = 1;
            switch (memberName)
            {
                case "lastModifiedVersion":
                    if (sortOrder == SortOrder.Ascending)
                    {
                        returnValue = v1.getLastWriteTime().CompareTo(v2.getLastWriteTime());
                    }
                    else
                    {
                        returnValue = v2.getLastWriteTime().CompareTo(v1.getLastWriteTime());
                    }

                    break;
                
                default:
                    if (sortOrder == SortOrder.Ascending)
                    {
                        returnValue = v1.getLastWriteTime().CompareTo(v2.getLastWriteTime());
                    }
                    else
                    {
                        returnValue = v2.getLastWriteTime().CompareTo(v1.getLastWriteTime());
                    }
                    break;
            }
            return returnValue;
        }

    }
}
