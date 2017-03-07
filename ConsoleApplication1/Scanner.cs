using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototypeKioskSystem
{
    /* This class serves to simulate a scanner
     * it reads an text file containing a list of Strings representing products
     * it forwards this information to a new checkout session
     */
    public class ItemScanner
    {
        public static void Main()
        {
            String[] scannedGroceries;
            String input;

            while (true)
            {  
                Console.WriteLine("Please input the file name/path to the item list or q to quit");
                input = Console.ReadLine();

                if (input == "q") break;
                else input = "Data/" + input;

                if (!System.IO.File.Exists(input)) 
                {
                    Console.WriteLine("File not found");
                    Console.WriteLine("________________________________________________________________________________");
                    continue;
                }

                scannedGroceries = System.IO.File.ReadAllLines(input).ToArray();

                Checkout checkoutSystem = new Checkout(scannedGroceries);
                checkoutSystem.computeItemizedReceipt();


                Console.WriteLine("________________________________________________________________________________");
            }
        }
    }
}
