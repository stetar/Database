using Microsoft.Xna.Framework;

namespace Working_title.MapGenerator
{
    public class Door : BuildObject
    {
        private Room Room;

        public Door(Vector2 position, Size size,Room room) : 
            base(position,size)
        {
            Room = room;
        }

        public override void Entered()
        {
            base.Entered();
            Room.EnteredRoom = !Room.EnteredRoom;
        }

        public override bool IsWalkable()
        {
            return true;
        }
    }
}