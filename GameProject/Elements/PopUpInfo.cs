using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace GameProject.Elements
{
    class PopUpInfo
    {
        Text ContainedInfo;
        RectangleShape shape;

        public PopUpInfo(String info)
        {
            shape = new RectangleShape(new Vector2f(1000, 200)) /// to powinno działać tak że: wysyłamy funcję do delegatu który się wykonuje na podstawie czasu i ten obiekt w subie przzechowuje , w jakim momencie animacji aktualnie jest, po wykonaniu tej animecji , obiekt usywa się z kolejki
            {                                                       // potrzeba zrobić kolejke pop upów w klasie gra
                FillColor = new Color(213, 239, 110),
            };

            String tmp = Functions.Dividing(info, 25, shape.Size, 10);


        }

    }
}
