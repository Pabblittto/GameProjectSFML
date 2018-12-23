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
using System.Collections.Concurrent;

namespace GameProject.Game.Objects
{
    class Map// map which is used by View object- its constructewd by tiles 
    {       // it denfined how map is displayed and constructed
        private int[,] Matrix;
        private RectangleShape AllField;
        public Vector2f ShipPosition;// bay be useless

        public MyTile[,] MapStructure;// this need to be switched to private
        private Vector2f StandardTileSize;
        private Player User;
        private uint MaxX, MaxY;// size of map
        private int nr_columns;
        private int nr_rows;

        Texture land;
        Texture shallow;
        Texture water;
        Texture error;


        public ConcurrentBag<RectangleShape> TilesOnScreen = new ConcurrentBag<RectangleShape>();
        public ConcurrentBag<RectangleShape> TilesToColision = new ConcurrentBag<RectangleShape>();

        int UpRow;
        int DownRow;

        int LeftColumn;
        int RightColumn;


        public Map(Player User_)
        {
            User = User_;
            StandardTileSize = new Vector2f(80, 80);

            Matrix = User.MapMatrix;

            nr_columns = Matrix.GetLength(1);
            nr_rows = Matrix.GetLength(0);
            MaxX = (uint)nr_columns * 80;
            MaxY = (uint)nr_rows * 80;
            MapStructure = new MyTile[nr_rows, nr_columns];

            //ShipPosition = User.UserShip.PositionOnMap;
            this.LoadTextures();

            CreateMapStructre(nr_columns, nr_rows, Matrix, MapStructure);

            

        }




        private void CreateMapStructre(int columns, int rows, int[,] Array, MyTile[,] MapArray)
        {
            for (int actualRow = 0; actualRow < rows; actualRow++)
            {
                for (int actualColumn = 0; actualColumn < columns; actualColumn++)
                {
                    MapArray[actualRow, actualColumn] = new MyTile(StandardTileSize, Array[actualRow, actualColumn])
                    {
                        Position = new Vector2f(actualColumn * StandardTileSize.X, actualRow * StandardTileSize.Y),
                        Texture = SetTextureOfTile(Array[actualRow, actualColumn]),
                        type = Array[actualRow, actualColumn]
                    };
                    MapArray[actualRow, actualColumn].SetPunish();
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
                        return shallow;// if the tile is land
                    }
                case 2:
                    {
                        return land;// if the tile is land
                    }

                default:
                    return error;// something gone wrong
            }
        }



         void RenderMap(int nr_columns, int nr_rows)
        {

            foreach (RectangleShape item in TilesOnScreen)
            {
                ObjectsBank.window.Draw(item);
            }
        }


        private void LoadTextures()
        {
            land = ObjectsBank.land;
            water = ObjectsBank.water;
            error = ObjectsBank.error;
            shallow = ObjectsBank.shallow;
        }




        public void Render()
        {
            this.RenderMap(nr_columns,nr_rows);
        }


        public void TilesToCheckColision(SFML.Graphics.View view)           // need additional if , if tile is  land (or city) or mielizna  add to list !!!
        {                                                                           // one additional if will be excecudet on about 10 tiles so t is not very hard
            TilesToColision = new ConcurrentBag<RectangleShape>();
            int squareColision = 40;

            UpRow = (int)((view.Center.Y - squareColision) / 80);
            DownRow = (int)((view.Center.Y + squareColision) / 80);

            LeftColumn = (int)((view.Center.X - squareColision) / 80);
            RightColumn = (int)((view.Center.X + squareColision) / 80);

            if (UpRow < 0) { UpRow = 0; };
            if (DownRow > nr_rows - 1) { DownRow = nr_rows - 1; };

            if (LeftColumn < 0) { LeftColumn = 0; };
            if (RightColumn > nr_columns - 1) { RightColumn = nr_columns - 1; };

            for (int i = UpRow; i <= DownRow; i++)
            {
                for (int j = LeftColumn; j <= RightColumn; j++)
                {
                    if (MapStructure[i, j].type > 0)// becouse 0 means pure water, so look for anything but water
                        TilesToColision.Add(MapStructure[i, j]);

                }
            }

        }


        public void TilesOnWindow(SFML.Graphics.View view)// this function specifiin which tiles should be drawn on descop
        {
            TilesOnScreen = new ConcurrentBag<RectangleShape>();// clearing bag
            int squareside = 700;

             UpRow = (int)((view.Center.Y - squareside) / 80);
             DownRow = (int)((view.Center.Y + squareside) / 80);

             LeftColumn = (int)((view.Center.X - squareside) / 80);
             RightColumn = (int)((view.Center.X + squareside) / 80);

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
