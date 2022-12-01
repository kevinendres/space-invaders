using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class PlaySoundObserver : CollisionObserver
    {
        public PlaySoundObserver(SoundAdaptor.Name _name)
        {
            name = _name;
        }
        public override void Notify()
        {
            SoundManager.PlaySound(name);
        }
        SoundAdaptor.Name name;
    }
}
