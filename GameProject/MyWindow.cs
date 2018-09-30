using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.System;
using SFML.Window;
using SFML.Graphics;
using GameProject.Game;


namespace GameProject
{
    class MyWindow : RenderWindow
    {
        public static GameObj game= new GameObj();// static obiect of game- easy access :)
        
        public static Font MyFont;
        public static MyWindow window;// I invent it too late :/- less coding 


         
        public delegate void CheckingEvents(MyWindow window);//This is handler for one function which check if button was pressed etc.
        public delegate void RenderingElements(MyWindow window);// This is handler for rendering game scene, each Window have its own elements
        public CheckingEvents CheckSomeEents;
        public RenderingElements RenderSomeElements;


        public MyWindow(VideoMode mode,string title): base(mode,title)
        {
            MyFont = new Font("./Res/Font.ttf");
            window = this;

            this.Closed += Onclose;
            
        }

        private void Onclose(object sender, EventArgs e)//need to add warning and save window
        {
            MyWindow window = (MyWindow)sender;
            window.Close();
        }





    }
}
