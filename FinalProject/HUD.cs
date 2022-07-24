using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    class HUD
    {

        char[] _hpHud = { '▓', '▓', '▓', '▓', '▓', '▓', '▓', '▓', '▓', '▓' };

        int _hp;

        public void HpCaculation(int hp,int maxHp)
        {
            float hudHp = (float)hp * 10 / (float)maxHp;
            _hp = (int)Math.Round(hudHp);

            if (_hp <= 0)
            {
                _hp = 0;
            }
            else if (_hp > 9)
            {
                _hp = 9;
            }
            else
            {
                _hp -= 1;
            }
        }

        public void PrintHud(int hp, int maxHp,int damage,int level)
        {
            
            HpCaculation(hp, maxHp);
            Console.WriteLine();
            Console.WriteLine("      HP           Damage     Level");
            Console.WriteLine("╔════════════╗");
            Console.Write("║ ");
            for (int i = 0; i < _hpHud.Length; i++)
            {
                if (i <= _hp)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("▓");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.Write("▓");
                }
            }
            Console.WriteLine($" ║       {damage}          {level}");
            Console.WriteLine( "╚════════════╝");
            Console.WriteLine($"    {hp}/{maxHp}");
            
        }

        public void PlayerEncounterLine(string name, string enemyname, int damage, int enemyHp)
        {
            Console.WriteLine($"╔════════════╗                         {name} Attacked {enemyname} for {damage} Damage Toad HP: {enemyHp}");
        }


//       HP           Damage     Level 
// ╔════════════╗                         You Attacked Toad for 12 Damage Toad HP:
// ║ ▓▓▓▓▓▓▓▓▓▓ ║       7          1
// ╚════════════╝                         Toad Attacked You For 5 Damage.
//     100/100

        
    }
}
