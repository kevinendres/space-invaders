using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class CollisionRectangle : Azul.Rect
    {
        public CollisionRectangle(Azul.Rect otherRect)
            : base(otherRect)
        {
        }
        public CollisionRectangle()
        {
        }

        public void Union(CollisionRectangle _rect)
        {
            if (x == 0) {
                x = _rect.x;
            }
            if (y == 0) {
                y = _rect.y;
            }
            float maxY, minY;
            float maxX, minX;
            if ((this.x - this.width / 2) < (_rect.x - _rect.width / 2)) {
                minX = (this.x - this.width / 2);
            } else {
                minX = (_rect.x - _rect.width / 2);
            }

            if ((this.x + this.width / 2) > (_rect.x + _rect.width / 2)) {
                maxX = (this.x + this.width / 2);
            } else {
                maxX = (_rect.x + _rect.width / 2);
            }
            if ((this.y + this.height / 2) > (_rect.y + _rect.height / 2)) {
                maxY = (this.y + this.height / 2);
            } else {
                maxY = (_rect.y + _rect.height / 2);
            }

            if ((this.y - this.height / 2) < (_rect.y - _rect.height / 2)) {
                minY = (this.y - this.height / 2);
            } else {
                minY = (_rect.y - _rect.height / 2);
            }
            width = maxX - minX;
            height = maxY - minY;
            x = minX + width / 2; 
            y = minY + height / 2;

        }
        static public bool Intersect(GameObjectBase colliderA, GameObjectBase colliderB)
        {
            CollisionRectangle ColRectA = colliderA.poCollisionObject.poCollisionRectangle;
            CollisionRectangle ColRectB = colliderB.poCollisionObject.poCollisionRectangle;

            bool result = false;

            float A_minx = ColRectA.x - ColRectA.width / 2;
            float A_maxx = ColRectA.x + ColRectA.width / 2;
            float A_miny = ColRectA.y - ColRectA.height / 2;
            float A_maxy = ColRectA.y + ColRectA.height / 2;

            float B_minx = ColRectB.x - ColRectB.width / 2;
            float B_maxx = ColRectB.x + ColRectB.width / 2;
            float B_miny = ColRectB.y - ColRectB.height / 2;
            float B_maxy = ColRectB.y + ColRectB.height / 2;

            if ((B_maxx < A_minx) || (B_minx > A_maxx) || (B_maxy < A_miny) || (B_miny > A_maxy)) {
                result = false;
            } else {
                result = true;
            }

            return result;
        }
        ~CollisionRectangle()
        {
        }

    }
}
