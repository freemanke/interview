using System;
using System.Collections.Generic;

namespace Main
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(new Caculator().Caculate("20+30+10+4*10-100-100/10-10"));
        }
    }
}
