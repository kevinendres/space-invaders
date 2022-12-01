using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class ShieldManager
    {
        public static ShieldGrid GetShield(int i)
        {
            ShieldGrid pShield;
            switch (i) {
                case 1:
                    pShield = pShield1;
                    break;
                case 2:
                    pShield = pShield2;
                    break;
                case 3:
                    pShield = pShield3;
                    break;
                case 4:
                    pShield = pShield4;
                    break;
                default:
                    Debug.Assert(false);
                    pShield = null;
                    break;
            }
            return pShield;
        }
        public static ShieldGrid pShield1;
        public static ShieldGrid pShield2;
        public static ShieldGrid pShield3;
        public static ShieldGrid pShield4;
    }
}
