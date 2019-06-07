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
    class CardSlot<Type> : Slot,Drawable where Type: Card 
    {
        Boolean hovered = false;

        public Boolean avavailable = true;


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

        public override void SetCardIn(Card card)
        {
            CardInSlot = card;

            if (card != null )
            {
                card.SetItemPosition(this.CardPos);
                if(card.Slot != this)
                card.SetCardSlot(this);
            }
        }

         public void Draw(RenderTarget window, RenderStates states)
        {
            window.Draw(shape);
            Functions.DropOnSlot(ObjectsBank.DraggedCard, this);
            
        }

        public void Disable()
        {
            avavailable = false;
            shape.FillColor = new Color(40,29,5);
        }

        public void Unlock()
        {
            avavailable = true;
            shape.FillColor = Color.White;
        }



        public void OnHover()// maybe need to use somewhere
        {
            if (Functions.CheckIfMouseHover(shape.Size, shape.Position, ObjectsBank.window) && hovered == false)// this function run only once, when mouse is hovered on item
            {
                hovered = true;
                shape.FillColor = new Color(173, 173, 173);

            }

            if (!Functions.CheckIfMouseHover(shape.Size, shape.Position, ObjectsBank.window) && hovered == true)// this function run only once, when mouse is hovered out item
            {
                hovered = false;
                shape.FillColor = Color.White;
            }

        }

    }
}
