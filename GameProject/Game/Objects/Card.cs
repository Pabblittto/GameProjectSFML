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
    abstract class Card : Drawable// All items will be presented by "cards"
    {
        Text Info;

        Boolean hovered = false;
        Time TimeOfHover;
       
        private List<String> InfoToDisplay;// its list with info for displaying in additional rectangle, this should be overriden somewhere
        private String AdditionInfo;// this info is some addition informations from me-developer

        Texture Image;
        RectangleShape shape = new RectangleShape(new Vector2f(90, 90));


        RectangleShape InfoShape;
        

        public Card(String Path,String _AdditionalInfo)
        {
            AdditionInfo = _AdditionalInfo;
            Info.Color = Color.Black;
            InfoShape.FillColor = Color.White;
            InfoShape = new RectangleShape();
            
            TimeOfHover = new Time();

            Image = new Texture(Path);
            shape.Texture = Image;
        }



        public void Draw(RenderTarget window, RenderStates states)
        {
            window.Draw(shape);
        }

        public void SetItemPosition(Vector2f position)
        {
            shape.Position = position;
            InfoShape.Position = new Vector2f(shape.Position.X + 45, shape.Position.Y + 45);// setting info rectangle position in the center of card

        }
        /// <summary>
        /// Text need to be set first
        /// </summary>
        private void DrawInfoBox()
        {
            


        }

        public void SetInfo()
        {
            if (Info == null)
            {
                Info = new Text("", MyWindow.MyFont, 20);
            }



        }





        public void OnHover()
        {
               if( Functions.CheckIfMouseHover(shape.Size,shape.Position,MyWindow.window) && hovered==false)// this function run only once, when mouse is hovered on item
            {
                hovered = true;
                shape.FillColor = new Color(173, 173, 173);

            }

            if (!Functions.CheckIfMouseHover(shape.Size, shape.Position, MyWindow.window) && hovered == true)// this function run only once, when mouse is hovered out item
            {
                hovered = false;
                shape.FillColor = Color.White;
                TimeOfHover = Time.Zero;
            }

            if (hovered==true)
            {

                if(TimeOfHover.AsSeconds()>3 )
                {




                }
                else
                {
                    TimeOfHover += Program.clock.ElapsedTime;
                }
            }
        }






    }
}
