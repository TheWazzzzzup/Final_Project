using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    internal class ChestLog
    {
        PlayerStats _player;

        private bool _opend;

        // Value of chest content, and buff type
        private int _value;
        private string _buffType;

        public ChestLog(PlayerStats player)
        {
            _player = player;
            _opend = false;
        }
        
        public void ChestEncounter()
        {
            if (!_opend)
            {
                Random rnd = new Random();

                int reward = rnd.Next(0,3);
                switch (reward)
                {
                    case 0:
                        _buffType = "health";
                        _value = rnd.Next(5, 25);
                        _player.PlayerPara.Heal(_value);
                        break;
                    case 1:
                        _buffType = "damage";
                        _value = rnd.Next(2, 8);
                        _player.PlayerPara.DamageBoost(_value);
                        // need prompt
                        break;
                    case 2:
                        _buffType = "max HP";
                        _value = rnd.Next(5, 15);
                        _player.PlayerPara.IncreaseMaxHp(_value);
                        // need prompt
                        break;
                }
                _opend = true;
            }
            else { }
        }

        public bool ChestOpend()
        {
            return _opend;
        }

        public string ChestOutput()
        {
            if (_opend)
            {
                return $"You gain a {_value} points increase into your {_buffType}";
            }
            else
            {
                return "You faild to interact with a chest";
            }
        }
    }
}
