using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class TimeEvent : OrderedDLinkNode
    {
        public override void Clear()
        {
            base.Clear();
            deltaTime = 0;
            command = null;
        }
        public void Set(float _deltaTime, CommandBase _command)
        {
            deltaTime = _deltaTime;
            command = _command;

        }
        public void Execute()
        {
            command.Execute(deltaTime);
        }
        public override void Print()
        {
            Debug.Assert(false);
        }

        float deltaTime;
        CommandBase command;
    }
}
