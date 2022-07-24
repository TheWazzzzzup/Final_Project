using System;
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

        private int lastIX;
        private int lastJY;

        private int stepsTaken;

        public int currentLvl = 0;

        private bool _mineTriggerd = false;
        private bool _lvlClearRec = false;
        private bool _battleInitiate = false;

        //
        ChestLog _chest;
        EnemyGen _enemy;
        PlayerStats _currentPlayer ;
        Options _options;
        HUD _hud = new HUD();
        //

        public Maps(Options options)
        {
            _options = options;
        }

        public void FirstLoad()
        {
            _currentPlayer = new PlayerStats(_options);
        }

        public void LoadMap()
        {
            Console.Clear();
            // Resets and count
            {
                currentLvl++;
                _mineTriggerd = false;
                _battleInitiate = false;
                lastIX = 500;
                lastJY = 500;
            }
            // Generate
            {
                _enemy = new EnemyGen(this, _options);
                _chest = new ChestLog(_currentPlayer);
                Random rnd = new Random();
                var map = new string[rnd.Next(10, 30), rnd.Next(30, 110)];
                CreateFrame(map);
                PrintGame(map);
                PlayerMovement(playerY, playerX, map);
            }
  
        }

        private void LevelCleardLogic(string[,] map)
        {
            if (_enemy.enemyPara.IsDead() == true)
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
            if (_currentPlayer.PlayerPara.IsDead())
            {
                Prompts.PlayerDiedPrompt();
            }
            // Mine Check
            if (playerX == mineX && playerY == mineY && _mineTriggerd == false)
            {
                // Play Sound (if you can)
                _mineTriggerd = true;
                _currentPlayer.PlayerPara.GetDamage(9);
                _map[mineX, mineY] = "*";
                PrintGame(_map);
            }
            // Chest Check
            else if (playerX == chestX && playerY == chestY && _chest.ChestOpend() == false)
            {
                _chest.ChestEncounter();
                _map[chestX, chestY] = "s";
                Console.SetCursorPosition(0, 0);
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
                        if (_currentPlayer.PlayerPara.IsDead() == false && _enemy.enemyPara.IsDead() ==  false)
                        {
                            _battleInitiate = true;
                            _currentPlayer.PlayerPara.InflictDamage(_enemy.enemyPara);
                            _currentPlayer.PlayerPara.GetDamage(_enemy.enemyPara);
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
            PrintGame(map);
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
            Console.SetCursorPosition(0, 0);
            Console.CursorVisible = false;
            if ((lastIX < map.GetLength(0) || lastJY < map.GetLength(1)) && map[lastIX, lastJY] == _currentPlayer.GetAvatar())
            {
                map[lastIX, lastJY] = " ";
            }
            if (_enemy.enemyPara.IsDead())
            {
                map[enemyX, enemyY] = " ";
            }
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    if (j == playerY && i == playerX && map[i,j] == " ")
                    {
                        map[i, j] = _currentPlayer.GetAvatar();
                        lastIX = i;
                        lastJY = j;
                    }
                    else if (map[i, j] == _enemy.GetEnemyAvatar())
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(map[i, j]);
                        Console.ForegroundColor = ConsoleColor.White;
                        continue;
                    } 
                    switch (map[i, j])
                    {
                        case "8":
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write(map[i, j]);
                            Console.ForegroundColor = ConsoleColor.White;
                            break;
                        case "s":
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.Write(map[i, j]);
                            Console.ForegroundColor = ConsoleColor.White;
                            break;
                        case "*":
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write(map[i, j]);
                            Console.ForegroundColor = ConsoleColor.White;
                            break;
                        case "X":
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write(map[i, j]);
                            Console.ForegroundColor = ConsoleColor.White;
                            break;
                        case "E":
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write(map[i, j]);
                            Console.ForegroundColor = ConsoleColor.White;
                            break;
                        default:
                            Console.Write(map[i, j]);
                            break;
                    }
                }
                Console.WriteLine();
            }
            //_hud.PrintHud(_currentPlayer.PlayerPara.GetHp(), _currentPlayer.PlayerPara.GetMaxHp(),_currentPlayer.PlayerPara.ShowDamage(),currentLvl);
            _currentPlayer.PlayerPara.UpdateStruct(_enemy.enemyPara);
            _hud.PrintHud(_currentPlayer.PlayerPara,currentLvl,_battleInitiate);
            if (_lvlClearRec == true)
            {
                Console.WriteLine(Prompts.ClearRoomPrompt());
            }

            Prompts.GameNamePrompt();

            // Debug
            Console.WriteLine();
            Console.WriteLine($"Debug: Mine Loc is {mineX},{mineY}");
            Console.WriteLine($"Debug: PlayerX {playerX} PlayerY {playerY},player damage {_currentPlayer.PlayerPara.ShowDamage()} ,Max Hp {_currentPlayer.PlayerPara.GetMaxHp()}");
            Console.WriteLine($"Debug: Row {rowcheck} Col {colcheck}");
            Console.WriteLine($"Debug: enemy Damage {_enemy.enemyPara.ShowDamage()}");
            Console.WriteLine($"Debug: player avatar {_options._chosenAvater} name {_options._chosenName} gender {_options._chosenGender}");
            Console.WriteLine(Console.GetCursorPosition());
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

            mapSize[enemyX, enemyY] = _enemy.GetEnemyAvatar();         
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

