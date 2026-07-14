using System;
 
//   1. Avoids asking the same journal prompt twice in a row (see
//      Journal.WriteNewEntry), sothe usergets more variety over a session.
//   2. Handles errors gracefully when saving or loading a file - a missing
//      file, bad path, or permission problem is caught and reported to the
//      user instead of crashing the whole program (see Journal.SaveToFile
//      and Journal.LoadFromFile).

 
class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        bool keepGoing = true;
 
        while (keepGoing)
        {
            Console.WriteLine("Journal Menu");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");
 
            string choice = Console.ReadLine();
 
            switch (choice)
            {
                case "1":
                    journal.WriteNewEntry();
                    break;
 
                case "2":
                    journal.DisplayAll();
                    break;
 
                case "3":
                    Console.Write("What is the filename? ");
                    string saveFile = Console.ReadLine();
                    journal.SaveToFile(saveFile);
                    break;
 
                case "4":
                    Console.Write("What is the filename? ");
                    string loadFile = Console.ReadLine();
                    journal.LoadFromFile(loadFile);
                    break;
 
                case "5":
                    keepGoing = false;
                    break;
 
                default:
                    Console.WriteLine("Invalid option, try again.");
                    break;
            }
 
            Console.WriteLine();
        }
    }
}