using Lessons.Gameplay.Atomic2.Practice;
using Lessons.Gameplay.Atomic2.Practice.Components;
using UnityEngine;

namespace Lessons.Gameplay.Atomic2
{
    public sealed class BulletManager : MonoBehaviour
    {
        public static BulletManager Instance;

        [SerializeField]
        private Bullet bulletPrefab;

        private void Awake()
        {
            Instance = this;
        }

        public void LaunchBullet(Vector3 position, Vector3 direction)
        {
            var bullet = Instantiate(this.bulletPrefab, position, Quaternion.identity, null);
            bullet.OnCollisionEntered += this.OnCollisionEntered;
            bullet.OnLifetimeFinished += this.OnLifetimeFinished;
            bullet.Move(direction);
            bullet.Activate();
        }

        private void OnCollisionEntered(Bullet bullet, Collision collision)
        {
            var target = collision.transform;
            
            if (target.TryGetComponent(out Entity entity))
            {
                if (entity.TryGet(out ITakeDamageComponent takeDamageComponent))
                {
                    takeDamageComponent.TakeDamage(bullet.Damage);
                }
            }

            this.DestroyBullet(bullet);
        }

        private void OnLifetimeFinished(Bullet bullet)
        {
            this.DestroyBullet(bullet);
        }

        private void DestroyBullet(Bullet bullet)
        {
            bullet.OnCollisionEntered -= this.OnCollisionEntered;
            bullet.OnLifetimeFinished -= this.OnLifetimeFinished;
            Destroy(bullet.gameObject);
        }
    }
}