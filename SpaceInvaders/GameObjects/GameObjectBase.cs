using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    abstract class GameObjectBase : Component
    {
        public enum Name
        {
            Alien,
            BombStraight,
            BombCross,
            BombZigZag,
            Crab,
            Squid,
            Grid,
            Column,
            ShieldColumn,
            ShieldGrid,
            ShieldBrick,
            Player,
            Explosion,
            Missile,
            Saucer,
            WallLeft,
            WallRight,
            WallTop,
            WallBottom,
            WallGroup,
            Uninitialized
        }
        public GameObjectBase(Name _name, ProxySprite _proxy, float _x, float _y)
        {
            name = _name;
            pProxySprite = _proxy;
            //LTN - GameObjectBase
            poCollisionObject = new CollisionObject(pProxySprite);
            x = _x;
            y = _y;
        }
        public GameObjectBase(Name _name, SpriteAdaptor.Name spriteName, float _x, float _y)
        {
            name = _name;
            SpriteAdaptor pSprite = SpriteManager.Find(spriteName);
            Debug.Assert(pSprite != null);
            pProxySprite = ProxySpriteManager.Add(ProxySprite.Name.Proxy, _x, _y, pSprite);
            x = _x;
            y = _y;
            //LTN - GameObjectBase
            poCollisionObject = new CollisionObject(pProxySprite);
        }
        public virtual void PushToProxySprite()
        {
            Debug.Assert(pProxySprite != null);
            pProxySprite.x = x;
            pProxySprite.y = y;
        }

        public virtual void PushToCollisionObject()
        {
            poCollisionObject.UpdatePosition(x, y);
        }

        public override object GetName()
        {
            return name;
        }

        public SpriteBase GetCollisionSprite()
        {
            return poCollisionObject.pSpriteBox;
        }

        public virtual void Update()
        {
            PushToCollisionObject();
            PushToProxySprite();
        }

        public virtual void Remove()
        {
            pProxySprite.GetParent().Remove(pProxySprite.GetContainer());
            poCollisionObject.pSpriteBox.GetParent().Remove(poCollisionObject.pSpriteBox.GetContainer());
            if (this.GetParent() != null) {
                GetParent().DetachChildren(this);
            }
            if (pParent != null) {
                GenericGameObjectManager.Detach(pParent);
            }
            //GhostManager.Attach(this);
        }
        public virtual void SetParent(GenericGameObject _parent)
        {
            pParent = _parent;
        }
        public virtual void MarkForDeletion()
        {
            delete = true;
        }
        ~GameObjectBase()
        {
        }

        public Name name;
        public ProxySprite pProxySprite;
        public GenericGameObject pParent;
        public CollisionObject poCollisionObject;
        public bool delete;
        public float x;
        public float y;
    }
}
