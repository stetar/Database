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
            LoadTexture("UpUp", "Images/Tiles/Up and Down");
            LoadTexture("RightRight", "Images/Tiles/Left and Right");
            LoadTexture("UpRight", "Images/Tiles/Down and Right");
            LoadTexture("UpLeft", "Images/Tiles/Down and Left");
            LoadTexture("DownLeft", "Images/Tiles/Up and Left");
            LoadTexture("DownRight", "Images/Tiles/Up and Right");
            LoadTexture("TCrossLeft", "Images/Tiles/Up, Down and Left");
            LoadTexture("TCrossRight", "Images/Tiles/Up, Down and Right");
            LoadTexture("TCrossDown", "Images/Tiles/Up, Left and Right");
            LoadTexture("TCrossUp", "Images/Tiles/Down, Left and Right");
            LoadTexture("Door", "Images/Diverse/Door");
            LoadTexture("Floor", "Images/Diverse/Room Floor");
            LoadTexture("MapLoadingBackground", "Images/Diverse/Background");
        }
    }
}