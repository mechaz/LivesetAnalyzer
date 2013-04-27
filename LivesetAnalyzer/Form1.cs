#region usings

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Windows;
using LivesetAnalyzer.Properties;
using System.Media;


#endregion


namespace LivesetAnalyzer
{
    public partial class MainForm : Form
    {

        #region fields


        private LivesetHandler lh;
        private Liveset currentLiveset = null;
        private List<Liveset> allLivesets;
        private bool isSearchSelection = false;

        private String rootPath = null;
        private string liveExePath = null;
        private SoundPlayer player = null;
        private AudioFileVisualizer fileVisualizer;
        public bool hasUnsavedChangesInReadMeBox { get; set; }
       
        
        #endregion
        

        // constructor
        public MainForm()
        {
            // main 
            InitializeComponent();
            this.Icon = Resources.lalogo;
            // add global event handlers
            this.KeyPreview = true;
            this.Shown += new EventHandler(Form1_Shown);
            this.KeyDown += new KeyEventHandler(Form1_KeyDown);
            this.Load += new EventHandler(MainFormLoad);
            
            // configure tables            
            livesetTable.ColumnHeaderMouseClick += new DataGridViewCellMouseEventHandler(livesetTable_ColumnHeaderMouseClick);
            livesetTable.SelectionChanged += new EventHandler(livesetTable_SelectionChanged);
            livesetTable.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            livesetTable.MultiSelect = false;
            livesetTable.ReadOnly = true;
            for (int i = 0; i < livesetTable.Columns.Count; i++) 
            {
                if (i != 1)
                {
                    livesetTable.Columns[i].SortMode = DataGridViewColumnSortMode.Programmatic;
                }
                else
                {
                    livesetTable.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                }
                if (i != 0)
                {
                    livesetTable.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
                
            }

            versionNamesTable.ColumnHeaderMouseClick += new DataGridViewCellMouseEventHandler(versionNamesTable_ColumnHeaderMouseClick);
            versionNamesTable.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            versionNamesTable.MultiSelect = false;
            versionNamesTable.ReadOnly = true;
            versionNamesTable.CellContentDoubleClick += new DataGridViewCellEventHandler(versionNamesTable_CellContentDoubleClick);

            for (int i = 0; i < versionNamesTable.Columns.Count; i++)
            {
                versionNamesTable.Columns[i].SortMode = DataGridViewColumnSortMode.Programmatic;
            }

            tbExePath.Enabled = false;

            // handler for searchtextfield
            textboxSearch.KeyDown += new KeyEventHandler(textboxSearch_KeyDown);

            // handler for readmebox
            tbReadmeText.KeyDown += new KeyEventHandler(tbReadmeText_KeyDown);

            // get all livesets and fill table

            String rootPath = Settings.Default.LivesetsRootPath;
            liveExePath = Settings.Default.LiveExePath;
            if (File.Exists(liveExePath))
            {
                tbExePath.Text = liveExePath;
            }


            Settings.Default.LivesetsRootPath = rootPath;
            Settings.Default.Save();

            if (Directory.Exists(rootPath))
            {
                lh = new LivesetHandler(new DirectoryInfo(rootPath));
                allLivesets = lh.getLivesetList();
                fillLivesetTable(allLivesets);
                textBoxCurrentDir.Text = rootPath;
                fillLivesetTreeView(lh.getFilePath().FullName);
            }
            else
            {
                lh = new LivesetHandler();
                startRootDirSelection(true);
                
                if (lh.getFilePath().FullName != null)
                {
                    fillLivesetTreeView(lh.getFilePath().FullName);
                }
            }
            fileVisualizer = new AudioFileVisualizer();
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.CenterToScreen();
            CreateShortcuts();
        }


        // assign shortcuts to avaialable functionalities
        private void CreateShortcuts()
        {
            // Todo: assign shortcuts for gui elements here
        }


        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


        #region eventhandling


        #region eventhandling key

        void tbReadmeText_KeyDown(object sender, KeyEventArgs e)
        {
            // STRG + S pressed
            if (e.Control && e.KeyCode == Keys.T)
            {
                // saveReadmeTextProcedure();
            }
        }

        // handle key events in searchbox
        void textboxSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                livesetTable.Focus();
            }
        }

