using System;
using System.IO;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Linq;
using static hw1.Board;

namespace hw1
{
    
    class Program
    {
        static int valuetoObtain;
        static Coordinates gridSize;
        static List<List<int>> puzzle_input = new List<List<int>>();

        static void Main(string[] args)
        {
            
            ReadFile();
        }
        private static void ReadFile()
        {
            // Taking a new input stream i.e.  
            // geeksforgeeks.txt and opens it 
            StreamReader sr = new StreamReader("puzzle1.txt");

            // This is use to specify from where  
            // to start reading input stream 
            sr.BaseStream.Seek(0, SeekOrigin.Begin);

            string[] input;
            //1st line
            input = sr.ReadLine().Split(' ');
            valuetoObtain = Int32.Parse(input[0]);
            //2nd line
            input = sr.ReadLine().Split(' ');
            gridSize= new Coordinates(Int32.Parse(input[0]),Int32.Parse(input[1]));
            //Rest of grid
            while (sr.EndOfStream == false)
            {
                input = sr.ReadLine().Split(' ');
                int [] temp_converted = Array.ConvertAll(input, int.Parse);
                List<int> converted = new List<int>(temp_converted);
                puzzle_input.Add(converted);
            }

            // to close the stream 
            sr.Close();
            /* test readin
            
            Console.WriteLine(valuetoObtain);
            Console.WriteLine(gridSize);
            foreach(List<int> l in puzzle_input)
            {
                foreach(int i in l)
                {
                    Console.Write(i + " ");
                }
                Console.WriteLine();
            }
            */

        }
    }

    
}
