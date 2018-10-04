using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.System;
using GameProject.Elements;

namespace GameProject.Game.Objects
{
      class Cargo: Card 
    {
        String Name;
        float Price;
        uint AmountOfCArgo;



        public Cargo(String Path,String AdditionalInfo, String nameOfCargo, float price,uint amount):base(Path,AdditionalInfo) 
        {
            Name = nameOfCargo;
            Price = price;
            AmountOfCArgo = amount;
            InfoToDisplay = new List<string>() {"Item","","Name",Name,"Price",Price.ToString(),"Amount",AmountOfCArgo.ToString()};
            this.SetInfo();

        }

    }
}
