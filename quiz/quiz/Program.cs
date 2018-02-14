using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quiz
{
    class Program
    {
        static void Main(string[] args)
        {
            string value = "abc123";
            value = Transform(s => s.ToUpper(), value);
            value = Transform(s => new string(s.Reverse().ToArray()), value);
            Console.WriteLine(value);
        }

        static string Transform(Func<string, string> transformer, string value)
        {
            return transformer(value);
        }
    }
}
