using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.DirectX.AudioVideoPlayback;

namespace LivesetAnalyzer
{
    public class AudioFileHandler
    {
        private long sampleRate;
        private byte bufferSize;


        public AudioFileHandler(long sRate, byte bSize)
        {
            this.sampleRate = sRate;
            this.bufferSize = bSize;
        }



    }
}
