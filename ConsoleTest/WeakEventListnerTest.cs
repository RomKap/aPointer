using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp
{
    public class WeakEventListnerTest
    {

        public void TestEventBehaviour()
        {
            Console.WriteLine("=== Naive listener (bad) ===");

            EventSoruce source = new EventSoruce();

            NaiveEventListener listener = new NaiveEventListener(source);

            source.Raise();

            Console.WriteLine("Setting listener to null.");
            listener = null;

            TriggerGC();

            source.Raise();

            Console.WriteLine("Setting source to null.");
            source = null;

            TriggerGC();
             
        }

        static void TriggerGC()
        {
            Console.WriteLine("Starting GC.");

            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();

            Console.WriteLine("GC finished.");
        }
    }

    public class EventSoruce
    {
        public EventHandler<EventArgs> MyEvent =  delegate { };

        public void Raise()
        {
            MyEvent(this, EventArgs.Empty);
        }
    } 

    public class NaiveEventListener
    {
        public NaiveEventListener(EventSoruce source)
        {
            source.MyEvent += OnEvent;
        }

        private void OnEvent(object source, EventArgs e)
        {
            Console.WriteLine("EventListener received event.");
        }

        ~NaiveEventListener()
        {
            Console.WriteLine("NaiveEventListener finalized.");
        }
    }

 
 
}
