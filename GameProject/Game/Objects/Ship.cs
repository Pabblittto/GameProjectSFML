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
    class Ship : Drawable // obiect of ship, hsve all properties, 
    {
        public Vector2f PositionOnMap;
        public float DegreeOfShip = 0;
        protected uint TrunkCapacity;// how many cargo ship can have
        protected uint CrewCapacity; // how many crew ship can contain
        protected uint CanoonNumber;// how many canoons ship can contain
        protected RectangleShape shape;
        protected Texture texture;
        protected Texture SideShipRight;
        protected Texture SideShipLeft;
        Sprite tmp;

       

        public Ship(Vector2f SizeOfShip, uint CrewAmount, uint TrunkAmount, uint CanoonAmount,string TexturePath,string TexturePathSide, Vector2f positionOfShip,float Degree)
        {
             tmp = new Sprite(new Texture(TexturePathSide), new IntRect(new Vector2i(0, 0), (Vector2i)SizeOfShip));//
            //SideShipRight = tmp.Texture;
            tmp = new Sprite(new Texture(TexturePathSide),new IntRect(0, (int)SizeOfShip.Y, (int)SizeOfShip.X, -(int)SizeOfShip.Y));
            SideShipLeft =new Texture( tmp.Texture );

            SideShipRight = new Texture(TexturePathSide, new IntRect(new Vector2i(0, 0), (Vector2i)SizeOfShip));
          //  SideShipLeft = new Texture(TexturePathSide, new IntRect(0, (int)SizeOfShip.Y, (int)SizeOfShip.X, -(int)SizeOfShip.Y));
            //TRZEBA ZMIENIC obiekt który jest wyswietlany na spraita !!!!!!!!!!!!!!!!!!!!

            texture = new Texture(TexturePath);


            shape = new RectangleShape(SizeOfShip)
            {
                Texture = texture,
                Origin = new Vector2f(SizeOfShip.X / 2, SizeOfShip.Y / 2),
                Position = PositionOnMap,
                Rotation = Degree,
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
        }

        public void Rotate(float value)
        {
            if(value<0)
            {
                shape.Texture = SideShipLeft;
                Console.WriteLine("zmiana na left");
                if(DegreeOfShip == 0)
                DegreeOfShip = 360;
            }

            if(value>=0)
            {
                Console.WriteLine("Zmiana na right");
            
                if (DegreeOfShip == 360)
                DegreeOfShip = 0;
            }

            DegreeOfShip += value;
        }




        /// <summary>
        /// Ship will move only straight, where its beak facing
        /// </summary>
        public void Move(int value)
        {
            double angle = Math.PI*((double)DegreeOfShip-90)/180.0;
            float Cos = (float)Math.Cos(angle) * value;
            float sin = (float)Math.Sin(angle) * value;
            PositionOnMap += new Vector2f(Cos,sin);
        }






        public void Draw(RenderTarget window, RenderStates states)
        {
            window.Draw(shape);
            window.Draw(tmp);
        }




    }
}
