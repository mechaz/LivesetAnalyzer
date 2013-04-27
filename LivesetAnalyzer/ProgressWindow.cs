using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Reflection;

namespace LivesetAnalyzer
{
    class ProgressWindow : Form
    {
        ProgressBar pBar;
        private int step;
        private Label lab; 
        private int percentCount = 0;


        public ProgressWindow(int stepsize)
        {
            
            lab = new Label();
            lab.Text = "0 %";
            // iconLive = Properties.Resources.lalogo;
            this.Icon = Properties.Resources.lalogo;
            this.Width = 400;
            this.Height = 90;
            this.Text = "Analyzing directory ...";
            this.FormClosing += new FormClosingEventHandler(ProgressWindow_FormClosing);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            pBar = new ProgressBar();
            pBar.Width = 390;
            pBar.Height = 25;
            pBar.Left = 2;
            pBar.Top = 35;
            this.step = stepsize;
            pBar.Step = stepsize;
            lab.Left = 190;
            lab.Top = 5;
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.Controls.Add(lab);
            this.Controls.Add(pBar);
            this.CenterToParent();
        }

        void ProgressWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }

        public void updateProgress(int percent)
        {       
            pBar.PerformStep();
            percentCount += step;
            lab.Text = percentCount + " %";
        }


        public void resetProgress()
        {
            this.pBar.Value = 0;
        }
    }
}
