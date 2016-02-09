using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace App.GameObjects
{
    class Hero : Character
    {
        public Hero(int x = 0, int y = 0)
        {
            texture = LoadAsset(Assets.HERO);
            this.x = x;
            this.y = y;

            this.texWidth = 64;
            this.texHeight = 64;

            this.texX = 0 * texWidth;

            this.texY = 0 * texHeight;

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }

    }
}
