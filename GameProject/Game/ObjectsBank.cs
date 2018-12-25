using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using SFML.System;
using SFML.Window;
using SFML.Graphics;
using GameProject.Elements;
using GameProject.Game;
using GameProject.Game.Objects;

namespace GameProject.Game
{
     static class ObjectsBank// static class with only statisc elements, this contains all textures, fonts etc. Everything is loaded in constructor. Constructor is called once, before all game
    {
        public static float PunishtoSpeed = 0;

        public static Texture WindRose;
        public static Texture WindArrow;
        public static Texture LettersToCompas;

        public static Texture land;
        public static Texture shallow;
        public static Texture water;
        public static Texture error;

        static public Font MyFont;
        static public MyWindow window;
        static public GameObj game;

        public static float MaxDistanceSlot_Card = 1.4f * 36 + 1.4f * 20;// excuse: diagonal of Cardslot + diagonal of small rectangle in Card

        //mouse and card events
        public static bool MouseIsDragging = false;
        public static Card DraggedCard = null;
        public static bool MouseButtonWasPressed = false;// so, if sb is pressing left mouse button all the time and then they hover cursor on some item- the function "on pressed" will active
                                                         // this wariable prevent that.

        public static Thread ColisionThread;
        public static Thread MovingThread;// thread for moving ship
        public static ThreadStart ListOfMethodToExegute;

        public static Clock clockNr2;// global clock to make some hronical events etc.
        public static float DeltaTime;

        public static void EndlassFuncForThreat()
        {
            
            while(true)
            {
                DeltaTime= clockNr2.Restart().AsSeconds();

                ObjectsBank.ListOfMethodToExegute();
            }

        }

        public static void CheckMouseLeftButton()// if you want to know whaat is it, read comment near MouseButtonWasPressed variable
        {
            if (Mouse.IsButtonPressed(Mouse.Button.Left))
                MouseButtonWasPressed = true;
            else
                MouseButtonWasPressed = false;
        }

        /// <summary>
        /// loading all textures to bank
        /// </summary>
           static  public void LoadAll()
        {
            clockNr2 = new Clock();

            WindRose = new Texture("Res/Map/windrose.png");
            WindArrow = new Texture("Res/Map/arrow.png");
            land = new Texture("Res/Map/land.bmp");
            water = new Texture("Res/Map/water.bmp");
            error = new Texture("Res/Map/error.bmp");
            shallow = new Texture("Res/Map/shallow.bmp");
            LettersToCompas= new Texture("Res/Map/letters.png");

        }
    }
}
