using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
namespace App.Debug
{
    class Debugger
    {
        static bool _debugMode = true;


        static bool isDebugSetup = false;
        static LineBatch line;


        public static bool debugMode
        {
            get { return _debugMode; }
            /*
               set 
               {
                  name = value; 
               }
             */
        }


        public static void Toggle_DebugMode()
        {
            _debugMode = !_debugMode;
        }




        public static void Setup_Debugger(Game1 game)
        {
            if (isDebugSetup)
            {
                Debug_Error("Debugger setup already invoked!");
                return;
            }
            line = new LineBatch(game);
            isDebugSetup = true;
           // line = new LineBatch(graphics);
        }
        public static void Debug_Error(string message)
        {
            Console.WriteLine("ERROR:" + message);
            throw new AppException(message);
        }
        public static void Debug_Log(string message)
        {
            Console.WriteLine(message);
        }
    
        public static void Debug_DrawRectangle(Rectangle rect, Color color, SpriteBatch sb)
        {
            if (!_debugMode)
                return;
                //line.Begin();
            //line.DrawOutLineOfRectangle(rect, color);
            //line.End();

            //Draw Bottom Line
            Debug_DrawLine(new Vector2(rect.Left, rect.Bottom), new Vector2(rect.Right, rect.Bottom), color, sb);
            //Draw Top Line
            Debug_DrawLine(new Vector2(rect.Left, rect.Top), new Vector2(rect.Right, rect.Top), color, sb);

            //Draw Left Line
            Debug_DrawLine(new Vector2(rect.Left, rect.Bottom), new Vector2(rect.Left, rect.Top), color, sb);
            //Draw Right Line
            Debug_DrawLine(new Vector2(rect.Right, rect.Bottom), new Vector2(rect.Right, rect.Top), color, sb);
        }

        public static void Debug_DrawCenter(Point position, Color color, SpriteBatch sb)
        {
            Debug_DrawCenter(new Vector2(position.X, position.Y), color, sb);
        }
        public static void Debug_DrawCenter(Vector2 position, Color color, SpriteBatch sb)
        {
            //Take the Point and add a 2 pixel buffer each side
            int pixelBuffer = 2;
            Rectangle rect = new Rectangle((int)position.X - pixelBuffer, (int)position.Y - pixelBuffer, pixelBuffer * 2, pixelBuffer * 2);
            Debug_DrawRectangle(rect, color, sb);

        }

        public static void Debug_DrawLine(Vector2 start, Vector2 end, Color color, SpriteBatch sb)
        {
            if (!_debugMode)
                return;
            line.CreateLineFiles(start, end, 2, color);
            line.DrawLoadedLine(sb);
        }



    }
}
