using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    abstract class WallBase : Leaf
    {
        public WallBase(Name _name, SpriteAdaptor.Name _proxy, float _x, float _y)
            : base(_name, _proxy, _x, _y) { }

        public override void Move(float _x, float _y)
        {
            Debug.Print("Move called on Wall");
            Debug.Assert(false);
        }
    }
}
