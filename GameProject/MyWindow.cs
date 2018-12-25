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

        public static int TickTAck = 1;// intresting variable.  If some event need unstopable mouse focus on it(for some period), its method check if TickTack 
                                       // have next values, ich there is lack of continuity it means that user moved mouse from item, and Time of focus 
                                       // need to be calculated again, THIS IS USED FOR ITEMS AND ITS DELAYED SHOWING INFO

         
        public delegate void CheckingEvents(MyWindow window);//This is handler for one function which check if button was pressed etc.
        public delegate void RenderingElements(MyWindow window);// This is handler for rendering game scene, each Window have its own elements
        public CheckingEvents CheckSomeEents;
        public RenderingElements RenderSomeElements;


        public MyWindow(VideoMode mode,string title): base(mode,title)
        {

            ObjectsBank.game = new GameObj();
            ObjectsBank.MyFont = new Font("./Res/Font.ttf");
            ObjectsBank.window = this;

            this.Closed += Onclose;
            
        }

        private void Onclose(object sender, EventArgs e)//need to add warning and save window
        {
            MyWindow window = (MyWindow)sender;

            if(ObjectsBank.ColisionThread!=null)
            ObjectsBank.ColisionThread.Abort();

            if (ObjectsBank.MovingThread != null)
                ObjectsBank.MovingThread.Abort();

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




        public void CloseThis()
        {
            this.Close();
        }


    }
}
