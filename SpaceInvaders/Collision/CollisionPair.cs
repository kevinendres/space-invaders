using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class CollisionPair : DLinkNode
    {
        public enum Name
        {
            AlienGrid_Missile,
            Alien_Shield,
            Bomb_Shield,
            Bomb_Player,
            Bomb_Floor,
            Bomb_Missile,
            Grid_Wall,
            Missile_Shield,
            Missile_Wall,
            Saucer_Wall,
            Ship_Wall,
            Uninitialized
        }
        public CollisionPair()
        {
            name = Name.Uninitialized;
            poSubject = new CollisionSubject();
        }
        public void Set(Name _name, GameObjectBase _colliderA, GameObjectBase _colliderB)
        {
            Debug.Assert(_colliderA != null);
            Debug.Assert(_colliderB != null);

            pColliderA = _colliderA;
            pColliderB = _colliderB;
            name = _name;
        }
        public void ProcessCollision()
        {
            Collide(pColliderA, pColliderB);
        }
        public static void Collide(GameObjectBase pColliderA, GameObjectBase pColliderB)
        {
            if (CollisionRectangle.Intersect(pColliderA, pColliderB)) {
                pColliderA.Accept(pColliderB);
            }
        }
        public override void Clear()
        {
            base.Clear();
            pColliderA = null;
            pColliderA = null;
            name = Name.Uninitialized;
        }
        public override void Print()
        {
            throw new NotImplementedException();
        }
        public void SetPair(GameObjectBase _A, GameObjectBase _B)
        {
            poSubject.pColliderA = _A;
            poSubject.pColliderB = _B;
        }

        public void Notify()
        {
            poSubject.Notify();
        }

        Name name = Name.Uninitialized;
        GameObjectBase pColliderA;
        GameObjectBase pColliderB;
        public CollisionSubject poSubject;
    }
}
