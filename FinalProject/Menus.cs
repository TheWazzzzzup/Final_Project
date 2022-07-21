using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    class Menus
    {
        MenuLog logic;
        Options options = new Options();


        private string[] mainMenu = { "Play", "How To Play", "Options", "About", "Exit", };
        private string[] howTo = { "Play", "Exit" };
        private string[] about = { "Exit" };

        public Menus()
        {
            logic = new MenuLog(mainMenu);
        }




    }
}
