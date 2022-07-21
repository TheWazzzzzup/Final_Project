using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    class Options
    {
        private enum _player
        {
            WhiteSmile, // ☺
            BlackSmile, // ☻
            Note, // ♫
            Dimoand, // ♦
        };
        private enum _enemy
        {
            Spade, // ♠
            Sun, // ☼
            Jesus, // †
            Copyright, // ©
        };
        private enum _enemyColor
        {
            Red,
            darkGreen,
            Magenta
        }
        private enum _gender
        {
            Male,
            Female
        };
        private enum _difficulty
        {
            Noraml,
            Meduim,
            Hard,
        }

        private string _playerS;
        private string _enemyS;
        private string _enemyColorS;
        private string _genderS;


    }
}
