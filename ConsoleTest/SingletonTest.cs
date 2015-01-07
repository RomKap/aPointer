using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ConsoleApp
{
    public class SingletonTest
    {

        public static void TestSingleton()
        {
            //Singleton.GetInstance();          

           
            ParameterizedThreadStart threadStart1 = new ParameterizedThreadStart(delegate { Singleton.GetInstance(); });
            Thread thread1 = new Thread(threadStart1);
            thread1.Start();
        }

        public static void ThreadMethod(string name)
        {
             
            Singleton.GetInstance();
        }
    }

   

    public class Singleton
    {
        private static Singleton instance = null;
        private Singleton()
        {
        }

        private static object lockthis = new object();
        public static Singleton GetInstance()
        {
            lock (lockthis)
            {
                if (instance == null)
                    instance = new Singleton();
                
                return instance;
            }
        }
    }


    public class SingletonEager
    {
        private static SingletonEager instance = new SingletonEager();
        private SingletonEager()
        {
        }

        public static SingletonEager GetInstance
        {
            get
            {
                return instance;
            }
        }
    }
}
