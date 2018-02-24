using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Week7
{
    public class File
    {
        private string fileName;
        public string FileName
        {
            get
            {
                return fileName;
            }
            set
            {
                fileName = value;
            }
        }
        public async void ProcessFile()
        {
            Task<int> task = new Task<int>(CountCharacters);
            task.Start();

            int count = await task;
        }

        public int CountCharacters()
        {
            int count = 0;
            using (StreamReader reader = new StreamReader(fileName))
            {
                string content = reader.ReadToEnd();
                count = content.Length;
                Thread.Sleep(5000);
            }

            return count;
        }
        /*File(string fileName)
        {

        }*/
    }
}
