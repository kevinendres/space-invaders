using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class Texture : DLinkNode
    {
        public enum Name
        {
            Birds,
            Aliens,
            Shield,
            PacMan,
            Uninitialized
        }
        public Texture()
        {
            name = Name.Uninitialized;
            // LTN - Texture
            poLegacyTexture = new Azul.Texture();
            Debug.Assert(poLegacyTexture != null);
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

        public void Set(Name _name, string fileName)
        {
            name = _name;
            poLegacyTexture.Set(fileName, Azul.Texture_Filter.NEAREST, Azul.Texture_Filter.NEAREST);
        }

        override public void Print()
        {
            // we are using HASH code as its unique identifier 
            Debug.WriteLine("   {0} ({1})", this.name, this.GetHashCode());

            // Data:
            Debug.WriteLine("   Name: {0} ({1})", this.name, this.GetHashCode());
            if (this.name != Name.Uninitialized) {
                Debug.WriteLine("      poAzulTexture: {0} ", this.poLegacyTexture.GetHashCode());
            }

            this.basePrint();
        }

        Name name;
        public Azul.Texture poLegacyTexture;
    }
}
