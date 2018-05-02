using System;
using System.IO;
using System.Media;
using VoiceRSS_SDK;
using NAudio.Wave;
using System.Text;
using System.Security.Cryptography;
using System.Threading;
using System.Collections.Generic;
using System.Linq;

namespace ParsonsFinalProject
{
    /// <summary>
    /// A class that makes API calls, encryption, and file conversion.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Starts the main program.
        /// </summary>
        /// <param name="args">A string parameter.</param>
        protected static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the RSS TTS Vocalizer!");
            Console.WriteLine("Before you begin, Break the ice and play a little tongue twister (1)," +
                " a familiar little song (2), " +
                "or a simple wierd statement (3)?");
            
            string userInput = Console.ReadLine();

            int index = Convert.ToInt32(userInput);
            List<string> myList = new List<string>();

            myList.Add("If you must cross a course cross cow across a crowded cow crossing, cross the cross coarse cow across the crowded cow crossing carefully.");
            myList.Add("The wheels on the bus go round and round, round and round, round and round. The wheels on the bus go round and round, all through the town!");
            myList.Add("I am speaking with absolutely no emotions or inflections in my speech. he is dead. I am scared. he is angry. i am angry. but you cannot tell! So many emotions...");

            var value = myList.ElementAt(index-1);

            APICallAsync(value);
            while (true)
            {
                UserView.UserInterface();
            }
        }

        /// <summary>
        /// An async method that calls the API with some error handling.
        /// </summary>
        /// <param name="speechText"> A string to be converted to bytes and passed to the API.</param>
        public static async void APICallAsync(string speechText)
        {
            var apiKey = "22c1257eb63c445793bb5e6e14d73611";
            var isSSL = false;
            var text = speechText;
            var lang = Languages.English_UnitedStates; ;
                /*
            Languages.English_UnitedStates;
            Languages.English_India;
            Languages.English_Australia;
            Languages.English_Canada;
            Languages.English_GreatBritain;
            */
            var voiceParams = new VoiceParameters(text, lang)
            {
                AudioCodec = AudioCodec.MP3,
                AudioFormat = AudioFormat.Format_48KHZ.AF_48khz_16bit_stereo,
                IsBase64 = false,
                IsSsml = false,
                SpeedRate = 1
            };
                        
            var voiceProvider = new VoiceProvider(apiKey, isSSL);

            // An asynchonous API call.
            var voice = await voiceProvider.SpeechTaskAsync<byte[]>(voiceParams);

            var fileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "voice.mp3");

            voiceProvider.SpeechFailed += (Exception ex) =>
            {
                Console.WriteLine(ex.Message);
            };

            Console.WriteLine("Working on it...");
            Thread.Sleep(3000);

            try
            {
                using (var stream = File.Create(fileName)) { }
                File.WriteAllBytes(fileName, voice);
            }
            catch
            {
                Console.WriteLine("File in use, try again.");
                UserView.UserInterface();
            }
            Console.WriteLine("Success!");
            PlayAudio();            
        }

        /// <summary>
        /// A private method that plays .wav audio files from the base directory.
        /// </summary>
        private static void PlayAudio()
        {
            var pathAndName = AppDomain.CurrentDomain.BaseDirectory + @"\voice.mp3";
            var oldPathAndName = AppDomain.CurrentDomain.BaseDirectory + @"\voice.wav";
            ConvertMp3ToWav(pathAndName, oldPathAndName);

            try
            {
                SoundPlayer typewriter = new SoundPlayer
                {
                    SoundLocation = oldPathAndName
                };
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

        

        /// <summary>
        /// Encrypts a file using the Rijndael algorithm.
        /// </summary>
        /// <param name="outputFile"> A string file path to be encrypted.</param>
        public static string EncryptFile(string outputFile)
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
            return outputFile;
        }


        /// <summary>
        /// A method to convert .mp3 files to .wav files.
        /// </summary>
        /// <param name="pathAndName">A string file path to be converted.</param>
        /// <param name="oldPathAndName"> A string file path to be created from the conversion.</param>
        public static void ConvertMp3ToWav(string pathAndName, string oldPathAndName)
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