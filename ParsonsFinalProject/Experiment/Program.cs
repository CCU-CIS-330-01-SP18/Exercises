using System.Reflection;
using System.IO;
using System.Resources;
using System.Media;
using System.Diagnostics;
using System;

namespace Yournamespace
{
    public partial class class1
    {
        static SoundPlayer typewritter;

        public static void Load()
        {
            Assembly assembly;
            assembly = Assembly.GetExecutingAssembly();
            //
            SoundPlayer typewriter = new SoundPlayer();
            typewriter.SoundLocation = Environment.CurrentDirectory + "/voice.mp3";
            ///
           
        }
    }
}