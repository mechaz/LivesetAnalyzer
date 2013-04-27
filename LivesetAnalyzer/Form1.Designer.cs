namespace LivesetAnalyzer
{
    partial class MainForm
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.btnWrite = new System.Windows.Forms.Button();
            this.livesetTable = new System.Windows.Forms.DataGridView();
            this.nameOfLiveset = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lsID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BPM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastModified = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.size = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.versionCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.wavFiles = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelFilesTotalCount = new System.Windows.Forms.Label();
            this.labelWavFilesCount = new System.Windows.Forms.Label();
            this.labelVersionCount = new System.Windows.Forms.Label();
            this.labelSize = new System.Windows.Forms.Label();
            this.labelLastModified = new System.Windows.Forms.Label();
            this.labelBPM = new System.Windows.Forms.Label();
            this.labelName = new System.Windows.Forms.Label();
            this.tbFileCount = new System.Windows.Forms.TextBox();
            this.tbWavFiles = new System.Windows.Forms.TextBox();
            this.tbVersionCount = new System.Windows.Forms.TextBox();
            this.tbSize = new System.Windows.Forms.TextBox();
            this.tbLastModified = new System.Windows.Forms.TextBox();
            this.tbBPM = new System.Windows.Forms.TextBox();
            this.tbName = new System.Windows.Forms.TextBox();
            this.labelSearch = new System.Windows.Forms.Label();
            this.textboxSearch = new System.Windows.Forms.TextBox();
            this.tbReadmeText = new System.Windows.Forms.TextBox();
            this.labelRootDir = new System.Windows.Forms.Label();
            this.textBoxCurrentDir = new System.Windows.Forms.TextBox();
            this.btnChangeRootDir = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.versionNamesTable = new System.Windows.Forms.DataGridView();
            this.versionName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastModifiedVersion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.treeViewLivesets = new System.Windows.Forms.TreeView();
            this.label1 = new System.Windows.Forms.Label();
            this.tbExePath = new System.Windows.Forms.TextBox();
            this.btnChangeLiveExe = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.livesetTable)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.versionNamesTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btnWrite
            // 
            this.btnWrite.Enabled = false;
            this.btnWrite.Location = new System.Drawing.Point(1407, 523);
            this.btnWrite.Name = "btnWrite";
            this.btnWrite.Size = new System.Drawing.Size(75, 23);
            this.btnWrite.TabIndex = 5;
            this.btnWrite.Text = "save";
            this.btnWrite.UseVisualStyleBackColor = true;
            this.btnWrite.Click += new System.EventHandler(this.btnWrite_Click);
            // 
            // livesetTable
            // 
            this.livesetTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.livesetTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameOfLiveset,
            this.lsID,
            this.BPM,
            this.lastModified,
            this.size,
            this.versionCount,
            this.wavFiles});
            this.livesetTable.Location = new System.Drawing.Point(4, 96);
            this.livesetTable.Name = "livesetTable";
            this.livesetTable.RowHeadersWidth = 20;
            this.livesetTable.Size = new System.Drawing.Size(809, 709);
            this.livesetTable.TabIndex = 1;
            // 
            // nameOfLiveset
            // 
            this.nameOfLiveset.HeaderText = "name";
            this.nameOfLiveset.Name = "nameOfLiveset";
            this.nameOfLiveset.ToolTipText = "the name of the liveset minus \"project\"";
            this.nameOfLiveset.Width = 300;
            // 
            // lsID
            // 
            this.lsID.HeaderText = "ID";
            this.lsID.MinimumWidth = 35;
            this.lsID.Name = "lsID";
            this.lsID.Width = 35;
            // 
            // BPM
            // 
            this.BPM.HeaderText = "bpm";
            this.BPM.MinimumWidth = 60;
            this.BPM.Name = "BPM";
            this.BPM.ToolTipText = "beats per minute of the liveset, if found in existing readme file";
            this.BPM.Width = 60;
            // 
            // lastModified
            // 
            this.lastModified.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.lastModified.HeaderText = "last modified";
            this.lastModified.MinimumWidth = 80;
            this.lastModified.Name = "lastModified";
            // 
            // size
            // 
            this.size.HeaderText = "size";
            this.size.Name = "size";
            this.size.Width = 60;
            // 
            // versionCount
            // 
            this.versionCount.HeaderText = "versions";
            this.versionCount.Name = "versionCount";
            this.versionCount.ToolTipText = "number of versions (.als files found)";
            this.versionCount.Width = 60;
            // 
            // wavFiles
            // 
            this.wavFiles.HeaderText = "wav files";
            this.wavFiles.Name = "wavFiles";
            this.wavFiles.Width = 80;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.labelFilesTotalCount);
            this.panel1.Controls.Add(this.labelWavFilesCount);
            this.panel1.Controls.Add(this.labelVersionCount);
            this.panel1.Controls.Add(this.labelSize);
            this.panel1.Controls.Add(this.labelLastModified);
            this.panel1.Controls.Add(this.labelBPM);
            this.panel1.Controls.Add(this.labelName);
            this.panel1.Controls.Add(this.tbFileCount);
            this.panel1.Controls.Add(this.tbWavFiles);
            this.panel1.Controls.Add(this.tbVersionCount);
            this.panel1.Controls.Add(this.tbSize);
            this.panel1.Controls.Add(this.tbLastModified);
            this.panel1.Controls.Add(this.tbBPM);
            this.panel1.Controls.Add(this.tbName);
            this.panel1.Location = new System.Drawing.Point(834, 70);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(281, 200);
            this.panel1.TabIndex = 6;
            // 
            // labelFilesTotalCount
            // 
            this.labelFilesTotalCount.AutoSize = true;
            this.labelFilesTotalCount.Location = new System.Drawing.Point(4, 169);
            this.labelFilesTotalCount.MinimumSize = new System.Drawing.Size(80, 0);
            this.labelFilesTotalCount.Name = "labelFilesTotalCount";
            this.labelFilesTotalCount.Size = new System.Drawing.Size(80, 13);
            this.labelFilesTotalCount.TabIndex = 13;
            this.labelFilesTotalCount.Text = "files total";
            this.labelFilesTotalCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelWavFilesCount
            // 
            this.labelWavFilesCount.AutoSize = true;
            this.labelWavFilesCount.Location = new System.Drawing.Point(4, 142);
            this.labelWavFilesCount.MinimumSize = new System.Drawing.Size(80, 0);
            this.labelWavFilesCount.Name = "labelWavFilesCount";
            this.labelWavFilesCount.Size = new System.Drawing.Size(80, 13);
            this.labelWavFilesCount.TabIndex = 12;
            this.labelWavFilesCount.Text = "wav files";
            this.labelWavFilesCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelVersionCount
            // 
            this.labelVersionCount.AutoSize = true;
            this.labelVersionCount.Location = new System.Drawing.Point(4, 115);
            this.labelVersionCount.MinimumSize = new System.Drawing.Size(80, 0);
            this.labelVersionCount.Name = "labelVersionCount";
            this.labelVersionCount.Size = new System.Drawing.Size(80, 13);
            this.labelVersionCount.TabIndex = 11;
            this.labelVersionCount.Text = "versions";
            this.labelVersionCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelSize
            // 
            this.labelSize.AutoSize = true;
            this.labelSize.Location = new System.Drawing.Point(4, 88);
            this.labelSize.MinimumSize = new System.Drawing.Size(80, 0);
            this.labelSize.Name = "labelSize";
            this.labelSize.Size = new System.Drawing.Size(80, 13);
            this.labelSize.TabIndex = 10;
            this.labelSize.Text = "size (MB)";
            this.labelSize.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelLastModified
            // 
            this.labelLastModified.AutoSize = true;
            this.labelLastModified.Location = new System.Drawing.Point(4, 61);
            this.labelLastModified.MinimumSize = new System.Drawing.Size(80, 0);
            this.labelLastModified.Name = "labelLastModified";
            this.labelLastModified.Size = new System.Drawing.Size(80, 13);
            this.labelLastModified.TabIndex = 9;
            this.labelLastModified.Text = "last modified";
            this.labelLastModified.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelBPM
            // 
            this.labelBPM.AutoSize = true;
            this.labelBPM.Location = new System.Drawing.Point(4, 34);
            this.labelBPM.MinimumSize = new System.Drawing.Size(80, 0);
            this.labelBPM.Name = "labelBPM";
            this.labelBPM.Size = new System.Drawing.Size(80, 13);
            this.labelBPM.TabIndex = 8;
            this.labelBPM.Text = "bpm";
            this.labelBPM.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(4, 7);
            this.labelName.MinimumSize = new System.Drawing.Size(80, 0);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(80, 13);
            this.labelName.TabIndex = 7;
            this.labelName.Text = "name";
            this.labelName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbFileCount
            // 
            this.tbFileCount.Location = new System.Drawing.Point(102, 166);
            this.tbFileCount.Name = "tbFileCount";
            this.tbFileCount.Size = new System.Drawing.Size(166, 20);
            this.tbFileCount.TabIndex = 6;
            // 
            // tbWavFiles
            // 
            this.tbWavFiles.Location = new System.Drawing.Point(102, 139);
            this.tbWavFiles.Name = "tbWavFiles";
            this.tbWavFiles.Size = new System.Drawing.Size(166, 20);
            this.tbWavFiles.TabIndex = 5;
            // 
            // tbVersionCount
            // 
            this.tbVersionCount.Location = new System.Drawing.Point(102, 112);
            this.tbVersionCount.Name = "tbVersionCount";
            this.tbVersionCount.Size = new System.Drawing.Size(166, 20);
            this.tbVersionCount.TabIndex = 4;
            // 
            // tbSize
            // 
            this.tbSize.Location = new System.Drawing.Point(102, 85);
            this.tbSize.Name = "tbSize";
            this.tbSize.Size = new System.Drawing.Size(166, 20);
            this.tbSize.TabIndex = 3;
            // 
            // tbLastModified
            // 
            this.tbLastModified.Location = new System.Drawing.Point(102, 58);
            this.tbLastModified.Name = "tbLastModified";
            this.tbLastModified.Size = new System.Drawing.Size(166, 20);
            this.tbLastModified.TabIndex = 2;
            // 
            // tbBPM
            // 
            this.tbBPM.Location = new System.Drawing.Point(102, 31);
            this.tbBPM.Name = "tbBPM";
            this.tbBPM.Size = new System.Drawing.Size(166, 20);
            this.tbBPM.TabIndex = 1;
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(102, 4);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(166, 20);
            this.tbName.TabIndex = 0;
            // 
            // labelSearch
            // 
            this.labelSearch.AutoSize = true;
            this.labelSearch.Location = new System.Drawing.Point(7, 70);
            this.labelSearch.Name = "labelSearch";
            this.labelSearch.Size = new System.Drawing.Size(39, 13);
            this.labelSearch.TabIndex = 7;
            this.labelSearch.Text = "search";
            this.labelSearch.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textboxSearch
            // 
            this.textboxSearch.Location = new System.Drawing.Point(50, 67);
            this.textboxSearch.Name = "textboxSearch";
            this.textboxSearch.Size = new System.Drawing.Size(177, 20);
            this.textboxSearch.TabIndex = 0;
            this.textboxSearch.TextChanged += new System.EventHandler(this.textboxSearch_TextChanged);
            // 
            // tbReadmeText
            // 
            this.tbReadmeText.Location = new System.Drawing.Point(834, 552);
            this.tbReadmeText.Multiline = true;
            this.tbReadmeText.Name = "tbReadmeText";
            this.tbReadmeText.Size = new System.Drawing.Size(648, 253);
            this.tbReadmeText.TabIndex = 4;
            this.tbReadmeText.TextChanged += new System.EventHandler(this.tbReadmeText_TextChanged);
            // 
            // labelRootDir
            // 
            this.labelRootDir.AutoSize = true;
            this.labelRootDir.Location = new System.Drawing.Point(256, 70);
            this.labelRootDir.Name = "labelRootDir";
            this.labelRootDir.Size = new System.Drawing.Size(54, 13);
            this.labelRootDir.TabIndex = 10;
            this.labelRootDir.Text = "root folder";
            // 
            // textBoxCurrentDir
            // 
            this.textBoxCurrentDir.Enabled = false;
            this.textBoxCurrentDir.Location = new System.Drawing.Point(314, 67);
            this.textBoxCurrentDir.Name = "textBoxCurrentDir";
            this.textBoxCurrentDir.Size = new System.Drawing.Size(417, 20);
            this.textBoxCurrentDir.TabIndex = 11;
            // 
            // btnChangeRootDir
            // 
            this.btnChangeRootDir.Location = new System.Drawing.Point(737, 65);
            this.btnChangeRootDir.Name = "btnChangeRootDir";
            this.btnChangeRootDir.Size = new System.Drawing.Size(75, 23);
            this.btnChangeRootDir.TabIndex = 12;
            this.btnChangeRootDir.Text = "change root";
            this.btnChangeRootDir.UseVisualStyleBackColor = true;
            this.btnChangeRootDir.Click += new System.EventHandler(this.btnChangeRootDir_Click);
            // 
            // versionNamesTable
            // 
            this.versionNamesTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.versionNamesTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.versionName,
            this.lastModifiedVersion});
            this.versionNamesTable.Location = new System.Drawing.Point(834, 302);
            this.versionNamesTable.Name = "versionNamesTable";
            this.versionNamesTable.RowHeadersWidth = 20;
            this.versionNamesTable.Size = new System.Drawing.Size(648, 215);
            this.versionNamesTable.TabIndex = 3;
            // 
            // versionName
            // 
            this.versionName.HeaderText = "version name";
            this.versionName.MinimumWidth = 500;
            this.versionName.Name = "versionName";
            this.versionName.Width = 500;
            // 
            // lastModifiedVersion
            // 
            this.lastModifiedVersion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.lastModifiedVersion.HeaderText = "last modified";
            this.lastModifiedVersion.MinimumWidth = 150;
            this.lastModifiedVersion.Name = "lastModifiedVersion";
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // treeViewLivesets
            // 
            this.treeViewLivesets.Location = new System.Drawing.Point(1121, 70);
            this.treeViewLivesets.Name = "treeViewLivesets";
            this.treeViewLivesets.Size = new System.Drawing.Size(361, 220);
            this.treeViewLivesets.TabIndex = 2;
            this.treeViewLivesets.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewLivesets_AfterSelect);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(268, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "live exe";
            // 
            // tbExePath
            // 
            this.tbExePath.Location = new System.Drawing.Point(314, 31);
            this.tbExePath.Name = "tbExePath";
            this.tbExePath.Size = new System.Drawing.Size(417, 20);
            this.tbExePath.TabIndex = 18;
            // 
            // btnChangeLiveExe
            // 
            this.btnChangeLiveExe.Location = new System.Drawing.Point(738, 30);
            this.btnChangeLiveExe.Name = "btnChangeLiveExe";
            this.btnChangeLiveExe.Size = new System.Drawing.Size(75, 23);
            this.btnChangeLiveExe.TabIndex = 19;
            this.btnChangeLiveExe.Text = "change exe";
            this.btnChangeLiveExe.UseVisualStyleBackColor = true;
            this.btnChangeLiveExe.Click += new System.EventHandler(this.btnChangeLiveExe_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(838, 531);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "readme.txt content:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1487, 813);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnChangeLiveExe);
            this.Controls.Add(this.tbExePath);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.treeViewLivesets);
            this.Controls.Add(this.versionNamesTable);
            this.Controls.Add(this.btnChangeRootDir);
            this.Controls.Add(this.textBoxCurrentDir);
            this.Controls.Add(this.labelRootDir);
            this.Controls.Add(this.tbReadmeText);
            this.Controls.Add(this.textboxSearch);
            this.Controls.Add(this.labelSearch);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.livesetTable);
            this.Controls.Add(this.btnWrite);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MainForm";
            this.Text = "Liveset Analyzer";
            this.Load += new System.EventHandler(this.MainFormLoad);
            ((System.ComponentModel.ISupportInitialize)(this.livesetTable)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.versionNamesTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button btnWrite;
        private System.Windows.Forms.DataGridView livesetTable;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelSearch;
        private System.Windows.Forms.TextBox textboxSearch;
        private System.Windows.Forms.Label labelFilesTotalCount;
        private System.Windows.Forms.Label labelWavFilesCount;
        private System.Windows.Forms.Label labelVersionCount;
        private System.Windows.Forms.Label labelSize;
        private System.Windows.Forms.Label labelLastModified;
        private System.Windows.Forms.Label labelBPM;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.TextBox tbFileCount;
        private System.Windows.Forms.TextBox tbWavFiles;
        private System.Windows.Forms.TextBox tbVersionCount;
        private System.Windows.Forms.TextBox tbSize;
        private System.Windows.Forms.TextBox tbLastModified;
        private System.Windows.Forms.TextBox tbBPM;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.TextBox tbReadmeText;
        private System.Windows.Forms.Label labelRootDir;
        private System.Windows.Forms.TextBox textBoxCurrentDir;
        private System.Windows.Forms.Button btnChangeRootDir;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.DataGridView versionNamesTable;
        private System.Windows.Forms.DataGridViewTextBoxColumn versionName;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastModifiedVersion;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private System.Windows.Forms.TreeView treeViewLivesets;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameOfLiveset;
        private System.Windows.Forms.DataGridViewTextBoxColumn lsID;
        private System.Windows.Forms.DataGridViewTextBoxColumn BPM;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastModified;
        private System.Windows.Forms.DataGridViewTextBoxColumn size;
        private System.Windows.Forms.DataGridViewTextBoxColumn versionCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn wavFiles;
        private System.Windows.Forms.Button btnChangeLiveExe;
        private System.Windows.Forms.TextBox tbExePath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;


        public System.Windows.Forms.DataGridViewCellEventHandler dataGridView1_CellContentClick { get; set; }

        public System.EventHandler Form1_Load { get; set; }
    }
}

