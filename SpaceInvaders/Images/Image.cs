using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class Image : DLinkNode
    {
        public enum Name
        {
            Alien1,
            Alien2,
            BombStraight,
            BombZigZag1,
            BombZigZag2,
            BombCross1,
            BombCross2,
            Crab1,
            Crab2,
            Squid1,
            Squid2,
            Player,
            Missile,
            Wall,
            FloorCeiling,
            OctopusA,
            OctopusB,
            AlienA,
            AlienB,
            SquidA,
            SquidB,
            AlienExplosion,
            Saucer,
            SaucerExplosion,
            PlayerExplosionA,
            PlayerExplosionB,
            AlienPullYA,
            AlienPullYB,
            AlienPullUpisdeDownYA,
            AlienPullUpsideDownYB,
            PlayerShot,
            PlayerShotExplosion,
            SquigglyShotA,
            SquigglyShotB,
            SquigglyShotC,
            SquigglyShotD,
            PlungerShotA,
            PlungerShotB,
            PlungerShotC,
            PlungerShotD,
            RollingShotA,
            RollingShotB,
            RollingShotC,
            RollingShotD,
            AlienShotExplosion,
            LeftTopBrick,
            LeftBrick,
            MidLeftBottom,
            MidBrick,
            MidRightBottom,
            RightTopBrick,
            RightBrick,
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
        public Image()
        {
            name = Name.Uninitialized;
            // LTN - Image
            poRect = new Azul.Rect();
        }
        public override void Clear()
        {
            base.Clear();
            name = Name.Uninitialized;
        }

        override public object GetName()
        {
            return name;
        }

        public void Set(Name _name, Texture _texture, float _x, float _y, float _width, float _height)
        {
            name = _name;
            pTexture = _texture;
            poRect.Set(_x, _y, _width, _height);
        }
        public void Set(Name _name, Texture _texture, Azul.Rect _rect)
        {
            name = _name;
            pTexture = _texture;
            poRect.Set(_rect);
        }

        public override bool Compare(NodeBase pNode)
        {
            Image pImage = (Image)pNode;
            if (pImage.name == this.name) {
                return true;
            } else {
                return false;
            }
        }
        override public void Print()
        {
            // we are using HASH code as its unique identifier 
            Debug.WriteLine("   {0} ({1})", this.name, this.GetHashCode());

            // Data:
            Debug.WriteLine("   Name: {0} ({1})", this.name, this.GetHashCode());
            if (this.name != Name.Uninitialized) {
                Debug.WriteLine("      Rect: [{0} {1} {2} {3}] ", this.poRect.x, this.poRect.y, this.poRect.width, this.poRect.height);
            }

            this.basePrint();
        }

        public Name name;
        public Texture pTexture;
        public Azul.Rect poRect;
    }
}
