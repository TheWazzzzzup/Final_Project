﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    class Maps
    {
        // Player,Enemy,Mine,Chest,EntryPoint,ExitPoint
        private int playerX;
        private int playerY;
        
        private int enemyX = 9;
        private int enemyY = 9;
        
        private int mineX;
        private int mineY;
        
        private int chestX = 1;
        private int chestY = 8;

        private int enterPointX;
        private int enterPointY;
        
        private int exitPointX;
        private int exitPointY;

        //
        PlayerStats Wazzzzzup = new PlayerStats("Amit");

        //
        
        private void PlayerCheck()
        {
            // Mine Chechk
            if (playerX == mineX && playerY == mineY)
            {
                Console.Clear();
                Console.WriteLine("Mine Engaged");
            }
            // Chest Check
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
            for (int i = 0; i < boxCollider.GetLength(1); i++)
            {
                for (int j = 0; j < boxCollider.GetLength(1); j++)
                {
                    if (boxCollider[0, i] == playerX && boxCollider[1, j] == playerY)
                    {
                    
                    }
                }
            }
        }

        public void PlayerMovement(int row,int col,string[,] map)
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
        public void PrintMap(string[,] map)
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
        public void CreateFrame(string[,] mapSize)
        {            
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
            // Small Map: Add Small Map Logic
            if (row < 20 && col < 60)
            {

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

        private void SetXY(int row, int col)
        {
            playerX = col;
            playerY = row;
        }

        private void EntityGenerator(int row,int col)
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

