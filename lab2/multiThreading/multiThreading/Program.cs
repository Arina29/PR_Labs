using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace multiThreading
{
    class Program
    {
        static void Main(string[] args)
        {
            Parallel.Invoke(() => writeNode(4), () => writeNode(5));
            Task task2 = Task.Factory.StartNew(() => writeNode(2));
            Task.WaitAll(task2);
            Task task3 = Task.Factory.StartNew(() => writeNode(3));
            Task.WaitAll(task2, task3);
            Task task1 = Task.Factory.StartNew(() => writeNode(1));

            Console.ReadKey();
        }

        static void writeNode(object nodeCode) 
        {
            Console.WriteLine("Thread" + (int)nodeCode);
            Thread.Sleep(1500);
        }
        
    }
}
