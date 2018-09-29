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
        static void Main(string[] args)
        {

            MyWindow window = new MyWindow(new VideoMode(1800, 900), "GAME");
            Menu MenuObj = new Menu(window);

            window.CheckSomeEents = MenuObj.CheckEvents;
            window.RenderSomeElements = MenuObj.Render;

            while (window.IsOpen)
            {
                window.Clear();
                window.DispatchEvents();

                window.CheckSomeEents.Invoke(window);
                window.RenderSomeElements.Invoke(window);


                window.Display();
            }
        }// Main
    }
}
