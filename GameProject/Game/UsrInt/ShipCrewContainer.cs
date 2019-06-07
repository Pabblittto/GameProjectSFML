using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameProject.Game.Objects;
using GameProject.Game.Objects.Items;
using GameProject.Elements;
using SFML.System;
using SFML;
using SFML.Window;
using SFML.Graphics;

namespace GameProject.Game.UsrInt
{
    class ShipCrewContainer : Drawable// this will be rectangle containing full/epmty slots with sailors
    {
        RectangleShape body;

        Player Usr;
        List<CardSlot<Sailor>> SlotList = new List<CardSlot<Sailor>>();
        Text ContainerName;


        public ShipCrewContainer(Player _Usr)
        {
            Usr = _Usr;
            body = new RectangleShape(new Vector2f(780, 200))
            {
                Position = new Vector2f(10, 10),
                OutlineThickness = 3,
                OutlineColor = new Color(132, 34, 37),
                //Texture= new Texture("Res/UserInt.bmp"),
                FillColor= new Color(131,57,57)
            };

            for (int i = 0; i < 9; i++)
            {
                SlotList.Add(new CardSlot<Sailor>(new Vector2f(23+85*i,body.Position.Y+27),"Res/Cards/Slot.png"));// first row 
            }

            for (int i = 0; i < 9; i++)
            {
                SlotList.Add(new CardSlot<Sailor>(new Vector2f(23 + 85 * i, body.Position.Y + 112), "Res/Cards/Slot.png"));// second row
            }

            ContainerName = new Text("Ship Crew", ObjectsBank.MyFont, 30)
            {
                Color = Color.White,
            };
            ContainerName.Origin = new Vector2f(ContainerName.GetLocalBounds().Width / 2, ContainerName.GetLocalBounds().Height / 2);
            ContainerName.Position = body.Position + new Vector2f(body.Size.X/2,0);
        }

        public void Draw(RenderTarget window,RenderStates states)
        {
            window.Draw(body);
            window.Draw(ContainerName);

            foreach (CardSlot<Sailor> item in SlotList)
            {
                window.Draw(item);
            }
            

        }



    }
}
