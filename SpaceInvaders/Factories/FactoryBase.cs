using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    abstract class FactoryBase
    {
        public abstract GameObjectBase Create(GameObjectBase.Name name, float x, float y);
    }
}
