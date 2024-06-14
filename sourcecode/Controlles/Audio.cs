using NAudio.Wave;
using System;
using System.Linq;
using WaveFormat = NAudio.Wave.WaveFormat;

namespace new_ga_e.AudioGame
{
    public static class Audio
    {
        public static int powerOfNoise;

        public static WaveInEvent waveIn = new()
        {
            DeviceNumber = 0,
            WaveFormat = new WaveFormat(rate: 44100, bits: 16, channels: 1),
            BufferMilliseconds = 30
        };
        
        public static void Recording()
        {
            waveIn.DataAvailable += WaveIn_DataAvailable;
            try
            {
                waveIn.StartRecording();
            }
            catch { }
        }
        public static void Stopp()
        {
            waveIn.StopRecording();
        }
        public static void WaveIn_DataAvailable(object sender, WaveInEventArgs e)
        {
            Int16[] values = new Int16[e.Buffer.Length / 2];
            Buffer.BlockCopy(e.Buffer, 0, values, 0, e.Buffer.Length);
            powerOfNoise = values.Max()/10;
        }
    }
}
