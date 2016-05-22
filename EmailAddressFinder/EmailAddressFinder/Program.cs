using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace EmailAddressFinder
{
    class Program
    {
        static void Main(string[] args)
        {

            string path = string.Empty;
            Console.SetWindowSize(100, 50);

            try
            {
                Console.WriteLine("EmailAddressFinder 1.0");
                Console.WriteLine("By Phillip Smith");
                Console.WriteLine("---------");
                Console.WriteLine("A small program created to give you a list of unique");
                Console.WriteLine("email addresses found in a certain text file.");
                Console.WriteLine("---------------------------------------------------");
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Instructions (Regular):");
                Console.WriteLine("1. Open this program");
                Console.WriteLine("2. Drag the file you would like to process into this window");
                Console.WriteLine("3. Press enter");
                Console.WriteLine("4. A list of email addresses and the number");
                Console.WriteLine("   of times they appear in the file will be");
                Console.WriteLine("   displayed on screen.");
                Console.WriteLine();
                Console.WriteLine("Instructions (Quick):");
                Console.WriteLine("1. Drag the text file you would like to process directly");
                Console.WriteLine("   onto the program file (EmailAddressFinder1_0.exe) for this program.");
                Console.WriteLine("   It will instantly process the file without needing you");
                Console.WriteLine("   to press enter.");
                Console.WriteLine();
                Console.WriteLine("Please drag your file into the console window now, and hit enter after you do so.");

                if (args.Length == 0)
                {
                    path = Console.ReadLine();
                    if (path == string.Empty)
                        throw new Exception("No input received.");
                }
                else if (args.Length == 1)
                    path = args[0];
                else
                    throw new InvalidOperationException("ERROR: Too many arguments passed");


                if (!File.Exists(path))
                    throw new Exception("Sorry, I could not find the file you specified.");
                else
                {

                    UniqueStringCounter counter = new UniqueStringCounter();

                    string theFile = File.ReadAllText(path);



                    string[] strings = theFile.Split(' ');

                    foreach (string s in strings)
                    {
                        if (s.Contains("@gmail.com"))
                        {
                            counter.addString(s);
                        }
                    }

                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine("{0,-20} {1,5}\n", "Address", "Count");
                    Console.WriteLine("-----------------------------------------");
                    //for (int ctr = 0; ctr < names.Length; ctr++)
                    //    Console.WriteLine("{0,-20} {1,5:N1}", names[ctr], hours[ctr]);


                    foreach (KeyValuePair<string, int> pair in counter.getList())
                    {
                        Console.WriteLine("{0,-20} {1,5:N0}", pair.Key, pair.Value);
                    }





                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine("Processing complete.");
                    Console.WriteLine();
                    Console.WriteLine("Please hit enter to exit.");
                    Console.ReadLine();


                }



            }
            catch (Exception ex)
            {
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine(ex.Message);
                Console.WriteLine("Please hit enter to exit.");
                Console.ReadLine();
            }
        }



    }
}
