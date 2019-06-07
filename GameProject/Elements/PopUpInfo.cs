using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using GameProject.Elements;
using GameProject.Game;

namespace GameProject.Elements
{
    /// <summary>
    /// One have to only add object to list in Game object. Object itself count its life time and remove itself from list.
    /// </summary>
    class PopUpInfo: Drawable
    {
        Text ContainedInfo;
        RectangleShape shape;
        float speed;// deafult speed of sliding of Info 
        float TimeOfVisibility;// time in seconds when info is full visible (completely expanded)
        float ExpandingTime;
        float TimeCount = 0f;
        Boolean showed = false; // if info was showed, it can be deleted
        public Boolean SendToThread = false;// variable for chceking if function Change position was added to event List of method to execude


        public PopUpInfo(String info,GameObj game)
        {
            shape = new RectangleShape(new Vector2f(1000, 100)) /// to powinno działać tak że: wysyłamy funcję do delegatu który się wykonuje na podstawie czasu i ten obiekt w subie przzechowuje , w jakim momencie animacji aktualnie jest, po wykonaniu tej animecji , obiekt usywa się z kolejki
            {                                                       // potrzeba zrobić kolejke pop upów w klasie gra
                FillColor = new Color(213, 239, 110),
            };
            shape.Origin = new Vector2f(shape.Size.X/2, shape.Size.Y/2);// orgin is set to the center of upper edge
            shape.Position = new Vector2f(game.MapRightSite.Size.X/2+game.UserLeftSite.Size.X,game.MapRightSite.Size.Y+shape.Size.Y/2);//set position under Map view

            String tmp = Functions.Dividing(info, 25, shape.Size,10);

            ContainedInfo = new Text(tmp, ObjectsBank.MyFont, 30)
            {
                Color = Color.Black,
            };
            ContainedInfo.Origin = new Vector2f(ContainedInfo.GetLocalBounds().Width / 2, ContainedInfo.GetLocalBounds().Height / 2);
            ContainedInfo.Position = new Vector2f(shape.Position.X,shape.Position.Y);// set text position in center of shape

            ExpandingTime = 0.5f;// in 1 second it should expand completely
            TimeOfVisibility = 3f;// two seconds visible and then hide
            speed = shape.Size.Y / ExpandingTime;// certain speed is calculated for specific Expanding time
        }

        /// <summary>
        /// vertical moving by certain value postive-upward movement
        /// </summary>
        void Move(float value)// value in pixels
        {
            shape.Position += new Vector2f(0, -value);
            ContainedInfo.Position = shape.Position;
        }

        /// <summary>
        /// Function added to listOfMethodsToExecude in objectsBank
        /// </summary>
        public void ChangePosition()
        {
            float TimeFromClock = ObjectsBank.timeStep;

            if (TimeCount <= ExpandingTime)
            {
                Move(TimeFromClock * speed);// expanding (become more visible)
            }
            else if(TimeCount>ExpandingTime+TimeOfVisibility && TimeCount<2*ExpandingTime+TimeOfVisibility)
            {
                Move(-TimeFromClock * speed);
            }

            if(TimeCount > 2 * ExpandingTime + TimeOfVisibility)
            {
                showed = true;

                lock(ObjectsBank.ListOfMethodToExegute)
                ObjectsBank.ListOfMethodToExegute -= this.ChangePosition;// after beeing showed, object can be deleted from list 
            }

            TimeCount += TimeFromClock;
        }


        public void StartDisplaying()
        {
            lock (ObjectsBank.ListOfMethodToExegute)
                ObjectsBank.ListOfMethodToExegute += ChangePosition;
            SendToThread = true;
        }


        public void Draw(RenderTarget window, RenderStates states)
        {
            if (showed == true)
                GameObj.ListOfPopingUpInfo.Remove(this);// remove this object from list if it was showed already

            window.Draw(shape);
            window.Draw(ContainedInfo);
        }





    }
}
