using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using App.Terrains;
using App.Controllers;
using App.GameObjects;
namespace App.States
{
    class LevelTester : State
    {
        Terrain _terrain;
        PlayerController playerController;

        public void Destroy()
        {
            throw new NotImplementedException();
        }



        public void Init(Game1 game, PlayerController pc)
        {
            if (_terrain == null)
            { 
                _terrain = new Terrain(game, Assets.DATA_TESTROOM_MANEUVER);

            }
            playerController = pc;
        }

        public void Update(float deltaTime)
        {
       
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //Draw BackDrop

            //Draw Tiles
            _terrain.Draw(spriteBatch);

            //Draw Characters

            //Draw Projectiles
        }
    }
}
