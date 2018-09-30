using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML;


namespace GameProject
{
    /// <summary>
    /// This class specify what items should be displayed
    /// </summary>
    abstract class Frame
    {
        public abstract void Render(MyWindow window);// function for rendering all obiects

        public abstract void CheckEvents(MyWindow window);


    }
}
