using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.System;
using SFML;
using SFML.Window;

namespace GameProject.Elements
{
    static class  Functions
    {


        /// <summary>
        /// function to check if mouse is hoveren on object
        /// </summary
        public static Boolean CheckIfMouseHover(Vector2f SizeOfElement,Vector2f PositionOfElement, MyWindow window)
        {
            
            int x = Mouse.GetPosition(window).X;
            int y = Mouse.GetPosition(window).Y;
            if ((x >= PositionOfElement.X && x <= (PositionOfElement.X + SizeOfElement.X)) && (y >= PositionOfElement.Y && y <= PositionOfElement.Y + SizeOfElement.Y))
            { return true; }
            else
            { return false; }
        }


    }
}
