using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TiledSharp;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using App.Debug;
namespace App.Terrains
{
    /*
        This class is for containing all data needed for collision within the environment.

    */
    sealed class CollisionMap
    {
        int _width = 0;
        int _height = 0;
        int _tileWidth = 0;

        //Collision Map for Tiles
        Tile[][] tiles;

        TmxMap _TileMap;

        //Singleton Constructor
        private static readonly CollisionMap instance = new CollisionMap();
        private CollisionMap() { }

        public static CollisionMap Instance
        {
            get
            {
                return instance;
            }
        }

        public void Init(TmxMap tileMap)
        {
            _TileMap = tileMap;
            _width = _TileMap.Width;
            _height = _TileMap.Height;

            if (tiles != null)
                tiles = null;

            SetupMap();
        }

        void SetupMap()
        {
            int gid = 0;
            int i = 0;
            tiles = new Tile[_TileMap.Width][];

            for (int x = 0; x < _TileMap.Width; x++)
            {
                tiles[x] = new Tile[_TileMap.Height]; 
                for (int y = 0; y < _TileMap.Height; y++)
                {
                    i = x + y * _TileMap.Width;

                    Vector2 worldP = MapToWorld(x, y);
                    Vector2 worldCoords = MapToWorld(x, y);
                    Rectangle tileRect = new Rectangle((int)worldP.X, (int)worldP.Y, _TileMap.TileWidth, _TileMap.TileHeight);

                    //Debugger.Debug_Log("[" + x + "," + y + "]=" + i);
                    if (_TileMap.Layers[0].Tiles[i].Gid >0)
                    {

                        tiles[x][y] = new Tile(true,tileRect);
                    }
                    else
                    {
                        tiles[x][y] = new Tile(false, tileRect);
                    }
                }
            }
        }

        public Vector2 WorldToTiledWorld(float worldX, float worldY)
        {
            return WorldToTiledWorld((int)worldX, (int)worldY);
        }
        public Vector2 WorldToTiledWorld(int worldX, int worldY)
        {
            //Due to using ints decimals will be lost :)
            int x = worldX / _TileMap.TileWidth  * _TileMap.TileWidth;
            int y = worldY / _TileMap.TileHeight * _TileMap.TileHeight;
            return new Vector2(x, y);
        }

        public Vector2 WorldToMap(int worldX, int worldY)
        {
            int x = worldX / _TileMap.TileWidth;
            int y = worldY / _TileMap.TileHeight;
            return new Vector2(x, y);
        }

        public Vector2 MapToWorld(int mapX, int mapY)
        {
            int x = mapX * _TileMap.TileWidth;
            int y = mapY * _TileMap.TileHeight;
            return new Vector2(x, y);
        }

       

      
        public void DrawMap(SpriteBatch spriteBatch)
        {
            Rectangle rect;
            for (int x = 0; x < _TileMap.Width; x++)
                for (int y = 0; y < _TileMap.Height; y++)
                {
                    if (tiles[x][y].isCollidable)
                    {
                        //Draw Collision Rectangle
                        Debug.Debugger.Debug_DrawRectangle(tiles[x][y].collisionBox, Color.Red, spriteBatch);
                        //Draw Origin
                        Debug.Debugger.Debug_DrawCenter(tiles[x][y].collisionBox.Center, Color.Orange, spriteBatch);
                    }

                }
        }








        //Casts to int from floats
        public bool isCollision_Against_Tiles(float worldX, float worldY)
        {
            return isCollision_Against_Tiles((int)worldX, (int)worldY);
        }

        public bool isCollision_Against_Tiles(int worldX, int worldY)
        {
            Vector2 local = WorldToMap(worldX, worldY);

            //If we are outside our tile's boundaries
            if (worldX < 0 || worldX > _TileMap.TileWidth * _TileMap.Width)
                return false;
            if (worldY < 0 || worldY > _TileMap.TileHeight * _TileMap.Height)
                return false;

            //

            return tiles[(int)local.X][(int)local.Y].isCollidable; 
        }

        public bool isCollision_Against_Tiles(Rectangle characterBox)
        {
            Vector2 local = WorldToMap(characterBox.Center.X, characterBox.Center.Y);

            //If we are outside our tile's boundaries
            if (characterBox.X < 0 || characterBox.X > _TileMap.TileWidth * _TileMap.Width)
                return false;
            if (characterBox.Y < 0 || characterBox.Y > _TileMap.TileHeight * _TileMap.Height)
                return false;

            //Create the Rectangle representing this node

            //Check the Tile itself
            /* if (tiles[(int)local.X][(int)local.Y].isCollidable)
             {
                 Vector2 worldP = MapToWorld((int)local.X, (int)local.Y);
                 Rectangle tileRect = new Rectangle((int)worldP.X, (int)worldP.Y, _TileMap.TileWidth, _TileMap.TileHeight);


                 return tileRect.Intersects(characterBox);
             }*/

            //Check Tile + Surrounding tiles
            return
            (
                (collisionHelper(characterBox, local.X, local.Y))// ||
                //Bottom Tile
       //         (collisionHelper(characterBox, local.X, local.Y+1)) ||
                //Top Tile
         //       (collisionHelper(characterBox, local.X, local.Y-1)) ||
                //Right Tile
          //      (collisionHelper(characterBox, local.X+1, local.Y)) ||
                //Left Tile
         //       (collisionHelper(characterBox, local.X-1, local.Y)) 

            );



        }

        bool collisionHelper(Rectangle characterBox, float localX, float localY)
        {
            return collisionHelper(characterBox, (int)localX, (int)localY);
        }
        bool collisionHelper(Rectangle characterBox, int localX, int localY)
        {
            if (tiles[localX][localY].isCollidable)
            { 
                Vector2 worldP = MapToWorld(localX, localY);
                Rectangle tileRect = new Rectangle((int)worldP.X, (int)worldP.Y, _TileMap.TileWidth, _TileMap.TileHeight);

                return tileRect.Intersects(characterBox);
            }
            return false;
        }


        //The information contained at each position
        struct Tile
        {
            public Rectangle collisionBox;
            public bool isCollidable;
           // public Rectangle boundingRect;
            public Tile(bool isCollidable, Rectangle collisionBox)
            {
                this.collisionBox = collisionBox;
                //this.boundingRect = boundingRect;
                this.isCollidable = isCollidable;
            }
        }

        //An enum representing all the possible combinations of Collisions
        public enum CollisionSides
        {
            None    =0,
            Bot     =1,
            Top     =2,
            Left    =3,
            Right   =4,

            Top_Right,
            Top_Left,
            Top_Bot,

            Bot_Left,
            Bot_Right,

            Left_Right
        }
    }
}
