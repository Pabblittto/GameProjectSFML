using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.System;
using SFML.Window;
using SFML.Graphics;
using GameProject.Game;

namespace GameProject.Elements
{
    class Button: Drawable
    {
        public delegate void FunctionToDo();
        private FunctionToDo Adding;// functions wchich can be casted after click

        public Action<string> FunctionString;// function with string
        private string StringForFunct;

        public FunctionToDo Main;// inaccording to selected mode main will contain different functions

        Boolean focus = false;
        Text Content;
        public RectangleShape Shape;
        Color OnHoverColor, NormalColor;
        Frame DestinationSet;// public for fast access, possible Destination if needed

        int Mode; // mode specifies how the button works, it can warp to another Frame,, or it can run som functions only

        public Player FutureUser; // pool for setting players for game

        /// <summary>
        /// If Button dont lead to another frame- Dest can be null
        ///Modes: 1-leading to another frame
        ///       2-mode for calling additional functions after click 
        ///       3- mode for calling function with additional string
        ///       To be honest mode 2 and 3 do nothing special (nothing...realy), mode 1 is neccessary 
        /// </summary>
        public Button(Vector2f position, Vector2f size, Color Background, Color OnHover, Font UsedFont, string ToDisplay, uint CharacterSize,Frame Dest,int Mode_)
        {
            DestinationSet = Dest;
            OnHoverColor = OnHover;
            NormalColor = Background;

            Shape = new RectangleShape(size)
            {
                Position = position,
                FillColor = Background,
                OutlineThickness = 3,
                OutlineColor = Color.Black
            };

            Content = new Text(ToDisplay, UsedFont, CharacterSize)
            {
                Color = Color.Black,
                Position = new Vector2f(Shape.Position.X + 5, Shape.Position.Y + 5)
            };

            Mode = Mode_;
            switch (Mode)
            {
                case 1: // this mode changes frame 
                    {
                        Main = ModeOne;

                        break;
                    }
                case 2: // this is for casting other functions
                    {
                        //Main = Adding;
                        break;
                    }
                case 3: // this is for functions with extra string needed
                    {
                       // Main = ModeThree;
                        break;
                    }
                default:
                    {
                        throw new Exception();// jakiś nieobsługiwany mode
                        break;
                    }
            }

        }


        private void WhenHover()
        {
            if (Functions.CheckIfMouseHover(Shape.Size, Shape.Position, ObjectsBank.window))
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

        private void ModeOne()
        {
            if (Mode == 1)
            {
                ObjectsBank.window.RenderSomeElements = DestinationSet.Render;
                ObjectsBank.window.CheckSomeEents = DestinationSet.CheckEvents;

                //ObjectsBank.window.KeyPressed=DestinationSet.



            }
            else
                throw new Exception();// this shoul never happend

        }

        private void ModeTwo() // this will be uselless, probably
        {
        }



        private void OnClick()
        {
            if (Functions.CheckIfMouseHover(Shape.Size, Shape.Position, ObjectsBank.window) && Mouse.IsButtonPressed(Mouse.Button.Left) && ObjectsBank.MouseButtonWasPressed == false)
            {
                if (Adding!=null)
                Adding.Invoke();
                if (StringForFunct!= null)
                    FunctionString.Invoke(StringForFunct);
                if(Main!=null)
                Main.Invoke();

                if (FutureUser!=null)
                    ObjectsBank.game.SetPlayer(ref FutureUser);

            }

        }


        /// <summary>
        /// method to move text manually
        /// </summary>
        /// <param name="xToRight"></param>
        public void MoveText(float xToRight, float yToDown)
        {
            Content.Position = new Vector2f(Content.Position.X + xToRight, Content.Position.Y+ yToDown);
        }


        /// <summary>
        /// function wchich centers text on button
        /// </summary>
        public void Center()
        {
            Content.Position= new Vector2f(Content.Position.X +Shape.Size.X/2-Content.GetLocalBounds().Width/2 , Content.Position.Y);
        }

        public void AddingAdditionalFunction(FunctionToDo function)
        {
            Adding += function;
        }

        public void SetStringFunction(Action<string> function,string neededString)
        {
            FunctionString = function;
            StringForFunct = neededString;
        }

        /// <summary>
        /// this one set one functions to do on click and remove old ones
        /// </summary>
        /// <param name="function"></param>
        public void SetOneFunction(FunctionToDo function)
        {
            Adding = function;
        }

        public void Draw(RenderTarget window, RenderStates states)
        {
            this.WhenHover();
            this.OnClick();
            window.Draw(Shape);
            window.Draw(Content);

        }

    }
}
