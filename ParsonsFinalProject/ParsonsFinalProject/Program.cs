using System;
using System.IO;
using VoiceRSS_SDK;

namespace Examples
{
    class Program
    {
        static void Main(string[] args)
        {
            var apiKey = "22c1257eb63c445793bb5e6e14d73611";
            var isSSL = false;
            var text = "Hi Chad, You are at step one!";
            var lang = Languages.English_UnitedStates;

            var voiceParams = new VoiceParameters(text, lang)
            {
                AudioCodec = AudioCodec.MP3,
                AudioFormat = AudioFormat.Format_44KHZ.AF_44khz_16bit_stereo,
                IsBase64 = false,
                IsSsml = false,
                SpeedRate = 0
            };
            /*
             var voiceProvider = new VoiceProvider(apiKey, isSSL);

            voiceProvider.SpeechFailed += (Exception ex) =>
            {
                Console.WriteLine(ex.Message);
            };

            voiceProvider.SpeechReady += (object data) =>
            {
                var fileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "voice.mp3");
                File.WriteAllBytes(fileName, (byte[])data);
            };

            voiceProvider.SpeechAsync<byte[]>(voiceParams);*/
            /////
            var voiceProvider = new VoiceProvider(apiKey, isSSL);
            var voice = voiceProvider.Speech<byte[]>(voiceParams);

            var fileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "voice.mp3");
            File.WriteAllBytes(fileName, voice);
        }
    }
}

