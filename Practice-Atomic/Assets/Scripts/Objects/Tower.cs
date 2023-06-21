using Sirenix.OdinInspector;
using UnityEngine;

namespace Lessons.Gameplay.Atomic2
{
    public sealed class Tower : MonoBehaviour
    {
        [SerializeField]
        private int hitPoints;

        [Header("Range Attack")]
        [SerializeField]
        private float rangeDistance;
        
        [SerializeField]
        private Transform firePoint;

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
        public void Attack(GameObject target)
        {
            var distanceVector = target.transform.position - this.transform.position;
            if (distanceVector.magnitude > this.rangeDistance)
            {
                return;
            }

            var direction = distanceVector.normalized;
            this.transform.rotation = Quaternion.LookRotation(direction, Vector3.up);
            BulletManager.Instance.LaunchBullet(this.firePoint.position, direction);
        }
    }
}