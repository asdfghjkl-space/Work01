using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListSample
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = new List<string>();

            for (int i = 0; i < 5; i++)
            {
                numbers.Add(Console.ReadLine());
            }

            numbers.Clear();

            foreach (var item in numbers)
            {
                Console.Write(item + " ");
            }



        }
    }
}
