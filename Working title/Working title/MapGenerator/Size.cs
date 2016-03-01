using System;
using Microsoft.Xna.Framework;

namespace Working_title.MapGenerator
{
    public class Size
    {
        public int Height;
        public int Width;

        public Size(int width, int height)
        {
            Height = height;
            Width = width;
        }


        public static Size operator +(Size size1, Size size2)
        {
            return new Size(size1.Width + size2.Width, size1.Height + size2.Height);
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
            return new Vector2(Width,Height);
        }

        public Point ToPoint()
        {
            return new Point(Width, Height);
        }

        public bool IsEmpty()
        {
            return Height == 0 && Width == 0;
        }

        public static Size GetRandomSize(Size minSize, Size maxSize)
        {
            Random Random = new Random();
            int RandomWidth = Random.Next(minSize.Width, maxSize.Width);
            int RandomHeight = Random.Next(minSize.Height, maxSize.Height);

            return new Size(RandomWidth, RandomHeight);
        }

    }
}