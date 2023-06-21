using System;
using Declarative;
using Lessons.Gameplay.Atomic1;
using Lessons.Gameplay.Atomic2.Mechanics;
using UnityEngine;

namespace Lessons.Gameplay.Atomic2.Practice.Models
{
    [Serializable]
    public class MovingCharacterModel
    {
        public AtomicEvent<Vector3> onMove;
    
        [SerializeField]
        private Transform moveTransform;

        [SerializeField]
        private AtomicVariable<float> moveSpeed;
    
        private readonly AtomicVariable<bool> moveRequired = new();
        private readonly AtomicVariable<Vector3> moveDirection = new();
        private readonly FixedUpdateMechanics fixedUpdate = new();

        [Construct]
        public void Construct()
        {
            this.onMove += direction =>
            {
                this.moveRequired.Value = true;
                this.moveDirection.Value = direction;
            };

            this.fixedUpdate.Do(deltaTime =>
            {
                if (this.moveRequired.Value)
                {
                    this.moveTransform.position += this.moveDirection.Value * this.moveSpeed.Value * deltaTime;
                    this.moveRequired.Value = false;
                }
            });
        }
    }
}