﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    class Para
    {
        public struct Info
        {
            public string AttackerName;
            public string DefenderName;
            public int AttackerDamage;
            public int DefenderHp;
            public int AttackerMaxHp;
            public int AttackerHp;
            public int DefenderDamage;
        }

        public Info playerAttack;

        private int _hp;
        private int _damage;
        private bool _isDead = false;
        private int _maxHp;

        private string _name;

        public Para (int hp, int damage,string name)
        {
            _maxHp = hp;
            _damage = damage;
            _hp = _maxHp;
            _name = name;
        }

        public int GetMaxHp()
        {
            return _maxHp;
        }
        
        public int ShowDamage()
        {
            return _damage;
        }

        public bool IsDead()
        {
            return _isDead;
        }

        public void Heal (int healAmount)
        {
            _hp += healAmount;
            if (_hp >= _maxHp)
            {
                _hp = _maxHp;
            }
        }

        public int GetHp()
        {
            return _hp;
        }

        public void IncreaseMaxHp(int maxHpBoostVaule)
        {
            _maxHp += maxHpBoostVaule;
        }

        public void DamageBoost(int boostValue)
        {
            _damage += boostValue;
        }

        public void UpdateStruct()
        {
            playerAttack.AttackerName = _name;
            playerAttack.AttackerDamage = _damage;
            playerAttack.AttackerHp = _hp;
            playerAttack.AttackerMaxHp = _maxHp;
        }

        public void InflictDamage(Para challanger)
        {
            challanger._hp -= _damage;
            if (challanger._hp < 0)
            {
                challanger._hp = 0;
                challanger._isDead = true;
            }
            UpdateStruct(challanger);
        }

        public void GetDamage(int damage)
        {
            _hp -= damage;
            if (_hp < 0)
            {
                _hp = 0;
                _isDead = true;
            }
        }

        public void GetDamage(Para challanger)
        {
            _hp -= challanger._damage;
            if (_hp < 0)
            {
                _hp = 0;
                _isDead = true;
                UpdateStruct(challanger);
            }
        }

        public void UpdateStruct(Para challanger)
        {
            playerAttack.AttackerName = _name;
            playerAttack.AttackerDamage = _damage;
            playerAttack.AttackerHp = _hp;
            playerAttack.AttackerMaxHp = _maxHp;
            playerAttack.DefenderHp = challanger._hp;
            playerAttack.DefenderName = challanger._name;
            playerAttack.DefenderDamage = challanger._damage;
        }

    }
}
