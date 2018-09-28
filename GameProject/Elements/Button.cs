using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using SFML.Audio;


namespace GameProject.Elements
{
    class Button
    {
        Boolean focus = false;// bool for protecting PCU against usless color setting in WhenHover
        MyWindow WindowPoint;
        Text Content;
        Color OnHoverColor,NormalColor;
        RectangleShape Shape;
        public delegate void FunctionEventHandler();

        public Button(Vector2f Size, Vector2f position ,Color color, Color OnHover, string display, Font UsedFont,MyWindow window)
        {
            NormalColor = color;
            OnHoverColor = OnHover;

            WindowPoint = window;

            Shape = new RectangleShape(Size);
            Shape.Position = position;
            Shape.FillColor = color; Shape.OutlineThickness = 3;
            Shape.OutlineColor = Color.Black;

            Content = new Text(display, UsedFont,30);
            Content.Color = Color.Black;
            Content.Position = new Vector2f(Shape.Position.X+5,Shape.Position.Y+10);

        }

        private void WhenHover()
        {
            if (Functions.CheckIfMouseHover(Shape.Size, Shape.Position, WindowPoint))
            {
                if (focus == false)
                {
                    Shape.FillColor = OnHoverColor;
                    Shape.OutlineColor = new Color(232, 0, 23);
                    focus = true;

                }
            }
            else
            {
                if (focus == true)
                {
                    Shape.OutlineColor = Color.Black;
                    Shape.FillColor = NormalColor;
                    focus = false;
                }
            }
        }

        public void Draw(MyWindow window)
        {
            window.Draw(Shape);
            window.Draw(Content);
        }



        public void Functionality()// all Possible events
        {
            this.WhenHover();
            // function when click
        }





    }
}
