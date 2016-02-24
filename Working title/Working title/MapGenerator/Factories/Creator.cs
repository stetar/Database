using System;
using Microsoft.Xna.Framework;

namespace Working_title.MapGenerator
{
    public class Creator
    {
        public Vector2 StartPosition { get; protected set; }

        protected Factory Factory;


        public Creator(Factory factory, Vector2 startPosition)
        {
            Factory = factory;
            StartPosition = startPosition;
        }

        public GameObject CreateObject()
        {
            return Factory.CreateObject(this);
        }
    }
}