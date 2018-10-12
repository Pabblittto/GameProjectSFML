using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameProject.Game.Objects;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary ;

namespace GameProject.Elements
{
    [Serializable]
    class Player// player contains all informations, its like save
    {
        public String name;
        public UsrShip UserShip;
        Map PlayerMap;



        public Player(String _name)
        {
            name = _name;
        }

        // need to make constructor to loading save from file



        public void Save()
        {
            FileStream file = new FileStream("Res/Sav/"+name +"G.sav", FileMode.Create,FileAccess.Write,FileShare.None);
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(file, this);
            file.Close();
        }





    }
}
