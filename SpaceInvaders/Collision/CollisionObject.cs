using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class CollisionObject : CollisionBase
    {
        public CollisionObject(ProxySprite pProxy)
        {
            if (pProxy.name == ProxySprite.Name.Null) {
                // LTN - CollisionObject
                poCollisionRectangle = new CollisionRectangle();
            }
            else {
                // LTN - CollisionObject
                poCollisionRectangle = new CollisionRectangle(pProxy.pSprite.GetRect());
            }
            Debug.Assert(poCollisionRectangle != null);
            pSpriteBox = SpriteBoxManager.Add(SpriteBoxAdaptor.Name.WhiteBox, poCollisionRectangle.x, 
            poCollisionRectangle.y, poCollisionRectangle.width, poCollisionRectangle.height, 1f, 1f, 1f);
            Debug.Assert(pSpriteBox != null);
        }
        public void Set(ProxySprite pProxy)
        {
            poCollisionRectangle.Set(pProxy.pSprite.GetRect());
            pSpriteBox.Set(SpriteBoxAdaptor.Name.WhiteBox, pProxy.x, pProxy.y, poCollisionRectangle.width, poCollisionRectangle.height, 1f, 1f, 1f);
        }
        public override void Union() { }
        public override void UpdatePosition(float _x, float _y) 
        {
            poCollisionRectangle.x = _x;
            poCollisionRectangle.y = _y;
            pSpriteBox.x = _x;
            pSpriteBox.y = _y;
            pSpriteBox.Set(SpriteBoxAdaptor.Name.WhiteBox, poCollisionRectangle.x, poCollisionRectangle.y,
                poCollisionRectangle.width, poCollisionRectangle.height, 1f, 1f, 1f);
            pSpriteBox.Update();
        }

        ~CollisionObject()
        {
        }
    }
}
