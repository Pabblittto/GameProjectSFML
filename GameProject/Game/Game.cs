using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.System;
using SFML.Window;
using SFML.Graphics;
using SFML.Audio;
using GameProject.Elements;
using GameProject.Game.Objects.Items;
using GameProject.Game.Objects;
using GameProject.Game.UsrInt;

namespace GameProject.Game
{
    class GameObj: Frame// game is combined with many elements
    {
        public SFML.Graphics.View UserLeftSite;
        public SFML.Graphics.View MapRightSite;
        static public Ship BeginnerShip = new Ship(new Vector2f(65, 100), 5, 10, 5, "Res/Ships/Ship2.png","Res/Ships/Side.png",new Vector2f(20,20),0,100,120,2);


        Player User;
        UserInterface UserInterface;
        Map MyMap;
        SettingsOnGame settings;
        RectangleShape CollisionRectangle;//this one represents ship rectangle
        Wind WindRose;

       static public List<PopUpInfo> ListOfPopingUpInfo = new List<PopUpInfo>();// if 

        public GameObj()
        {
            ObjectsBank.GameFrame = this;
            UserLeftSite = new SFML.Graphics.View(new FloatRect(0, 0, 800, 900))
            {
                Viewport = new FloatRect(0, 0, 8 / 18f, 1f)
            };

            MapRightSite = new SFML.Graphics.View(new FloatRect(0, 0, 1000, 900))
            {
                Viewport = new FloatRect(8 / 18f, 0, 10 / 18f, 1f)
            };

            ListOfPopingUpInfo.Add(new PopUpInfo("Siema siema, o tej porze kazdy wypic morze", this));
            ListOfPopingUpInfo.Add(new PopUpInfo("A to kolejne info w kolejce", this));
            ListOfPopingUpInfo.Add(new PopUpInfo("A te jeszcze jedno", this));



        }


        public void SetPlayer( ref Player userObj)//really important method- game need Player obiect, almost work like constructor
        {
            User = userObj;
            UserInterface = new UserInterface(User);
            MyMap = new Map(userObj);
            MapRightSite.Center = MyMap.ShipPosition;
            settings = new SettingsOnGame(userObj);
            CollisionRectangle = new RectangleShape()
            {
                Size = new Vector2f(User.UserShip.shape.TextureRect.Width/2, User.UserShip.shape.TextureRect.Height/2),
                Rotation = User.UserShip.shape.Rotation,
                FillColor = Color.Magenta,
                Origin = User.UserShip.shape.Origin/2
            };

            WindRose = new Wind(new Vector2f(1710,80));


            ObjectsBank.ListOfMethodToExegute += User.UserShip.CalculatePos;
            ObjectsBank.ListOfMethodToExegute += CheckColision;



        }




        public override void Render(MyWindow window)
        {


            window.SetView(UserLeftSite);
            UserInterface.Render();
            UserInterface.CheckEvents();

            window.SetView(MapRightSite);
            MyMap.TilesOnWindow(MapRightSite);
            MyMap.TilesToCheckColision(MapRightSite);

            MyMap.Render();


            CollisionRectangle.Rotation = User.UserShip.shape.Rotation;
            CollisionRectangle.Position = User.UserShip.shape.Position;


            if (User != null)
            {
                User.UserShip.UpdateView(MapRightSite);
                window.Draw(User.UserShip);
                window.Draw(CollisionRectangle); // pink rectangle shape for colision need to hide this after testing
            }
            window.SetView(window.DefaultView);
            window.Draw(settings);

            WindRose.Update(-1*MapRightSite.Rotation);
            window.Draw(WindRose);

            if (ListOfPopingUpInfo.Count != 0)
            {
                if (ListOfPopingUpInfo[0].SendToThread == false)
                    ListOfPopingUpInfo[0].StartDisplaying();// send methot to thread
                
                window.Draw(ListOfPopingUpInfo[0]);
            }

        }


        private void CheckColision()// if there will be added AI ships , this function need to be moved to ship Class
        {
            List<float> ListOfActualPunish = new List<float>();//this list contains contemporary all punishes for speed due to colision wiyh some objects
            float max=0;
             //after  adding, thread find the biggest number from that list
            float tmp;


             max=0;
             ListOfActualPunish.Clear();
            foreach (MyTile item in MyMap.TilesToColision)
            {
                //ListOfActualPunish.Add(Functions.CheckColision(CollisionRectangle, item));

                //ObjectsBank.PunishtoSpeed = Functions.CheckColision(CollisionRectangle, item);// so far works the best

                tmp = Ship.CheckColision(CollisionRectangle, item);
                if (max < tmp)                                                                  // to musi zostać poprawione
                max = tmp;
            }
           // Console.WriteLine( max.ToString() );
            //if (ListOfActualPunish.Count != 0)
            //{
            //    max = ListOfActualPunish[0];

            //    foreach (float item in ListOfActualPunish)
            //    {
            //        if (max < item)
            //            max = item;
            //    }
                ObjectsBank.PunishtoSpeed = max;// there is counting max of punish , if ship is colliding with many different tiles with different punish
            //}
            //}
        }




        public override void CheckEvents(MyWindow window)// prawdopodobnie to jest nie potrzebne
        {

            if (User == null)
            {
                throw new Exception();// Player was not set :/
            }
            // MainMap.CheckEvents();
            float y = 0.5f;

            if (Keyboard.IsKeyPressed(Keyboard.Key.Down))
            {
                User.UserShip.Move(y*Program.clockmeasure); //this dont work well :/
                User.UserShip.Rotate(0);
                CollisionRectangle.Position = User.UserShip.shape.Position;
            }

            float x = 1;// this for "if" below

            if (Keyboard.IsKeyPressed(Keyboard.Key.Up))
            {
                User.UserShip.Move(x-x*ObjectsBank.PunishtoSpeed);
                User.UserShip.Rotate(0);
                CollisionRectangle.Position = User.UserShip.shape.Position;
            }


            if (Keyboard.IsKeyPressed(Keyboard.Key.D))
            {
               // User.UserShip.Rotate(0.1f);        
                User.UserShip.ShipIsTurning();
            }

            if (Keyboard.IsKeyPressed(Keyboard.Key.A))
            {
               // User.UserShip.Rotate(-0.1f);
                User.UserShip.ShipIsTurning();
            }


            if (Keyboard.IsKeyPressed(Keyboard.Key.Escape))
            {
                settings.SetActive();
                ObjectsBank.ClockPause = true;
            }

            if (Keyboard.IsKeyPressed(Keyboard.Key.Space))
            {
                Wind.valueOfWind = 0;
            }

            if (Keyboard.IsKeyPressed(Keyboard.Key.H))
            {
                Wind.VectorOfWind = Functions.RotateVector(Wind.VectorOfWind, -1);

            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.K))
            {
                Wind.VectorOfWind = Functions.RotateVector(Wind.VectorOfWind, 1);
            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.U))
            {
                WindRose.AddToValue(1f);
            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.J))
            {
                WindRose.AddToValue(-1f);

            }

            if (Keyboard.IsKeyPressed(Keyboard.Key.P))
            {
                    if (ObjectsBank.ClockPause == false)
                        ObjectsBank.ClockPause = true;
                    else
                        ObjectsBank.ClockPause = false;
            }


        }



    }
}
