using System;
using System.Diagnostics;

namespace SpaceInvaders
{
     abstract class EnemyBase : Leaf
    {
        public EnemyBase(Name _name, SpriteAdaptor.Name _proxy, float _x, float _y)
            : base(_name, _proxy, _x, _y) { }
        public override void Move(float _x, float _y)
        {
            x += _x;
            y += _y;
        }
    }
}
