using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class ImageNode : DLinkNode
    {
        public ImageNode(Image _pImage) 
            : base()
        {
            pImage = _pImage;
        }
        public override void Print()
        {
            pImage.Print();
        }
        public Image pImage;
    }
}
