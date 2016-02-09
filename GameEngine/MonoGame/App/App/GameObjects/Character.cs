using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

using App.Terrains;
namespace App.GameObjects
{
    class Character : GameObject
    {
        protected float gravity     = 460;
        protected float yImpulse    = 100;
        protected float xSpeed      = 250;

        //The Velocity of the Character to be applied each Frame
        protected Vector2 velocity = new Vector2(0, 0);

        /*
        protected float speed = 250;
        protected const int GRAVITY = 460;
        protected int jumpForce =  800;

        protected bool jumping = false;
        protected bool grounded = false;
        protected bool maxJumpReached = false;

        protected float currentJumpForce = 0;
        */




        //This method can be overwritten by Inherited Classes
        private bool moveRight = false;
        private bool moveLeft = false;
        private bool grounded = false;

        public override void Update(float deltaTime)
        {
            //This velocity is applied instantaneously through the player
            float xVelocity = 0;
            float yVelocity = gravity * deltaTime;
            if (moveRight)
            {
                xVelocity += xSpeed * deltaTime;
                moveRight = false;
            }
            if (moveLeft)
            {
                xVelocity -= xSpeed * deltaTime;
                moveLeft = false;
            }


            float projectedPosition_X = centerPosition.X + xVelocity;
            //Check if our new Position collides with anything



            //Horizontal Movement
            //Create Rectangle for Horizontal movement
            Rectangle projectectRectangle = new Rectangle((int)projectedPosition_X, (int)this.y, texWidth, texHeight);
            if (!CollisionMap.Instance.isCollision_Against_Tiles(projectectRectangle))
            {
                this.x += xVelocity;
            }

            float projectedPosition_Y = centerPosition.Y + yVelocity;
            //Create Rectangle for Vertical  movement
             projectectRectangle = new Rectangle((int)this.x, (int)projectedPosition_Y, texWidth, texHeight);
            if (!CollisionMap.Instance.isCollision_Against_Tiles(projectectRectangle))
            {
                this.y += yVelocity;
            }
            else
            {
                //Our Y coordinate is probably slightly above or below the ideal spot. Get the exact location from Map
                this.y = CollisionMap.Instance.WorldToTiledWorld(this.x, projectedPosition_Y).Y;
            }
        }

        





        //Controller Entry Points 
        public virtual void Jump()
        {

        }

        public virtual void MoveRight()
        {
            moveRight = true;
           // float newX = this.x + (float)gTime.ElapsedGameTime.TotalSeconds * xSpeed;
           // if (!CollidesOnTile((int)newX, (int)this.y+ texHeight-5))
            //    this.x = newX;
        }
        public virtual void MoveLeft()
        {
            moveLeft = true;
           // float newX = this.x - (float)gTime.ElapsedGameTime.TotalSeconds * xSpeed;
           // if (!CollidesOnTile((int)newX, (int)this.y + texHeight - 5))
           //     this.x = newX;
        }



    }
}
