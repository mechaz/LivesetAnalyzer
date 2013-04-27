/* 
 * Copyright (C) 2009 Sebastian Gray - sebastiangray@gmail.com 
 * Website: http://www.evolvingsoftware.com/
 * 
 *  This program is free software: you can redistribute it and/or modify
 *  it under the terms of the GNU General Public License as published by
 *  the Free Software Foundation, either version 3 of the License, or
 *  (at your option) any later version.
 * 
 *  This program is distributed in the hope that it will be useful,
 *  but WITHOUT ANY WARRANTY; without even the implied warranty of
 *  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *  GNU General Public License for more details.
 * 
 *  You should have received a copy of the GNU General Public License
 *  along with this program.  If not, see <http://www.gnu.org/licenses/>.
 * 
*/


using System;
using System.Collections.Generic;
using System.Text;

using NAudio.Wave;

namespace LivesetAnalyzer
{
    public static class NAudioInterface
    {
        //Declarations required for audio out and mixing
        private static IWavePlayer waveOutDevice;
        private static WaveMixerStream32 mixer;

        // The Sample array we will load our Audio Samples in to
        private static AudioSample[] Sample;

        /// <summary>
        /// Setup Audio via NAudio. Defaults to using Asio for Audio Output.
        /// </summary>
        public static void SetupAudio(int Samples)
        {
            //Setup the Mixer
            mixer = new WaveMixerStream32();
            mixer.AutoStop = false;

            if (waveOutDevice == null)
            {
                waveOutDevice = new AsioOut();
                waveOutDevice.Init(mixer);
                waveOutDevice.Play();
            }

            Sample = new AudioSample[Samples];
        }

        public static void LoadSample(string fileName, int sampleNumber)
        {
            Sample[sampleNumber] = new AudioSample(fileName);
            mixer.AddInputStream(Sample[sampleNumber]);

            // The stop is required because when an InputStream is added, if it is too long it will start playing because we do not turn off the mixer.
            // This is effectively just a work around by making sure that we move the playback position to the end of the stream to aviod this issue.
            Stop(sampleNumber);
        }

        public static void Play(int sampleNumber)
        {
            Sample[sampleNumber].Position = 0;
        }

        public static void Play(int sampleNumber, long position)
        {
            throw new NotImplementedException();
        }

        public static void Pause(int sampleNumber)
        {
            Sample[sampleNumber].Pause();
        }

        public static void Resume(int sampleNumber)
        {
            Sample[sampleNumber].Resume();
        }

        public static void Stop(int sampleNumber)
        {
            // Set the position at the end of the sample length
            Sample[sampleNumber].Position = Sample[sampleNumber].Length;
        }

        public static void Loop(int sampleNumber, bool Loop)
        {
            Sample[sampleNumber].SetLoop(Loop);
        }

        public static void ShutdownAudio()
        {
            throw new NotImplementedException();
        }

        // Need to add Get/Set for Volume, Pan and Looping


        public static void SetPan(int sampleNumber, float pan)
        {
            Sample[sampleNumber].SetPan(pan);
        }

        public static void SetVolume(int sampleNumber, float volume)
        {
            Sample[sampleNumber].Volume = volume;

        }


        internal static void SetPostion(int sampleNumber, long position)
        {
            Sample[sampleNumber].Position = position;
        }

        internal static long GetLength(int sampleNumber)
        {
            return Sample[sampleNumber].Length;
        }



    }



}













