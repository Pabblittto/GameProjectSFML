using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace GameProject
{
    class Program
    {
        static public Menu MenuObj;
        public static Clock clock = new Clock();// global clock to make some hronical events etc.
        static void Main(string[] args)
        {

            MyWindow window = new MyWindow(new VideoMode(1800, 900), "GAME");
              MenuObj = new Menu(window);

            window.CheckSomeEents = MenuObj.CheckEvents;
            window.RenderSomeElements = MenuObj.Render;

            while (window.IsOpen)
            {
                clock.Restart();

                MyWindow.UpdateTickTAck();


                window.Clear();
                window.DispatchEvents();

                window.RenderSomeElements.Invoke(window);
                window.CheckSomeEents.Invoke(window);


                window.Display();
            }
        }// Main
    }
}
