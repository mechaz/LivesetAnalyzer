using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LivesetAnalyzer
{
    interface ILiveset
    {
        
        String getName();
        List<LivesetVersion> getLivesetVersions();

        bool GetHasValidAlsFile();
        bool GetHasBPMValue();
        bool GetHasReadmeFile();
        int getNumberOfVersions();
        long getProjectSizeInBytes();
        String getReadmeText();
        DateTime getLastModifiedLiveset();
        DateTime getLastModifiedReadmeFile();
        int getTotalFiles();
        int getTotalFolders();
        int getProjectSizeInMB();
        int getLivesetID();
        int getBPMValue();
        
        String getBPMAsString();
        void setReadmeTextAndSaveToFile(String t);
    }
}
