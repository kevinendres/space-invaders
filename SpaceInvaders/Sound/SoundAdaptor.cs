using System;
using IrrKlang;

namespace SpaceInvaders
{
    class SoundAdaptor : DLinkNode
    {
        public enum Name
        {
            Music,
            MissileFire,
            AlienMovement1,
            AlienMovement2,
            AlienMovement3,
            AlienMovement4,
            AlienDeath,
            PlayerDeath,
            UFO1,
            UFO2,
            Uninitialized
        }
        public SoundAdaptor() 
        {
            name = Name.Uninitialized;
        }
        public SoundAdaptor(SoundAdaptor other) 
        {
            name = other.name;
            poSound = other.poSound;
        }
        public void Set(Name _name, ISoundSource sound)
        {
            poSound = sound;
            name = _name;
        }
        public override void Print()
        {
            throw new NotImplementedException();
        }
        public override bool Compare(NodeBase other)
        {
            SoundAdaptor otherSound = (SoundAdaptor)other;
            return name == otherSound.name;
        }
        public void Play()
        {
            SoundManager.PlaySound(this);
        }
        public ISoundSource poSound;
        public Name name;
    }
}
