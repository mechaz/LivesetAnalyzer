using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NAudio.Utils;
using NAudio.Wave;
using System.Windows.Forms;

namespace LivesetAnalyzer
{
    class NAudioHandler
    {
        // private WaveFileReader waveReader;

        // private List<AudioSample> audioSamples;
        
        public NAudioHandler()
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Filter = "*.wav | *.wav";
            openDialog.ShowDialog();
            if (openDialog.FileName != null)
            {
                try
                {
                    NAudioInterface.SetupAudio(20);
                    NAudioInterface.LoadSample(openDialog.FileName, 0);
                    NAudioInterface.Play(0);
                }
                catch (Exception e)
                {
                    MessageBox.Show(openDialog.FileName + "       " + e.Message);

                }
                
            } 
        }

        public void PlayFirstSample()
        {


        }
    }
}
