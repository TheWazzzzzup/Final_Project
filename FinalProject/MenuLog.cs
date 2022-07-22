using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    internal class MenuLog
    {
        private int _selected;
        private string[] _givenOptions;
        private string _permanentText;

        public MenuLog(string[] options)
        {
            _givenOptions = options;
            _selected = 0;
        }

        public int WaterMarkRunMenu(string permenentText)
        {
            ConsoleKey keyPressed;
            do
            {
                Console.Clear();
                OptionsWaterMark(permenentText);
                ConsoleKeyInfo keyReg = Console.ReadKey(true);
                keyPressed = keyReg.Key;

                if (keyPressed == ConsoleKey.UpArrow)
                {
                    _selected--;
                    if (_selected < 0)
                    {
                        _selected = _givenOptions.Length - 1;
                    }

                }
                else if (keyPressed == ConsoleKey.DownArrow)
                {
                    _selected++;
                    if (_selected > _givenOptions.Length - 1)
                    {
                        _selected = 0;
                    }
                }

            } while (keyPressed != ConsoleKey.Enter);

            return _selected;
        }

        private void OptionsWaterMark(string permenentText)
        {
            Console.WriteLine();
            Console.WriteLine(permenentText);
            Console.WriteLine();
            for (int i = 0; i < _givenOptions.Length; i++)
            {
                if (_selected == i)
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"> {_givenOptions[i]} ");
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"  { _givenOptions[i]} ");
                }
                Console.ResetColor();
                Console.WriteLine();
            }
        }

        private void Options()
        {
            for (int i = 0; i < _givenOptions.Length; i++)
            {
                if (_selected == i)
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"> {_givenOptions[i]} ");
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"  { _givenOptions[i]} ");
                }
                Console.ResetColor();
                Console.WriteLine();
            }
        }

        public int RunMenu()
        {
            ConsoleKey keyPressed;
            do
            {
                Console.Clear();
                Options();
                ConsoleKeyInfo keyReg = Console.ReadKey(true);
                keyPressed = keyReg.Key;

                if (keyPressed == ConsoleKey.UpArrow)
                {
                    _selected --;
                    if (_selected < 0)
                    {
                        _selected = _givenOptions.Length - 1;
                    }

                }
                else if (keyPressed == ConsoleKey.DownArrow)
                {
                    _selected ++;
                    if(_selected > _givenOptions.Length - 1)
                    {
                        _selected = 0;
                    }
                }

            } while (keyPressed != ConsoleKey.Enter);

            return _selected;
        }

    }
}
