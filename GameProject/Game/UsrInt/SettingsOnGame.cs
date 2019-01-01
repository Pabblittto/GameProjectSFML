using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using SFML.Audio;
using GameProject.Elements;

namespace GameProject.Game.UsrInt
{
    class SettingsOnGame :Drawable //red rectangle with exit and save button, which can be called in game
    {
        Boolean active = false;
        Button SaveAndClose;// close entire game

        //Button2 SaveAndClose;// close entire game
        Button Close;// close info windwo
        //Button2 Close; // close this info window
        Button SaveAndMenu;// save and back to menu
        RectangleShape shape;

        public SettingsOnGame(Player User)
        {
            Vector2f temp = new Vector2f(500, 100);
            shape = new RectangleShape(temp)
            {
                OutlineColor = Color.Black,
                OutlineThickness = 5,
                Origin = new Vector2f(temp.X / 2, temp.Y / 2),
                Position= new Vector2f(ObjectsBank.window.Size.X/2, ObjectsBank.window.Size.Y/2),
                FillColor= new Color(184,111,111,67)
            };

            Close = new Button(new Vector2f(this.shape.Position.X + 215, this.shape.Position.Y - 45), new Vector2f(30, 38), Color.Red, new Color(137, 4, 4), ObjectsBank.MyFont, "X", 30, null, 2);
            Close.SetOneFunction(SetDesactive);
            SaveAndClose = new Button(new Vector2f(this.shape.Position.X - 240, this.shape.Position.Y - 10), new Vector2f(200, 50), new Color(0, 250, 255), new Color(0, 152, 155), ObjectsBank.MyFont, "Save & Exit", 30, null, 2);

            SaveAndClose.AddingAdditionalFunction(User.Save);
            SaveAndClose.AddingAdditionalFunction(ObjectsBank.window.CloseThis);//


        }

        public void SetDesactive()
        {
            active = false;
            ObjectsBank.ClockPause = false;
        }

        public void SetActive()//this string is required becoues of button2 way of working
        {
            active = true;
        }


        public void Draw(RenderTarget window, RenderStates States)
        {
            if (active == true)
            {
                window.Draw(shape);
                window.Draw(Close);
                window.Draw(SaveAndClose);

            }

        }



    }
}
