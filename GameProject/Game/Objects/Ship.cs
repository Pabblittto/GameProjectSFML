using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using GameProject.Elements;



namespace GameProject.Game.Objects
{
    [Serializable]
    class Ship : Physics, Drawable // obiect of ship, hsve all properties, 
    {
        public Vector2f PositionOnMap;
        public float DegreeOfShip = 0;
        protected uint TrunkCapacity;// how many cargo ship can have
        protected uint CrewCapacity; // how many crew ship can contain
        protected uint CanoonNumber;// how many canoons ship can contain
        public RectangleShape HitBox;
        protected Texture NormalShip;
        protected Texture SideShip;
        public Sprite shape;
        IntRect RightSide;// way to render a texture of rotatated ship
        IntRect LeftSide;

        Boolean changed = false;// i dont have idea what it is for
        double MaxSpeed;
        Vector2f Friction;



        Vector2f VectorOfSail = new Vector2f(1, 0);
        

        public Ship(Vector2f SizeOfShip, uint CrewAmount, uint TrunkAmount, uint CanoonAmount,string TexturePath,string TexturePathSide, Vector2f positionOfShip,float Degree,float _mass,float _MaxSpeed)
        {
            RightSide = new IntRect((int)SizeOfShip.X,0,  -(int)SizeOfShip.X, (int)SizeOfShip.Y);
            LeftSide = new IntRect(new Vector2i(0, 0), (Vector2i)SizeOfShip);

            NormalShip = new Texture(TexturePath);
            SideShip = new Texture(TexturePathSide);

            mass = _mass;
            MaxSpeed = _MaxSpeed;
            
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
            VectorOfSail = Functions.RotateVector(VectorOfSail, value);

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
                double angle = Math.PI * ((double)DegreeOfShip-90 ) / 180.0;
                float Cos = (float)Math.Cos(angle) * value;
                float sin = (float)Math.Sin(angle) * value;
                PositionOnMap += new Vector2f(Cos, sin);
            }

        }


        public float testmax = 0;
        int i = 0;
        /// <summary>
        /// this function is responsible for moving ship due to wind
        /// </summary>
        public override void CalculatePos()// to nie działa dobrze, 
        {

                if (Program.clockmeasure > testmax)             //this works preety well, but need fix with 
                    testmax = Program.clockmeasure;

                //double time = ObjectsBank.DeltaTime;

                // double time = 0.00000012 * 1000;


                float number = (float)Math.Pow(ObjectsBank.DeltaTime, 2) / (mass * 2);
                Vector2f velocity = Wind.VectorOfWind * number * Wind.valueOfWind * 10000;

            if (Functions.DistBetwPoints(new Vector2f(0, 0), SpeedVect) < 2f / 10f * MaxSpeed)
                Friction = -SpeedVect * (float)ObjectsBank.DeltaTime/100000; //static friction
            else
                Friction = mass * (1f / 100000f) * -1 * SpeedVect / 100000f;// dynamic friction
                 // mi *mass*G*20%* -velocity;


            if (Functions.DistBetwPoints(new Vector2f(0, 0), SpeedVect + velocity) < MaxSpeed)
                SpeedVect += velocity + Friction;
            

                //Console.WriteLine( "HHHHHHHHHHAAAAAAAAAAAAMMMMMUUUUULLLLLLLEEEEEEEEECCCCCCCCCCCCCCC");
                //Console.Clear();
                //Console.WriteLine("Vector of wind:" + Wind.VectorOfWind.ToString());
                //Console.WriteLine("velocuty " + velocity.ToString());
                //Console.WriteLine("speed vector of ship:" + SpeedVect.ToString());
               // Console.WriteLine("dlugosc vektora predkosci:" + Functions.DistBetwPoints(new Vector2f(0, 0), SpeedVect));
                //Console.WriteLine("wektor oporu"+ Friction);
                //Console.WriteLine("czas:" + ObjectsBank.DeltaTime);
                //Console.WriteLine(testmax);
                //Console.WriteLine(i);
                //i++;


                this.PositionOnMap += SpeedVect * (float)ObjectsBank.DeltaTime * 2;// to jest potrzebne nie ruszać

            
            
        }




        public void Draw(RenderTarget window, RenderStates states)
        {
            window.Draw(shape);
          //  window.Draw(tmp);
        }




    }
}
