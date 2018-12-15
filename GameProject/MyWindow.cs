using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.System;
using SFML.Window;
using SFML.Graphics;
using GameProject.Game;
using GameProject.Game.Objects;


namespace GameProject
{
    class MyWindow : RenderWindow
    {
        public static bool MouseIsDragging = false;
        public static Card DraggedCard = null;
        public static bool MouseButtonWasPressed=false;// so, if sb is pressing left mouse button all the time and then they hover cursor on some item- the function "on pressed" will active
                                                        // this wariable prevent that.
       

        public static float MaxDistanceSlot_Card = 1.4f * 36 + 1.4f * 20;// excuse: diagonal of Cardslot + diagonal of small rectangle in Card

        public static int TickTAck = 1;// intresting variable.  If some event need unstopable mouse focus on it(for some period), its method check if TickTack 
                                       // have next values, ich there is lack of continuity it means that user moved mouse from item, and Time of focus 
                                       // need to be calculated again, THIS IS USED FOR ITEMS AND ITS DELAYED SHOWING INFO

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

        public static void UpdateTickTAck()
        {
            if (TickTAck == 1000)
            {
                TickTAck = 1;
            }
            else
                TickTAck++;
        }

        public static void CheckMouseLeftButton()// if you want to know whaat is it, read comment near MouseButtonWasPressed variable
        {
            if (Mouse.IsButtonPressed(Mouse.Button.Left))
                MouseButtonWasPressed = true;
            else
                MouseButtonWasPressed = false;
        }


        public void CloseThis()
        {
            this.Close();
        }


    }
}
