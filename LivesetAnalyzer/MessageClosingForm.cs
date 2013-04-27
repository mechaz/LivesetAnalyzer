using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LivesetAnalyzer
{
    public partial class MessageClosingForm : Form
    {

        private int selectedOption = 10;

        public MessageClosingForm()
        {
            InitializeComponent();
            setupHandlers();
        }

        void setupHandlers()
        {
            this.btnSAC.Click += new EventHandler(btn_Click);
            this.btnDSAC.Click += new EventHandler(btn_Click);
            this.btnC.Click += new EventHandler(btn_Click);
        }

        public int GetSelectedOption()
        {
            return this.selectedOption;
        }


        void btn_Click(object sender, EventArgs e)
        {
            if (sender == btnSAC)
            {
                this.selectedOption = AnalyzerConstants.OPTION_SAC;
                this.Visible = false;
            }
            else if(sender == btnDSAC)
            {
                this.selectedOption = AnalyzerConstants.OPTION_DSAC;
                this.Visible = false;
            }
            else if (sender == btnC)
            {
                this.selectedOption = AnalyzerConstants.OPTION_C;
                this.Visible = false;
            }
        }
    }
}
