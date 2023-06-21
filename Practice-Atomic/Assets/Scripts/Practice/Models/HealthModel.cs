using System;
using Declarative;
using Lessons.Gameplay.Atomic1;
using Sirenix.OdinInspector;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Lessons.Gameplay.Atomic2.Practice.Models
{
    [Serializable]
    public class HealthModel
    {
        public AtomicVariable<int> HitPoints;
        [ShowInInspector] public AtomicEvent<int> OnTakeDamage = new();

        [Construct]
        public void Construct(GameObject gameObject)
        {
            this.OnTakeDamage += (damage) =>
            {
                this.HitPoints.Value -= damage;
                if (this.HitPoints.Value <= 0)
                {
                    Object.Destroy(gameObject);
                }
            };
        }
    }
}