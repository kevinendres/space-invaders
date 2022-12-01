using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class NullProxySprite : ProxySprite
    {
        private NullProxySprite()
        {
            name = Name.Null;
        }

        public void Set(Name _name, float _x, float _y, SpriteAdaptor _pSprite)
        {
        }
        public static NullProxySprite GetInstance()
        {
            return pInstance;
        }
        public override void Clear()
        {
        }

        override public void Render()
        {
        }
        override public void Update()
        {
        }

        override public object GetName()
        {
            return this.name;
        }
        override public void Print()
        {
        }

        // LTN - NullProxySprite Singleton
        private static readonly NullProxySprite pInstance = new NullProxySprite();
        private new readonly SpriteAdaptor pSprite;
    }
}
