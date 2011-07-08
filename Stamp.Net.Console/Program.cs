using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stamp.Net;

namespace StampNetConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var currentDate = DateTime.Now;
            Console.WriteLine(currentDate.Format("June 24, 2001"));
            Console.WriteLine(currentDate.Format("Jun 23, 2345"));
            Console.WriteLine(currentDate.Format("Jun 09"));
            Console.WriteLine(currentDate.Format("Monday, June 09, 2003"));
            Console.ReadLine();
        }
    }
}
