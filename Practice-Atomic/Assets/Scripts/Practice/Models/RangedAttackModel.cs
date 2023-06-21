using System;
using Declarative;
using Lessons.Gameplay.Atomic1;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Lessons.Gameplay.Atomic2.Practice.Models
{
    [Serializable]
    public class RangedAttackModel
    {
        [ShowInInspector] public AtomicEvent<GameObject> OnAttack = new();
        
        public AtomicVariable<float> RangeDistance;
        public AtomicVariable<Transform> Transform;
        public AtomicVariable<Transform> FirePointTransform;

        [Construct]
        public void Construct()
        {
            this.OnAttack += (target) =>
            {
                var distanceVector = target.transform.position - this.Transform.Value.position;
                if (distanceVector.magnitude > this.RangeDistance.Value)
                {
                    return;
                }

                var direction = distanceVector.normalized;
                this.Transform.Value.rotation = Quaternion.LookRotation(direction, Vector3.up);
                BulletManager.Instance.LaunchBullet(this.FirePointTransform.Value.position, direction);
            };
        }
    }
}