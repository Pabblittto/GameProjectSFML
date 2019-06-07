using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameProject.Elements;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace GameProject.Game
{
    class View//this class is this big rectangle on the right
    {
        Player User;
        RectangleShape Field;
        Vector2f center;

        Texture ship;
        RectangleShape test;
        RectangleShape testOfTile;


        public View(Player _User)
        {
            User = _User;
            Field = new RectangleShape(new Vector2f(1000, 900));
            Field.Position = new Vector2f(800, 0);
            Field.FillColor = new Color(0,0,0,255);// to do wyjebania 

            ship = new Texture("./Res/Ships/Ship2.png");
            test = new RectangleShape(new Vector2f(60, 100));
            test.Origin = new Vector2f(30, 50);
            test.Texture = ship;
            testOfTile = new RectangleShape(new Vector2f(80, 80));
            testOfTile.Position = Field.Position + new Vector2f(500, 200);
            testOfTile.FillColor = Color.Blue;
            // to do wyjebania 
            center = new Vector2f(Field.Position.X+Field.Size.X/2,Field.Position.Y+ Field.Size.Y/2);
            test.Position = center;
        }


        // to do wyjebania // to do wyjebania 

        public void Render()
        {// to do wyjebania 
            ObjectsBank.window.Draw(Field);
            ObjectsBank.window.Draw(testOfTile);

            ObjectsBank.window.Draw(test);
        }
        // to do wyjebania // to do wyjebania 
        public void CheckEvents()
        {
            Move();
        }




        private void Move()
        {
            if(Keyboard.IsKeyPressed(Keyboard.Key.Left))// to do wyjebania 
            {
                test.Rotation += -1f;
            }// to do wyjebania 
            else if (Keyboard.IsKeyPressed(Keyboard.Key.Right))
            {
                test.Rotation += 1f;
                // to do wyjebania 
            }


            if (Keyboard.IsKeyPressed(Keyboard.Key.Up))
            {
                test.Position = test.Position + new Vector2f(0, -1f);
                // to do wyjebania 
            }
            else if (Keyboard.IsKeyPressed(Keyboard.Key.Down))
        {// to do wyjebania 
            test.Position = test.Position + new Vector2f(0, 1f);

            }
        // to do wyjebania 
    }
}
}
