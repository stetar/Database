using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Working_title.Combat;
using Working_title.Enemies;
using Working_title.Managers;
using Working_title.MapGenerator;
using Working_title.MoveableClasses.XP;
using Working_title.UI;

namespace Working_title.MoveableClasses
{
    public delegate Vector2 KeyDirection();

    public class Player : AttackingSprite
    {
        private GridObjectMover GridObjectMover;
        private Vector2 LastDirection;

        public List<KeyChecker> MoveableDirections = new List<KeyChecker>()
        {
             new KeyChecker(new List<Keys>(){ Keys.A, Keys.Left },-Vector2.UnitX),
             new KeyChecker(new List<Keys>(){ Keys.D, Keys.Right },Vector2.UnitX),
             new KeyChecker(new List<Keys>(){ Keys.S, Keys.Down }, Vector2.UnitY),
             new KeyChecker(new List<Keys>(){ Keys.W, Keys.Up },  -Vector2.UnitY)
        };

        private float MoveInterval = 250;
        private float NextTimeToMove;
        private PlayerItems PlayerItems;

        public UpdatePlayerStats UpdatePlayerStats { get; }

        public Player(Vector2 position, GridMap gridMap) :
            base(position)
        {
            GridObjectMover = new GridObjectMover(gridMap, this);
            TextureName = "Player";
            TextureSize = new Size(30, 30);
            Game1.AddObjectInNextCycle(new HealthBar(new Size(TextureSize.Width, 10), this, new Vector2(0, -(float)TextureSize.Width / 2)));
            UpdatePlayerStats = new UpdatePlayerStats(this);
            Game1.AddObjectInNextCycle(new XpBar(new Size(150, 30), Game1.Camera, new Vector2(0, 0), UpdatePlayerStats.Level));
            LayerDepth = 1;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            Move();
        }

        public void AddItem(EnemyDropType enemyDropType, PlayerStat playerStat)
        {
            PlayerItems.AddItemIfNotExist(enemyDropType, playerStat);
        }

        private void Move()
        {
            if (GetDirectionMovingIn() != Vector2.Zero && NextTimeToMove < TotalGameTime)
            {
                LastDirection = GetDirectionMovingIn();
                GridObjectMover.Move(LastDirection);
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

        protected override void DoDamage(AttackingSprite attackingSprite)
        {
            if (attackingSprite is Enemy)
            {
                base.DoDamage(attackingSprite);
                GridObjectMover.Move(-LastDirection);
            }
        }

        public override void Die()
        {
            base.Die();
            Game1.CurrentGameState = GameState.MapLoading;
            Game1.RemoveAllObjects();
            GameManager.Level = 1;
        }
    }
}