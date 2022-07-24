using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    class Menus
    {
        Maps _map;
        MenuLog _main;
        MenuLog _howTo;
        MenuLog _about;
        MenuLog _options;
        MenuLog _avatarLog;
        MenuLog _difficultyLog;
        MenuLog _enemyAvaLog;
        MenuLog _genderLog;
        MenuLog _nameLog;

        public Options options = new Options();

        private string[] _mainMenu = { "Play", "How To Play", "Options", "About", "Exit", };
        private string[] _howToArr = { "Play", "Exit" };
        private string[] _aboutArr = { "Back To Menu" };


        public Menus()
        {
            _map = new Maps(options);
            _main = new MenuLog(_mainMenu);
            _howTo = new MenuLog(_howToArr);
            _about = new MenuLog(_aboutArr);
            _options = new MenuLog(options._options);
            _avatarLog = new MenuLog(options._playerAva);
            _difficultyLog = new MenuLog(options._difficulty);
            _enemyAvaLog = new MenuLog(options._enemyAva);
            _genderLog = new MenuLog(options._gender);
            _nameLog = new MenuLog(options._name);
        }

        public void MainMenu()
        {
            int currentIndex = _main.WaterMarkRunMenu(Prompts.BatFluffPrompt());
            switch (currentIndex)
            {
                case 0:
                    _map.FirstLoad();
                    _map.LoadMap();
                    break;
                case 1:
                    HowToPlay();
                    break;
                case 2:
                    Options();
                    break;
                case 3:
                    About();
                    break;
                case 4:
                    //Exit 
                    break;
            }
        }
        
        private void HowToPlay()
        {
            int currentIndex = _howTo.WaterMarkRunMenu(Prompts.HowToPlayPrompt());
            switch (currentIndex)
            {
                case 0:
                    _map.FirstLoad();
                    _map.LoadMap();
                    break;
                case 1:
                    MainMenu();
                    break;

            }
        }

        private void About()
        {
            int currentIndex = _about.WaterMarkRunMenu(Prompts.AboutDescription());
            switch (currentIndex)
            {
                case 0:
                    MainMenu();
                    break;
            }
        }

        private void Options()
        {
            int currentIndex = _options.WaterMarkRunMenu(Prompts.OptionPrompt());
            switch (currentIndex)
            {
                case 0:
                    PlayerAvatar();
                    break;
                case 1:
                    PlayerName();
                    break;
                case 2:
                    Difficulty();
                    break;
                case 3:
                    EnemyAvatar();
                    break;
                case 4:
                    Gender();
                    break;
                case 5:
                    MainMenu();
                    break;

            }
        }

        private void PlayerAvatar()
        {
            int currentIndex = _avatarLog.RunMenu();
            switch (currentIndex)
            {
                case 0:
                    options.SetPlayerAvatar(options._playerAva[0]);
                    Options();
                    break;
                case 1:
                    options.SetPlayerAvatar(options._playerAva[1]);
                    Options();
                    break;
                case 2:
                    options.SetPlayerAvatar(options._playerAva[2]);
                    Options();
                    break;
                case 3:
                    options.SetPlayerAvatar(options._playerAva[3]);
                    Options();
                    break;
            }
        }

        private void EnemyAvatar()
        {
            int currentIndex = _enemyAvaLog.RunMenu();
            switch (currentIndex)
            {
                case 0:
                    options.SetEnemyAvatar(options._enemyAva[0]);
                    Options();
                    break;
                case 1:
                    options.SetEnemyAvatar(options._enemyAva[1]);
                    Options();
                    break;
                case 2:
                    options.SetEnemyAvatar(options._enemyAva[2]);
                    Options();
                    break;
                case 3:
                    options.SetEnemyAvatar(options._enemyAva[3]);
                    Options();
                    break;
            }
        }

        private void Difficulty()
        {
            int currentIndex = _difficultyLog.RunMenu();
            switch (currentIndex)
            {
                case 0:
                    options.SetDifficulty(1);
                    Options();
                    break;
                case 1:
                    options.SetDifficulty(2);
                    Options();
                    break;
                case 2:
                    options.SetDifficulty(3);
                    Options();
                    break;

            }
        }

        private void Gender()
        {
            int currentIndex = _genderLog.RunMenu();
            switch (currentIndex)
            {
                case 0:
                    options.SetGender(options._gender[0]);
                    Options();
                    break;
                case 1:
                    options.SetGender(options._gender[1]);
                    Options();
                    break;
            }
        }

        private void PlayerName()
        {
            Console.Clear();
            Console.WriteLine("Please choose your player name");
            Console.WriteLine();
            string name = Console.ReadLine();
            options.SetName(name);
            Options();
        }
    }
}
