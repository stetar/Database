using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Working_title.MapGenerator;

namespace Working_title.UI
{
    public delegate void LoadingBarDoneCallback();

    public abstract class Bar : NonCollidingSprite
    {
        protected float LoadingSpeed = 0.1f;

        protected float WantedLoadingBarProcent;

        protected Size FullSize;

        public Bar(Vector2 position, Size fullSize) :
            base(position)
        {
            FullSize = fullSize;
            TextureSize = new Size(0, FullSize.Height);
            TextureName = "Green";
            LayerDepth = 0.9f;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            if (CurrentLoadingBarProcent() < WantedLoadingBarProcent)
            {
                TextureSize += new Size((int)(LoadingSpeed * DeltaTime), 0);
            }
            if (CurrentLoadingBarProcent() > WantedLoadingBarProcent)
            {
                TextureSize -= new Size((int)(LoadingSpeed * DeltaTime), 0);
            }
        }

        public float CurrentLoadingBarProcent()
        {
            return (float)TextureSize.Width / (float)FullSize.Width;
        }

        public void SetWantedLoadingBarProcent(float loadingBarProcent)
        {
            WantedLoadingBarProcent = loadingBarProcent;
        }

    
    }
}