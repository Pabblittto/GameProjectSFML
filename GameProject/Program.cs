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
            RenderWindow Window = new RenderWindow(new VideoMode(1800, 800), "Game Tests!!");



            while(Window.IsOpen)
            {
                Window.Clear();
                Window.DispatchEvents();



                Window.Display();
            }




        }
    }
}
