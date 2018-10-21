﻿using System;
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
    abstract class Card : Drawable// All items will be presented by "cards"
    {
        Text Info = new Text("",MyWindow.MyFont,20);

        Vector2f Position;// this position is permanent, set only in cardSlots
        Boolean DisplayInfo = false;
        Boolean hovered = false;
        Time TimeOfHover;
        Boolean Dragging = false;
        Boolean OnHovered = false;
        //public CardSlot<Card> Slot; // i decidet that this is useless


        protected List<String> InfoToDisplay;// its list with info for displaying in additional rectangle, this should be overriden somewhere
                                            // the idea is simple, strings are added in pairs like:
                                            // "Property","Value"
                                            // then function Display it like:
                                            // "Property: Value \n"<- its one line. Function mmakes this lines until pairs exist
                                            //THIS INFO NEED TO BE ADDED IN PAIRS!!!!!!
        private String AdditionInfo;// this info is some addition informations from me-developer
                                    // this shouldnt be long, or one have to write code to divite it to rows

        Texture Image;
        public RectangleShape shape = new RectangleShape(new Vector2f(70, 70));


        RectangleShape InfoShape;
        

        public Card(String Path,String _AdditionalInfo)
        {
            AdditionInfo = _AdditionalInfo;
            Info.Color = Color.Black;
            InfoShape = new RectangleShape();
            InfoShape.FillColor = Color.White;
            
            TimeOfHover = new Time();

            Image = new Texture(Path);
            shape.Texture = Image;
        }



        public void Draw(RenderTarget window, RenderStates states)
        {
            window.Draw(shape);
            OnHover();
            Drag();
        }

        public void SetItemPosition(Vector2f position)
        {
            Position = position;
            shape.Position = position;
        }
        /// <summary>
        /// Text need to be set first
        /// </summary>
        public void DrawInfoBox()
        {
            if (DisplayInfo==true && Dragging==false && MyWindow.MouseIsDragging==false) {
                if (InfoShape.Size == new Vector2f(0, 0))
                {
                    InfoShape.Size = new Vector2f(Info.GetLocalBounds().Width + 10, Info.GetLocalBounds().Height + 10);// added 5 pixel padding
                }
                InfoShape.Position = new Vector2f(Mouse.GetPosition(MyWindow.window).X + 10, Mouse.GetPosition(MyWindow.window).Y + 10);// setting info rectangle position in the center of card
                Info.Position = new Vector2f(InfoShape.Position.X + 5, InfoShape.Position.Y + 5);


                MyWindow.window.Draw(InfoShape);
                MyWindow.window.Draw(Info);
            }

        }

        public void SetInfo()// function which need to be played in sonstructors of obiects
        {

            for (int i = 0; i < InfoToDisplay.Count ; i+=2)
            {
                Info.DisplayedString += InfoToDisplay[i] + ": " + InfoToDisplay[1+(i)]+"\n";
            }

            if (AdditionInfo != "")// if additional info is added- add it XD
            {
                Info.DisplayedString += AdditionInfo+"\n";
            }

        }

        private void OnHover()// this is activated while displayng
        {
               if( Functions.CheckIfMouseHover(shape.Size,shape.Position,MyWindow.window) && hovered==false)// this function run only once, when mouse is hovered on item
            {
                hovered = true;
                shape.FillColor = new Color(173, 173, 173);

            }

            if (!Functions.CheckIfMouseHover(shape.Size, shape.Position, MyWindow.window) && hovered == true)// this function run only once, when mouse is hovered out item
            {
                DisplayInfo = false;
                hovered = false;
                shape.FillColor = Color.White;
                TimeOfHover = Time.Zero;
            }

            if (hovered==true)
            {
                if(TimeOfHover.AsSeconds()>0.01 )
                {
                    DisplayInfo = true;
                }
                else
                {
                    TimeOfHover += Program.clock.ElapsedTime;
                }
            }
        }

        /// <summary>
        /// function responsible for moving card between cardslots
        /// </summary>
        private void Drag()
        {
            
            
                if ((hovered == true && Mouse.IsButtonPressed(Mouse.Button.Left) && MyWindow.MouseIsDragging==false) || Dragging == true)
                {
                    MyWindow.MouseIsDragging = true;
                    MyWindow.DraggedCard = this;
                    Dragging = true;
                    shape.Position = (Vector2f)Mouse.GetPosition(MyWindow.window) - shape.Size / 2;

                }

                if (!Mouse.IsButtonPressed(Mouse.Button.Left) && Dragging == true)
                {
                   
                    MyWindow.MouseIsDragging = false;
                    MyWindow.DraggedCard = null;
                    Dragging = false;
                    shape.Position = Position;
                }
        }

        //public void SetCardSlot(CardSlot<Card> slot)
        //{
        //    Slot = slot;
        //}
        

        


    }
}