        // handle key events
        void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            // STRG + F pressed
            if (e.Control && e.KeyCode == Keys.F)
            {
                this.textboxSearch.Focus();
            }
            // STRG + T pressed
            if (e.Control && e.KeyCode == Keys.T)
            {
                this.livesetTable.Focus();
            }
            // STRG + S pressed
            if (e.Control && e.KeyCode == Keys.S)
            {
                saveReadmeTextProcedure();
                updateDetailPanel(lh.getLivesetByID_New(currentLiveset.getLivesetID()));
            }
        }

        #endregion


        #region eventhandling click

        // handle save button clicked
        private void btnWrite_Click(object sender, EventArgs e)
        {
            saveReadmeTextProcedure();
            updateDetailPanel(lh.getLivesetByID_New(currentLiveset.getLivesetID()));
        }

        // handle table header cell clicked
        private void livesetTable_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            // resort livesets by index and name of clicked column
            ResortLivesets(e.ColumnIndex, livesetTable.Columns[e.ColumnIndex].Name);
        }

        // resort versionnames table 
        private void versionNamesTable_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string strColumnName = versionNamesTable.Columns[e.ColumnIndex].Name;
            SortOrder strSortOrder = getSortOrderVersionsTable(e.ColumnIndex);
            List<LivesetVersion> listToSort = currentLiveset.getLivesetVersions();
            listToSort.Sort(new VersionComparer(strColumnName, strSortOrder));
            versionNamesTable.DataSource = null;
            versionNamesTable.DataSource = listToSort;
            updateVersionNamesTable(listToSort);
            versionNamesTable.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = strSortOrder;
        }

        // btn root dir change clicked
        private void btnChangeRootDir_Click(object sender, EventArgs e)
        {
            startRootDirSelection(false);
        }

        // maybe unused ???
        private void btnCountDirDepth_Click(object sender, EventArgs e)
        {
            int erg = countDirDepth(lh.getFilePath(), 0);
            MessageBox.Show("dir depth counted: " + erg);
        }

        // change exe path clicked
        private void btnChangeLiveExe_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = false;
            DialogResult dr = ofd.ShowDialog(this);
            if (dr == DialogResult.OK || dr == DialogResult.Yes)
            {
                liveExePath = ofd.FileName;
                tbExePath.Text = liveExePath;
            }
        }

        // handle doublclick in versionnames table (open liveset)
        void versionNamesTable_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            string s = versionNamesTable.Rows[i].Cells[0].Value.ToString();
            openLivesetInAbleton(Path.Combine(currentLiveset.getAbsFilePath().ToString(), s));
        }


        #endregion


        #region eventhandling selection


        // handle treeview node selection finished, play sound file
        private void treeViewLivesets_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string fullPath = rootPath + "\\" + ((TreeView)sender).SelectedNode.FullPath;
            FileInfo fInfo = new FileInfo(fullPath);

            if (fInfo.Extension == ".wav")
            {
                if (fInfo.Exists)
                {
                    PlaySoundFile(fInfo);
                    if (fileVisualizer != null)
                    {

                    }
                }
            }
            else
            {
                StopCurrentSoundFile();
            }
        }

        // handle tableselection changed
        void livesetTable_SelectionChanged(object sender, EventArgs e)
        {
            // find selected liveset
            DataGridViewSelectedRowCollection selRows = livesetTable.SelectedRows;
            if (selRows.Count == 1)
            {
                int selRowIndex = livesetTable.SelectedCells[0].RowIndex;
                try
                {
                    String lsIDString = livesetTable.Rows[selRowIndex].Cells[1].Value.ToString();
                    int lsIDInt = Convert.ToInt32(livesetTable.Rows[livesetTable.SelectedCells[0].RowIndex].Cells[1].Value.ToString());
                    Liveset ls = lh.getLivesetByID_New(lsIDInt);
                    currentLiveset = ls;
                    updateDetailPanel(ls);
                    updateTreeView(ls);
                }
                catch (NullReferenceException nre)
                {
                    // MessageBox.Show("Error message: " + nre.Message);
                }
                catch (Exception ee)
                {
                    // MessageBox.Show("Error message: " + ee.Message);
                }
            }
        }


        #endregion


        #region eventhandling mainform related


        // handle form being shown the first time
        void Form1_Shown(object sender, EventArgs e)
        {
            textboxSearch.Focus();
        }

        // handle closing, ask for unsaved changes
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            if (e.CloseReason == CloseReason.UserClosing && hasUnsavedChangesInReadMeBox)
            {
                MessageClosingForm mcf = new MessageClosingForm();
                mcf.ShowDialog(this);
                switch (mcf.GetSelectedOption())
                {
                    case AnalyzerConstants.OPTION_SAC:
                        currentLiveset.setReadmeTextAndSaveToFile(tbReadmeText.Text);
                        break;
                    case AnalyzerConstants.OPTION_DSAC:
                        break;
                    case AnalyzerConstants.OPTION_C:
                        e.Cancel = true;
                        break;
                    default:
                        e.Cancel = true;
                        break;
                }

            }

            // Copy rootpath to app settings
            Settings.Default.LivesetsRootPath = this.rootPath;

            // Copy exePath to app settings
            Settings.Default.LiveExePath = this.liveExePath;

            // Save settings
            Settings.Default.Save();

        }


        // on mainform load
        private void MainFormLoad(object sender, EventArgs e)
        {
            // Set default location
            String t = Settings.Default.LivesetsRootPath;

            if (Settings.Default.LivesetsRootPath != null)
            {
                this.rootPath = Settings.Default.LivesetsRootPath;
            }
            else
            {

            }
            player = new SoundPlayer();

        }





        #endregion


        #region eventhandling text changed


        // handle textchanged from readmebox
        private void tbReadmeText_TextChanged(object sender, EventArgs e)
        {
            btnWrite.Enabled = true;
            this.hasUnsavedChangesInReadMeBox = true;
        }

        // handle textchanged from searchtextbox
        private void textboxSearch_TextChanged(object sender, EventArgs e)
        {
            computeSearchTextChanged();
        }


        #endregion


        #endregion


        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


        #region gui change


        #region fill

        // fill liveset table with data (add rows without deleting old ones)
        private void fillLivesetTable(List<Liveset> lsList)
        {
            string[,] lsData = getLivesetsData(lsList);
            for (int i = 0; i < lsData.GetLength(0); i++)
            {
                string[] d = new string[7];
                for (int j = 0; j < lsData.GetLength(1); j++)
                {
                    d[j] = lsData[i, j];
                }
                DataGridViewRow dgRow = new DataGridViewRow();
                dgRow.CreateCells(livesetTable, d);
                livesetTable.Rows.Add(dgRow);
            }
        }


        // fill the liveset reeview
        private void fillLivesetTreeView(string rootPath)
        {
            while (treeViewLivesets.Nodes.Count > 0)
            {
                treeViewLivesets.Nodes.RemoveAt(0);
            }
            string[] dirs = Directory.GetDirectories(rootPath);

            for (int i = 0; i < dirs.Length; i++)
            {
                DirectoryInfo di = new DirectoryInfo(dirs[i]);
                TreeNode tn = new TreeNode(di.Name);
                PopulateTree(di.FullName, tn);
                treeViewLivesets.Nodes.Add(tn);
            }
        }


        // fill (populate) treeView with directories, subdirectories, etc
        public void PopulateTree(string dir, TreeNode node)
        {
            // get the information of the directory
            DirectoryInfo directory = new DirectoryInfo(dir);
            // loop through each subdirectory
            foreach (DirectoryInfo d in directory.GetDirectories())
            {
                // create a new node
                TreeNode t = new TreeNode(d.Name);
                // populate the new node recursively
                PopulateTree(d.FullName, t);
                node.Nodes.Add(t); // add the node to the "master" node
            }
            // lastly, loop through each file in the directory, and add these as nodes
            foreach (FileInfo f in directory.GetFiles())
            {
                // do not add files with ending .asd to treeview
                if (!(f.Extension == ".asd"))
                {
                    // create a new node
                    TreeNode t = new TreeNode(f.Name);
                    // add it to the "master"
                    node.Nodes.Add(t);
                }
            }
        }


        // fill liveset table with data
        private void fillVersionNamesTable(List<LivesetVersion> versionList)
        {
            for (int i = 0; i < versionList.Count; i++)
            {
                string[] d = new string[2];
                d[0] = versionList[i].getName();
                d[1] = versionList[i].getLastWriteTime().ToString();
                DataGridViewRow dgRow = new DataGridViewRow();
                dgRow.CreateCells(versionNamesTable, d);
                versionNamesTable.Rows.Add(dgRow);
            }
        }

        #endregion


        #region update

        // update table with data from liveset list
        public int[] updateLivesetTable(List<Liveset> lsList)
        {
            // Clear DataGridView here
            livesetTable.ClearSelection();
            livesetTable.DataSource = null;
            livesetTable.Rows.Clear();

            // string[,] ergStrings = new string[lsList.Count, 6];
            int[] listLivesetIDs = new int[lsList.Count];
            for (int i = 0; i < lsList.Count; i++)
            {
                Liveset liveset = lsList[i];
                listLivesetIDs[i] = lsList[i].getLivesetID();
                String[] values = 
                { 
				    liveset.getName(),
                    liveset.getLivesetID().ToString(),
				    liveset.getBPMAsString(),
                    liveset.getLastModifiedLiveset().ToString(),
				    liveset.getProjectSizeInMB().ToString(),
                    liveset.getNumberOfVersions().ToString(),
                    liveset.getTotalWavFiles().ToString()
			    };
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(livesetTable, values);
                livesetTable.Rows.Add(row);
            }
            return listLivesetIDs;
            // MessageBox.Show("tabel filling fiished");
        }

        // update detail panel fields with liveset data
        private void updateDetailPanel(Liveset ls)
        {
            tbReadmeText.TextChanged -= tbReadmeText_TextChanged;
            tbName.Text = ls.getName();
            tbBPM.Text = ls.getBPMAsString();
            tbLastModified.Text = ls.getLastModifiedLiveset().ToString();
            tbSize.Text = ls.getProjectSizeInMB().ToString();
            tbVersionCount.Text = ls.getNumberOfVersions().ToString();
            tbFileCount.Text = ls.getTotalFiles().ToString();
            tbWavFiles.Text = ls.getTotalWavFiles().ToString();
            //listBoxVersions.DataSource = ls.getVersionNames();
            if (ls.GetHasReadmeFile())
            {
                tbReadmeText.Text = ls.getReadmeText();
            }
            else
            {
                tbReadmeText.Text = AnalyzerConstants.ERR_NO_README_TEXT;
            }
            tbReadmeText.TextChanged += tbReadmeText_TextChanged;
            updateVersionNamesTable(ls.getLivesetVersions());
            // updateTreeViewSelection(ls);
        }

        // update treeview (select, expand, ...)
        private void updateTreeView(Liveset ls)
        {
            TreeNode tnSelected = null;
            treeViewLivesets.CollapseAll();
            foreach (TreeNode tn in treeViewLivesets.Nodes)
            {
                tn.BackColor = Color.White;
                if (tn.Text.Equals(ls.getName() + " Project"))
                {
                    tnSelected = tn;
                }
            }
            treeViewLivesets.SelectedNode = tnSelected;
            treeViewLivesets.SelectedNode.BackColor = Color.LightGray;
            treeViewLivesets.SelectedNode.Expand();
            doValidFocusSelection();
        }


        // update versionNames table
        private void updateVersionNamesTable(List<LivesetVersion> versionList)
        {
            clearVersionNamesTable();
            fillVersionNamesTable(versionList);
        }

        // update (filter) livesets matching the searchtext to separate list and refill gui
        private void computeSearchTextChanged()
        {
            String t = textboxSearch.Text.ToLower();

            // no search text 
            if (t.Length == 0)
            {
                isSearchSelection = false;
                updateLivesetTable(lh.getLivesetList());
                return;
            }
            else
            {
                isSearchSelection = true;
            }

            List<Liveset> foundLivesets = new List<Liveset>();

            for (int i = 0; i < lh.getLivesetList().Count - 1; i++)
            {
                Liveset ls = lh.getLivesetList().ElementAt(i);
                String lsName = ls.getName().ToLower();
                if (lsName.Contains(t))
                {
                    foundLivesets.Add(ls);
                }
            }
            lh.setLivesetSearchResults(foundLivesets);

            if (lh.getLivesetSearchResults().Count > 0)
            {
                updateLivesetTable(lh.getLivesetSearchResults());
                updateDetailPanel(lh.getLivesetSearchResults()[0]);
            }
            else
            {
                clearDetailPanel();
                clearLivesetTable();
                tbReadmeText.TextChanged -= tbReadmeText_TextChanged;
                tbReadmeText.Text = "";
                tbReadmeText.TextChanged += tbReadmeText_TextChanged;
            }
        }

        // update (resort) livesets by column index clicked
        private void ResortLivesets(int ci, string cName)
        {
            // dont sort when Column ID clicked
            if (!cName.Equals("lsID"))
            {
                SortOrder strSortOrder = getSortOrderLivesetTable(ci);
                List<Liveset> listToSort = null;
                if (isSearchSelection)
                {
                    listToSort = lh.getLivesetSearchResults();
                }
                else
                {
                    listToSort = lh.getLivesetList();
                }

                listToSort.Sort(new LivesetComparer(cName, strSortOrder));
                livesetTable.DataSource = null;
                livesetTable.DataSource = listToSort;
                // listCurrentLivesetIDs = updateLivesetTable(listToSort);
                updateLivesetTable(listToSort);
                livesetTable.Columns[ci].HeaderCell.SortGlyphDirection = strSortOrder;
            }
        }      


        #endregion


        #region clear

        // clear the livesetTable
        private void clearLivesetTable()
        {
            // Clear DataGridView here
            livesetTable.ClearSelection();
            livesetTable.DataSource = null;
            livesetTable.Rows.Clear();
        }

        // clear the detail panel
        private void clearDetailPanel()
        {
            tbBPM.Text = String.Empty;
            tbFileCount.Text = String.Empty;
            tbLastModified.Text = String.Empty;
            tbName.Text = String.Empty;
            tbSize.Text = String.Empty;
            tbVersionCount.Text = String.Empty;
            tbWavFiles.Text = String.Empty;
        }

        // clear the versionNames table
        private void clearVersionNamesTable()
        {
            versionNamesTable.DataSource = null;
            versionNamesTable.ClearSelection();
            versionNamesTable.Rows.Clear();
        }


        #endregion


        #endregion


        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


        #region sound control


        // start playing soundfile
        private void PlaySoundFile(FileInfo fi)
        {
            try
            {
                // MessageBox.Show("Is wav!");
                SoundPlayer player = new SoundPlayer();
                player.SoundLocation = fi.FullName;
                player.Load();
                player.Play();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Fehler beim Spielen: " + ex.Message);
            }
        }

        // stop playing soundfile
        private void StopCurrentSoundFile()
        {
            try
            {
                if (player != null)
                {
                    player.Stop();
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Could not stop current audio file: " + ex.Message);
            }
        }



        #endregion sound control


        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


        #region helpers and others


        #region helpers


        // helper method:  count directoty depth recursive
        private int countDirDepth(DirectoryInfo di, int depth)
        {
            string[] dirPaths = Directory.GetDirectories(di.FullName);
            int index = 0;
            if (dirPaths.Length > 0)
            {
                depth += 1;
                int counted = 0;
                for (int i = 0; i < dirPaths.Length; i++)
                {
                    DirectoryInfo dInfo1 = new DirectoryInfo(dirPaths[i]);
                    int d = countDirDepth(dInfo1, 0);
                    if (d > counted)
                    {
                        counted = d;
                        index = i;
                    }
                }
                depth = depth + countDirDepth(new DirectoryInfo(dirPaths[index]), 0);
                return depth;
            }
            else
            {
                return depth;
            }
        }

        // helper method:  find treenode by dirInfo
        private TreeNode getTreeNodeFromDir(DirectoryInfo dInfo)
        {
            TreeNode tn = new TreeNode(dInfo.FullName);
            return tn;
        }

        // helper method:  extract name from filepath
        private string getNameFromFilePath(string filePath)
        {
            return filePath.Substring(filePath.LastIndexOf("\\"), filePath.Length - filePath.LastIndexOf("\\"));
        }

        // helper method:  convert liveset list to 2dim string array
        private string[,] getLivesetsData(List<Liveset> list)
        {
            string[,] data = new string[list.Count, 7];
            for (int i = 0; i < list.Count; i++)
            {
                data[i, 0] = list[i].getName();
                data[i, 1] = list[i].getLivesetID().ToString();
                data[i, 2] = list[i].getBPMAsString();
                data[i, 3] = list[i].getLastModifiedLiveset().ToString();
                data[i, 4] = list[i].getProjectSizeInMB().ToString();
                data[i, 5] = list[i].getNumberOfVersions().ToString();
                data[i, 6] = list[i].getTotalWavFiles().ToString();

            }
            return data;
        }

        // helper method:  invert current SortOrder livesetTable 
        private SortOrder getSortOrderLivesetTable(int columnIndex)
        {
            if (livesetTable.Columns[columnIndex].HeaderCell.SortGlyphDirection == SortOrder.None ||
                livesetTable.Columns[columnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending)
            {
                livesetTable.Columns[columnIndex].HeaderCell.SortGlyphDirection = SortOrder.Ascending;
                return SortOrder.Ascending;
            }
            else
            {
                livesetTable.Columns[columnIndex].HeaderCell.SortGlyphDirection = SortOrder.Descending;
                return SortOrder.Descending;
            }
        }

        // helper method:  invert current SortOrder versionsTbale
        private SortOrder getSortOrderVersionsTable(int columnIndex)
        {
            if (versionNamesTable.Columns[columnIndex].HeaderCell.SortGlyphDirection == SortOrder.None ||
                versionNamesTable.Columns[columnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending)
            {
                versionNamesTable.Columns[columnIndex].HeaderCell.SortGlyphDirection = SortOrder.Ascending;
                return SortOrder.Ascending;
            }
            else
            {
                versionNamesTable.Columns[columnIndex].HeaderCell.SortGlyphDirection = SortOrder.Descending;
                return SortOrder.Descending;
            }
        }

        // helper method:  select and focus the rorrect gui elements
        private void doValidFocusSelection()
        {
            if (textboxSearch.Focused)
            {
                treeViewLivesets.Select();
                treeViewLivesets.Focus();
                textboxSearch.Focus();
            }
            else if (livesetTable.Focused)
            {
                treeViewLivesets.Select();
                treeViewLivesets.Focus();
                livesetTable.Focus();
            }
            else
            {
                treeViewLivesets.Select();
                treeViewLivesets.Focus();
            }
        }


        #endregion


        #region others


        // save text to readme.txt and update states
        private void saveReadmeTextProcedure()
        {
            lh.getLivesetByID_New(currentLiveset.getLivesetID()).setReadmeTextAndSaveToFile(tbReadmeText.Text);
            lh.getLivesetByID_New(currentLiveset.getLivesetID()).rescanForBPM();
            btnWrite.Enabled = false;
            this.hasUnsavedChangesInReadMeBox = false;
        }

        // open file in selected ableton live version
        public void openLivesetInAbleton(string filepath)
        {
            try
            {
                System.Diagnostics.ProcessStartInfo si = new System.Diagnostics.ProcessStartInfo();
                si.FileName = @liveExePath;
                filepath = "\"" + filepath + "\"";
                si.Arguments = @filepath;
                System.Diagnostics.Process.Start(si);
            }
            catch (Exception e)
            {
                MessageBox.Show("Unable to open Liveset: " + e.Message);
            }
        }

        // start root dir selection
        private void startRootDirSelection(bool isFirst)
        {
            this.Visible = false;
            if (lh.getFilePath() != null)
            {
                folderBrowserDialog1.SelectedPath = lh.getFilePath().FullName;
            }
            folderBrowserDialog1.Description = "Select your root directory:";
            folderBrowserDialog1.ShowDialog();

            if (Directory.Exists(folderBrowserDialog1.SelectedPath))
            {
                DirectoryInfo di = new DirectoryInfo(folderBrowserDialog1.SelectedPath);
                lh.setParentDir(di);  // already triggers "analyzeDirectory(di)"
                updateLivesetTable(lh.getLivesetList());
                fillLivesetTreeView(lh.getFilePath().FullName);
                textBoxCurrentDir.Text = lh.getFilePath().FullName;
                this.rootPath = lh.getFilePath().FullName;
                Settings.Default.LivesetsRootPath = rootPath;
                Settings.Default.Save();
            }
            else
            {
                MessageBox.Show("No valid directory selected ...");
            }
            this.Visible = true;
        }


        #endregion




        #endregion helpers


        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


    }
}