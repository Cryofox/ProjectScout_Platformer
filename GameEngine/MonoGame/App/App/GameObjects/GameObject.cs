using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace App.GameObjects
{
    class GameObject
    {

        protected Texture2D texture;
        protected int texX = 0;
        protected int texY = 0;
        protected int texWidth = 0;
        protected int texHeight = 0;

        protected float x = 0;
        protected float y = 0;

        protected ContentManager content;


        public Vector2 position {
            get { return new Vector2((int)x,(int)y); }
        }
        public Vector2 centerPosition
        {
            get { return new Vector2( (int)(x+ texWidth/2),(int)(y+texHeight/2)); }
        }

        public Rectangle collisionBox
        {
            get { return new Rectangle((int)this.x,(int)this.y, texWidth, texHeight); }
        }




        /* public GameObject(ContentManager content)
         {
             this.content = content;
         }*/

        //This method can be overwritten by Inherited Classes
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            if (texture != null)
            {
                Rectangle dest_Rect = new Rectangle((int)x, (int)(y), texWidth, texHeight);
                Rectangle texture_rect = new Rectangle(texX, texY, texWidth, texHeight);
                spriteBatch.Draw(texture, dest_Rect, texture_rect, Color.White);

                Debug.Debugger.Debug_DrawRectangle( collisionBox, Color.Aqua, spriteBatch);
                Debug.Debugger.Debug_DrawCenter(position, Color.Orange, spriteBatch);
                Debug.Debugger.Debug_DrawCenter(centerPosition, Color.Aqua, spriteBatch);

            }
        }

        //This method can be overwritten by Inherited Classes
        public virtual void Update(float deltaTime)
        {}


        protected Texture2D LoadAsset(string name)
        {
            return GameObjectManager.Instance.content.Load<Texture2D>(name);
        }





       

    }
}
