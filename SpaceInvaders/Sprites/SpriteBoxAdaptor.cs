using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class SpriteBoxAdaptor : SpriteBase
    {
        public enum Name
        {
            RedBox,
            BlueBox,
            GreenBox,
            WhiteBox,
            WallLeft,
            WallRight,
            WallTop,
            WallBottom,
            Uninitialized
        }
        public SpriteBoxAdaptor()
        {
            name = Name.Uninitialized;
            // LTN - SpriteBoxAdaptor
            poRect = new Azul.Rect();
            // LTN - SpriteBoxAdaptor
            poLegacySpriteBox = new Azul.SpriteBox();
            // LTN - SpriteBoxAdaptor
            poColor = new Azul.Color(0.9f, 0.3f, 0.3f, 0.8f);
        }
        public void Set(Name _name, float _x, float _y, float _width, float _height, float R, float G, float B)
        {
            name = _name;
            poRect.Set(_x, _y, _width, _height);
            poColor.Set(R, G, B);
            poLegacySpriteBox.Swap(poRect, poColor);
            x = poLegacySpriteBox.x;
            y = poLegacySpriteBox.y;
            sx = poLegacySpriteBox.sx;
            sy = poLegacySpriteBox.sy;
        }
        public override void Render()
        {
            poLegacySpriteBox.Render();
        }
        public override void Update()
        {
            poLegacySpriteBox.x = x;
            poLegacySpriteBox.y = y;
            poLegacySpriteBox.sx = sx;
            poLegacySpriteBox.sy = sy;
            poLegacySpriteBox.Update();
        }

        public override void Print()
        {
            // we are using HASH code as its unique identifier 
            Debug.WriteLine("   {0} ({1})", this.name, this.GetHashCode());

            // Data:
            if (this.name != Name.Uninitialized) {
                Debug.WriteLine("   Name: {0} ({1})", this.name, this.GetHashCode());
                Debug.WriteLine("        AzulSprite: ({0})", this.poLegacySpriteBox.GetHashCode());
                Debug.WriteLine("             (x,y): {0},{1}", this.x, this.y);
                Debug.WriteLine("           (sx,sy): {0},{1}", this.sx, this.sy);
            }
            this.basePrint();
        }

        public override object GetName()
        {
            return name;
        }
        ~SpriteBoxAdaptor()
        {
        }

        public Name name;
        public Azul.Color poColor;
        public Azul.SpriteBox poLegacySpriteBox;
        public Azul.Rect poRect;
        public float x;
        public float y;
        private float sx;
        private float sy;
    }
}
