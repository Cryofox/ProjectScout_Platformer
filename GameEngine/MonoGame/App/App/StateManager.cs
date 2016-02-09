using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework; //Contains "Content' Needed for loading in the Assets
using Microsoft.Xna.Framework.Graphics; //Contains Spritebatch definition
using Microsoft.Xna.Framework.Content;


using App.States;
using App.Controllers;
using App.Debug;
using App.GameObjects;
namespace App
{
    sealed class StateManager
    {

        Game1 _game;
        State activeState;
        PlayerController playerController;
        public static bool showDebug = false;

        public static void ToggleDebug()
        {
            showDebug = !showDebug;
        }

        //Singleton Constructor
        private static readonly StateManager instance = new StateManager();
        private StateManager() { }

        public static StateManager Instance
        {
            get
            {
                return instance;
            }
        }

        public void Init(Game1 game)
        {
            _game = game;
            //Setup the Content in the Manager
            GameObjectManager.Instance.Init(game.Content);

            playerController = new PlayerController();
        }

        public void LinkPlayerController(Character go)
        {
            playerController.LinkControls(go);
        }

        public void SwitchState(State changeTo)
        {
            //Destroy the Current State
            if(activeState!= null)
                activeState.Destroy();

            //Setup new State
            activeState = changeTo;
            Debugger.Debug_Log("Initializing State-" + changeTo.GetType().Name);
            activeState.Init(_game, playerController);
    
        }
       

        public void Update(float deltaTime)
        {
            float maxTime = 0.05f;
            //Throttle Delta Time to 1second MAX intervals
            float timeInterval = 0;
            while (deltaTime > 0)
            {
                timeInterval = Math.Min(maxTime, deltaTime);
                deltaTime -= timeInterval;

                if (activeState != null)
                {
                    activeState.Update(timeInterval);
                    GameObjectManager.Instance.Update(timeInterval);
                    playerController.Update(timeInterval);
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //spriteBatch.Draw()
            if (activeState != null)
                activeState.Draw(spriteBatch);

            //Draw GameObjects Now
            GameObjectManager.Instance.Draw(spriteBatch);
        }


    }
}
