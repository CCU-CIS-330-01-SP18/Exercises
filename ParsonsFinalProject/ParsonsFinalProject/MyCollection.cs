using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParsonsFinalProject
{
    public class MyCollection
    {
        public void StoreCollection()
        {
            SortedList<int, string> myList = new SortedList<int, string>();

            myList.Add(1, "Skipity skip skip skippy skippila skipish skipping");
            myList.Add(2, "The wheels on the bus go round and round, round and round, round and round. The wheels on the bus go round and round, all through the town!");
            myList.Add(3, "I am speaking with absolutely no emotions or inflections on my speech. he is dead. he is funny. he is angry. i am angry. but you cannot tell! moooooo hoooooooo haaaaaa haaaaaa");
        }
        
            /*
        SortedList mylist = new List(new string[] {
            "1. Skipity skip skip skippy skippila skipish skipping",
            "2. The wheels on the bus go round and round, round and round, round and round. The wheels on the bus go round and round, all through the town!",
            "3. I am speaking with absolutely no emotions or inflections on my speech. he is dead. he is funny. he is angry. i am angry. but you cannot tell! moooooo hoooooooo haaaaaa haaaaaa" });
            */
    }
}