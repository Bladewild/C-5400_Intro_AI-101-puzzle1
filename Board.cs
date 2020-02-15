using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.IO;

namespace hw1
{
    class Board
    {
        //internally  all coordinates start from 0,0
        //displaying should add 1,1

        public struct Coordinates
        {
            public int x, y;//the value is for blocks

            public Coordinates(Coordinates currentCoordinate) : this()
            {
                this.x = currentCoordinate.x;
                this.y = currentCoordinate.y;
            }

            public Coordinates(int p1, int p2)
            {
                x = p1;
                y = p2;
            }
            public override string ToString()
            {
                return "[" + x + "," + y + "]";
            }
            public static bool operator== (Coordinates obj1, Coordinates obj2)
            {
                if (obj1.x == obj2.x && obj1.y == obj2.y)
                    return true;
                return false;
            }

            public static bool operator!= (Coordinates obj1, Coordinates obj2)
            {
                if (obj1.x != obj2.x && obj1.y != obj2.y)
                    return true;
                return false;
            }
        }
        public struct Property
        {
            public int value;
            public Property(int v)
            {
                value = v;
            }
            public Property(Property p)
            {
                value = p.value;
            }
        }

        public struct Cell
        {
            public Coordinates coordinates;
            public Property property;

            public Cell(Coordinates c, Property p)
            {
                coordinates = c;
                property = p;
            }
            public Cell(Cell c)
            {
                coordinates = c.coordinates;
                property = c.property;
            }
            
            public override string ToString()
            {
                return property.value.ToString();
            }
        }

        //Configurations
        public int row, coloumn;
        public Cell[,] GameBoard; //THE MAIN GAMEBOARD
        public int valuetoObtain;
        public List<int> tilespawnPool;

        public Board(int r, int c, int input_valuetoObtain, List<int> input_pooltoSpawn)
        {
            row = r;
            c = c;
            valuetoObtain = input_valuetoObtain;
            tilespawnPool = input_pooltoSpawn;
        }
        public Board(Board b) //update listings
        {
            row = b.row;
            coloumn = b.coloumn;            
            valuetoObtain = b.valuetoObtain;
            tilespawnPool = b.tilespawnPool;
        }

        public void FillBoard(List<List<int>> input)
        {
            GameBoard = new Cell[row, coloumn];
            //fillBoard
            for (int yPos = 0; yPos < row; yPos++)
            {
                List<int> input_Row= input[yPos];
                for (int xPos = 0; xPos < coloumn; xPos++)
                {
                    //make coordinate, put value into property, place into board
                    Coordinates new_c= new Coordinates(xPos, yPos);
                    Property new_p= new Property(input_Row[xPos]);
                    GameBoard[yPos, xPos] = new Cell(new_c, new_p);
                }
            }

        }


        //----debugging methods
        public void DisplayBoard()
        {
            //displayed inversed since the origin of the array is topleft. switching to bottomleft
            for (int yPos = row - 1; yPos >= 0; yPos--)
            {
                for (int xPos = 0; xPos < coloumn; xPos++)
                {
                    string displaytext=GameBoard[yPos,xPos].ToString();
                    Console.Write(displaytext);
                }
                Console.WriteLine();
            }
            Console.WriteLine();            
        }


    }
}
        
        