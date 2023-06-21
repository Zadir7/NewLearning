using System.Collections;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Lessons.Gameplay.Atomic2
{
    public sealed class Warrior : MonoBehaviour
    {
        [Header("Hit Points")]
        [SerializeField]
        private int hitPoints;

        [Header("Move")]
        [SerializeField]
        private float speed;

        private bool moveRequired = new();
        
        private Vector3 moveDirection = new();

        [Header("Melee Attack")]
        [SerializeField]
        private float minMeleeDistance;

        [SerializeField]
        private float attackCountdown;

        [SerializeField]
        private int meleeDamage;

        private Coroutine attackCoroutine;

        private void FixedUpdate()
        {
            if (this.moveRequired)
            {
                this.transform.position += this.moveDirection * (this.speed * Time.fixedDeltaTime);
                this.moveRequired = false;
            }
        }

        [Button]
        public void TakeDamage(int damage)
        {
            this.hitPoints -= damage;
            if (this.hitPoints <= 0)
            {
                Destroy(this.gameObject);
            }
        }

        [Button]
        public void Move(Vector3 direction)
        {
            this.moveRequired = true;
            this.moveDirection = direction;
        }

        [Button]
        public void Attack(GameObject target)
        {
            if (this.attackCoroutine != null)
            {
                return;
            }

            if (Vector3.Distance(target.transform.position, this.transform.position) > this.minMeleeDistance)
            {
                return;
            }

            if (target.TryGetComponent(out Warrior warrior))
            {
                warrior.TakeDamage(this.meleeDamage);
                this.attackCoroutine = this.StartCoroutine(this.AttackCountdown());
            }
            else if (target.TryGetComponent(out Tower tower))
            {
                tower.TakeDamage(this.meleeDamage);
                this.attackCoroutine = this.StartCoroutine(this.AttackCountdown());
            }
        }

        private IEnumerator AttackCountdown()
        {
            yield return new WaitForSeconds(this.attackCountdown);
            this.attackCoroutine = null;
        }
    }
}