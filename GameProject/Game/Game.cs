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
using GameProject.Game.Objects;
using GameProject.Game.UsrInt;

namespace GameProject.Game
{
    class GameObj: Frame// game is combined with many elements
    {
        SFML.Graphics.View UserLeftSite;
        SFML.Graphics.View MapRightSite;
        static public Ship BeginnerShip = new Ship(new Vector2f(65, 100), 5, 10, 5, "Res/Ships/Ship2.png","Res/Ships/Side.png",new Vector2f(20,20),90,100,60);


        Player User;
        UserInterface UserInterface;
        Map MyMap;
        SettingsOnGame settings;
        RectangleShape CollisionRectangle;//this one represents ship rectangle
        Wind WindRose;

        public GameObj()
        {
            UserLeftSite = new SFML.Graphics.View(new FloatRect(0,0,800,900));
            UserLeftSite.Viewport = new FloatRect(0,0,8/18f,1f);

            MapRightSite = new SFML.Graphics.View(new FloatRect(0,0,1000,900));
            MapRightSite.Viewport = new FloatRect(8 / 18f, 0, 10 / 18f, 1f);
            


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

            ObjectsBank.ColisionThread = new System.Threading.Thread(CheckColision);
            // ObjectsBank.ColisionThread.Start();// ten start moze byc w move a while w środku zmienionu na while wokłó jest jakiś lad, mielizna

            ObjectsBank.ListOfMethodToExegute += User.UserShip.CalculatePos;
            ObjectsBank.MovingThread = new System.Threading.Thread( ObjectsBank.EndlassFuncForThreat);
            ObjectsBank.MovingThread.Start();

        }




        public override void Render(MyWindow window)
        {
           // ObjectsBank.MovingThread = new System.Threading.Thread(() => User.UserShip.CalculatePos(Wind.VectorOfWind, Wind.valueOfWind));
          //  ObjectsBank.MovingThread.Start();
           // User.UserShip.CalculatePos(Wind.VectorOfWind, Wind.valueOfWind);

            window.SetView(UserLeftSite);
            UserInterface.Render();
            UserInterface.CheckEvents();

            window.SetView(MapRightSite);
            MyMap.TilesOnWindow(MapRightSite);
            MyMap.TilesToCheckColision(MapRightSite);

            MyMap.Render();


            CollisionRectangle.Rotation = User.UserShip.shape.Rotation;
            CollisionRectangle.Position = User.UserShip.shape.Position;
           // User.UserShip.CalculatePos(WindRose.VectorOfWind, WindRose.valueOfWind);


            if (User != null)
            {
                User.UserShip.UpdateView(MapRightSite);
                window.Draw(User.UserShip);
                window.Draw(CollisionRectangle);
            }
            window.SetView(window.DefaultView);
            window.Draw(settings);

            WindRose.Update(-1*MapRightSite.Rotation);
            window.Draw(WindRose);


        }


        private void CheckColision()
        {
            while (true)
            {
                //foreach (MyTile item in MyMap.TilesToColision)
              //  {
               //     ObjectsBank.PunishtoSpeed=Functions.CheckColision(CollisionRectangle,item);
                   // Console.WriteLine("Punish speed:"+ ObjectsBank.PunishtoSpeed);
               // }
            }
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
            float x = 1;
            if (Keyboard.IsKeyPressed(Keyboard.Key.Up))
            {
                User.UserShip.Move(x-x*ObjectsBank.PunishtoSpeed);
                User.UserShip.Rotate(0);
                CollisionRectangle.Position = User.UserShip.shape.Position;


            }

            //if (Keyboard.IsKeyPressed(Keyboard.Key.Right))
            //{
            //    MapRightSite.Move(new Vector2f(1, 0));
            //}

            //if (Keyboard.IsKeyPressed(Keyboard.Key.Left))
            //{
            //    MapRightSite.Move(new Vector2f(-1, 0));
            //}

            if (Keyboard.IsKeyPressed(Keyboard.Key.D))
            {
                User.UserShip.Rotate(0.1f);        
               

            }

            if (Keyboard.IsKeyPressed(Keyboard.Key.A))
            {
                User.UserShip.Rotate( -0.1f);
                

            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.Escape))
            {
                settings.SetActive("");
            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.Escape))
            {
                settings.SetActive("");
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




        }



    }
}
