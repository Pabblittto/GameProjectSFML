using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.System;
using SFML.Window;
using SFML.Graphics;
using SFML.Audio;
using GameProject.Elements;

namespace GameProject.Game
{
    class GameObj: Frame// game is combined with many elements
    {
        Player User;

        public GameObj(Player player)// to inicialize game user must choose player- load or create new
        {
            User = player;
        }



        public override void CheckEvents(MyWindow window)
        {
            
        }
        public override void Render(MyWindow window)
        {
            
        }

    }
}
