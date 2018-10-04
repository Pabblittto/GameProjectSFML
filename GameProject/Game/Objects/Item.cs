using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using GameProject.Elements;

namespace GameProject.Game.Objects
{
    abstract class Item// basic item 
    {
        Time DurationOfHover;
        String Name;
        Texture texture;
        RectangleShape shape;
        float Price;

        public Item(String name, String pathToImage,float price)
        {
            DurationOfHover = new Time();
            Name = name;
            texture = new Texture(pathToImage);
            shape = new RectangleShape(new Vector2f(90,90));
            Price = price;
        }

        public void SetPosition(Vector2f posit)
        {
            shape.Position = posit;
        }


        public virtual void InfoOnHover(params String[] Info)//add additional info
        {
            if (Functions.CheckIfMouseHover(shape.Size,shape.Position,MyWindow.window))
            {






            }

        }



    }
}
