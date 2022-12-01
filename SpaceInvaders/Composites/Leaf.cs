using System;

namespace SpaceInvaders
{
    abstract class Leaf : GameObjectBase
    {
        public override void Print()
        {
            // STN - SHOULD NEVER HAPPEN
            throw new NotImplementedException();
        }

        public Leaf(Name _name, ProxySprite _proxy, float _x, float _y)
            : base(_name, _proxy, _x, _y) { }
        public Leaf(Name _name, SpriteAdaptor.Name spriteName, float _x, float _y)
            : base(_name, spriteName, _x, _y) { }
    }
}
