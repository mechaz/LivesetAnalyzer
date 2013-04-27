/* 
 * This code was origionaly written by Mark Heath - MixDiffStream.cs; contained in the MixDiffDemo application from NAudio. 
 * The following code is licenced under the MS-PL.
 * 
 * Additional modifications writen by Sebastian Gray.
*/

using System;
using System.Collections.Generic;
using System.Text;

using NAudio.Wave;

namespace LivesetAnalyzer
{
    public class AudioSample : WaveStream
    {
        // General Sample Settings (Info)
        string _fileName = "";
        bool _loop;
        long _pausePosition = -1;
        bool _pauseLoop;

        // Sample WaveStream Settings
        WaveOffsetStream offsetStream;
        WaveChannel32 channelSteam;
        bool muted;
        float volume;

        public AudioSample(string fileName)
        {
            _fileName = fileName;
            WaveFileReader reader = new WaveFileReader(fileName);
            offsetStream = new WaveOffsetStream(reader);
            channelSteam = new WaveChannel32(offsetStream);
            muted = false;
            volume = 1.0f;
        }

        public override int BlockAlign
        {
            get
            {
                return channelSteam.BlockAlign;
            }
        }

        public override WaveFormat WaveFormat
        {
            get { return channelSteam.WaveFormat; }
        }

        public override long Length
        {
            get { return channelSteam.Length; }
        }

        public override long Position
        {
            get
            {
                return channelSteam.Position;
            }
            set
            {
                channelSteam.Position = value;
            }
        }

        public bool Mute
        {
            get
            {
                return muted;
            }
            set
            {
                muted = value;
                if (muted)
                {
                    channelSteam.Volume = 0.0f;
                }
                else
                {
                    // reset the volume                
                    Volume = Volume;
                }
            }
        }

        //public override int Read(byte[] buffer, int offset, int count)
        //{
        //    return channelSteam.Read(buffer, offset, count);
        //}

        public override int Read(byte[] buffer, int offset, int count)
        {
            // Check if the stream has been set to loop
            if (_loop)
            {
                // Looping code taken from NAudio Demo
                int read = 0;
                while (read < count)
                {
                    int required = count - read;
                    int readThisTime = channelSteam.Read(buffer, offset + read, required);
                    if (readThisTime < required)
                    {
                        channelSteam.Position = 0;
                    }

                    if (channelSteam.Position >= channelSteam.Length)
                    {
                        channelSteam.Position = 0;
                    }
                    read += readThisTime;
                }
                return read;
            }
            else
            {
                // Normal read code, sample has not been set to loop
                return channelSteam.Read(buffer, offset, count);
            }


            // Thinking about how I could pass back a reversed buffer to be read - review latter.
            //byte[] reverseBuffer = new byte[buffer.Length];
            //for (int i = 0; i < buffer.Length; i++)
            //{

            //}


        }



        public override bool HasData(int count)
        {
            return channelSteam.HasData(count);
        }

        public float Volume
        {
            get
            {
                return volume;
            }
            set
            {
                volume = value;
                if (!Mute)
                {
                    channelSteam.Volume = volume;
                }
            }
        }

        public TimeSpan PreDelay
        {
            get { return offsetStream.StartTime; }
            set { offsetStream.StartTime = value; }
        }

        public TimeSpan Offset
        {
            get { return offsetStream.SourceOffset; }
            set { offsetStream.SourceOffset = value; }
        }

        protected override void Dispose(bool disposing)
        {
            if (channelSteam != null)
            {
                channelSteam.Dispose();
            }

            base.Dispose(disposing);
        }




        // General Sample Settings (Info)

        /// <summary>
        /// FileName of the loaded sample
        /// </summary>
        public string FileName
        {
            get { return _fileName; }
        }

        /// <summary>
        /// Loop determines wether the sample will play in a loop - takes imediate effect and cna be turned on and off while a sample is playing.
        /// </summary>
        public void SetLoop(bool Loop)
        {
            _loop = Loop;
        }

        public void Pause()
        {
            // Store the current stream settings
            _pausePosition = Position;
            _pauseLoop = _loop;

            // Ensure the sample is temporairly not looped and set the position to the end of the stream
            _loop = false;
            Position = Length;

            // Set the loop status back, so that any further modifications of the loop status are observed
            _loop = _pauseLoop;
        }

        public void Resume()
        {
            // Ensure that the sample had actuall been paused and that we are not just jumping to a random position
            if (_pausePosition >= 0)
            {
                // Set the position of the stream back to where it was paused
                Position = _pausePosition;

                // Set the pause position to negative so that we know the sample is not currently paused
                _pausePosition = -1;
            }
        }

        public void SetPan(float pan)
        {
            channelSteam.Pan = pan;
        }



    }
}
