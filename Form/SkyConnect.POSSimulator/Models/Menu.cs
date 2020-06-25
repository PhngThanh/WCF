using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyConnect.POSSimulator.Models
{
    public class Menu
    {
        public List<string> Items { get; set; }
        public int ChoiceItems()
        {
            int yourChoice = 0;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("================Menu================");
            foreach (var item in this.Items)
            {
                Console.WriteLine("{0}", item);
            }

            Console.Write("Insert your choice: ");
            int.TryParse(Console.ReadLine(), out yourChoice);


            Console.ResetColor();
            return yourChoice;
        }
    }
}
