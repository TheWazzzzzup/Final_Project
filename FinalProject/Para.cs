using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    class Para
    {
        private int _hp;
        private int _damage;
        private bool _isDead = false;
        static private int _maxHp;

        public Para (int hp, int damage)
        {
            _hp = hp;
            _damage = damage;
            _maxHp = hp;
        }

        public bool IsDead()
        {
            return _isDead;
        }

        public void Heal (int healAmount)
        {
            _hp += healAmount;
            if (_hp > _maxHp)
            {
                _hp = _maxHp;
            }
        }

        public int GetHp()
        {
            return _hp;
        }

        public void DamageBoost(int boostValue)
        {
            _damage += boostValue;
        }

        public void InflictDamage(Para challanger)
        {
            challanger._hp -= _damage;
        }

        public void GetDamage(Para challanger)
        {
            _hp -= challanger._damage;
            if (_hp < 0)
            {
                _hp = 0;
                _isDead = true;
            }
        }
    }
}
