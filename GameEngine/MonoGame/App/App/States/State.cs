using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework; //Contains "Content' Needed for loading in the Assets
using Microsoft.Xna.Framework.Graphics; //Contains Spritebatch definition

using App.Controllers;
namespace App.States
{
    interface State
    {
        //Update Logic
         void Update(float deltaTime);
        //Draw Logic
         void Draw(SpriteBatch spriteBatch);
        //init Logic
        void Init(Game1 game, PlayerController pc);
        //Destroy Logic, cleanup
        void Destroy();

    }
}
