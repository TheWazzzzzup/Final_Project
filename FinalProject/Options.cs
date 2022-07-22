using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    public class Options
    {

        public string _chosenAvater = "☺";
        public string _chosenEnemyAvater = "♠";
        public string _chosenGender = "♂";
        public string _chosenName = "Alejandro";
        
        public int _chosenDifficulty = 1;       

        public string[] _options = {"Character","Character Name", "Difficulty","Enemy","Gender","Exit and Save"};
        public string[] _playerAva = { "☺", "☻", "♫", "♦"};
        public string[] _difficulty = { "Easy", "Medium", "Hard"};
        public string[] _enemyAva = { "♠", "☼", "†", "©" };
        public string[] _gender = { "♂", "♀" };
        public string[] _name = { "Back"};
        
        public Options()
        {

        }

        public void SetPlayerAvatar(string avatar)
        {
            _chosenAvater = avatar;
        }

        public void SetEnemyAvatar(string avatar)
        {
            _chosenEnemyAvater = avatar;
        }

        public void SetDifficulty(int diff)
        {
            _chosenDifficulty = diff;
        }

        public void SetGender(string avatar)
        {
            _chosenGender = avatar;
        }

        public void SetName(string name)
        {
            _chosenName = name;
        }
    
    }

}
