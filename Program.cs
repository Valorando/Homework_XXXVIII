using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Homework_02_11
{
    internal class Program
    {
        static void Collection_ToString()
        {
            List<string> list = new List<string>
            {
                "Test1", 
                "Test2", 
                "Test3", 
                "Test4", 
                "Test5"
            };

            foreach (var item in list)
            {
                string result = item.ToString();
                Console.WriteLine(result);
            }
        }
        static void Main(string[] args)
        {
            ThreadStart ts = new ThreadStart(Collection_ToString);
            Thread t = new Thread(ts);
            t.Start();
            Console.Read();
        }
    }
}
