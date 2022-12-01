using System;

namespace SpaceInvaders
{
    abstract class CollisionObserver : ObserverBase
    {
        public override void SetSubject(SubjectBase _subject)
        {
            pSubject = (CollisionSubject)_subject;
        }
        protected CollisionSubject pSubject;
    }
}
