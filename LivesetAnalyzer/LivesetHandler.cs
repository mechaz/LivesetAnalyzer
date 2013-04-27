using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.ComponentModel;

namespace LivesetAnalyzer
{
    class LivesetHandler
    {
        private DirectoryInfo dirParent;
        private List<Liveset> listLivesets;
        private List<Liveset> listLivesetsSearchResult;
        private int lastSortMode = 0;
        BackgroundWorker bgAnalyze;
        ProgressWindow pw = null;

        // constructor 1
        public LivesetHandler(DirectoryInfo mainDir)
        {
            this.dirParent = mainDir;
            // pw = new ProgressWindow(1);
            listLivesets = new List<Liveset>();
            SetupBGWorkerAnalyzeDirectory();
            
            analyzeDirectory(dirParent);
        }

        // constructor 2
        public LivesetHandler()
        {
            // pw = new ProgressWindow();
            listLivesets = new List<Liveset>();
            SetupBGWorkerAnalyzeDirectory();
        }


        private void SetupBGWorkerAnalyzeDirectory() 
        {
            bgAnalyze = new BackgroundWorker();
            bgAnalyze.DoWork += new DoWorkEventHandler(bg_DoWorkAnalyzeDir);
            bgAnalyze.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bg_RunWorkerCompletedAnalyzeDir);
            bgAnalyze.WorkerReportsProgress = true;
            bgAnalyze.ProgressChanged += new ProgressChangedEventHandler(bgAnalyze_ProgressChanged);
        }

