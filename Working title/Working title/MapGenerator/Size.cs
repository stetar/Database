using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Working_title.MapGenerator
{
    public class Size
    {
        public int Height;
        public int Width;
        private static Size RandomSize = new Size(0, 0);

        public Size(int width, int height)
        {
            Height = height;
            Width = width;
        }


        public static Size operator +(Size size1, Size size2)
        {
            return new Size(size1.Width + size2.Width, size1.Height + size2.Height);
        }

        public static Size operator -(Size size1, Size size2)
        {
            return new Size(size1.Width - size2.Width, size1.Height - size2.Height);
        }

        public static Size operator *(Size size1, Size size2)
        {
            return new Size(size1.Width * size2.Width, size1.Height * size2.Height);
        }

        public static Size operator /(Size size1, Size size2)
        {
            return new Size(size1.Width / size2.Width, size1.Height / size2.Height);
        }

        public static Size operator *(Size size1, float multiplier)
        {
            return new Size((int)(size1.Width * multiplier), (int)(size1.Height * multiplier));
        }

        public Vector2 ToVector2()
        {
            return new Vector2(Width ,Height);
        }

        public Point ToPoint()
        {
            return new Point(Width, Height);
        }

        public bool IsEmpty()
        {
            return Height == 0 && Width == 0;
        }

        public static Size GetRandomSize(Size minSize, Size maxSize,Random random)
        {
            int RandomWidth = random.Next(minSize.Width, maxSize.Width);
            int RandomHeight = random.Next(minSize.Height, maxSize.Height);
            RandomSize.Width = RandomWidth;
            RandomSize.Height = RandomHeight;
            
            return (Size)RandomSize.MemberwiseClone();
        }

        public List<Vector2> Positions(Vector2 upLeftCornerPosition)
        {
            List<Vector2> Positions = new List<Vector2>();

            Vector2 StartPosition = upLeftCornerPosition;

            for (int X = 0; X < Width; X++)
            {
                for (int Y = 0; Y < Height; Y++)
                {
                    Positions.Add(new Vector2((int)StartPosition.X + X, (int)StartPosition.Y + Y));
                }
            }

            return Positions;
        }


        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}