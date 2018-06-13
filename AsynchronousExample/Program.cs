using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsynchronousExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Task task = new Task(CallingMethod);
            task.Start();
            task.Wait();
            Console.ReadLine();
        }

        static async void CallingMethod()
        {
            string filepath = "C:\\Learnings\\MyExample.txt";
            Task<int> task = ReadFile(filepath);

            Console.WriteLine("some  other work 1");
            Console.WriteLine("some other work 2");
            Console.WriteLine("some other work 3");

            int Length = await task;
            Console.WriteLine("Total length " + Length);

            Console.WriteLine("after execution work 1");
            Console.WriteLine("after execution work 2");

        }


        //read the contents of a text file and get the length of the total characters of that file
        static async Task<int> ReadFile(string file)
        {
            int length = 0;
            Console.WriteLine("File reading");

            using(StreamReader reader = new StreamReader(file))
            {
                string s = await reader.ReadToEndAsync();
                length = s.Length;


            }
            Console.WriteLine("File reading is completed");
            return length;
        }
    }
}
