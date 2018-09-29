using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using SFML.Audio;
using System.Threading;
using GameProject.Game;


namespace GameProject.Elements
{
    class Button
    {
        Action PossibleMethod;

        public Frame DestinationSet;// public for fast 
        Boolean focus = false;// bool for protecting PCU against usless color setting in WhenHover
        MyWindow WindowPoint;
        Text Content;
        Color OnHoverColor,NormalColor;
        RectangleShape Shape;
        public delegate void FunctionEventHandler();

        public Button(Vector2f Size, Vector2f position ,Color color, Color OnHover, string display, Font UsedFont,MyWindow window, Frame Destination)
        {
            NormalColor = color;
            OnHoverColor = OnHover;

            WindowPoint = window;

            DestinationSet = Destination;

            Shape = new RectangleShape(Size)
            {
                Position = position,
                FillColor = color,
                OutlineThickness = 3,
                OutlineColor = Color.Black
            };

            Content = new Text(display, UsedFont, 30)
            {
                Color = Color.Black,
                Position = new Vector2f(Shape.Position.X + 5, Shape.Position.Y + 10)
            };

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
                    // add here sound of click
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

        private void OnClick(Frame NextSet,MyWindow window)
        {

                if (Functions.CheckIfMouseHover(Shape.Size, Shape.Position, WindowPoint) && Mouse.IsButtonPressed(Mouse.Button.Left))
                {
                    if (PossibleMethod != null)
                    {
                    PossibleMethod.Invoke();
                    }

                    window.RenderSomeElements = NextSet.Render;
                    window.CheckSomeEents = NextSet.CheckEvents;
                    
                }
            
        }



        public void Functionality()// all Possible eventsw with this button
        {
            this.WhenHover();
            this.OnClick(DestinationSet, WindowPoint);
            // function when click
        }

        /// <summary>
        /// method to move content to the center of button, unfortynaly one have to do manually :/
        /// </summary>
        /// <param name="xToRight"></param>
        public void MoveText(float xToRight)
        {
            Content.Position = new Vector2f(Content.Position.X + xToRight, Content.Position.Y);
        }

        /// <summary>
        /// Additional method for creating player object and creating game object- only for NewPlayerFrame
        /// </summary>

        public void AddingAdditionalFunction(Action function)
        {
            PossibleMethod += function;
        }

        

    }
}
