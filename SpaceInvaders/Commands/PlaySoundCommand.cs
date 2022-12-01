using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class PlaySoundCommand : CommandBase
    {
        public PlaySoundCommand()
        {
            pSounds = new DLinkList();
            pIt = pSounds.GetIterator();
        }
        public override void Execute(float deltaTime)
        {
            if (!pIt.IsValid()) {
                pIt = pSounds.GetIterator();
            }
            SoundAdaptor nextSound = (SoundAdaptor)pIt.Current();
            Debug.Assert(nextSound != null);
            nextSound.Play();

            pIt.Next();

            //TimeEventManager.Add(deltaTime, this);
        }
        public void Attach(SoundAdaptor pSound)
        {
            Debug.Assert(pSounds != null);
            Debug.Assert(pSound != null);
            // LTN - AnimateCommand's animationFrames owns it
            SoundAdaptor pSoundCopy = new SoundAdaptor(pSound);
            pSounds.Add(pSoundCopy);
        }

        DLinkList pSounds;
        IteratorBase pIt;
    }
}
