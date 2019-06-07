using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameProject.Elements;
using SFML.System;



namespace GameProject.Game.Objects.Items
{
    class Cannon: Card
    {
        int Class;
        int damage;
        float Price;
        float TimeOfLoading;

        public Cannon(String Path, String AdditionalInfo, float price, int _Damage, float _TimeofLoading,int _Class) : base(Path,AdditionalInfo)
        {
            Price = price;
            damage = _Damage;
            TimeOfLoading = _TimeofLoading;
            Class = _Class;

            InfoToDisplay = new List<string>() {"Cannon","","Class",Class.ToString(),"Damage",damage.ToString(),"Price",Price.ToString(),"Time of Loading(sec)",TimeOfLoading.ToString() };
            this.SetInfo();
        }
    }
}
