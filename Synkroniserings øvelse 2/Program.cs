using System;
using System.Threading;

namespace Synkroniserings_øvelse_2
{
    class Program
    {

        static int count = 0;
        static object printLock = new object();


        static void Main(string[] args)
        {
            var t1 = new Thread(printStar);
            var t2 = new Thread(printHtag);

            t1.Start();
            Thread.Sleep(10);
            t2.Start();
        }

        static void printStar()
        {
            string star = "*";
            while (true)
            {
                print(star);
            }

        }

        static void printHtag()
        {
            string hashtag = "#";
            while (true)
            {
                print(hashtag);
            }

        }

        static void print(string print)
        {
            lock (printLock)
            {
                for (int i = 0; i < 60; i++)
                {
                    count++;
                    Console.Write(print);
                    Thread.Sleep(10);
                }

                Console.Write($" {count}");
                Console.WriteLine();
            }

        }
    }
}
