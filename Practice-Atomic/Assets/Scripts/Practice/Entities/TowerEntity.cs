using Lessons.Gameplay.Atomic2.Practice.Components;
using Lessons.Gameplay.Atomic2.Practice.Models;
using UnityEngine;

namespace Lessons.Gameplay.Atomic2.Practice.Entities
{
    [RequireComponent(typeof(TowerModel))]
    public sealed class TowerEntity : Entity
    {
        private void Awake()
        {
            var model = this.GetComponent<TowerModel>();
            this.Add(new TakeDamageComponent(model.HealthModel.OnTakeDamage));
            this.Add(new AttackComponent(model.RangedAttackModel.OnAttack));
        }
    }
}