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
        public  Para PlayerPara = new Para(100,7);

        private Options _options;

        private string _name;
        private string _avatar;
        private string _gender;

        public PlayerStats(Options options)
        {
            _options = options;
            _name = _options._chosenName;
            _gender = _options._chosenGender;
            _avatar = _options._chosenAvater;
        }

        public string GetName()
        {
            return _name;
        }

        public string GetGender()
        {
            return _gender;
        }

        public string GetAvatar()
        {
            return _avatar;
        }

    }
}
