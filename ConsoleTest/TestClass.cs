using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;


namespace ConsoleApp
{

    public class TestFine
    {

        public void TestConnection()
        {

            //ConnectionFactory.MakeConnection();
            //ConnectionFactory.MakeConnection();
            //ConnectionFactory.MakeConnection();

            ConnectionFactory1 cf1 = new ConnectionFactory1();
            cf1.MakeConnection();
            cf1.MakeConnection();
            cf1.MakeConnection();        
            

        }
    }

    public static class ConnectionFactory
    {
        public static ConnectionObject MakeConnection()
        {
            ConnectionObject cn = new ConnectionObject();
            Thread.Sleep(2000);
            return cn;
        }
    }

    public class ConnectionFactory1
    {
        public ConnectionObject MakeConnection()
        {
            ConnectionObject cn = new ConnectionObject();
            Thread.Sleep(2000);
            return cn;
        }
    }

    public class ConnectionObject
    {
        public ConnectionObject()
        {
            Console.WriteLine("New Connection created");
        }
    }
 
}

