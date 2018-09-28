using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            window.Close();// just close the window
        }
    }
}
