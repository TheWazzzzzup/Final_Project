using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Runtime.Serialization;

namespace FinalProject
{
    // i guess player class as a whole needs to be save
    // if player IsDead == false user should also saved loaded map and mayber even location
    // need to create few menus regarding that
    [DataContract] 
    class PlayerStats
    {
        public Para PlayerPara = new Para(100,7);

        [DataMember]
        private string _name;

        [DataMember]
        private int _coins = 0;

        public PlayerStats(string name)
        {
            _name = name;
        }

        public string GetName()
        {
            return _name;
        }

        public void IsPlayerDead()
        {
            if (PlayerPara.IsDead() == true)
            {
                Console.WriteLine($"{_name} you lost, HAHAHAHAHAHAHAHA");
            }
        }

        public int CoinBalance()
        {
            return _coins;  
        }

        /// <summary>
        /// Accept a value 5 for coin addition and -5 for coin reduction
        /// </summary>
        /// <param name="newCoinValue"></param>
        public void CoinManager(int newCoinValue)
        {
            _coins += newCoinValue;
        }
    }
}
