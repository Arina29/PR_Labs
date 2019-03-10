using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace multiThreading
{
    class Program
    {
        private static AutoResetEvent secondWaitsLast = new AutoResetEvent(false);
        private static AutoResetEvent secondWaitsFourth = new AutoResetEvent(false);
        private static AutoResetEvent thirdWaitsSecond = new AutoResetEvent(false);
        private static AutoResetEvent FirstWaitsThird = new AutoResetEvent(false);


        static void Main(string[] args)
        {
            new Thread(() =>
            {
                writeNode(5);
                secondWaitsLast.Set();
            }).Start();

            new Thread(() =>
            {
                writeNode(4);
                secondWaitsFourth.Set();
            }).Start();

            new Thread(() =>
            {
                thirdWaitsSecond.WaitOne();
                writeNode(3);
                FirstWaitsThird.Set();
            }).Start();

            new Thread(() =>
            {
                FirstWaitsThird.WaitOne();
                writeNode(1);
            }).Start();

            new Thread(() =>
            {
                secondWaitsLast.WaitOne();
                secondWaitsFourth.WaitOne();
                writeNode(2);
                thirdWaitsSecond.Set();

            }).Start();

       


            Console.ReadKey();
        }

        static void writeNode(object nodeCode) 
        {
            Console.WriteLine("Thread" + (int)nodeCode);
            Thread.Sleep(1500);
        }
        
    }
}
