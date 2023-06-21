using Lessons.Gameplay.Atomic1;
using UnityEngine;

namespace Lessons.Gameplay.Atomic2.Practice.Components
{
    public interface IAttackComponent
    {
        void Attack(GameObject target);
    }
    
    public sealed class AttackComponent : IAttackComponent
    {
        private readonly IAction<GameObject> onAttack;
        
        public AttackComponent(IAction<GameObject> onAttack)
        {
            this.onAttack = onAttack;
        }

        public void Attack(GameObject target)
        {
            this.onAttack.Invoke(target);
        }
    }
}