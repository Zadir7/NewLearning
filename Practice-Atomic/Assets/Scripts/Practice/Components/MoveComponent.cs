using UnityEngine;
using Lessons.Gameplay.Atomic1;

namespace Lessons.Gameplay.Atomic2.Practice.Components
{
    public interface IMoveComponent
    {
        void Move(Vector3 direction);
    }

    public sealed class MoveComponent : IMoveComponent
    {
        private readonly IAction<Vector3> onMove;

        public MoveComponent(IAction<Vector3> onMove)
        {
            this.onMove = onMove;
        }

        public void Move(Vector3 direction)
        {
            this.onMove.Invoke(direction);
        }
    }
}