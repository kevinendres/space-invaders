using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class AddPointsObserver : CollisionObserver
    {
        public AddPointsObserver()
        {
            addCommand = new AddPointsCommand();
        }

        public override void Notify()
        {
            int points = CalculatePoints(pSubject.pColliderA);
            points += CalculatePoints(pSubject.pColliderB);
            addCommand.Execute(points);
        }
        private int CalculatePoints(GameObjectBase pGamObj)
        {
            switch (pGamObj.name) {
                case GameObjectBase.Name.Alien:
                    return 10;
                    break;
                case GameObjectBase.Name.Crab:
                    return 20;
                    break;
                case GameObjectBase.Name.Squid:
                    return 30;
                    break;
                case GameObjectBase.Name.Saucer:
                    return 100;
                    break;
                default:
                    return 0;
                    break;
            }

        }
        AddPointsCommand addCommand;
    }
}
