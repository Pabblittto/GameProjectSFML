using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using GameProject.Game;
using GameProject.Elements;

namespace GameProject
{
    class Program
    {
        static public Menu MenuObj;
        public static Clock clock = new Clock();// global clock to make some hronical events etc.
        public static float clockmeasure;//
        static void Main(string[] args)
        {

            ObjectsBank.LoadAll();// load all textures

            MyWindow window = new MyWindow(new VideoMode(1800, 900), "GAME");
              MenuObj = new Menu(window);

            window.CheckSomeEents = MenuObj.CheckEvents;
            window.RenderSomeElements = MenuObj.Render;
            window.SetFramerateLimit(120);

            ObjectsBank.ParallelThread = new Thread(ObjectsBank.EndlessFuncForThreadWithoutTime);
            ObjectsBank.ParallelThread.Start();


            while (window.IsOpen)
            {
                
                MyWindow.UpdateTickTAck();


                window.Clear();
                window.DispatchEvents();

                
                window.RenderSomeElements.Invoke(window);
                window.CheckSomeEents.Invoke(window);
                ObjectsBank.CheckInfoWindowList();

                ObjectsBank.CheckMouseLeftButton();

                window.Display();


                if (ObjectsBank.ClockPause == false)
                    ObjectsBank.ElapsedTime += clock.ElapsedTime.AsSeconds();// everything based on time need to be connected with this variable

                clock.Restart();
            }
        }// Main
    }
}
