using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using SFML;
using GameProject.Elements;

namespace GameProject.Game.Objects
{
    class Map// map which is used by View object- its constructewd by tiles 
    {       // it denfined how map is displayed and constructed
        private int[,] Matrix;
        private RectangleShape AllField;
        public Vector2f ShipPosition;// bay be useless
        private RectangleShape[,] MapStructure;
        private Vector2f StandardTileSize;
        private Player User;
        private uint MaxX, MaxY;// size of map
        private int nr_columns;
        private int nr_rows;

        Texture land;
        Texture error;
        Texture water;


        private List<RectangleShape> TilesOnScreen = new List<RectangleShape>();


        public Map(Player User_)
        {
            User = User_;
            StandardTileSize = new Vector2f(80, 80);

            Matrix = User.MapMatrix;

            nr_columns = Matrix.GetLength(1);
            nr_rows = Matrix.GetLength(0);
            MaxX = (uint)nr_columns * 80;
            MaxY = (uint)nr_rows * 80;
            MapStructure = new RectangleShape[nr_rows, nr_columns];

            //ShipPosition = User.UserShip.PositionOnMap;
            this.LoadTextures();

            CreateMapStructre(nr_columns, nr_rows, Matrix, MapStructure);


        }




        private void CreateMapStructre(int columns, int rows, int[,] Array, RectangleShape[,] MapArray)
        {
            for (int actualRow = 0; actualRow < rows; actualRow++)
            {
                for (int actualColumn = 0; actualColumn < columns; actualColumn++)
                {
                    MapArray[actualRow, actualColumn] = new RectangleShape(StandardTileSize)
                    {
                        Position = new Vector2f(actualColumn * StandardTileSize.X, actualRow * StandardTileSize.Y),
                        Texture = SetTextureOfTile(Array[actualRow, actualColumn])
                    };
                }
            }
        }




        private Texture SetTextureOfTile(int numberInArray) // function for setting texture for all tiles ona map
        {
            switch (numberInArray)
            {
                case 0:
                    {
                        return water;// if the tile is water
                    }
                case 1:
                    {
                        return land;// if the tile is land
                    }
                default:
                    return error;// something gone wrong
            }
        }



         void RenderMap(int nr_columns, int nr_rows)
        {

            for (int i = 0; i < TilesOnScreen.Count; i++)
            {
                MyWindow.window.Draw(TilesOnScreen[i]);
            }
          

        }


        private void LoadTextures()
        {
            land = new Texture("Res/Map/land.bmp");
            water = new Texture("Res/Map/water.bmp");
            error = new Texture("Res/Map/error.bmp");
        }




        public void Render()
        {
            this.RenderMap(nr_columns,nr_rows);
        }





        public void TilesOnWindow(SFML.Graphics.View view)// this function specifiin which tiles should be drawn on descop
        {
            TilesOnScreen.Clear();

            int UpRow = (int)((view.Center.Y - 700 )/ 80);
            int DownRow = (int)((view.Center.Y + 700 )/ 80);

            int LeftColumn = (int)((view.Center.X - 700) / 80);
            int RightColumn = (int)((view.Center.X + 700) / 80);

            if (UpRow < 0) { UpRow = 0; };
            if(DownRow> nr_rows - 1) { DownRow = nr_rows - 1; };

            if (LeftColumn < 0) { LeftColumn = 0; };
            if(RightColumn> nr_columns-1) { RightColumn = nr_columns - 1; };
            

            for (int i =UpRow ; i <= DownRow; i++)
            {
                for (int j = LeftColumn; j <= RightColumn; j++)
                {
                    TilesOnScreen.Add(MapStructure[i, j]);

                }
            }
        }


    }
}
