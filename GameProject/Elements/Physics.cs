using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace GameProject.Elements
{
    abstract class Physics
    {
        public float mass;
        public float speed;
        public Vector2f SpeedVect;



        abstract public void CalculatePos();//calculate position this function takes time from program class


    }
}
