using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Working_title.MapGenerator;

namespace Working_title
{
    public class CellSprite : NonCollidingSprite
    {
        private Vector2 DirectionCommingFrom;
        private Vector2 DirectionMovingTo;

        public CellSprite(Vector2 position, Size size,Vector2 directionCommingFrom,Vector2 directionMovingTo) :
            base(position)
        {
            TextureName = "Green";
            TextureSize = size;
            DirectionCommingFrom = directionCommingFrom;
            DirectionMovingTo = directionMovingTo;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            string DirectionString = "";
            DirectionString += GetDirectionLetter(DirectionCommingFrom);
            DirectionString += GetDirectionLetter(DirectionMovingTo);

            spriteBatch.DrawString(Game1.SpriteFonts["StandardFont"], DirectionString, Position,Color.White);
        }

        private string GetDirectionLetter(Vector2 direction)
        {
            if (direction == Vector2.UnitX)
            {
                return "R";
            }
            if (direction == -Vector2.UnitX)
            {
                return "L";
            }
            if (direction == Vector2.UnitY)
            {
                return "U";
            }
            if (direction == -Vector2.UnitY)
            {
                return "D";
            }
            return "";
        }
    }
}