using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
namespace App.GameObjects
{
    sealed class GameObjectManager
    {
        List<GameObject> objects;
        ContentManager _content;



        //Singleton Constructor
        private static readonly GameObjectManager instance = new GameObjectManager();
        private GameObjectManager() { }

        public static GameObjectManager Instance
        {
            get
            {
                return instance;
            }
        }
        

        //Accessors
        public ContentManager content
        {
            get { return _content; }
        }


        //Logic
        public void Init(ContentManager content)
        {
            this._content = content;
            objects = new List<GameObject>();
        }



        public void AddGameObject(GameObject go)
        {
            if (go.GetType().Name == "Hero")
            {
                //Link PlayerController to this.
                StateManager.Instance.LinkPlayerController((Character)go);
            }
            objects.Add(go);
        }

        public void Update(float deltaTime)
        {
            for (int i = 0; i < objects.Count; i++)
            {
                objects[i].Update(deltaTime);
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < objects.Count; i++)
            {
                objects[i].Draw(spriteBatch);
            }
        }





        public void Clear()
        {

            objects.Clear();
        }
    }
}
