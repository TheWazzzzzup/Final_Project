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

        public void PrintHud(Para player, int level, bool showLog)
        {
            HpCaculation(player.playerAttack.AttackerHp, player.playerAttack.AttackerMaxHp);
            Console.WriteLine();
            Console.WriteLine("      HP           Damage     Level");
            if (showLog)
            {
                PlayerEncounterLine(player);
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
                Console.WriteLine($" ║       {player.playerAttack.AttackerDamage}          {level}");
                EnemyEncounterLine(player);
                Console.WriteLine($"    {player.playerAttack.AttackerHp}/{player.playerAttack.AttackerMaxHp}");
            }
            else
            {
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
            Console.WriteLine($" ║       {player.playerAttack.AttackerDamage}          {level}");
            Console.WriteLine("╚════════════╝");
            Console.WriteLine($"    {player.playerAttack.AttackerHp}/{player.playerAttack.AttackerMaxHp}");
            }
        }

        public void PlayerEncounterLine(Para player)
        {
            Console.WriteLine($"╔════════════╗                         You " +
                $"Attacked {player.playerAttack.DefenderName} for {player.playerAttack.AttackerDamage} " +
                $"Damage, {player.playerAttack.DefenderName} HP: {player.playerAttack.DefenderHp}");
        }

        public void EnemyEncounterLine(Para player)
        {
            Console.WriteLine($"╚════════════╝                         {player.playerAttack.DefenderName} Attacked You For {player.playerAttack.DefenderDamage} Damage.");
        }


        //       HP           Damage     Level 
        // ╔════════════╗                         You Attacked Toad for 12 Damage Toad HP:
        // ║ ▓▓▓▓▓▓▓▓▓▓ ║       7          1
        // ╚════════════╝                         Toad Attacked You For 5 Damage.
        //     100/100


    }
}
