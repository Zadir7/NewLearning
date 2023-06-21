using System;
using System.Collections;
using Declarative;
using Lessons.Gameplay.Atomic1;
using Lessons.Gameplay.Atomic2.Mechanics;
using Lessons.Gameplay.Atomic2.Practice.Components;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Lessons.Gameplay.Atomic2.Practice.Models
{
    [Serializable]
    public sealed class MeleeAttackModel
    {
        [ShowInInspector] public AtomicEvent<GameObject> OnAttack = new();
        
        public AtomicVariable<Transform> Transform;
        public AtomicVariable<float> MinMeleeDistance;
        public AtomicVariable<int> MeleeDamage;
        public AtomicVariable<float> AttackCountdown;
        public UpdateMechanics UpdateMechanics = new();

        private Timer _timer;

        [Construct]
        public void Construct()
        {
            _timer = new Timer(AttackCountdown.Value);
            
            this.OnAttack += (target) =>
            {
                if (_timer.InProgress)
                {
                    return;
                }
                
                if (Vector3.Distance(target.transform.position, this.Transform.Value.position) > this.MinMeleeDistance.Value)
                {
                    return;
                }

                if (target.TryGetComponent(out Entity entity))
                {
                    if (entity.TryGet(out ITakeDamageComponent takeDamageComponent))
                    {
                        takeDamageComponent.TakeDamage(this.MeleeDamage.Value);
                        _timer.Start();
                    }
                }
            };
            
            this.UpdateMechanics.Do((deltaTime) => { _timer.Update(deltaTime); });
        }
    }
}