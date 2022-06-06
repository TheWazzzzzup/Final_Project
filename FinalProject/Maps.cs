using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    internal class Maps
    {
        public static void PlayerMovement(int row,int col,string[,] map)
        {
            ConsoleKeyInfo currentPress = Console.ReadKey(true);
            int mapHieght = map.GetLength(0);
            int mapLength = map.GetLength(1);

            Console.SetCursorPosition(row, col);
            // Right
            if (currentPress.Key == ConsoleKey.D && row < mapLength - 2)
            {
                row++;
                Console.SetCursorPosition(row, col);
                PlayerMovement(row, col,map);
            }
            // Left
            if (currentPress.Key == ConsoleKey.A && row > 1)
            {
                row--;
                Console.SetCursorPosition(row, col);
                PlayerMovement(row, col, map);
            }
            //Up
            if (currentPress.Key == ConsoleKey.W && col > 1)
            {
                col--;
                Console.SetCursorPosition(row, col);
                PlayerMovement(row, col, map); 
            }
            //Down
            if (currentPress.Key == ConsoleKey.S && col < mapHieght - 2)
            {
                col++;
                Console.SetCursorPosition(row, col);
                PlayerMovement(row, col, map);
            }
            else
            {
                PlayerMovement(row, col, map);
            }
        }

        public static void PrintMap(string[,] map)
        {
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    Console.Write(map[i,j]);
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

            int row = mapSize.GetLength(0);
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
        }
    }
}

// Contatins Map Logic And Map Generator.
// Should Contain Mine and Chest Data.
// 
