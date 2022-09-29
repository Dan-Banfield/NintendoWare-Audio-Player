using System;
using System.IO;
using System.Media;
using VGAudio.Formats;
using VGAudio.Containers.Wave;
using VGAudio.Containers.NintendoWare;

namespace NintendoWare_Audio_Player.Audio
{
    public static class AudioPlayer
    {
        private static SoundPlayer soundPlayer;

        private static byte[] bfstmBytes;
        private static AudioData bfstmData;
        private static byte[] wavBytes;

        private static WaveWriter waveWriter;
        private static BCFstmReader bcfstmReader;

        public static void PlayBFSTMFile(string fileLocation)
        {
            if (soundPlayer == null) soundPlayer = new SoundPlayer();

            bfstmBytes = File.ReadAllBytes(fileLocation);

            if (bcfstmReader == null) bcfstmReader = new BCFstmReader();
            bfstmData = bcfstmReader.Read(bfstmBytes);

            if (waveWriter == null) waveWriter = new WaveWriter();
            wavBytes = waveWriter.GetFile(bfstmData);

            using (MemoryStream memoryStream = new MemoryStream(wavBytes))
            {
                soundPlayer.Stream = memoryStream;
                soundPlayer.Play();
            }

            GC.Collect();
        }
    }
}