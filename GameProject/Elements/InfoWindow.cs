﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using GameProject.Game;

namespace GameProject.Elements
{
    class InfoWindow 
    {
        RectangleShape shape;
        Text ContainedText;
        Button OK;
        float Padding;
        Vector2f standard = new Vector2f(800, 300);

        /// <summary>
        /// Info window with possble changing size, (size of button is 150,35- be aware of that)
        /// </summary>
        public InfoWindow(Vector2f size,String text, Button.FunctionToDo DeletePause, uint CharacterSize, float _Padding=30)
        {
            Padding = _Padding;
            shape = new RectangleShape(size)
            {
                FillColor = new Color(173, 127, 86),
                OutlineThickness = 3,
                OutlineColor = Color.Black,
            };
            shape.Origin = new Vector2f(shape.Size.X / 2, shape.Size.Y / 2);
            shape.Position = new Vector2f(ObjectsBank.window.Size.X / 2, ObjectsBank.window.Size.Y / 2);

            String tmp = Dividing(text, CharacterSize, shape.Size,Padding);

            ContainedText = new Text(tmp, ObjectsBank.MyFont, CharacterSize)
            {
                Color = Color.Black,
            };
            ContainedText.Origin = new Vector2f(ContainedText.GetLocalBounds().Width / 2, ContainedText.GetLocalBounds().Height / 2);
            ContainedText.Position = shape.Position;


            OK = new Button(new Vector2f(shape.Position.X, shape.Position.Y + shape.Size.Y - 20), new Vector2f(150, 35), new Color(158, 115, 74), new Color(211, 162, 114), ObjectsBank.MyFont, "OK", 30, null, 2);
            OK.AddingAdditionalFunction(this.DeletePause);
            OK.AddingAdditionalFunction(this.DeleteFromList);
            OK.Center();

        }

        /// <summary>
        /// Window with certain size-(800,300) with padding 30 and button OK in the bottom (within padding)
        /// </summary>
        public InfoWindow(String text, Button.FunctionToDo Function, uint CharacterSize,float _Padding=30 )
        {
            Padding = _Padding;
            shape = new RectangleShape(new Vector2f(800, 400))
            {
                FillColor = new Color(173, 127, 86),
                OutlineThickness = 3,
                OutlineColor = Color.Black,
            };
            shape.Origin = new Vector2f(shape.Size.X / 2, shape.Size.Y / 2);
            shape.Position = new Vector2f(ObjectsBank.window.Size.X / 2,ObjectsBank.window.Size.Y / 2);

            String tmp = Dividing(text, CharacterSize, shape.Size,Padding);

            ContainedText = new Text(tmp, ObjectsBank.MyFont,CharacterSize)
            {
                Color= Color.Black,
            };
            ContainedText.Origin = new Vector2f(ContainedText.GetLocalBounds().Width / 2, ContainedText.GetLocalBounds().Height / 2);
            ContainedText.Position = shape.Position;


            OK = new Button(new Vector2f(shape.Position.X-75, shape.Position.Y + shape.Size.Y/2 - 20), new Vector2f(150, 45), new Color(158, 115, 74), new Color(211, 162, 114), ObjectsBank.MyFont, "OK", 30, null, 2);
            OK.AddingAdditionalFunction(Function);
            OK.AddingAdditionalFunction(this.DeletePause);// deflaut function- if clicked turn off pause
            OK.AddingAdditionalFunction(this.DeleteFromList);
            OK.Center();

        }


        void DeletePause()
        {
            ObjectsBank.ClockPause = false;
        }


        //function for dividing long text sended to info window. It divide text into string rows ("\n")
        String Dividing(String text, uint sizeOfCharacter,Vector2f WindowSize,float Padding)
        {
            String[] List = text.Split(' ');
            List<String> Rows = new List<String>();
            Text tmp = new Text("",ObjectsBank.MyFont,sizeOfCharacter);
            float MaxWidth = WindowSize.X - 2 * Padding;
            float MaxHeight = WindowSize.Y - Padding - 40;// 40 pixels is reserved for button below

            String row;
            String moved;
            String[] realyTmp;

            float test;

            foreach(String  word in List)
            {
                tmp.DisplayedString += " " + word;
                test = tmp.GetLocalBounds().Width;
                if (test >MaxWidth)// if string is too long for one row
                {
                    realyTmp = tmp.DisplayedString.Split(' ');
                    moved = realyTmp[realyTmp.Length - 1];// take last string 

                    row = tmp.DisplayedString.Replace(moved, "\n");
                    Rows.Add((string)row.Clone());
                    tmp.DisplayedString = moved;// string which can't go to upper row goes to lower row
                }
            }
            Rows.Add((String)tmp.DisplayedString.Clone());
            float height = tmp.GetLocalBounds().Height;
            height *= Rows.Count();// multiplied by numbers of rows

            if (height > MaxHeight)
                throw new Exception(); // so now lest check if there is enought place for rows

            row = "";//clearing row
            foreach (string item in Rows)
            {
                row += item + " ";// creating result
            }

            return row;
        }

        public void Render()
        {
           
            ObjectsBank.window.Draw(shape);
            ObjectsBank.window.Draw(ContainedText);
            ObjectsBank.window.Draw(OK);

        }

        void DeleteFromList()
        {
            lock (ObjectsBank.ListOfInfoToShow)
            {
                ObjectsBank.ListOfInfoToShow.Remove(this);
            }
        }

    }
}
