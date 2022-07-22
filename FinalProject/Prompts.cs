using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    static class Prompts
    {
        public static void GameNamePrompt()
        {
            Console.WriteLine(@"
 _______   ______   ______    __        ______     ______ .___________. __    ______   .__   __. 
|   ____| /      | /  __  \  |  |      /  __  \   /      ||           ||  |  /  __  \  |  \ |  | 
|  |__   |  ,----'|  |  |  | |  |     |  |  |  | |  ,----'`---|  |----`|  | |  |  |  | |   \|  | 
|   __|  |  |     |  |  |  | |  |     |  |  |  | |  |         |  |     |  | |  |  |  | |  . `  | 
|  |____ |  `----.|  `--'  | |  `----.|  `--'  | |  `----.    |  |     |  | |  `--'  | |  |\   | 
|_______| \______| \______/  |_______| \______/   \______|    |__|     |__|  \______/  |__| \__| 
                                               

");
        }

        public static string ClearRoomPrompt()
        {
            string text = @"
 _   ___ _ _  ___  ___                _              _____       _____ _                   _                    _ 
| | / (_| | | |  \/  |               | |            |_   _|     /  __ | |                 | |                  | |
| |/ / _| | | | .  . | ___  _ __  ___| |_ ___ _ __    | | ___   | /  \| | ___  __ _ _ __  | |     _____   _____| |
|    \| | | | | |\/| |/ _ \| '_ \/ __| __/ _ | '__|   | |/ _ \  | |   | |/ _ \/ _` | '__| | |    / _ \ \ / / _ | |
| |\  | | | | | |  | | (_) | | | \__ | ||  __| |      | | (_) | | \__/| |  __| (_| | |    | |___|  __/\ V |  __| |
\_| \_|_|_|_| \_|  |_/\___/|_| |_|___/\__\___|_|      \_/\___/   \____|_|\___|\__,_|_|    \_____/\___| \_/ \___|_|
    ";
            return text;
        }

        public static string StartGamePrompt()
        {
            string text = @"Please Press F11 For Best Experience
 - - - - - - - - - - - - - - - - - -
Press Enter To Start Playing";
            return text;
        }

        public static string BatFluffPrompt()
        {
            string text = @"         (_    ,_,    _)
         / `'--) (--'` \
        /  _,-'\_/'-,_  \
       /.-'     ""     '-.\


 _______   ______   ______    __        ______     ______ .___________. __    ______   .__   __. 
|   ____| /      | /  __  \  |  |      /  __  \   /      ||           ||  |  /  __  \  |  \ |  | 
|  |__   |  ,----'|  |  |  | |  |     |  |  |  | |  ,----'`---|  |----`|  | |  |  |  | |   \|  | 
|   __|  |  |     |  |  |  | |  |     |  |  |  | |  |         |  |     |  | |  |  |  | |  . `  | 
|  |____ |  `----.|  `--'  | |  `----.|  `--'  | |  `----.    |  |     |  | |  `--'  | |  |\   | 
|_______| \______| \______/  |_______| \______/   \______|    |__|     |__|  \______/  |__| \__| 
";
            return text;
        }

        public static void PlayerDiedPrompt()
        {
            Console.Clear();
            Console.WriteLine(@"                                                          ▄▄  
▀████▀     █     ▀███▀                ██                ▀███  
  ▀██     ▄██     ▄█                  ██                  ██  
   ██▄   ▄███▄   ▄█   ▄█▀██▄  ▄██▀████████  ▄▄█▀██   ▄█▀▀███  
    ██▄  █▀ ██▄  █▀  ██   ██  ██   ▀▀ ██   ▄█▀   ██▄██    ██  
    ▀██ █▀  ▀██ █▀    ▄█████  ▀█████▄ ██   ██▀▀▀▀▀▀███    ██  
     ▄██▄    ▄██▄    ██   ██  █▄   ██ ██   ██▄    ▄▀██    ██  
      ██      ██     ▀████▀██▄██████▀ ▀████ ▀█████▀ ▀████▀███▄
                                                              
                                                              
");

        }

        public static string AboutDescription()
        {
            string text = @"Hey whoever dedicated the time to read this,
you need to brace yourself because this about is nothing like marvel's post credit...
this is my final C# project of game Dev 1st year,1st semester
ohh yeah, my == me && me == Amit Mor Yosef.

or like DBD likes it:
- - - - - C# 101 (Dor Ben Dor) - - - - - -
          Amit Yosef Mor Yosef
               24/07/2022
             C# FinalProject
- - - - - - - - - - - - - - - - - - - - - -";
            return text;
        }

        public static string OptionPrompt()
        {
            string text = @" Welcome Young Bat                                         (_    ,_,    _)
                                                           / `'--) (--'` \
                                                          /  _,-'\_/'-,_  \
                                                         /.-'     ""     '-.\
since this is a video game and you are not really a bat
this it the spot you can go through the game options and set them to your liking";
            return text;
        }

        public static string HowToPlayPrompt()
        {
            string text = @"Movement: Use the W,A,S,D to move up ↑ ,left ← ,right → ,down ↓

legend:
E = Map entrance point.
X = Map exit point. (i dare you use it like a crying babay ☻)
| or - = Just try...
8 = Closed chest.
s = Opend chest.";
            return text;
        }
    }
}
