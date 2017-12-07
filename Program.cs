using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace StudentRecords
{
    class Program
    {
        
        static List<string> records = new List<string>();

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Student Records");
            ReadInFile();
            Console.WriteLine("Main Menu: ");
            bool keepGoing = true;
            while (keepGoing)
            {
                Console.WriteLine("1 - Read Another File");
                Console.WriteLine("2 - List All Records");
                Console.WriteLine("3 - Find Student by index No.");
                Console.WriteLine("4 - Find First Match");
                Console.WriteLine("6 - Add New Student");
                Console.WriteLine("9 - Quit");
                Console.Write("Select an option: ");
                char menuChoice = Console.ReadLine().ToCharArray()[0];
                Console.WriteLine();
                switch (menuChoice)
                {
                    case '1':
                        ReadInFile();
                        break;
                    case '2':
                        ListAllRecords();
                        break;
                    case '3':
                        FindRecordByIndex();
                        break;
                    case '4':
                        FindFirstMatch();
                        break;
                    case '6':
                        writeNewRecord();
                        break;
                    case '9':
                        keepGoing = false;
                        break;
                    default:
                        Console.WriteLine("Invalid menu choice");
                        break;
                }
            }
        }

        static void ReadInFile()
        {
            Console.Write("Enter FileName (including extension): ");
            string fileName = Console.ReadLine();
            try
            {
                
                int number = ReadFileIntoRecordsList(fileName);
                Console.WriteLine("{0} Records read in", number);
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File does not exist");
            }
        }

        static void FindRecordByIndex()
        {
            Console.Write("Enter Index No. :");
            try
            {
                int index = Convert.ToInt32(Console.ReadLine());
                WriteRecordToConsole(records[index]);
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Not a valid index");
            }
            catch (FormatException)
            {
                Console.WriteLine("Not a number");
            }
        }

        static void FindFirstMatch()
        {
            Console.Write("Enter a search string: ");
            string searchString = Console.ReadLine();
            var record = FindFirstMatch(searchString);
            WriteRecordToConsole(record);
        }

        static string FindFirstMatch(string searchString)
        {
            var searchUC = searchString.ToUpper();
            return records.Where(r => r.ToUpper().Contains(searchUC)).First();
        }

        //Returns the number of records read in
        static int ReadFileIntoRecordsList(string fileName)
        {
            int i = 0;
            using (StreamReader reader = new StreamReader(fileName))
            {
                while (!reader.EndOfStream)
                {
                    records.Add(reader.ReadLine());
                    i++;
                }
            }
            return i;
        }

        static void WriteRecordToConsole(string record)
        {
            var formatted = record.Replace(",", "\t");
            Console.WriteLine(formatted);
        }
        
        static void ListAllRecords()
        {
            foreach (var record in records)
            {
                WriteRecordToConsole(record);
            }
        }

        static void ChangeGrade()
        { 
                Console.Write("Enter Index No. :");
                try
                {
                    int index = Convert.ToInt32(Console.ReadLine());
                    WriteRecordToConsole(records[index]);
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("Not a valid index");
                }
                catch (FormatException)
                {
                    Console.WriteLine("Not a number");
                }
            
        }

        static void writeNewRecord()
        {
            Console.WriteLine("Please enter the new student's data in the following sequence (devide with comma)");
            Console.WriteLine("Student Number, Last Name, First Name, DOB, Average Grade ");
            string userinput = Convert.ToString(Console.ReadLine());
            WriteFileIntoRecordsList(userinput);
        }
        static void WriteFileIntoRecordsList(string userinput)
        {
            
            using (StreamWriter writer = new StreamWriter("database.csv"))
            {
                writer.WriteLine(userinput);
                writer.Flush();
                Console.WriteLine("Please re-read the database after you have altered it");
            }
            
            
        }
    }
}
