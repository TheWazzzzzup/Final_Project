using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    class EnemyGen
    {
        
        public Para enemyPara;

        private Options _options;

        private int _damage;

        private string _name;
        private string _enemyAvatar;

        private string[] EnemyName = {"Bat","Crow","Leaf","Ladybug","Scorpion","Toad"};

        public EnemyGen(Maps map, Options option)
        {
            Random rnd = new Random();
            string drawName = EnemyName[rnd.Next(0, EnemyName.Length)];
            _name = drawName;
            _options = option;
            _enemyAvatar = _options._chosenEnemyAvater;
            _damage = (int)(EnemyNameDamage[drawName] * ((map.currentLvl * 0.2f + 1) * _options._chosenDifficulty));
            int hp = _damage * 3;
            if (hp <= 0)
            {
                hp = map.currentLvl * 3;
            }
            enemyPara = new Para(hp, _damage);
        }

        public string GetName()
        {
            return _name;
        }

        public int GetDamage()
        {
            return _damage;
        }

        public string GetEnemyAvatar()
        {
            return _enemyAvatar;
        }

        private Dictionary<string, int> EnemyNameDamage = new Dictionary<string, int>()
        {
            {"Bat",7},
            {"Crow",15},
            {"Leaf",0},
            {"Scorpion",6},
            {"Toad",5},
            {"Ladybug",3}
        };
    }
}
