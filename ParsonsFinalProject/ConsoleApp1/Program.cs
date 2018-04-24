using System;
using System.IO;
using System.Media;
using VoiceRSS_SDK;
using NAudio.Wave;
using System.Threading;
using System.Threading.Tasks;

namespace ParsonsFinalProject
{
    class Program
    {
        static void Main(string[] args)
        {
            var apiKey = "22c1257eb63c445793bb5e6e14d73611";
            var isSSL = false;
            Console.WriteLine("Write out the statement for audio conversion:");
            var b = Console.ReadLine();
            var text = b;
            var lang = Languages.English_UnitedStates;

            var voiceParams = new VoiceParameters(text, lang)
            {
                AudioCodec = AudioCodec.MP3,
                AudioFormat = AudioFormat.Format_44KHZ.AF_44khz_16bit_stereo,
                IsBase64 = false,
                IsSsml = false,
                SpeedRate = 0
            };

            var voiceProvider = new VoiceProvider(apiKey, isSSL);
            var voice = voiceProvider.Speech<byte[]>(voiceParams);

            voiceProvider.SpeechFailed += (Exception ex) =>
            {
                Console.WriteLine(ex.Message);
            };

            voiceProvider.SpeechReady += (object data) =>
            {
                var fileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "voice.mp3");
                File.WriteAllBytes(fileName, (byte[])data);
            };

            voiceProvider.SpeechAsync<byte[]>(voiceParams);

            PlayAudio();
        }

        private static void PlayAudio()
        {
            var pathAndName = AppDomain.CurrentDomain.BaseDirectory + @"\voice.mp3";
            var oldPathAndName = AppDomain.CurrentDomain.BaseDirectory + @"\voice2.wav";


            ConvertMp3ToWav(pathAndName, oldPathAndName);

            SoundPlayer typewriter = new SoundPlayer();
            typewriter.SoundLocation = oldPathAndName;
            typewriter.PlaySync();
        }

        private static void ConvertMp3ToWav(string pathAndName, string oldPathAndName)
        {

            using (Mp3FileReader mp3 = new Mp3FileReader(pathAndName))
            {
                using (WaveStream pcm = WaveFormatConversionStream.CreatePcmStream(mp3))
                {
                    WaveFileWriter.CreateWaveFile(oldPathAndName, pcm);
                }
            }
        }
    }
}