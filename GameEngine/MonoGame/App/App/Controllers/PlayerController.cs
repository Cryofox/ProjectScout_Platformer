using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using App.GameObjects;
namespace App.Controllers
{


    class PlayerController
    {
        Character character;

        public static readonly Camera camera = new Camera();
        KeyboardState keyboard;
        KeyboardState last_keyboard;
        const float speed = 10;


        public PlayerController()
        {

        }
        public void LinkControls(Character go)
        {
            character = go;
//            camera.CenterOn(character.centerPosition);
        }
        public void Update(float deltaTime)
        {
            //Move(gameTime);
            if(character!=null)
            {
                Move();
                //Center on Characters CenterPosition 
                camera.CenterOn(character.centerPosition);
                
            }
           // Debug.Debugger.Debug_Log("CenterPosition=" + character.centerPosition);
        }


        void Move()
        {
            keyboard = Keyboard.GetState();
         // Vector2 direction = new Vector2(0, 0);
            if (keyboard.IsKeyDown(Keys.A))
            {
                character.MoveLeft();
            }
            if (keyboard.IsKeyDown(Keys.D))
            {
                character.MoveRight();
            }
            if (keyboard.IsKeyDown(Keys.Space)
                && last_keyboard.IsKeyUp(Keys.Space))

                character.Jump();
            //   if (keyboard.IsKeyDown(Keys.S))
            //   {
            //        direction.Y += 1;
            //    }
            //   if (keyboard.IsKeyDown(Keys.W))
            //   {
            //       direction.Y += -1;
            //   }
            ///   direction.X *= speed;
            //   direction.Y *= speed;

            //  character.position += direction;


            //    Debugger.Debug_Log("Moving in:" + direction);
            last_keyboard = keyboard;
        }





    }
}
