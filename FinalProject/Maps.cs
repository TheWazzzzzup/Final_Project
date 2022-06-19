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
        
        private int enemyX = 8;
        private int enemyY = 8;
        
        private int mineX;
        private int mineY;
        
        private int chestX;
        private int chestY;

        private int enterPointX;
        private int enterPointY;
        
        private int exitPointX;
        private int exitPointY;

        private bool _lvlClear = false;
        private bool _playerDead = false;
        private bool _enemyDead = false;

        //
        PlayerStats Wazzzzzup = new PlayerStats("Amit");
        EnemyGen enemy = new EnemyGen();
        //
        
        public void LoadGame(Random rnd,Random rnd1)
        {

        }

        public int GetEntryX()
        {
            return playerX;
        }
       
        public int GetEntryY()
        {
            return playerY;
        }

        private void PlayerCheck(string[,] _map)
        {
            
            // Mine Check
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
            // Exit Check
            if (exitPointX < exitPointY)
            {
                if (playerX == exitPointX && playerY == exitPointY - 1)
                {
                    _lvlClear = true;
                    Console.Clear();
                    Console.WriteLine($"Exit Engaged LeftRight");
                }
            }
            else
            {
                if (playerX == exitPointX - 1 && playerY == exitPointY)
                {
                    _lvlClear = true;
                    Console.Clear();
                    Console.WriteLine("Exit Enaged UpDown");
                }
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
                        if (_playerDead == false && _enemyDead ==  false)
                        {
                            // OnCollisonEnter""
                            Wazzzzzup.PlayerPara.InflictDamage(enemy.enemyPara);
                            Wazzzzzup.PlayerPara.GetDamage(enemy.enemyPara);
                            _playerDead = Wazzzzzup.PlayerPara.IsDead();
                            _enemyDead = enemy.enemyPara.IsDead();
                            Console.Clear();
                            PrintGame(_map);
                        }
                    }
                }
            }
        }

        public void PlayerMovement(int row,int col,string[,] map)
        {
            PlayerCheck(map);
            ConsoleKeyInfo currentPress = Console.ReadKey(true);
            int mapHieght = map.GetLength(0);
            int mapLength = map.GetLength(1);

            //Console.SetCursorPosition(playerX, playerY);
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
        public void PrintGame(string[,] map)
        {
            if (_enemyDead)
            {
                map[enemyX, enemyY] = " ";
            }
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    Console.Write(map[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine($"Player HP: {Wazzzzzup.PlayerPara.GetHp()} Dead = {_playerDead}");
            Console.WriteLine($"{enemy.GetName()} HP: {enemy.enemyPara.GetHp()} Dead = {enemy.enemyPara.IsDead()}");
            // Debug
            Console.WriteLine($"Debug: PlayerX {playerX} PlayerY{playerY}");
            Console.WriteLine($"Debug: ExitX {exitPointX} ExitY {exitPointY}");
            Console.WriteLine(Console.GetCursorPosition());

            // Should be next to Start Postion ** Note this is the last postion where cursor shown (Right on game start)
            Console.SetCursorPosition(playerY,playerX);   
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

            mapSize[enemyX, enemyY] = "N";         
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
            }

            // Mine (Can be anywhere on the map)
            // Check with "@"
            mineX = randomLocX.Next(1, row - 2);
            mineY = randomLocX.Next(1, col - 2);

            chestX = randomLocX.Next(1, row - 2);
            chestY = randomLocX.Next(1, col - 2);
        }
    }
}

// Contatins Map Logic And Map Generator.
// Should Contain Mine and Chest Data.
//

