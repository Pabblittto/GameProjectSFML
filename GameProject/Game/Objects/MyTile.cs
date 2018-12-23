using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using SFML;

namespace GameProject.Game.Objects
{
    class MyTile : RectangleShape// this represents one tile 
    { 
        public int type;// this means what tile tepresents- water, land, city etc.
        public float SpeedPunish;// percent of speed taen from ship if one moving on this tile- for land and city it will be 100%


        public MyTile(Vector2f _size,int _type): base(_size)
        {
            type = _type;
        }

        public void SetPunish()
        {
            if (type == 0)
                SpeedPunish = 0;
            else if (type == 1)
                SpeedPunish = 0.5f;
            else
                SpeedPunish = 1;
        }

    }
}
