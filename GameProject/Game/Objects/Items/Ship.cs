using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using GameProject.Elements;



namespace GameProject.Game.Objects.Items
{
    [Serializable]
    class Ship : Physics, Drawable // obiect of ship, hsve all properties, 
    {
        int SailAmount = 1;//default number of sails
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

        Boolean Turning = false;// if ship is turning, change texture;
        double MaxSpeed;
        Vector2f Friction;

        


       public  Vector2f VectorOfSail = new Vector2f(1, 0);
        

        public Ship(Vector2f SizeOfShip, uint CrewAmount, uint TrunkAmount, uint CanoonAmount,string TexturePath,string TexturePathSide, Vector2f positionOfShip,float Degree,float _mass,float _MaxSpeed,int AmountFoSails)
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
            VectorOfSail = Functions.RotateVector(VectorOfSail, DegreeOfShip);

            DegreeOfShip += 90;// this is needed because 
            SailAmount = AmountFoSails;
            
        }


        public void UpdateView(SFML.Graphics.View view)
        {
            UpdateShip();
            view.Rotation = DegreeOfShip;
            view.Center = PositionOnMap;
        }

        public void UpdateShip()
        {
            speed = Functions.DistBetwPoints(new Vector2f(0, 0), SpeedVect);
            shape.Position = PositionOnMap;
            shape.Rotation = DegreeOfShip;

            HitBox.Rotation = shape.Rotation;
            HitBox.Position = shape.Position;
        }

        public void Rotate(float value)
        {
            if(value<0)
            {
                //shape.Texture = SideShip;
                if(DegreeOfShip == 0)// to można ewentualnie zmidyfikować do >0.0001 większe do 0.1 coś takiego i to na dole podobnie
                DegreeOfShip = 360;
            }

            if(value>=0)
            {
                if (DegreeOfShip == 360)
                DegreeOfShip = 0;
            }

            DegreeOfShip += value;
            VectorOfSail = Functions.RotateVector(VectorOfSail, value);
            SpeedVect = Functions.RotateVector(SpeedVect, value);

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
        /// the origin of the rectangles need to be set on left upper corner, as it is ad default
        /// </summary>
        public static float CheckColision(RectangleShape rect1, MyTile rect2)
        {
            // Vector2f CenterReact1 = rect1.Position + new Vector2f(rect1.Size.X / 2, rect1.Size.Y / 2);
            // Vector2f CenterReact2 = rect2.Position + new Vector2f(rect2.Size.X / 2, rect2.Size.Y / 2);
            if (rect1.GetGlobalBounds().Intersects(rect2.GetGlobalBounds()) == true) // this need to be simpliied
                return rect2.SpeedPunish;
            else
                return 0;
        }

        /// <summary>
        /// Ship will move only straight, where its prow facing
        /// </summary>
        public void Move(float value)
        {
            //if (value != 0)
            //{
            //    double angle = Math.PI * ((double)DegreeOfShip ) / 180.0;// to musi zostać wyjebane
            //    float Cos = (float)Math.Cos(angle) * value;
            //    float sin = (float)Math.Sin(angle) * value;
            //    PositionOnMap += new Vector2f(Cos, sin);
            //}

        }


        public float testmax = 0;
        int i = 0;
        /// <summary>
        /// this function is responsible for moving ship due to wind
        /// </summary>
        public override void CalculatePos()// to nie działa dobrze, 
        {

            if(Keyboard.IsKeyPressed(Keyboard.Key.D)&&Turning==true)
            {
                shape.TextureRect = RightSide;
                Rotate(0.3f * speed / (float)MaxSpeed);

            }
            else if(Keyboard.IsKeyPressed(Keyboard.Key.A) && Turning == true)
            {
                shape.TextureRect = LeftSide;
                Rotate(-0.3f * speed / (float)MaxSpeed);
            }
            else
            {
                Turning = false;
                shape.Texture = NormalShip;
            }



            float SailAndWind;
            float AngleBetween = AngleBetweenVectors(this.VectorOfSail, Wind.VectorOfWind);
            if (AngleBetween <= 90 && AngleBetween >= 0)// its ok, wind blows into sail
                SailAndWind =1- AngleBetween / 90;
            else
                SailAndWind = 0;


            float value = (float)Math.Pow(ObjectsBank.timeStep, 2) / (mass * 2) * SailAndWind*SailAmount;


            float ApparentWind;
            if (Wind.valueOfWind != 0 )
                ApparentWind = Wind.valueOfWind * SailAndWind - speed;
            else
                ApparentWind = 0;


            Vector2f velocity = this.VectorOfSail* value * ApparentWind * 10000;



            //Friction sector//////////////////////
            if (Functions.DistBetwPoints(new Vector2f(0, 0), SpeedVect) < 1f / 10f * MaxSpeed)
                Friction = -SpeedVect * (float)ObjectsBank.timeStep/5 ; //static friction
            else
                Friction = mass * -1 * SpeedVect / 200000f;// dynamic friction
                                                          

            

            SpeedVect = SpeedVect - SpeedVect * ObjectsBank.PunishtoSpeed;//colision fragment



            if (Functions.DistBetwPoints(new Vector2f(0, 0), SpeedVect + velocity) < MaxSpeed)
                SpeedVect += velocity + Friction;


                this.PositionOnMap += SpeedVect * (float)ObjectsBank.timeStep*2 ;// to jest potrzebne nie ruszać

        }

        float AngleBetweenVectors(Vector2f Vect1,Vector2f Vect2)
        {
            float LVect1 = 1;
            float LVect2 = 1;// their lenght is always = 1
            float value = (Vect1.X * Vect2.X + Vect1.Y * Vect2.Y) / (LVect1 * LVect2);
            return (float)Math.Acos(value ) * 180 / (float)Math.PI;// wynik to NaN, to nie dobrze :/
        }


        public void Draw(RenderTarget window, RenderStates states)
        {
            window.Draw(shape);
        }

        public void ShipIsTurning()
        {
            Turning = true;
        }


    }
}
