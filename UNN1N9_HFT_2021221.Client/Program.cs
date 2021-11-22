using System;

namespace UNN1N9_HFT_2021221.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu.Wait();
            RestService rest = new RestService("http://localhost:35739");
            Menu.Start(rest);

            Console.ReadKey();
        }
    }
}
