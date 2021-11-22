using System;
using System.Collections.Generic;

namespace UNN1N9_HFT_2021221.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Threading.Thread.Sleep(8000);
            RestService rest = new RestService("http://localhost:35739");
            Menu.Start(rest);

            Console.ReadKey();
        }
    }
}
