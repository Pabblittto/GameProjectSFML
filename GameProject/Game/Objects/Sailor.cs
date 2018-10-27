using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace GameProject.Game.Objects
{
    class Sailor:Card // class for making possible members of player's crew
    {
        public string name;
        int Hp;
        int Class;

        public Sailor(string PathPhoto, string AdditionalInfo,string _name, int _hp, int _Class) : base(PathPhoto,AdditionalInfo)
        {
            name = _name;
            Hp = _hp;
            Class = _Class;

            InfoToDisplay = new List<string>() { "Sailor", "", };
                
        }
           
    }
}
