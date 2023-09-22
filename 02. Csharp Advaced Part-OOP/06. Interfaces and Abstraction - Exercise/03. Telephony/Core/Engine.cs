using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telephony.Core.Interface;
using Telephony.Models.Interface;
using Telephony.Models;

namespace Telephony.Core
{
    internal class Engine : IEngine
    {
        public void run()
        {
            string[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string[] webs = Console.ReadLine()
              .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            ICalling phone;

            foreach (string number in numbers)
            {
                if (number.Length == 10)
                {
                    phone = new Smartphone();
                }
                else
                {
                    phone = new StationaryPhone();
                }

                try
                {
                    Console.WriteLine($"{phone.Call(number)}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            IBrowsing web = new Smartphone();
            foreach (string url in webs)
            {
                try
                {
                    Console.WriteLine($"{web.Browse(url)}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
