using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    abstract class CommandBase
    {
        public abstract void Execute(float deltaTime);
    }
}
