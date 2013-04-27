using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace LivesetAnalyzer
{
    public class Liveset : ILiveset
    {
        #region fields
        private String name;
        private int livesetID;
        private int versionCount = 0;
        private int bpmValue;

        private DateTime lastModifiedReadmeFile;
        private DateTime lastModifiedLiveset;

        private DirectoryInfo absoluteFilePath;
        private DirectoryInfo directory;

        private List<LivesetVersion> lsVersions;
        private string[] versionNames;
        private long projectSize = 0;
        private String readmeFilePath = String.Empty;
        private String readmeText = String.Empty;
        
        int totalFolder = 0;
        int totalFile = 0;
        int totalWavFiles = 0;
        private bool hasValidAlsFile = false;
        private bool hasReadmeFile = false;
        private bool hasBPMValue = false;
        #endregion

        // Konstruktor
        public Liveset(String absFilePath, int id)
        {
            this.livesetID = id;
            this.absoluteFilePath = new DirectoryInfo(absFilePath);
            directory = new DirectoryInfo(absFilePath);
            lsVersions = new List<LivesetVersion>();
            
            // find and assign properties
            name = directory.Name.Substring(0, directory.Name.LastIndexOf("Project") - 1);

            // 
            readLivesetVersions();
            countWavFiles();
            totalFolder = countFolders(directory);
            totalFile = countFiles(directory);
            projectSize = calculateProjectSize(directory);
            checkForReadmeFileAndGetText(directory);
            if (this.hasReadmeFile == true)
            {
                bpmValue = findBPM(readmeText);
                if (!(bpmValue == -1)) hasBPMValue = true;
            }
            calculateLastModifiedDateLiveset(directory);
        }

        // count all wav-files
        private void countWavFiles()
        {
            totalWavFiles = Directory.GetFiles(directory.FullName, "*.wav", SearchOption.AllDirectories).Length;
        }


        // check readmetetxt for bpm info
        public void rescanForBPM()
        {
            if (this.readmeText != String.Empty)
            {
                this.bpmValue = findBPM(this.readmeText);
                if (!(bpmValue == -1))
                {
                    hasBPMValue = true;
                }
                else
                {
                    hasBPMValue = false;
                }
            }
        }

        // find bpm info in given string (not tested)
        private int findBPM(string text)
        {            
            int bpm = -1;
            String sPattern = "\\d{2,}\\s*[b][p][m]";
            text = text.ToLower();
            if (Regex.IsMatch(text, sPattern, RegexOptions.IgnoreCase))
            {
                Match m = Regex.Match(text, sPattern);
                int start = m.Index;
                int end = m.Index + m.Length;
                int digits = 0;
                for (int i = start; i < end; i++)
                {
                    bool isDigit = Char.IsDigit(text.ElementAt(i));
                    if (isDigit) digits += 1;
                }
                String sub = text.Substring(start, digits);
                bpm = Convert.ToInt32(sub);
            }
            return bpm;
        }

        // calc last write datetime of liveset files except readmefile (not tested)
        private void calculateLastModifiedDateLiveset(DirectoryInfo dir)
        {
            FileInfo[] list = dir.GetFiles("*", SearchOption.AllDirectories);
            for (int i = 0; i < list.Length; ++i)
            {
                String filename = System.IO.Path.GetFileName(list[i].FullName);
                if ( !filename.Equals(AnalyzerConstants.FILENAME_README_STANDARD))
                {
                    DateTime dt = list[i].LastWriteTime;
                    if (dt > lastModifiedLiveset)
                    {
                        lastModifiedLiveset = dt;
                        // lastModifiedDateLiveset = new Date(lastModifiedLiveset);
                        // lastModifiedDateLivesetFormatted = sdf.format(lastModifiedDateLiveset);
                    }

                }
            }
        }

        // looks for a readmefile, if one exists, saves the text to this.readmeText
        private void checkForReadmeFileAndGetText(DirectoryInfo dir)
        {
            bool b = false;
            var existing = Directory.GetFiles(dir.FullName, "*.txt", SearchOption.AllDirectories);
            foreach (string item in existing)
	        {
                String filename = System.IO.Path.GetFileName(item);
                if (filename.Equals(AnalyzerConstants.FILENAME_README_STANDARD))
                {
                    DirectoryInfo info = new DirectoryInfo(item);
                    readmeText = readTheReadmeText(info);
                    lastModifiedReadmeFile = info.LastWriteTime;
                    b = true;
                    break;
                }
	        }
            hasReadmeFile = b;
            if (hasReadmeFile)
            {
                
            }
        }

        // reads the text of the file specified by given DirectoryInfo (not tested)
        private string readTheReadmeText(DirectoryInfo info)
        {
            String t = null;
		    try {
			    t = AnalyzerLib.readFile(info.FullName);		
		    } catch (AnalyzerException e) {
			    System.Diagnostics.Debug.WriteLine("Could not read file ... hell no ..., message: " + e.Message);
		    }
		return t;
        }

        // returns size of project as long, is this method ever being used?? (not tested)
        private long calculateProjectSize(DirectoryInfo dir)
        {
            long size = 0;
            var dirs = dir.GetDirectories();
            var files = dir.GetFiles();
            for (int i = 0; i < files.Length; i++)
            {
                size += files[i].Length;
            }
            for (int i = 0; i < dirs.Length; i++)
            {
                size += calculateProjectSize(dirs[i]);
            }
            return size;
        }

        // counts all folders in a project (not tested)
        private int countFolders(DirectoryInfo dir)
        {
            int folderCount = 0;
            for (int i = 0; i < dir.GetDirectories().Length; i++)
            {
                folderCount += 1;
                folderCount += countFolders(dir.GetDirectories()[i]);
            }
            return folderCount;
        }

        // count all files in given directoryinfo, incl. subfolders (not tested)
        private int countFiles(DirectoryInfo dir)
        {
            return dir.GetFiles(".", SearchOption.AllDirectories).Length;
        }

        // all simple get methods
        #region GetMethods
        public String getName()
        {
            return this.name;
        }

        public int getLivesetID()
        {
            return this.livesetID;
        }

        public bool GetHasValidAlsFile()
        {
            return this.hasValidAlsFile;
        }

        public int getNumberOfVersions()
        {
            return this.versionCount;
        }

        public int getTotalFiles()
        {
            return this.totalFile;
        }

        public int getTotalFolders()
        {
            return this.totalFolder;
        }

        public int getTotalWavFiles()
        {
            return this.totalWavFiles;
        }

        public bool GetHasReadmeFile()
        {
            return this.hasReadmeFile;
        }

        public long getProjectSizeInBytes()
        {
            return this.projectSize;
        }

        public string getReadmeText()
        {
            if (hasReadmeFile && readmeText != null)
            {
                return this.readmeText;
            }
            else
            {
                return AnalyzerConstants.ERR_NO_README_TEXT;
            }  
        }

        public int getProjectSizeInMB()
        {
            return (int)(projectSize * 0.00000095367431640625);
        }

        public int getBPMValue()
        {
            return this.bpmValue;
        }

        public bool GetHasBPMValue()
        {
            return this.hasBPMValue;
        }

        public string getBPMAsString()
        {
            if (hasBPMValue)
            {
                return "" + bpmValue;
            }
            else
            {
                return AnalyzerConstants.NO_BPM_FOUND_TEXT;
            }
        }

        public DateTime getLastModifiedLiveset()
        {
            return this.lastModifiedLiveset;
        }
        
        public long getLastModifiedLivesetValue()
        {
            return this.lastModifiedLiveset.ToFileTime();
        }

        public DateTime getLastModifiedReadmeFile()
        {
            return this.lastModifiedReadmeFile;
        }

        public String getReadMeFilePath()
        {
            if (this.readmeFilePath == String.Empty)
            {
                readmeFilePath = this.absoluteFilePath.FullName + "\\" + "readme.txt";
            }
            return this.readmeFilePath;
        }

        public DirectoryInfo getAbsFilePath()
        {
            return this.absoluteFilePath;
        }

        public List<LivesetVersion> getLivesetVersions()
        {
            return lsVersions;
        }

        #endregion

        // save string from tbReadmetText and write to file, create file if necessary
        public void setReadmeTextAndSaveToFile(String t)
        {
            readmeText = t;
		    try {
			    if (readmeFilePath == String.Empty) {
				    readmeFilePath = Path.Combine(absoluteFilePath.FullName , "readme.txt");
			    }
			    AnalyzerLib.writeFile(t, @readmeFilePath);
                this.hasReadmeFile = true;
		    } catch (AnalyzerException ae) {
                MessageBox.Show("Could not write readme file: " + ae.Message);
			    System.Diagnostics.Debug.WriteLine("!!!");
			    System.Diagnostics.Debug.WriteLine(ae.Message);
			    System.Diagnostics.Debug.WriteLine("!!!");
		    } catch (Exception e) {
                System.Diagnostics.Debug.WriteLine("Some other error: " + e.Message);
                MessageBox.Show("Could not write readme file: " + e.Message);
		    }
        }

        // write all liveset properties to console
        public void printAllLivesetProperties() {
            System.Diagnostics.Debug.WriteLine("___________________________");
		    System.Diagnostics.Debug.WriteLine("");
		    System.Diagnostics.Debug.WriteLine("");
		    System.Diagnostics.Debug.WriteLine("Title:");
		    System.Diagnostics.Debug.WriteLine(this.getName());
		    System.Diagnostics.Debug.WriteLine("");
		    System.Diagnostics.Debug.WriteLine("Versions (" + getNumberOfVersions() + "):");
		    printVersionNames();
		    System.Diagnostics.Debug.WriteLine("");
		    System.Diagnostics.Debug.WriteLine("Contains:");
		    System.Diagnostics.Debug.WriteLine(getTotalFiles() + " files");
            System.Diagnostics.Debug.WriteLine(getTotalWavFiles() + " wav files");
		    System.Diagnostics.Debug.WriteLine(getTotalFolders() + " folders");
		    System.Diagnostics.Debug.WriteLine("");
		    System.Diagnostics.Debug.WriteLine("Size: ");
		    System.Diagnostics.Debug.WriteLine(getProjectSizeInBytes() + " bytes");
		    System.Diagnostics.Debug.WriteLine(getProjectSizeInMB() + " mb");
 		    System.Diagnostics.Debug.WriteLine("");
 		    System.Diagnostics.Debug.WriteLine("Has Readme File: " + hasReadmeFile);
 		    System.Diagnostics.Debug.WriteLine("");
 		    System.Diagnostics.Debug.WriteLine("readme.txt:");
 		    System.Diagnostics.Debug.WriteLine(getReadmeText());
 		    System.Diagnostics.Debug.WriteLine("");
 		    System.Diagnostics.Debug.WriteLine("last modified liveset: " + this.getLastModifiedLiveset());
 		    System.Diagnostics.Debug.WriteLine("last modified readme: " + this.getLastModifiedReadmeFile());
 		    System.Diagnostics.Debug.WriteLine("");
 		    System.Diagnostics.Debug.WriteLine("bpm: " + getBPMAsString());
 	    }

        // count als files and write names to versionNames
        private void readLivesetVersions()
        {
            List<String> names = new List<String>();
            FileInfo[] listAlsFiles = directory.GetFiles("*.als", SearchOption.AllDirectories);
            for (int i = 0; i < listAlsFiles.Length; ++i)
            {
                versionCount += 1;
                String name = listAlsFiles[i].Name;
                names.Add(name.Substring(0, name.LastIndexOf('.')));
                LivesetVersion lv = new LivesetVersion(name, versionCount, listAlsFiles[i].LastWriteTime);
                lsVersions.Add(lv);
            }
            String[] vNames = new String[listAlsFiles.Length];
            names.CopyTo(vNames, 0);
            versionNames = vNames;
            if (versionNames.Length > 0)
            {
                hasValidAlsFile = true;
            }
        }

        public string[] getVersionNames()
        {
            return this.versionNames;
        }

        // simply write all versionNames to console
        private void printVersionNames() 
        {
		    for (int i = 0; i < versionNames.Length; ++i) 
            {
			    System.Diagnostics.Debug.WriteLine("- " + versionNames[i]);
		    }
	    }

        

    }
}
