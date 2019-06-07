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
    class ShipCanoonsConatiner: Drawable
    {
        RectangleShape body;
        Player Usr;
        public List<CardSlot<Cannon>> SlotList = new List<CardSlot<Cannon>>();
        Text ContainerName;

        public ShipCanoonsConatiner(Player _User)
        {
            Usr = _User;

            body = new RectangleShape(new Vector2f(780, 200))
            {
                Position = new Vector2f(10, 230),
                OutlineThickness = 3,
                OutlineColor = new Color(132, 34, 37),
                //Texture= new Texture("Res/UserInt.bmp"),
                FillColor = new Color(131, 57, 57)
            };

            for (int i = 0; i < 9; i++)
            {
                SlotList.Add(new CardSlot<Cannon>(new Vector2f(23 + 85 * i, body.Position.Y + 27), "Res/Cards/Slot.png"));// first row 
            }
            SlotList[0].Disable();
            SlotList[1].Disable();

            for (int i = 0; i < 9; i++)
            {
                SlotList.Add(new CardSlot<Cannon>(new Vector2f(23 + 85 * i, body.Position.Y + 112), "Res/Cards/Slot.png"));// second row
            }

            ContainerName = new Text("Ship Canoons", ObjectsBank.MyFont, 30)
            {
                Color= Color.White
            };

            ContainerName.Origin = new Vector2f(ContainerName.GetLocalBounds().Width / 2, ContainerName.GetLocalBounds().Height / 2);
            ContainerName.Position = body.Position + new Vector2f(body.Size.X / 2, 0);

        }




        public void Draw(RenderTarget window, RenderStates states)
        {
            window.Draw(body);
            window.Draw(ContainerName);
            foreach (CardSlot<Cannon> item in SlotList)
            {
                window.Draw(item);
            }

            foreach (CardSlot<Cannon> item in SlotList)
            {
                if(item.CardInSlot!=null)
                {
                    window.Draw(item.CardInSlot);
                }
            }

        }

    }
}
