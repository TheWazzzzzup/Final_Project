using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    static class Menus
    {
        public static void GameName()
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

        public static void KillPrompt()
        {
            Console.WriteLine(@"

 _   ___ _ _  ___  ___                _              _____       _____ _                   _                    _ 
| | / (_| | | |  \/  |               | |            |_   _|     /  __ | |                 | |                  | |
| |/ / _| | | | .  . | ___  _ __  ___| |_ ___ _ __    | | ___   | /  \| | ___  __ _ _ __  | |     _____   _____| |
|    \| | | | | |\/| |/ _ \| '_ \/ __| __/ _ | '__|   | |/ _ \  | |   | |/ _ \/ _` | '__| | |    / _ \ \ / / _ | |
| |\  | | | | | |  | | (_) | | | \__ | ||  __| |      | | (_) | | \__/| |  __| (_| | |    | |___|  __/\ V |  __| |
\_| \_|_|_|_| \_|  |_/\___/|_| |_|___/\__\___|_|      \_/\___/   \____|_|\___|\__,_|_|    \_____/\___| \_/ \___|_|
                                                                                                                  
                                                                                                                  
");
        }

        public static void StartGamePrompt()
        {
            Console.WriteLine("Please Press F11 For Best Experience");
            Console.WriteLine(" - - - - - - - - - - - - - - - - - -");
            Console.WriteLine("Press Enter To Start Playing");
            Console.ReadKey();
            Fluff();
        }

        public static void Fluff()
        {
            Console.Clear();
            Console.WriteLine("      (_    ,_,    _)");
            Console.WriteLine(@"      / `'--) (--'` \");
            Console.WriteLine(@"     /  _,-'\_/'-,_  \");
            Console.Write(@"    /.-'     ""     '-.\");
            Console.ReadKey();
            GameName();
            Console.ReadKey();
        }
    }
}
