using System;
using System.IO;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Linq;
using static hw1.Board;

namespace hw1
{

    public enum Direction
    {
        swipeUp,
        swipeRight,
        swipeDown,
        swipeLeft,
    };
    class Program
    {
        static int valuetoObtain;
        static Coordinates gridSize;
        static List<List<int>> puzzle_input = new List<List<int>>();
        static Queue<int> readIn_SpawnPool = new Queue<int>();

        static void Main(string[] args)
        {
            bool moved;
            ReadFile();
            Board Puzzle_Board = new Board(gridSize.y, gridSize.x, valuetoObtain, readIn_SpawnPool);
            Puzzle_Board.FillBoard(puzzle_input);
            Puzzle_Board.DisplayBoard();
            Puzzle_Board.DebugBoard();
            //LDL
            Console.WriteLine("swipeLeft");
            moved = Puzzle_Board.moveBoard(Direction.swipeLeft); 
            Console.WriteLine("Has Moved: "+moved);
            Puzzle_Board.DisplayBoard();
            
            Console.WriteLine("swipeDown");
            moved = Puzzle_Board.moveBoard(Direction.swipeDown); 
            Console.WriteLine("Has Moved: "+moved);
            Puzzle_Board.DisplayBoard();
            
            Console.WriteLine("swipeLeft");
            moved = Puzzle_Board.moveBoard(Direction.swipeLeft); 
            Console.WriteLine("Has Moved: "+moved);
            Puzzle_Board.DisplayBoard();            

            /* test non movement
            Console.WriteLine("swipeUp");
            moved = Puzzle_Board.moveBoard(Direction.swipeUp); 
            Console.WriteLine("Has Moved: "+moved);
            Puzzle_Board.DisplayBoard();

            
            Console.WriteLine("swipeUp2222");
            moved = Puzzle_Board.moveBoard(Direction.swipeUp); 
            Console.WriteLine("Has Moved: "+moved);
            Puzzle_Board.DisplayBoard();
            */

            /* test up down left right
            Console.WriteLine("swipeRight");
            moved = Puzzle_Board.moveBoard(Direction.swipeRight); 
            Console.WriteLine("Has Moved: "+moved);
            Puzzle_Board.DisplayBoard();
            Console.WriteLine("swipeLeft");
            moved =Puzzle_Board.moveBoard(Direction.swipeLeft); 
            Console.WriteLine("Has Moved: "+moved);
            Puzzle_Board.DisplayBoard();
            Console.WriteLine("swipeUp");
            moved =Puzzle_Board.moveBoard(Direction.swipeUp);
            Console.WriteLine("Has Moved: "+moved);
            Puzzle_Board.DisplayBoard();
            Console.WriteLine("swipeDown");
            moved =Puzzle_Board.moveBoard(Direction.swipeDown); 
            Console.WriteLine("Has Moved: "+moved);
            Puzzle_Board.DisplayBoard();*/
            
        }
        private static void ReadFile()
        {
            // Taking a new input stream i.e.  
            // geeksforgeeks.txt and opens it 
            StreamReader sr = new StreamReader("puzzle1.txt");

            // This is use to specify from where  
            // to start reading input stream 
            sr.BaseStream.Seek(0, SeekOrigin.Begin);
            int[] temp_converted;
            List<int> converted;
            string[] input;
            //1st line
            input = sr.ReadLine().Split(' ');
            valuetoObtain = Int32.Parse(input[0]);
            //2nd line
            input = sr.ReadLine().Split(' ');
            gridSize = new Coordinates(Int32.Parse(input[0]), Int32.Parse(input[1]));
            //3rd line
            input = sr.ReadLine().Split(' ');
            temp_converted = Array.ConvertAll(input, int.Parse);
            converted = new List<int>(temp_converted);
            readIn_SpawnPool = new Queue<int>(converted);
            //Rest of grid
            while (sr.EndOfStream == false)
            {
                input = sr.ReadLine().Split(' ');
                temp_converted = Array.ConvertAll(input, int.Parse);
                converted = new List<int>(temp_converted);
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
