using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.System;
using SFML.Window;
using SFML.Graphics;
using GameProject.Elements;
using GameProject.Game.Objects;

namespace GameProject.Game.Objects
{
    class CardSlot<Type> : Drawable where Type: Card  
    {
        public RectangleShape shape;
        private Vector2f Pos;
        public Vector2f CardPos;// this position will be taken by card
        public Card CardInSlot = null;
        
       
        public CardSlot(Vector2f position,string TexturePath)
        {
            Texture temp = new Texture(TexturePath);
            Pos = position;
            CardPos = Pos+ new Vector2f(1,1);


            shape = new RectangleShape(new Vector2f(72, 72))
            {
                Position = Pos,
                Texture = new Texture(temp),
                OutlineColor = Color.Black,
                OutlineThickness = 3,
            };
        }

        public void SetCardIn(Card card)
        {
            CardInSlot = card;

            if (card != null)
            {
                card.SetItemPosition(this.CardPos);
            }
        }

         public void Draw(RenderTarget window, RenderStates states)
        {
            window.Draw(shape);
            Functions.DropOnSlot(MyWindow.DraggedCard, this);
        }
    }
}
