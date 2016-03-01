using System.Threading;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Working_title.MapGenerator;

namespace Working_title.Setup
{
    public class MapSetup : WorldSetup
    {


        public override void LoadContent(ContentManager contentManager)
        {
            base.LoadContent(contentManager);
            LoadTexture("UpUp", "Images/UpUp");
            LoadTexture("RightRight", "Images/RightRight");
            LoadTexture("UpRight", "Images/UpRight");
            LoadTexture("UpLeft", "Images/UpLeft");
            LoadTexture("DownLeft", "Images/DownLeft");
            LoadTexture("DownRight", "Images/DownRight");
        }
    }
}