﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace FinalProject
{
    class Maps
    {
        // debug
        int rowcheck;
        int colcheck;


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

        public int currentLvl = 0;

        // Random number of steps will make the Console clear and show mine location for limited time // Date time, time Span
        System.Timers.Timer amit = new System.Timers.Timer(1000);
        private int stepsTaken = 0;
        private int stepsTarget;

        private bool _mineTriggerd = false;
        private bool _lvlClearRec = false;

        //
        ChestLog chest;
        EnemyGen enemy;
        PlayerStats GamePlayer = new PlayerStats("Amit");
        //

        public void LoadMap()
        {
            _mineTriggerd = false;
            enemy = new EnemyGen(this);
            chest = new ChestLog(GamePlayer);
            Random rnd = new Random();
            stepsTarget = rnd.Next(90, 150);
            var map = new string[rnd.Next(10, 30), rnd.Next(30, 110)];
            currentLvl++;
            CreateFrame(map);
            PrintGame(map);
            PlayerMovement(playerY,playerX,map);
        }

        private void LevelCleardLogic(string[,] map)
        {
            if (enemy.enemyPara.IsDead() == true)
            {
                Console.Clear();
                _lvlClearRec = false;
                LoadMap();
            }
            else
            {
                _lvlClearRec = true;
                PrintGame(map);
            }
        }

        private void PlayerCheck(string[,] _map)
        {
            // Player Status Check
            if (GamePlayer.PlayerPara.IsDead())
            {
                Menus.PlayerDied();
            }
            // Mine Check
            if (playerX == mineX && playerY == mineY && _mineTriggerd == false)
            {
                // Play Sound (if you can)
                _mineTriggerd = true;
                GamePlayer.PlayerPara.GetDamage(9);
                _map[mineX, mineY] = "*";
                PrintGame(_map);
            }
            // Chest Check
            else if (playerX == chestX && playerY == chestY && chest.ChestOpend() == false)
            {
                chest.ChestEncounter();
                _map[chestX, chestY] = "s";
                Console.Clear();
                PrintGame(_map);
            }
            // Exit Check
            if (exitPointX < exitPointY)
            {
                if (playerX == exitPointX && playerY == exitPointY - 1)
                {
                    LevelCleardLogic(_map);
                }
            }
            else
            {
                if (playerX == exitPointX - 1 && playerY == exitPointY)
                {
                    LevelCleardLogic(_map);
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
                        if (GamePlayer.PlayerPara.IsDead() == false && enemy.enemyPara.IsDead() ==  false)
                        {
                            // OnCollisonEnter""
                            GamePlayer.PlayerPara.InflictDamage(enemy.enemyPara);
                            GamePlayer.PlayerPara.GetDamage(enemy.enemyPara);
                            Console.Clear();
                            PrintGame(_map);
                        }
                    }
                }
            }
        }

        private void PlayerMovement(int row,int col,string[,] map)
        {
            PlayerCheck(map);
            ConsoleKeyInfo currentPress = Console.ReadKey(true);
            int mapHieght = map.GetLength(0);
            int mapLength = map.GetLength(1);

            //Console.SetCursorPosition(playerX, playerY);
            SetXY(row, col);

            // Right
            if ((currentPress.Key == ConsoleKey.D && row < mapLength - 2) && map[playerX,playerY + 1] != "|")
            {
                row++;
                stepsTaken++;
                Console.SetCursorPosition(row, col);
                SetXY(row, col);
                PlayerMovement(row,col,map);
            }
            // Left
            if ((currentPress.Key == ConsoleKey.A && row > 1) && map[playerX, playerY - 1] != "|")
            {
                row--;
                stepsTaken++;
                Console.SetCursorPosition(row, col);
                SetXY(row, col);
                PlayerMovement(row, col, map);
            }
            // Up
            if ((currentPress.Key == ConsoleKey.W && col > 1) && map[playerX - 1,playerY] != "-" && map[playerX - 1, playerY] != "|")
            {
                col--;
                stepsTaken++;
                Console.SetCursorPosition(row, col);
                SetXY(row, col);
                PlayerMovement(row, col, map); 
            }
            // Down
            if ((currentPress.Key == ConsoleKey.S && col < mapHieght - 2) && map[playerX + 1, playerY] != "-" && map[playerX + 1, playerY] != "|")
            {
                col++;
                stepsTaken++;
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

        private void PrintGame(string[,] map)
        {
            Console.Clear();
            if (enemy.enemyPara.IsDead())
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
            Console.WriteLine($"Current Lvl {currentLvl}, Player HP: {GamePlayer.PlayerPara.GetHp()} Dead = {GamePlayer.PlayerPara.IsDead()}"); // place holder
            Console.WriteLine(chest.ChestOutput());
            Console.WriteLine($"{enemy.GetName()} HP: {enemy.enemyPara.GetHp()} Dead = {enemy.enemyPara.IsDead()}");
            // Cant Load next level before killing enemy
            if (_lvlClearRec == true)
            {
                Menus.ClearRoomPrompt();
            }

            // Debug
            Console.WriteLine();
            Console.WriteLine($"Debug: Mine Loc is {mineX},{mineY}");
            Console.WriteLine($"Debug: PlayerX {playerX} PlayerY {playerY},player damage {GamePlayer.PlayerPara.ShowDamage()} ,Max Hp {GamePlayer.PlayerPara.GetMaxHp()}");
            Console.WriteLine($"Debug: Row {rowcheck} Col {colcheck}");
            Console.WriteLine($"Debug: enemy Damage {enemy.enemyPara.ShowDamage()}");
            Console.WriteLine(Console.GetCursorPosition());

            Menus.GameName();
            // Should be next to Start Postion ** Note this is the last postion where cursor shown (Right on game start)
            Console.SetCursorPosition(playerY,playerX);   
        }

        /// <summary>
        /// Creates frame for map [30 max,110 max]
        /// </summary>
        /// <param name="mapSize"></param>
        private void CreateFrame(string[,] mapSize)
        {            
            //row == y
            int row = mapSize.GetLength(0);
            //debug
            rowcheck = row;

            //col == x
            int col = mapSize.GetLength(1);
            // debug
            colcheck = col;

            // Inner Wall/s Generation
            Random rnd = new Random();
            int roomRowLength = rnd.Next(4, row / 2);
            int roomColLength = rnd.Next(5, col / 2);
            int roomStartX = rnd.Next(2,(col - roomColLength) - 2);
            int roomStartY = rnd.Next(2,(row - roomRowLength) - 2);
            int roomDoor = rnd.Next(1,roomColLength);

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    // Outer Frame
                    if (j == 0 || j == col - 1)
                    {
                        mapSize[i, j] = "|";
                        continue;
                    }
                    else if (i == 0 || i == row - 1)
                    {
                        mapSize[i, j] = "-";
                        continue;
                    }
                    // Inner Room
                    else if ((j == roomStartX || j == roomStartX + roomColLength) && (i >= roomStartY && i <= roomStartY + roomRowLength))
                    {
                        mapSize[i, j] = "|";
                        continue;
                    }
                    else if ((i == roomStartY || i == roomStartY + roomRowLength) && (j >= roomStartX && j <= roomStartX + roomColLength) && j != roomDoor+roomStartX)
                    {
                        mapSize[i, j] = "-";
                        continue;
                    }
                    // Filler
                    else
                    {
                        mapSize[i,j] = " ";
                        continue;
                    }
                }
            }

            EntityGenerator(mapSize,row, col);

            // Frame Undependices(On Frame Scale) 
            mapSize[enterPointX, enterPointY] = "E";
            mapSize[exitPointX, exitPointY] = "X";

            // Frame Undependices(Inside Frame Scale)

            // Need to be "Transperant"
            mapSize[mineX, mineY] = " ";

            mapSize[chestX, chestY] = "8";

            mapSize[enemyX, enemyY] = "N";         
        }

        private void SetXY(int row, int col)
        {
            playerX = col;
            playerY = row;
        }

        private void EntityGenerator(string[,] map,int row,int col)
        {
            // Entery and Exit Start Point , Overrides Current Wall "String"
            Random randomLocX = new Random();
            Random randomLocY = new Random();
            
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

            // Checks that random spawn point is available
            int checker = 0;
            while (checker == 0)
            {
                mineX = randomLocX.Next(1, row - 2);
                mineY = randomLocX.Next(1, col - 2);

                chestX = randomLocX.Next(1, row - 2);
                chestY = randomLocX.Next(1, col - 2);

                if ((map[mineX,mineY] == " ") && (map[chestX,chestY] == " "))
                {
                    checker = 1;
                }
            }
        }
    }
}

// Contatins Map Logic And Map Generator.
// Should Contain Mine and Chest Data. Maybe not? and get them a class?
//

