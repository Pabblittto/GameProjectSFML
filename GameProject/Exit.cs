using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameProject.Game;

namespace GameProject
{
    class Exit :Frame
    {

        public override void CheckEvents(MyWindow window)
        {
            // nothing to check 
        }
        public override void Render(MyWindow window)
        {
            if (ObjectsBank.ParallelThread != null)
                ObjectsBank.ParallelThread.Abort();

            if (ObjectsBank.MovingThread != null)
                ObjectsBank.MovingThread.Abort();
            window.Close();// just close the window
        }
    }
}
