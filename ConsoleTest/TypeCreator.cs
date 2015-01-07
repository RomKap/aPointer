using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace ConsoleApp
{
    static class TypeCreator
    {
        public static List<T> TypeGenerator<T>(this T[] at)
        {
            return new List<T>(at);
        }

        public static void PrintToConsole<T>(this List<T> items)
        {
            PropertyInfo[] pi = typeof(T).GetProperties();
            // extra loop required to print column names only once
            foreach (var p in pi)
            {
                Console.Write("{0,-12}", p.Name);
            }
            Console.WriteLine();
            foreach (var item in items)
            {
                foreach (var p in pi)
                {
                    Console.Write("{0,-12}", p.GetValue(item, null));
                }
                Console.WriteLine();
            }
            Console.ReadLine();
        }
    }
}
