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
        public static List<InfoWindow> ListOfInfoToShow = new List<InfoWindow>();// global list for easy access

        public static GameObj GameFrame;

        public static float PunishtoSpeed = 0;// variable which defines how speed of ship should be lower- if one will add other AI ships, this should be moved to ship class

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

        
        public static Thread ParallelThread;// thread wchich works parallel with main one, it execude events wchich are independent from time 
        public static Thread MovingThread;// thread for moving ship and other chronical events
        public static ThreadStart ListOfMethodToExegute;
        public static ThreadStart listOfMethodToRunWithoutTime;


        public static float ElapsedTime;// it is set in program class // everything based on time need to be connected with this variable
        public static float timeStep = 0.0083f;// time step set by my self, 0.0083 s. it is about 120fps (i hope it works like that)
        public static bool ClockPause = false;// it defines if the clock is paused- all time based action will be stopped

        public static ThreadStart ListOfMethodToRunWithoutTime { get => listOfMethodToRunWithoutTime; set => listOfMethodToRunWithoutTime = value; }

        public static EventWaitHandle PauseHandle = new EventWaitHandle(true,EventResetMode.ManualReset);

        public static void EndlassFuncForThreat()// function called by second thread, if need add more function-add it to delegate  ListOfMethodToExecute 
        {
            while(true)
            {
                Thread.Sleep(TimeSpan.FromSeconds(timeStep));// tu jest droga do zapierdalania- trzeba nad tym pomyslec
                //PauseHandle // z funkcja pouzy trzeba ogarnąć i będzie git bardzo !!!
                //while (ElapsedTime > timeStep)
                //{
                    if(ListOfMethodToExegute!=null)
                    ObjectsBank.ListOfMethodToExegute();
                    ElapsedTime -= timeStep;
                //}
            }
        }

        public static void EndlessFuncForThreadWithoutTime()// function called by second thread, if need add more function-add it to delegate  ListOfMethodToExecute 
        {
            //while (true)
            //{
            //    if(ListOfMethodToRunWithoutTime!=null)
            //        ObjectsBank.ListOfMethodToRunWithoutTime();
            //}
        }


        public static void CheckMouseLeftButton()// if you want to know whaat is it, read comment near MouseButtonWasPressed variable
        {
            if (Mouse.IsButtonPressed(Mouse.Button.Left))
                MouseButtonWasPressed = true;
            else
                MouseButtonWasPressed = false;
        }

       public static void CheckInfoWindowList()
        {
            if (ObjectsBank.ListOfInfoToShow.Count() != 0)
            {
                ObjectsBank.ClockPause = true;
                ObjectsBank.ListOfInfoToShow[0].Render();
            }
        }

        private static void GainFocus(object sender, EventArgs e)
        {
            ClockPause = false;
        }

        private static void LostFocus(object sender, EventArgs e)
        {
            ClockPause = true;
        }


        /// <summary>
        /// loading all textures to bank
        /// </summary>
        static  public void LoadAll()
            {
            
            WindRose = new Texture("Res/Map/windrose.png");
                WindArrow = new Texture("Res/Map/arrow.png");
                land = new Texture("Res/Map/land.bmp");
                water = new Texture("Res/Map/water.bmp");
                error = new Texture("Res/Map/error.bmp");
                shallow = new Texture("Res/Map/shallow.bmp");
                LettersToCompas = new Texture("Res/Map/letters.png");

            window.LostFocus += LostFocus;
            window.GainedFocus += GainFocus;

            }




    }
}
