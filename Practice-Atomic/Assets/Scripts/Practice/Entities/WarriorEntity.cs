using Lessons.Gameplay.Atomic2.Practice.Components;
using Lessons.Gameplay.Atomic2.Practice.Models;
using UnityEngine;

namespace Lessons.Gameplay.Atomic2.Practice.Entities
{
    [RequireComponent(typeof(WarriorModel))]
    public sealed class WarriorEntity : Entity
    {
        private void Awake()
        {
            var model = this.GetComponent<WarriorModel>();
            this.Add(new MoveComponent(model.MoveModel.onMove));
            this.Add(new TakeDamageComponent(model.HealthModel.OnTakeDamage));
            this.Add(new AttackComponent(model.MeleeAttackModel.OnAttack));
        }
    }
}