using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace App.GameObjects
{
    class Checkpoint :GameObject
    {
        public Checkpoint(int x=0, int y=0, bool spawnHero=true)
        {
            texture = LoadAsset(Assets.TILESET);
            this.x = x;
            this.y = y;
         
            this.texWidth  = 64;
            this.texHeight = 64;

            this.texX = 2 * texWidth;

            this.texY = 12 * texHeight;

            if (spawnHero)
                GameObjectManager.Instance.AddGameObject(new Hero(x, (y-(texHeight * 4)) ));
        }

    }
}
