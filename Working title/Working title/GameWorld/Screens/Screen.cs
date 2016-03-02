using System;
using System.Collections.Generic;
using LearningMonoGameGame;
using The_RPG_thread_game.Utillity;

namespace Working_title.Screens
{
    public abstract class Screen
    {
        protected List<GameObject> ScreenObjects = new List<GameObject>();

        protected Action<GameObject> RemoveAction = (gameObject) => Game1.RemoveObjectInNextCycle(gameObject);
        protected Action<GameObject> AddAction = (gameObject) => Game1.AddObjectInNextCycle(gameObject);

        public abstract void Init();

        public virtual void Load()
        {
            ScreenObjects.DoActionOnItems(AddAction);
        }

        public virtual void UnLoad()
        {
            ScreenObjects.DoActionOnItems(RemoveAction);
        }

        protected virtual void AddObjectToLoadingList(GameObject gameObject)
        {
            ScreenObjects.Add(gameObject);
        }
    }
}