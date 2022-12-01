using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class SpriteAdaptor : SpriteBase
    {
        public enum Name
        {
            Alien,
            BombStraight,
            BombZigZag,
            BombCross,
            LeftTopBrick,
            LeftBrick,
            MidLeftBottom,
            MidBrick,
            MidRightBottom,
            RightTopBrick,
            RightBrick,
            Crab,
            Font,
            Squid,
            SILogo,
            Player,
            Missile,
            Wall,
            Saucer,
            SaucerExplosion,
            AlienExplosion,
            PlayerExplosion,
            AlienShotExplosion,
            PlayerShotExplosion,
            FloorCeiling,
            GreenAlien,
            RedAlien,
            A,
            B,
            C,
            D,
            E,
            F,
            G,
            H,
            I,
            J,
            K,
            L,
            M,
            N,
            O,
            P,
            Q,
            R,
            S,
            T,
            U,
            V,
            W,
            X,
            Y,
            Z,
            Zero,
            One,
            Two,
            Three,
            Four,
            Five,
            Six,
            Seven,
            Eight,
            Nine,
            LessThan,
            GreaterThan,
            Space,
            Equals,
            Asterisk,
            Question,
            Hyphen,
            Uninitialized
        }
        public SpriteAdaptor()
        {
            name = Name.Uninitialized;
            // LTN - SpriteAdaptor
            pRect = new Azul.Rect();
            // LTN - SpriteAdaptor
            poLegacySprite = new Azul.Sprite();
            // LTN - SpriteAdaptor
            poColor = new Azul.Color(1f, 1f, 1f);
        }
        public void Set(Name _name, Image _image, float _x, float _y, float _w, float _h)
        {
            name = _name;
            pImage = _image;
            pRect.Set(_x, _y, _w, _h);

            poLegacySprite.Swap(_image.pTexture.poLegacyTexture, _image.poRect, pRect, poColor);
            this.angle = poLegacySprite.angle;
            this.x = _x;
            this.y = _y;
            this.sx = 1f;
            this.sy = 1f;
        }
        public override void Clear()
        {
            base.Clear();
            name = Name.Uninitialized;
            pImage = null;
            x = 0;
            y = 0;
        }

        override public void Render()
        {
            poLegacySprite.Render();
        }
        override public void Update()
        {
            poLegacySprite.angle = this.angle;
            poLegacySprite.sx = this.sx;
            poLegacySprite.sy = this.sy;
            poLegacySprite.x = this.x;
            poLegacySprite.y = this.y;

            poLegacySprite.Update();
        }

        public void SwapImage(Image _image)
        {
            poLegacySprite.SwapTexture(_image.pTexture.poLegacyTexture);
            poLegacySprite.SwapTextureRect(_image.poRect);
        }

        override public object GetName()
        {
            return this.name;
        }
        override public void Print()
        {
            // we are using HASH code as its unique identifier 
            Debug.WriteLine("   {0} ({1})", this.name, this.GetHashCode());

            // Data:
            if (this.name != Name.Uninitialized) {
                Debug.WriteLine("   Name: {0} ({1})", this.name, this.GetHashCode());
                Debug.WriteLine("             Image: {0} ({1})", this.pImage.name, this.pImage.GetHashCode());
                Debug.WriteLine("        AzulSprite: ({0})", this.poLegacySprite.GetHashCode());
                Debug.WriteLine("             (x,y): {0},{1}", this.x, this.y);
                Debug.WriteLine("           (sx,sy): {0},{1}", this.sx, this.sy);
                Debug.WriteLine("           (angle): {0}", this.angle);
            }

            this.basePrint();
        }

        public void ChangeColor(float r, float g, float b)
        {
            poColor.Set(r, g, b);
            poLegacySprite.SwapColor(poColor);
        }
        public override bool Compare(NodeBase other)
        {
            SpriteAdaptor otherSprite = (SpriteAdaptor)other;
            return name == otherSprite.name;
        }

        public Azul.Rect GetRect()
        {
            return pRect;
        }


    public float angle;
    public Name name;
    private Image pImage;
    private Azul.Sprite poLegacySprite;
    public Azul.Color poColor;
    private Azul.Rect pRect;
    public float sx;
    public float sy;
    public float x;
    public float y;
    }
}
