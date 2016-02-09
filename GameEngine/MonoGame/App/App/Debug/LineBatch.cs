using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;


namespace App.Debug
{
    public class LineBatch
    {
        int loopCounter;
        int lineLegnth;
        Vector2 lineDirection;
        Vector2 _position;
        Color dotColor;
        Rectangle _rectangle;
        List<Texture2D> _dots = new List<Texture2D>();
        FunctionsLibrary functions = new FunctionsLibrary();
        Game1 game;
        public LineBatch(Game1 game)
        {
            this.game = game;
        }




        public void CreateLineFiles(Vector2 startPosition, Vector2 endPosition, int width, Color color)
        {
            dotColor = color;
            _position.X = startPosition.X;
            _position.Y = startPosition.Y;
            lineLegnth = functions.Distance((int)startPosition.X, (int)endPosition.X, (int)startPosition.Y, (int)endPosition.Y);
            lineDirection = new Vector2((endPosition.X - startPosition.X) / lineLegnth, (endPosition.Y - startPosition.Y) / lineLegnth);
            _dots.Clear();
            loopCounter = 0;
            _rectangle = new Rectangle((int)startPosition.X, (int)startPosition.Y, width, width);
            while (loopCounter < lineLegnth)
            {
                Texture2D dot = game.Content.Load<Texture2D>(Assets.PIXEL);
                _dots.Add(dot);

                loopCounter += 1;
            }

        }

        public void DrawLoadedLine(SpriteBatch sb)
        {
            foreach (Texture2D dot in _dots)
            {
                _position.X += lineDirection.X;
                _position.Y += lineDirection.Y;
                _rectangle.X = (int)_position.X;
                _rectangle.Y = (int)_position.Y;
                sb.Draw(dot, _rectangle, dotColor);
            }
        }
    }

    public class FunctionsLibrary
    {
        //Random for all methods
        Random Rand = new Random();

        #region math
        public int TriangleArea1(int bottom, int height)
        {
            int answer = (bottom * height / 2);
            return answer;
        }

        public double TriangleArea2(int A, int B, int C)
        {
            int s = ((A + B + C) / 2);
            double answer = (Math.Sqrt(s * (s - A) * (s - B) * (s - C)));
            return answer;
        }
        public int RectangleArea(int side1, int side2)
        {
            int answer = (side1 * side2);
            return answer;
        }
        public int SquareArea(int side)
        {
            int answer = (side * side);
            return answer;
        }
        public double CircleArea(int diameter)
        {
            double answer = (((diameter / 2) * (diameter / 2)) * Math.PI);
            return answer;
        }
        public int Diference(int A, int B)
        {
            int distance = Math.Abs(A - B);
            return distance;
        }
        #endregion

        #region standardFunctions


        public int RollDice(int sides)
        {

            int result = (Rand.Next(1, sides + 1));
            return result;
        }
        public void ConsoleWelcomeMessage(string gameName, string playerName = "\b")
        {
            Console.WriteLine("Welcome " + playerName + " to " + gameName + "!");

        }
        public string ConsoleGetName()
        {
            Console.WriteLine();
            Console.Write("Type your name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Your name will be: " + name);
            return name;
        }
        public int ConsoleGetDifficulty(int min, int max)
        {
            bool done = false;
            int difficulty = 1;

            Console.WriteLine();
            Console.Write("Choose your difficulty from " + min + " to " + max + ": ");
            while (done == false)
            {
                try
                {
                    string input = Console.ReadLine();
                    difficulty = int.Parse(input);
                    if (difficulty < max + 1 && difficulty > min - 1)
                    {
                        done = true;
                    }
                    else
                    {
                        //Ends the try block with an impossible action (bool.Parse)
                        bool tester = bool.Parse(input);

                    }
                }
                catch
                {
                    Console.Write("Enter a valid number: ");
                }
            }
            Console.WriteLine("Your difficulty will be: " + difficulty);
            return difficulty;
        }

        public int Distance(int x1, int x2, int y1, int y2)
        {
            return (int)(Math.Sqrt((x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2)));
        }

        public void Test()
        {

        }
        #endregion



    }
}