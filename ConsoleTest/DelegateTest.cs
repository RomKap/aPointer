using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp
{
    class DelegateTest
    {
        delegate void DelegateExample(string name);

        public void TestDelegate()
        {
            //create an instance of delegate
            DelegateExample dex1 = new DelegateExample(Notify);
            dex1("Romesh");

            //OR simpler way to declare instance of delegate
            DelegateExample dex2 = Notify;
            dex2("Pradip");

            //OR instantiate delegate by using anonymous method
            DelegateExample dex3 = delegate(string nm) { Console.WriteLine("Notification received for: {0}", nm); };
            dex2("Manish");

            //OR instantiate delegate using lambda expression
            DelegateExample dex4 = nm => { Console.WriteLine("Notification received for: {0}", nm); };
            //OR DelegateExample dex4 = (nm) => { Console.WriteLine("Notification received for: {0}", nm); };
            dex2("Gurmeet");


        }

        public void Notify(string nm)
        {
            Console.WriteLine("Notification received for: {0}", nm);
        }
    }
}
