using System;
using System.IO;
using System.Media;
using VoiceRSS_SDK;
using NAudio.Wave;
using System.Text;
using System.Security.Cryptography;
using System.Threading;

namespace ParsonsFinalProject
{
    public class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                UserView.UserInterface();
            }
        }

        public static void APICall(string speechText)
        {
            var apiKey = "22c1257eb63c445793bb5e6e14d73611";
            var isSSL = false;
            var text = speechText;
            var lang = Languages.English_GreatBritain;

            var voiceParams = new VoiceParameters(text, lang)
            {
                AudioCodec = AudioCodec.MP3,
                AudioFormat = AudioFormat.Format_48KHZ.AF_48khz_16bit_stereo,
                //Format_11KHZ.AF_11khz_8bit_mono,
                //Format_44KHZ.AF_44khz_16bit_stereo,
                IsBase64 = false,
                IsSsml = false,
                SpeedRate = 1
            };
            

            var voiceProvider = new VoiceProvider(apiKey, isSSL);

            voiceProvider.SpeechFailed += (Exception ex) =>
            {
                Console.WriteLine(ex.Message);
            };

            var voice = voiceProvider.Speech<byte[]>(voiceParams);

            var fileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "voice.mp3");


            int count = 3;
            for (int i = 1; i <= count; i++)
            {
                Console.WriteLine("Working on it..." + i);
                Thread.Sleep(600);
            }
            
            try
            {
                using (var stream = File.Create(fileName)){}
                File.WriteAllBytes(fileName, voice);
            }
            catch
            {
                Console.WriteLine("File in use, try again.");
                UserView.UserInterface();
            }
            Console.WriteLine("Success!");
            PlayAudio();
            /*
             Console.WriteLine("Do you want to encrypt the audio files? (yes/no)");
            var encrypt = Console.ReadLine();
            if (encrypt == "yes")
            {
                EncryptFile(pathAndName);
                EncryptFile(oldPathAndName);
                Console.WriteLine("Encrypting...");
                Thread.Sleep(200);
            }
            if (encrypt == "no")
            {
                Console.WriteLine("Directing back to program...");
                UserView.UserInterface();
            }*/

            
        }

        private static void PlayAudio()
        {
            var pathAndName = AppDomain.CurrentDomain.BaseDirectory + @"\voice.mp3";
            var oldPathAndName = AppDomain.CurrentDomain.BaseDirectory + @"\voice.wav";
            ConvertMp3ToWav(pathAndName, oldPathAndName);

            try
            {
                SoundPlayer typewriter = new SoundPlayer();
                typewriter.SoundLocation = oldPathAndName;
                typewriter.PlaySync();
            }
            catch
            {
                Console.WriteLine("File in use, try again.");
                UserView.UserInterface();
            }

            Console.WriteLine("Do you want to encrypt the audio files? (yes/no)");
            var encrypt = Console.ReadLine();
            if (encrypt == "yes")
            {
                EncryptFile(pathAndName);
                EncryptFile(oldPathAndName);
                Console.WriteLine("Encrypting...");
                Thread.Sleep(2000);
            }
            if (encrypt == "no")
            {
                Console.WriteLine("Directing back to program...");
                UserView.UserInterface();
            }
        }

        /// Encrypts a file using Rijndael algorithm.
        ///</summary>
        ///<param name="outputFile"></param>
        private static void EncryptFile(string outputFile)
        {
            try
            {
                string password = @"myKey123";
                UnicodeEncoding UE = new UnicodeEncoding();
                byte[] key = UE.GetBytes(password);

                string cryptFile = outputFile;
                FileStream fsCrypt = new FileStream(cryptFile, FileMode.Create);

                RijndaelManaged RMCrypto = new RijndaelManaged();

                CryptoStream cs = new CryptoStream(fsCrypt,
                    RMCrypto.CreateEncryptor(key, key),
                    CryptoStreamMode.Write);               
            }
            catch
            {
                Console.WriteLine("Encryption failed!", "Error");
                Console.Read();
            }      
        }

        private static void ConvertMp3ToWav(string pathAndName, string oldPathAndName)
        {
            try
            {
                using (Mp3FileReader mp3 = new Mp3FileReader(pathAndName))
                {
                    using (WaveStream pcm = WaveFormatConversionStream.CreatePcmStream(mp3))
                    {
                        WaveFileWriter.CreateWaveFile(oldPathAndName, pcm);
                    }
                }
            }
            catch
            {
                Console.WriteLine("File in use, try again.");
                UserView.UserInterface();
            }
        }
    }
}