        void bgAnalyze_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pw.updateProgress(e.ProgressPercentage);
        }

        void bg_DoWorkAnalyzeDir(object sender, DoWorkEventArgs e)
        {
            DirectoryInfo dirParent = (DirectoryInfo)e.Argument;
            List<Liveset> li = new List<Liveset>();
            DirectoryInfo[] allDirs = dirParent.GetDirectories();
            int length = allDirs.Length;
            int idAssigned = 0;
            int pLast = 0;
            int pNow = 0;
            
            for (int i = 0; i < allDirs.Length; i++)
            {
                DirectoryInfo dir = new DirectoryInfo(allDirs[i].FullName);
                if (dir.FullName.Contains(AnalyzerConstants.PROJECT_DIR_NAME_EXTENSION))
                {
                    idAssigned += 1;
                    Liveset ls = new Liveset(dir.FullName, idAssigned);
                    li.Add(ls);
                }
                
                pNow = (100 * i / length) + 1;
                if (Math.Abs(pNow - pLast) >= 1)
                {
                    pLast = pNow;
                    bgAnalyze.ReportProgress(pNow);
                }
            }
            e.Result = li;
        }

        void bg_RunWorkerCompletedAnalyzeDir(object sender, RunWorkerCompletedEventArgs e)
        {
            listLivesets = (List<Liveset>)e.Result;
            pw.resetProgress();
            pw.Dispose();
            pw.Visible = false;
            pw = null;
        }


        private void resetProgressBar()
        {
            pw.resetProgress();
        }



        #region get set


        public List<Liveset> getLivesetList()
        {
            return listLivesets;
        }

        public void setLivesetList(List<Liveset> lsList)
        {
            this.listLivesets = lsList;
        }

        public void setParentDir(DirectoryInfo dir)
        {
            this.dirParent = dir;
            analyzeDirectory(dir);
        }

        public DirectoryInfo getFilePath()
        {
            return dirParent;
        }

        public Liveset getLivesetByID_Olddd(int id)
        {
            return listLivesets.ElementAt(id - 1);
        }

        public Liveset getLivesetByID_New(int id)
        {
            Liveset ls = null;
            for (int i = 0; i < listLivesets.Count; i++)
            {
                if (listLivesets[i].getLivesetID() == id)
                {
                    return listLivesets[i];
                }
            }
            return ls;
        }


        public List<Liveset> getLivesetSearchResults()
        {
            return listLivesetsSearchResult;
        }

        public void setLivesetSearchResults(List<Liveset> searchResults)
        {
            this.listLivesetsSearchResult = searchResults;
        }


        #endregion


        // print all properties of all livesets to console
        public void printAllLivesets()
        {
            foreach (var item in listLivesets)
            {
                item.printAllLivesetProperties();
            }
        }

        // analyze the given root dir for livesets (async)
        private void analyzeDirectory(DirectoryInfo dirParent)
        {
            int count = dirParent.GetDirectories().Length;
            int stepSize = 1;
            if (count < 100)
            {
                stepSize = (100 / count);
            }
            bgAnalyze.RunWorkerAsync(dirParent);
            // reset progress bar
            if (pw == null)
            {
                pw = new ProgressWindow(stepSize);
            }
            
            pw.StartPosition = FormStartPosition.CenterParent;
            pw.ShowDialog();
        }

        private bool CanBeRemoved(Liveset ls)
        {
            return true;
        }







        // sort the livesets by different modes
        public void sortLivesets(int mode)
        {
            List<Liveset> lsList = listLivesets;
            bool unsortiert = true;
            Liveset tempSet;
            // Iterator<Liveset> iter = vector.iterator();
            Liveset[] livesetArray = new Liveset[lsList.Count];
            int i = 0;
            while (i < lsList.Count)
            {
                livesetArray[i] = lsList.ElementAt(i);
                i += 1;
            }
            switch (mode)
            {
                case AnalyzerConstants.SORT_BY_PROJECT_SIZE:
                    while (unsortiert)
                    {
                        unsortiert = false;
                        for (int j = 0; j < livesetArray.Length - 1; ++j)
                        {
                            if (livesetArray[j].getProjectSizeInBytes() > livesetArray[j + 1].getProjectSizeInBytes())
                            {
                                tempSet = livesetArray[j];
                                livesetArray[j] = livesetArray[j + 1];
                                livesetArray[j + 1] = tempSet;
                                unsortiert = true;
                            }
                        }
                    }
                    break;
                case AnalyzerConstants.SORT_BY_BPM:
                    while (unsortiert)
                    {
                        unsortiert = false;
                        for (int j = 0; j < livesetArray.Length - 1; ++j)
                        {
                            if (livesetArray[j].GetHasBPMValue())
                            {
                                if (livesetArray[j].getBPMValue() > livesetArray[j + 1].getBPMValue())
                                {
                                    tempSet = livesetArray[j];
                                    livesetArray[j] = livesetArray[j + 1];
                                    livesetArray[j + 1] = tempSet;
                                    unsortiert = true;
                                }
                            }
                        }
                    }

                    break;
                case AnalyzerConstants.SORT_BY_LAST_MODIFIED:
                    while (unsortiert)
                    {
                        unsortiert = false;
                        for (int j = 0; j < livesetArray.Length - 1; ++j)
                        {
                            if (livesetArray[j].getLastModifiedLiveset() > livesetArray[j + 1].getLastModifiedLiveset())
                            {
                                tempSet = livesetArray[j];
                                livesetArray[j] = livesetArray[j + 1];
                                livesetArray[j + 1] = tempSet;
                                unsortiert = true;
                            }
                        }
                    }

                    break;
                case AnalyzerConstants.SORT_BY_NAME:
                    while (unsortiert)
                    {
                        unsortiert = false;
                        for (int j = 0; j < livesetArray.Length - 1; ++j)
                        {
                            if (livesetArray[j].getLivesetID() > livesetArray[j + 1].getLivesetID())
                            {
                                tempSet = livesetArray[j];
                                livesetArray[j] = livesetArray[j + 1];
                                livesetArray[j + 1] = tempSet;
                                unsortiert = true;
                            }
                        }
                    }
                    break;
                default:
                    break;
            }
            List<Liveset> ergList = new List<Liveset>();
            for (int k = 0; k < livesetArray.Length; ++k)
            {
                ergList.Add(livesetArray[k]);
            }
            listLivesets = ergList;
            setLastSortMode(mode);
        }


        public void invertCurrentOrder()
        {
            List<Liveset> oldOrder = listLivesets;
            List<Liveset> newOrder = new List<Liveset>();
            Liveset[] array = new Liveset[oldOrder.Count];
            oldOrder.CopyTo(array);
            for (int i = array.Length; i > 0; i--)
            {
                newOrder.Add(array[i - 1]);
            }
            this.listLivesets = newOrder;
        }



        public void setLastSortMode(int lastSortMode)
        {
            this.lastSortMode = lastSortMode;
        }

        public int getLastSortMode()
        {
            return lastSortMode;
        }



    }
}
