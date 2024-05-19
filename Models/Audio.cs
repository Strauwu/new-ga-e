using System;
using System.Linq;
using NAudio.Wave;
using WaveFormat = NAudio.Wave.WaveFormat;
using System.Timers;
using System.Drawing;

namespace new_ga_e.AudioGame
{
    public class Audio
    {
        public static int powerOfNoise;
        public int sred;

        public WaveInEvent waveIn = new WaveInEvent
        {
            DeviceNumber = 0,
            WaveFormat = new WaveFormat(rate: 44100, bits: 16, channels: 1),
            BufferMilliseconds = 30
        };
        public Audio()
        {
            powerOfNoise = 0;
        }
        public void Recording()
        {
            waveIn.DataAvailable += WaveIn_DataAvailable;
            try
            {
                waveIn.StartRecording();

            }
            catch { }

        }
        public void Stopp()
        {
            waveIn.StopRecording();
        }


     
        public void WaveIn_DataAvailable(object? sender, WaveInEventArgs e)
        {
            Int16[] values = new Int16[e.Buffer.Length / 2];
            Buffer.BlockCopy(e.Buffer, 0, values, 0, e.Buffer.Length);
            float fraction = (float)values.Max()/10;
            powerOfNoise = (int)(fraction);

        }
    }
}
