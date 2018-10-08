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
            Field.FillColor = Color.Magenta;

            ship = new Texture("./Res/Ships/Ship2.png");
            test = new RectangleShape(new Vector2f(60, 100));
            test.Origin = new Vector2f(30, 50);
            test.Texture = ship;
            testOfTile = new RectangleShape(new Vector2f(80, 80));
            testOfTile.Position = Field.Position + new Vector2f(500, 200);
            testOfTile.FillColor = Color.Blue;

            center = new Vector2f(Field.Position.X+Field.Size.X/2,Field.Position.Y+ Field.Size.Y/2);
            test.Position = center;
        }




        public void Render()
        {
            MyWindow.window.Draw(Field);
            MyWindow.window.Draw(testOfTile);

            MyWindow.window.Draw(test);
        }

        public void CheckEvents()
        {
            Move();
        }






        private void Move()
        {
            if(Keyboard.IsKeyPressed(Keyboard.Key.Left))
            {
                test.Rotation += -1f;
            }
            else if (Keyboard.IsKeyPressed(Keyboard.Key.Right))
            {
                test.Rotation += 1f;

            }
            
            
            if (Keyboard.IsKeyPressed(Keyboard.Key.Up))
            {
                test.Position = test.Position + new Vector2f(0, -1f);

            }
            else if (Keyboard.IsKeyPressed(Keyboard.Key.Down))
            {
                test.Position = test.Position + new Vector2f(0, 1f);

            }

        }
    }
}
