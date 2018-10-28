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
    [Serializable]
    class Ship : Drawable // obiect of ship, hsve all properties, 
    {
        public Vector2f PositionOnMap;
        public float DegreeOfShip = 0;
        protected uint TrunkCapacity;// how many cargo ship can have
        protected uint CrewCapacity; // how many crew ship can contain
        protected uint CanoonNumber;// how many canoons ship can contain
        protected RectangleShape HitBox;
        protected Texture NormalShip;
        protected Texture SideShip;
        Sprite shape;
        IntRect RightSide;// way to render a texture of rotatated ship
        IntRect LeftSide;

        Boolean changed = false;
       

        public Ship(Vector2f SizeOfShip, uint CrewAmount, uint TrunkAmount, uint CanoonAmount,string TexturePath,string TexturePathSide, Vector2f positionOfShip,float Degree)
        {
            RightSide = new IntRect((int)SizeOfShip.X,0,  -(int)SizeOfShip.X, (int)SizeOfShip.Y);
            LeftSide = new IntRect(new Vector2i(0, 0), (Vector2i)SizeOfShip);

            NormalShip = new Texture(TexturePath);
            SideShip = new Texture(TexturePathSide);
            
            shape = new Sprite()
            {
                Texture = NormalShip,
                Origin = new Vector2f(SizeOfShip.X / 2, SizeOfShip.Y / 2),
                Position = PositionOnMap,
                Rotation = Degree,
            };

            HitBox = new RectangleShape(SizeOfShip)
            {
                Origin = shape.Origin,
                Position = shape.Position,
                Rotation=shape.Rotation
            };
            PositionOnMap = positionOfShip;
            DegreeOfShip = Degree;



        }


        public void UpdateView(SFML.Graphics.View view)
        {
            UpdateShip();
            view.Rotation = DegreeOfShip;
            view.Center = PositionOnMap;
        }

        public void UpdateShip()
        { 
            shape.Position = PositionOnMap;
            shape.Rotation = DegreeOfShip;

            HitBox.Rotation = shape.Rotation;
            HitBox.Position = shape.Position;
        }

        public void Rotate(float value)
        {
            if(value<0)
            {
                shape.Texture = SideShip;
                if(DegreeOfShip == 0)
                DegreeOfShip = 360;
            }

            if(value>=0)
            {
                if (DegreeOfShip == 360)
                DegreeOfShip = 0;
            }
            DegreeOfShip += value;

                if (value != 0)
                {
                    shape.Texture = SideShip;

                    if (value > 0)
                        shape.TextureRect = RightSide;

                    if (value < 0)
                        shape.TextureRect = LeftSide;
                }
                else// value==0
                {
                    shape.TextureRect = LeftSide;
                    shape.Texture = NormalShip;
                }
        }




        /// <summary>
        /// Ship will move only straight, where its beak facing
        /// </summary>
        public void Move(float value)
        {
            if (value != 0)
            {
                double angle = Math.PI * ((double)DegreeOfShip - 90) / 180.0;
                float Cos = (float)Math.Cos(angle) * value;
                float sin = (float)Math.Sin(angle) * value;
                PositionOnMap += new Vector2f(Cos, sin);
            }

        }






        public void Draw(RenderTarget window, RenderStates states)
        {
            window.Draw(shape);
          //  window.Draw(tmp);
        }




    }
}
