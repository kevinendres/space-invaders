using System;

namespace SpaceInvaders
{
    abstract class CollisionBase
    {
        public abstract void Union();
        public abstract void UpdatePosition(float x, float y);
        public SpriteBoxAdaptor pSpriteBox;
        public CollisionRectangle poCollisionRectangle;
    }
}
