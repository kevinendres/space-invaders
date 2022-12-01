using System;

namespace SpaceInvaders
{
    class NullCollisionObject : CollisionBase
    {
        private NullCollisionObject()
        {

        }

        public override void Union()
        {
        }
        public override void UpdatePosition(float x, float y)
        {
        }

        // LTN - NullCollisionObject Singleton
        private static NullCollisionObject mInstance = new NullCollisionObject();
    }
}
