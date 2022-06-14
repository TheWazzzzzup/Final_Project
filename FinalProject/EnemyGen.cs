using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    class EnemyGen
    {
        private int _damage;
        private string _name;

        private string[] EnemyName = {"Bat","Crow","Leaf","Ladybug","Scorpion","Toad"};

        private Dictionary<string, int> EnemyNameDamage = new Dictionary<string, int>()
        {
            {"Bat",7},
            {"Crow",15},
            {"Leaf",0},
            {"Scorpion",6},
            {"Toad",5},
            {"Ladybug",3}
        };

        public EnemyGen()
        {
            Random rnd = new Random();
            string drawName = EnemyName[rnd.Next(0,EnemyName.Length)];
            _name = drawName;
            _damage = EnemyNameDamage[drawName];
        }
        // Name has to be Bat related

        public string GetName()
        {
            return _name;
        }

        public int GetDamage()
        {
            return _damage;
        }

    }
}
