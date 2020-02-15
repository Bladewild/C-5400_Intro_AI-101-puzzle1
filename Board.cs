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
            public static bool operator ==(Coordinates obj1, Coordinates obj2)
            {
                if (obj1.x == obj2.x && obj1.y == obj2.y)
                    return true;
                return false;
            }

            public static bool operator !=(Coordinates obj1, Coordinates obj2)
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
        public int[,] GameBoard; //THE MAIN GAMEBOARD
        public int valuetoObtain;
        public Queue<int> tilespawnPool;

        //empty gameboard;
        public Board(int r, int c, int input_valuetoObtain, Queue<int> input_pooltoSpawn)
        {
            row = r;
            coloumn = c;
            valuetoObtain = input_valuetoObtain;
            tilespawnPool = input_pooltoSpawn;
        }
        public Board(Board b) //update listings
        {
            row = b.row;
            coloumn = b.coloumn;
            valuetoObtain = b.valuetoObtain;
            tilespawnPool = b.tilespawnPool;
            GameBoard = b.GameBoard;
        }

        //resets Board. fills in with input grid
        public void FillBoard(List<List<int>> input)
        {
            GameBoard = new int[row, coloumn];
            //fillBoard
            for (int yPos = 0; yPos < row; yPos++)
            {
                List<int> input_Row = input[yPos];
                for (int xPos = 0; xPos < coloumn; xPos++)
                {
                    //make coordinate, put value into property, place into board
                    //Coordinates new_c = new Coordinates(xPos, yPos);
                    //Property new_p = new Property(input_Row[xPos]);
                    GameBoard[yPos, xPos] = input_Row[xPos];
                }
            }

        }


        //----debugging methods
        public void DisplayBoard()
        {
            for (int yPos = 0; yPos < row; yPos++)
            {
                for (int xPos = 0; xPos < coloumn; xPos++)
                {
                    string displaytext = GameBoard[yPos, xPos].ToString();
                    Console.Write(displaytext);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        public void DebugBoard()
        {
            Console.WriteLine("in [yPos,xPos] format");
            for (int yPos = 0; yPos < row; yPos++)
            {
                for (int xPos = 0; xPos < coloumn; xPos++)
                {

                    Console.Write("[" + yPos + "," + xPos + "]");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }




        public void spawn()
        {
          //top left > top right > bottom right > bottom left
          //Console.WriteLine("ATTEMPING TO SPAWN: ");
          bool hasSpawned= false;
          int yPos =-1;
          int xPos =-1;
          int valuetoSpawn;
          if (GameBoard[0, 0] == 0) //top left
          {
            //Console.WriteLine("Topleft");
            hasSpawned=true;
            yPos=0;
            xPos=0;
            //Console.Write("[" + yPos + "," + xPos + "]");
          }
          else if (GameBoard[0, coloumn -1] == 0) //top right
          {
            //Console.WriteLine("Topright");            
            hasSpawned=true;
            yPos=0;
            xPos=coloumn -1;
            //Console.Write("[" + yPos + "," + xPos + "]");
          }
          else if (GameBoard[row-1, coloumn-1] == 0) //bottom right
          {
            //Console.WriteLine("Bottomright");
            hasSpawned=true;
            yPos=row-1;
            xPos=coloumn-1;
            //Console.Write("[" + yPos + "," + xPos + "]");
          }
          else if (GameBoard[row-1, 0] == 0) //bottom left
          {
            //Console.WriteLine("bottomleft");
            hasSpawned=true;
            yPos=row-1;
            xPos=0;
            //Console.Write("[" + yPos + "," + xPos + "]");
          }

          if(hasSpawned)
          {            
            //Console.WriteLine("----------");
            //Console.WriteLine("BEFORE");
            //DisplayBoard();
            valuetoSpawn= tilespawnPool.Dequeue();
            tilespawnPool.Enqueue(valuetoSpawn);
            GameBoard[yPos, xPos]= valuetoSpawn;
            //Console.WriteLine("AFTER");
            //DisplayBoard();
            //Console.WriteLine("----------");
          }
          else
          {
            Console.WriteLine("spawnfailed");
          }
        }


        //returns success of move

        public bool moveBoard(Direction nDirection)
        {
            bool hasMoved = false;


            switch (nDirection)
            {

                case Direction.swipeUp:
                    for (int j = 0; j < coloumn; j++)  //coloumn selected
                    {
                        for (int i = 0; i < row; i++)
                        {
                            for (int k = i + 1; k < row; k++)
                            {
                                //[k,j] is the target being currently looked at
                                if (GameBoard[k, j] == 0)
                                {
                                    continue;
                                }
                                else if (GameBoard[k, j] == GameBoard[i, j]) //merge
                                {
                                    hasMoved = true;
                                    GameBoard[i, j] *= 2;
                                    //iScore += GameBoard[i,j];
                                    GameBoard[k, j] = 0;
                                    //bAdd = true;
                                    break;
                                }
                                else
                                {
                                    if (GameBoard[i, j] == 0 && GameBoard[k, j] != 0) //Move to new location
                                    {
                                        hasMoved = true;
                                        GameBoard[i, j] = GameBoard[k, j];
                                        GameBoard[k, j] = 0;
                                        i--;
                                        //bAdd = true;
                                        break;
                                    }
                                    else if (GameBoard[i, j] != 0)
                                    {
                                        break;
                                    }
                                }
                            }
                        }
                    }
                    break;
                case Direction.swipeDown:
                    for (int j = 0; j < coloumn; j++)
                    {
                        for (int i = row-1; i >= 0; i--)
                        {
                            for (int k = i - 1; k >= 0; k--)
                            {
                                if (GameBoard[k, j] == 0)
                                {
                                    continue;
                                }
                                else if (GameBoard[k, j] == GameBoard[i, j])
                                {
                                    hasMoved = true;
                                    GameBoard[i, j] *= 2;
                                    GameBoard[k, j] = 0;
                                    break;
                                }
                                else
                                {
                                    if (GameBoard[i, j] == 0 && GameBoard[k, j] != 0)
                                    {
                                        hasMoved = true;
                                        GameBoard[i, j] = GameBoard[k, j];
                                        GameBoard[k, j] = 0;
                                        i++;
                                        break;
                                    }
                                    else if (GameBoard[i, j] != 0)
                                    {
                                        break;
                                    }
                                }
                            }
                        }
                    }
                    break;
                case Direction.swipeRight:
                    for (int i = 0; i < row; i++)
                    {
                        for (int j = coloumn-1; j >= 0; j--)
                        {
                            for (int k = j - 1; k >= 0; k--)
                            {
                                if (GameBoard[i, k] == 0)
                                {
                                    continue;
                                }
                                else if (GameBoard[i, k] == GameBoard[i, j])
                                {
                                    hasMoved = true;
                                    GameBoard[i, j] *= 2;
                                    GameBoard[i, k] = 0;
                                    break;
                                }
                                else
                                {
                                    if (GameBoard[i, j] == 0 && GameBoard[i, k] != 0)
                                    {
                                        hasMoved = true;
                                        GameBoard[i, j] = GameBoard[i, k];
                                        GameBoard[i, k] = 0;
                                        j++;
                                        break;
                                    }
                                    else if (GameBoard[i, j] != 0)
                                    {
                                        break;
                                    }
                                }
                            }
                        }
                    }
                    break;

                case Direction.swipeLeft: //moves left
                    for (int i = 0; i < row; i++) // moves up
                    {
                        for (int j = 0; j < coloumn; j++)
                        {
                            for (int k = j + 1; k < coloumn; k++)
                            {
                                if (GameBoard[i, k] == 0) // move to next cell
                                {
                                    continue;
                                }
                                else if (GameBoard[i, k] == GameBoard[i, j]) // if same
                                {
                                    hasMoved = true;
                                    GameBoard[i, j] *= 2; //double
                                    GameBoard[i, k] = 0;
                                    break;
                                }
                                else    //not same, not 0
                                {
                                    if (GameBoard[i, j] == 0 && GameBoard[i, k] != 0) //not same
                                    {
                                        hasMoved = true;
                                        GameBoard[i, j] = GameBoard[i, k];
                                        GameBoard[i, k] = 0;
                                        j--;
                                        break;
                                    }
                                    else if (GameBoard[i, j] != 0)
                                    {
                                        break;
                                    }
                                }
                            }
                        }
                    }
                    break;
            }
            if(hasMoved) //spawn tile
            {
              spawn();
            }
            return hasMoved;
        }


    }
}

