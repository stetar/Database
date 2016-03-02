using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Working_title.MapGenerator;

namespace Working_title.MoveableClasses
{
    public delegate Vector2 KeyDirection();

    public class Player : NonCollidingSprite
    {
        private GridObjectMover GridObjectMover;
        public List<KeyChecker> MoveableDirections = new List<KeyChecker>()
        {
             new KeyChecker(new List<Keys>(){ Keys.A, Keys.Left },-Vector2.UnitX),
             new KeyChecker(new List<Keys>(){ Keys.D, Keys.Right },Vector2.UnitX),
             new KeyChecker(new List<Keys>(){ Keys.S, Keys.Down }, Vector2.UnitY),
             new KeyChecker(new List<Keys>(){ Keys.W, Keys.Up },  -Vector2.UnitY)
        };

        private float MoveInterval = 250;
        private float NextTimeToMove;

        public Player(Vector2 position, GridMap gridMap) :
            base(position)
        {
            GridObjectMover = new GridObjectMover(gridMap, this);
            TextureName = "Player";
            TextureSize = new Size(30, 30);
            LayerDepth = 1;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            Move();
        }

        private void Move()
        {
            if (GetDirectionMovingIn() != Vector2.Zero && NextTimeToMove < TotalGameTime)
            {
                GridObjectMover.Move(GetDirectionMovingIn());
                NextTimeToMove = TotalGameTime + MoveInterval;
            }
            Game1.Camera.SetCenterPosition(Position);
        }

        private Vector2 GetDirectionMovingIn()
        {
            foreach (var MoveableDirection in MoveableDirections)
            {
                if (MoveableDirection.KeysPressedDown().Count > 0)
                {
                    return MoveableDirection.KeysPressedDown()[0].Direction;
                }
            }

            return Vector2.Zero;
        }
    }
}