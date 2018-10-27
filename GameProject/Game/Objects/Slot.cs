using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject.Game.Objects
{
    abstract class Slot
    {

        public abstract void SetCardIn(Card card);
        // this is empty class i am using it to be able to make variable, which contains any kind of generic class CardSlot
        // preety clever :P
    }
}
