using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LivesetAnalyzer
{
    class LivesetComparer : IComparer<Liveset>
    {

            string memberName = string.Empty; // specifies the member name to be sorted
            SortOrder sortOrder = SortOrder.None; // Specifies the SortOrder.

            /// <summary>
            /// constructor to set the sort column and sort order.
            /// </summary>
            /// <param name="strMemberName"></param>
            /// <param name="sortingOrder"></param>
            public LivesetComparer(string strMemberName, SortOrder sortingOrder)
            {
                memberName = strMemberName;
                sortOrder = sortingOrder;
            }

            /// <summary>
            /// Compares two Students based on member name and sort order
            /// and return the result.
            /// </summary>
            /// <param name="Student1"></param>
            /// <param name="Student2"></param>
            /// <returns></returns>
            public int Compare(Liveset Liveset1, Liveset Liveset2)
            {
                int returnValue = 1;
                switch (memberName)
                {
                    case "nameOfLiveset":
                        if (sortOrder == SortOrder.Ascending)
                        {   
                            returnValue = Liveset1.getName().CompareTo(Liveset2.getName());  
                        }
                        else
                        {
                            returnValue = Liveset2.getName().CompareTo(Liveset1.getName());
                        }

                        break;
                    case "BPM":
                        if (sortOrder == SortOrder.Ascending)
                        {
                            returnValue = Liveset1.getBPMValue().CompareTo(Liveset2.getBPMValue());
                        }
                        else
                        {
                            returnValue = Liveset2.getBPMValue().CompareTo(Liveset1.getBPMValue());
                        }
                        break;
                    case "lastModified":
                        if (sortOrder == SortOrder.Ascending)
                        {
                            returnValue = Liveset1.getLastModifiedLivesetValue().CompareTo(Liveset2.getLastModifiedLivesetValue());
                        }
                        else
                        {
                            returnValue = Liveset2.getLastModifiedLivesetValue().CompareTo(Liveset1.getLastModifiedLivesetValue());
                        }
                        break;
                    case "size":
                        if (sortOrder == SortOrder.Ascending)
                        {
                            returnValue = Liveset1.getProjectSizeInBytes().CompareTo(Liveset2.getProjectSizeInBytes());
                        }
                        else
                        {
                            returnValue = Liveset2.getProjectSizeInBytes().CompareTo(Liveset1.getProjectSizeInBytes());
                        }
                        break;
                    case "versionCount":
                        if (sortOrder == SortOrder.Ascending)
                        {
                            returnValue = Liveset1.getNumberOfVersions().CompareTo(Liveset2.getNumberOfVersions());
                        }
                        else
                        {
                            returnValue = Liveset2.getNumberOfVersions().CompareTo(Liveset1.getNumberOfVersions());
                        }
                        break;
                    case "wavFiles":
                        if (sortOrder == SortOrder.Ascending)
                        {
                            returnValue = Liveset1.getTotalWavFiles().CompareTo(Liveset2.getTotalWavFiles());
                        }
                        else
                        {
                            returnValue = Liveset2.getTotalWavFiles().CompareTo(Liveset1.getTotalWavFiles());
                        }
                        break;
                    

                    default:
                        if (sortOrder == SortOrder.Ascending)
                        {
                            returnValue = Liveset1.getName().CompareTo(Liveset2.getName() );
                        }
                        else
                        {
                            returnValue = Liveset2.getName().CompareTo(Liveset1.getName());
                        }
                        break;
                }
                return returnValue;
            }
      
    }
}
