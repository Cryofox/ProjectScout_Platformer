using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework; 
using Microsoft.Xna.Framework.Graphics; //Contains Spritebatch definition
using Microsoft.Xna.Framework.Content;//Contains "Content' Needed for loading in the Assets

using App;
using App.Debug;
using TiledSharp;
using App.GameObjects;
namespace App.Terrains
{
    class Terrain
    {
        CollisionMap collisionMap;
        Texture2D tileSet;
        TmxMap map;

        public TmxMap tmxMap
        {
            get { return map; }
        }

        //The dimensions in pixels of an individual "tile"
        int tileWidth = 0;
        int tileHeight = 0;

        int numTilesWide = 0;
        int numTilesHigh = 0;



        public Terrain(Game1 game, string name=null)
        {
            loadContent(game, name);
        }


        void loadContent(Game1 game, string name = null)
        {

            tileSet = game.Content.Load<Texture2D>(Assets.TILESET);
            if (name == null)
                name = Assets.DATA_TESTROOM_PLATFORM;

            map = new TmxMap(name);
            ExtractObjects();
            collisionMap = CollisionMap.Instance;

            collisionMap.Init(map);


            tileWidth = map.Tilesets[0].TileWidth;
            tileHeight = map.Tilesets[0].TileHeight;

            numTilesWide =  tileSet.Width / tileWidth;
            numTilesHigh = tileSet.Height / tileHeight;

        }
        public void Draw(SpriteBatch spriteBatch)
        {
            int gid = 0;
            uint ugid = 0;
            //we draw the tiles
            //Debugger.Debug_Log("Drawing TileSet");
            for (int i = 0; i < map.Layers[0].Tiles.Count; i++)
            {
                gid = map.Layers[0].Tiles[i].Gid;
                
                if (gid != 0)
                {
                    int tileFrame = gid - 1;
                    int column = tileFrame % numTilesWide;
                    int row = (tileFrame/numTilesWide);

                    float x = (i % map.Width) * map.TileWidth;
                    float y = (float)Math.Floor(i / (double)map.Width) * map.TileHeight;
                    Rectangle tilesetRec;


                    if (map.Layers[0].Tiles[i].HorizontalFlip)
                        tilesetRec = new Rectangle(tileWidth * (column + 1), tileHeight * row, -tileWidth, tileHeight);
                    else
                        tilesetRec = new Rectangle(tileWidth * column, tileHeight * row, tileWidth, tileHeight);


                    //Debugger.Debug_Log("TW-"+ numTilesWide+ ","+numTilesHigh+"-Drawing Tile["+ tileFrame + "] at:" + column + "," + row);
                    spriteBatch.Draw(tileSet, new Rectangle((int)x, (int)y, tileWidth, tileHeight), tilesetRec, Color.White);
                }
            }

            if (Debug.Debugger.debugMode)
            {
               // Debugger.Debug_Log("Drawing Debug Rectangles");

                collisionMap.DrawMap(spriteBatch);
            }

        }

        public void Destroy()
        {
            if (tileSet != null)
                tileSet.Dispose();
        }


        public void ExtractObjects()
        {
            //Here we take out all the objects in the scene that are not to be treated as "tiles" and pull them into 
            //The Manager
            for (int i = 0; i < map.ObjectGroups.Count; i++)
            for (int j =0; j< map.ObjectGroups[i].Objects.Count; j++)
            {
                    TmxObjectGroup.TmxObject obj = map.ObjectGroups[i].Objects[j];
                    if (obj.Name == Assets.PLAYER_START)
                    {
                       // Vector2 worldCoord = collisionMap.MapToWorld(i, j);
                        GameObjectManager.Instance.AddGameObject(new Checkpoint( (int)obj.X, (int)obj.Y- map.TileHeight));
                    }
            }
        }

  
        

    }
}
