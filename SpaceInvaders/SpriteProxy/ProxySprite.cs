using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class ProxySprite : SpriteBase
    {
        public enum Name
        {
            Proxy,
            Null,
            Uninitialized
        }
        public ProxySprite()
        {
            name = Name.Uninitialized;
            sx = 1f;
            sy = 1f;
        }
        public void Set(Name _name, float _x, float _y, SpriteAdaptor _pSprite)
        {
            name = _name;
            x = _x;
            y = _y;
            pSprite = _pSprite;
        }
        public override void Clear()
        {
            base.Clear();
            x = 0;
            y = 0;
            pSprite = null;
        }

        override public void Render()
        {
            Debug.Assert(pSprite != null);
            Update();
            pSprite.Render();
        }
        override public void Update()
        {
            pSprite.x = x;
            pSprite.y = y;
            pSprite.sx = sx;
            pSprite.sy = sy;
            pSprite.Update();
        }

        override public object GetName()
        {
            return this.name;
        }
        override public void Print()
        {
            // we are using HASH code as its unique identifier 
            Debug.WriteLine("   {0} ({1})", this.name, this.GetHashCode());

            // Data:
            if (this.name != Name.Uninitialized) {
                Debug.WriteLine("   Name: {0} ({1})", this.name, this.GetHashCode());
                Debug.WriteLine("             (x,y): {0},{1}", this.x, this.y);
            }

            this.basePrint();
        }

        ~ProxySprite()
        {
        }

        public Name name;
        public SpriteAdaptor pSprite;
        public float x;
        public float y;
        public float sx;
        public float sy;
    }
}
