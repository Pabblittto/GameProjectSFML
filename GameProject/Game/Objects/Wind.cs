using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.System;
using SFML.Window;
using SFML.Graphics;
using GameProject.Elements;

namespace GameProject.Game.Objects
{
    class Wind : Drawable// object represneting wind 
    {
        //letters///////////////
        RectangleShape NL = new RectangleShape(new Vector2f(25, 29))
        {
            Texture = ObjectsBank.LettersToCompas,
            TextureRect= new IntRect(0,0,25,29),
        };
        RectangleShape SL = new RectangleShape(new Vector2f(20, 29))
        {
            Texture = ObjectsBank.LettersToCompas,
            TextureRect = new IntRect(25, 0, 20, 29)
        };
        RectangleShape WL = new RectangleShape(new Vector2f(31, 29))
        {
            Texture = ObjectsBank.LettersToCompas,
            TextureRect = new IntRect(46, 0, 31, 29)
        };
        RectangleShape EL = new RectangleShape(new Vector2f(21, 29))
        {
            Texture = ObjectsBank.LettersToCompas,
            TextureRect = new IntRect(77, 0, 21, 29)
        };
        // letters//////////////////////////////


        Vector2f vectorPointingN;// obracając wektor dzieki funkcji w Functions 
        Vector2f PositionOnWindow;
        public Vector2f VectorOfWind;// direction , always need to have lenght=1
        float valueOfWind;
        Text ValueofWindText;

        RectangleShape shape = new RectangleShape(new Vector2f(160, 160))
        {
            Texture = ObjectsBank.WindRose,// this one need position too
            Origin = new Vector2f(80, 80)
        };

        RectangleShape arrowInShape = new RectangleShape(new Vector2f(27, 51))// this need to set position!!!!
        {
            Texture = ObjectsBank.WindArrow,
            Origin= new Vector2f(14,51)
        };




        public Wind(Vector2f _positionOnwindow)
        {
            shape.Position = _positionOnwindow;
            arrowInShape.Position = _positionOnwindow;

            NL.Origin = Functions.CenterOfRectangle(NL);
            SL.Origin = Functions.CenterOfRectangle(SL);
            WL.Origin = Functions.CenterOfRectangle(WL);
            EL.Origin = Functions.CenterOfRectangle(EL);

            vectorPointingN = new Vector2f(0, -60);
            PositionOnWindow = _positionOnwindow;

            NL.Position = PositionOnWindow + vectorPointingN;
            SL.Position = PositionOnWindow + Functions.RotateVector(vectorPointingN, 180);
            WL.Position = PositionOnWindow + Functions.RotateVector(vectorPointingN, 270);
            EL.Position = PositionOnWindow + Functions.RotateVector(vectorPointingN, 90);

            VectorOfWind = new Vector2f(1, 0);
            valueOfWind = 10.1f;
            ValueofWindText = new Text(valueOfWind.ToString(), ObjectsBank.MyFont, 30);
            ValueofWindText.Origin = new Vector2f(20, 15);
        }

        public void Draw(RenderTarget window,RenderStates states)
        {
            window.Draw(shape);
            window.Draw(arrowInShape);
            window.Draw(EL);
            window.Draw(SL);
            window.Draw(WL);
            window.Draw(NL);
            window.Draw(ValueofWindText);
        }

        /// <summary>
        /// function to control value of the wind
        /// </summary>
        /// <param name="a"></param>
        public void AddToValue(float a)
        {
            valueOfWind += a;
        }



        public void Update(float degree)
        {
            Vector2f temp = Functions.RotateVector(this.vectorPointingN,  degree);

            NL.Position = PositionOnWindow + temp;
            SL.Position = PositionOnWindow + Functions.RotateVector(temp, 180);
            WL.Position = PositionOnWindow + Functions.RotateVector(temp, 270);
            EL.Position = PositionOnWindow + Functions.RotateVector(temp, 90);
            arrowInShape.Rotation = degree;

            arrowInShape.Rotation= (float)Math.Atan2(VectorOfWind.Y , VectorOfWind.X) * 180 / (float)Math.PI + degree;


            ValueofWindText.Position = PositionOnWindow;
            ValueofWindText.DisplayedString = valueOfWind.ToString();

        }
    }
}
