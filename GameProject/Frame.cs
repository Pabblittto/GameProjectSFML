using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.System;
using SFML.Window;



namespace GameProject
{
    /// <summary>
    /// This class specify what items should be displayed
    /// </summary>
    abstract class Frame
    {
        public abstract void Render(MyWindow window);// function for rendering all obiects

        public abstract void CheckEvents(MyWindow window);

         EventHandler<TextEventArgs> TextEntered;
         EventHandler<KeyEventArgs> KeyPressed;//(object sender, KeyEventArgs e);
         EventHandler<KeyEventArgs> KeyReleased;// (object sender, KeyEventArgs e);
         EventHandler<MouseButtonEventArgs> MouseButtonPressed;// (object sender, MouseButtonEventArgs e);
         EventHandler<MouseMoveEventArgs> MouseMoved;// (object sender, MouseMoveEventArgs e);
        /// czyli tak, to  by zadzaiłać , ale w klasie button musiałbym oddzielić funkce sprawdzające zdarzenia , nie wime czy to się opłaca
        /// i później trzeba by cały czas wysyłać obiekt okienka frame gdzie się wykonuje przycisk do samego przycisku żeby ten widział gdzie się znajduje , 
        /// ALE za tao dla wpisywania imienia, uprości się sprawdzanie czy można wczytywać info z klawiatury- zniknie zmienna focus z IEXT inputa
        /// 

    }
}
