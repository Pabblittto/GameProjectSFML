using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.System;
using SFML;
using SFML.Window;
using GameProject.Game.Objects;


namespace GameProject.Elements
{
    static class  Functions
    {




        /// <summary>
        /// this function set position of card, if it is dropped on slot
        /// </summary>
        public static void DropOnSlot<Type>(Card card, CardSlot<Type> cardSlot) where Type: Card
        {
            if (card!=null && card.GetType()==typeof(Type) && !Mouse.IsButtonPressed(Mouse.Button.Left)) {
                Vector2f SlotCenter = cardSlot.shape.Position + new Vector2f(36, 36);
                Vector2f CardCenter = card.shape.Position + new Vector2f(35, 35);

                if (DistBetwPoints(SlotCenter, CardCenter) < MyWindow.MaxDistanceSlot_Card)
                {
                    if (cardSlot.CardInSlot != null)// if there is some card in this slot- chanege places
                    {
                        Card tmpCard = cardSlot.CardInSlot;
                        //CardSlot<Card> slot = card.Slot;

                        //slot.SetCardIn(tmpCard);
                        //tmpCard.SetCardSlot(slot);
                    }
                    else
                        //card.Slot.SetCardIn(null);

                    cardSlot.SetCardIn(card);
                    card.SetCardSlot(cardSlot);// ZDECYDOWANIE POTRZEBA takieej funkcji !!!! trzeba pomyśleć
                }
            }
        }


        public static float DistBetwPoints(Vector2f P1, Vector2f P2)
        {
            return (int)(Math.Sqrt(Math.Pow((P1.X - P2.X),2) + Math.Pow((P1.Y - P2.Y),2)));
        }




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
