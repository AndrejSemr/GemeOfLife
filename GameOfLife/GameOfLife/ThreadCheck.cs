using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

namespace GameOfLife.GameOfLife
{
    public class ThreadCheck
    {
        private SmoleTask mytask = new SmoleTask();
        public void Start()
        {

            //Thread task = new Thread(new ThreadStart( mytask.WriteText ));
            //task.Start();
            //Console.Read();
            //mytask.WriteStop();
            Thread task = new Thread(new ThreadStart(Go));
            task.Start(km);
            while (true)
            {
                Thread.Sleep(500);
                Console.WriteLine(km);
            }
        }
        int km = 0;
        public void Go()
        {
            int kmi = (int)km;
            kmi++;
            km = kmi;
            Thread.Sleep(1000);
        }
        public void WriteThis(int km)
        {
            Console.WriteLine(km);
            Thread.Sleep(500);
        }
    }

    public class SmoleTask
    {
        public bool work;
        public void WriteText()
        {
            work = true;
            int i = 0;

            while (work)
            {
                Console.WriteLine("Text {0}", i++);
                Thread.Sleep(1000);
            }
        }

        public void WriteStop()
        {
            work = false;
        }
    }

}
