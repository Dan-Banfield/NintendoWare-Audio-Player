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

        public static void PlayBFSTMFile(string fileLocation)
        {
            if (soundPlayer == null)
                soundPlayer = new SoundPlayer();

            byte[] bfstmBytes = File.ReadAllBytes(fileLocation);
            AudioData bfstmData = new BCFstmReader().Read(bfstmBytes);
            byte[] wavBytes = new WaveWriter().GetFile(bfstmData);

            using (MemoryStream memoryStream = new MemoryStream(wavBytes))
            {
                soundPlayer.Stream = memoryStream;
                soundPlayer.PlayLooping();
            }
        }
    }
}