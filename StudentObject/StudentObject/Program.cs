using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentObject
{
    class Program
    {
        static String[] Records = new string[5];
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Students Record!");
            while (true)
            {
                Console.WriteLine("Select Option:");
                Console.WriteLine("1.Read the File");
                Console.WriteLine("2.Find a Record");

                int userInput = Convert.ToInt32(Console.ReadLine());
                if (userInput == 1)
                {
                    Console.WriteLine("Please Enter The File Name");
                    ReadFile();
                }
                if (userInput == 2)
                {
                    Console.WriteLine("Please enter the index number");
                    Tab();
                }
                else
                {
                    Console.WriteLine("Invalid Input");
                }
            }
        }

        private static void Tab()
        {


            int index = Convert.ToInt32(Console.ReadLine());
            var read = Records[index].Replace(",", "\t");
            Console.WriteLine(read);

        }

        private static void ReadFile()
        {
            string Filename = Console.ReadLine();
            using (StreamReader reader = new StreamReader(Filename))
            {
                int i = 0;
                while (!reader.EndOfStream)
                {
                    Records[i] = reader.ReadLine();
                    i++;
                }

                foreach (var Record in Records)
                {
                    Console.WriteLine(Record);
                }
            }

            Console.ReadKey();
        }
    }
}

 
