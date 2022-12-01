using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class AnimateCommand : CommandBase
    {
        public AnimateCommand(SpriteAdaptor _pSprite)
        {
            pSprite = _pSprite;
            // LTN - AnitameCommand
            animationFrames = new DLinkList();
            pIt = animationFrames.GetIterator();
        }
        public override void Execute(float deltaTime)
        {
            if (!pIt.IsValid()) {
                pIt = animationFrames.GetIterator();
            }
            ImageNode nextImage = (ImageNode)pIt.Current();
            Debug.Assert(nextImage != null);
            pSprite.SwapImage(nextImage.pImage);

            pIt.Next();

            TimeEventManager.Add(deltaTime, this);
        }
        public void Attach(Image pImage)
        {
            Debug.Assert(animationFrames != null);
            Debug.Assert(pImage != null);
            // LTN - AnimateCommand's animationFrames owns it
            ImageNode pImageNode = new ImageNode(pImage);
            animationFrames.Add(pImageNode);
        }

        SpriteAdaptor pSprite;
        DLinkList animationFrames;
        IteratorBase pIt;
    }
}
