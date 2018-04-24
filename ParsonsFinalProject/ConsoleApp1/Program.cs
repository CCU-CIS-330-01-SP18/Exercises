using System;
using System.IO;
using System.Media;
using VoiceRSS_SDK;
using NAudio.Wave;


namespace ParsonsFinalProject
{
    class Program
    {
        static void Main(string[] args)
        {
            var apiKey = "22c1257eb63c445793bb5e6e14d73611";
            var isSSL = false;
            var text = "Hi Chad, this is me talking to myself boi.";
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

            var fileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "voice.mp3");
            File.WriteAllBytes(fileName, voice);

            PlayAudio();
        }
        private static void PlayAudio()
        {
            var pathAndName = AppDomain.CurrentDomain.BaseDirectory + @"\voice.mp3";
            var oldPathAndName = AppDomain.CurrentDomain.BaseDirectory + @"\voice.wav";

            ConvertMp3ToWav(pathAndName, oldPathAndName);

            SoundPlayer typewriter = new SoundPlayer();
            typewriter.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + @"\voice.wav";
            typewriter.PlaySync();
        }

        private static void ConvertMp3ToWav(string _inPath_, string _outPath_)
        {
            using (Mp3FileReader mp3 = new Mp3FileReader(_inPath_))
            {
                using (WaveStream pcm = WaveFormatConversionStream.CreatePcmStream(mp3))
                {
                    WaveFileWriter.CreateWaveFile(_outPath_, pcm);
                }
            }
        }
    }
}

