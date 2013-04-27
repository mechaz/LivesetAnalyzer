namespace LivesetAnalyzer
{
    partial class MessageClosingForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnSAC = new System.Windows.Forms.Button();
            this.btnDSAC = new System.Windows.Forms.Button();
            this.btnC = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSAC
            // 
            this.btnSAC.Location = new System.Drawing.Point(13, 12);
            this.btnSAC.Name = "btnSAC";
            this.btnSAC.Size = new System.Drawing.Size(99, 91);
            this.btnSAC.TabIndex = 0;
            this.btnSAC.Text = "save and close";
            this.btnSAC.UseVisualStyleBackColor = true;
            // 
            // btnDSAC
            // 
            this.btnDSAC.Location = new System.Drawing.Point(118, 12);
            this.btnDSAC.Name = "btnDSAC";
            this.btnDSAC.Size = new System.Drawing.Size(99, 91);
            this.btnDSAC.TabIndex = 1;
            this.btnDSAC.Text = "dont save and close";
            this.btnDSAC.UseVisualStyleBackColor = true;
            // 
            // btnC
            // 
            this.btnC.Location = new System.Drawing.Point(223, 12);
            this.btnC.Name = "btnC";
            this.btnC.Size = new System.Drawing.Size(99, 91);
            this.btnC.TabIndex = 2;
            this.btnC.Text = "cancel";
            this.btnC.UseVisualStyleBackColor = true;
            // 
            // MessageClosingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(337, 117);
            this.Controls.Add(this.btnC);
            this.Controls.Add(this.btnDSAC);
            this.Controls.Add(this.btnSAC);
            this.Name = "MessageClosingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "unsaved changes";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSAC;
        private System.Windows.Forms.Button btnDSAC;
        private System.Windows.Forms.Button btnC;
    }
}