using RecordKeeper.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace RecordKeeper.CLI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Record Keeper. Please enter the file path(s) and sort order(s).");
            try
            {
                string input = Console.ReadLine();
                RecordProcessor recordProcessor = new RecordProcessor();
                string output = recordProcessor.Process(input);
                Console.WriteLine(output);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }    
            Console.Read();
        }
    }
}