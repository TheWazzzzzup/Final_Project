using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    internal class Maps
    {
        // Player,Enemy,Mine,Chest,EntryPoint,ExitPoint
        private static int playerX;
        private static int playerY;
        
        private static int enemyX = 9;
        private static int enemyY = 9;
        
        private static int mineX;
        private static int mineY;
        
        private static int chestX = 1;
        private static int chestY = 8;

        private static int enterPointX;
        private static int enterPointY;
        
        private static int exitPointX;
        private static int exitPointY;



        static void PlayerCheck()
        {
            if (playerX == mineX && playerY == mineY)
            {
                Console.Clear();
                Console.WriteLine("Mine Engaged");
            }
            else if (playerX == chestX && playerY == chestY)
            {
                Console.Clear();
                Console.WriteLine("Chest Engaged");
            }
            // Enemy check
            var boxCollider = new int[,]
            {
                {enemyX -1,enemyX,enemyX + 1},
                {enemyY -1,enemyY,enemyY + 1}
            };
            for (int i = 0;i < boxCollider.GetLength(1); i++)
            {
                for (int j = 0;j < boxCollider.GetLength(1); j++)
                {
                    if (boxCollider[0, i] == playerX && boxCollider[1,j] == playerY)
                    {
                        Console.Beep();
                    }
                }
            }

        }

        public static void PlayerMovement(int row,int col,string[,] map)
        {
            PlayerCheck();
            ConsoleKeyInfo currentPress = Console.ReadKey(true);
            int mapHieght = map.GetLength(0);
            int mapLength = map.GetLength(1);

            Console.SetCursorPosition(row, col);
            SetXY(row, col);
            // Right
            if (currentPress.Key == ConsoleKey.D && row < mapLength - 2)
            {
                row++;
                Console.SetCursorPosition(row, col);
                SetXY(row, col);
                PlayerMovement(row, col,map);
            }
            // Left
            if (currentPress.Key == ConsoleKey.A && row > 1)
            {
                row--;
                Console.SetCursorPosition(row, col);
                SetXY(row, col);
                PlayerMovement(row, col, map);
            }
            //Up
            if (currentPress.Key == ConsoleKey.W && col > 1)
            {
                col--;
                Console.SetCursorPosition(row, col);
                SetXY(row, col);
                PlayerMovement(row, col, map); 
            }
            //Down
            if (currentPress.Key == ConsoleKey.S && col < mapHieght - 2)
            {
                col++;
                Console.SetCursorPosition(row, col);
                SetXY(row, col);
                PlayerMovement(row, col, map);
            }
            else
            {
                PlayerMovement(row, col, map);
                SetXY(row, col);
            }
        }

        // Set To Become a private methods
        public static void PrintMap(string[,] map)
        {
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    Console.Write(map[i, j]);
                }
                Console.WriteLine();
            }
            Console.SetCursorPosition(1, 1);
        }
        
        /// <summary>
        /// Creates frame for map [40 max,110 max]
        /// </summary>
        /// <param name="mapSize"></param>
        public static void CreateFrame(string[,] mapSize)
        {
            // Note: Row max is 40 Col max is 110, in your screen size i guess...
            
            //row == y
            int row = mapSize.GetLength(0);

            //col == x
            int col = mapSize.GetLength(1);

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    if (j == 0 || j == col - 1)
                    {
                        mapSize[i,j] = "|";
                        continue;
                    }
                    else if (i == 0 || i == row - 1)
                    {
                        mapSize[i, j] = "-";
                        continue;
                    }
                    else
                    {
                        mapSize[i,j] = " ";
                        continue;
                    }
                }
            }
            EntityGenerator(row, col);

            // Frame Undependices(On Frame Scale) 
            mapSize[enterPointX, enterPointY] = "E";
            mapSize[exitPointX, exitPointY] = "X";

            // Frame Undependices(Inside Frame Scale) 
            mapSize[mineX, mineY] = "@";

            mapSize[chestX, chestY] = "#";

            mapSize[enemyX,enemyY] = "N";

        }

        private static void SetXY(int row, int col)
        {
            playerX = col;
            playerY = row;
        }

        private static void EntityGenerator(int row,int col)
        {
            Random randomLocX = new Random();
            Random randomLocY = new Random();
            // Entery and Exit Start Point
            if (randomLocX.Next(0,2) > 0)
            {
                // Left Right
                enterPointX = randomLocY.Next(row - 5, row - 1);
                enterPointY = 0;
                exitPointX = randomLocY.Next(row - (row - 1), row - (row - 5));
                exitPointY = col - 1;
                playerX = enterPointX;
                playerY = enterPointY + 1;
            }
            else
            {
                // Upper Lower
                enterPointY = randomLocX.Next(col - 5, col - 1);
                enterPointX = 0;
                exitPointY = randomLocY.Next(col - (col - 1), col - (col - 5));
                exitPointX = row - 1;
                playerX = enterPointX +1;
                playerY = enterPointY;
                playerY = enterPointY;
            }

            // Mine (Can be anywhere on the map)
            // Check with "@"
            mineX = randomLocX.Next(1, row - 2);
            mineY = randomLocX.Next(1, col - 2);
        }

    }
}

// Contatins Map Logic And Map Generator.
// Should Contain Mine and Chest Data.
//

