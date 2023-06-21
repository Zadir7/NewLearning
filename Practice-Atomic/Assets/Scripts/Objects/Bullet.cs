using System;
using System.Collections;
using UnityEngine;

namespace Lessons.Gameplay.Atomic2
{
    public sealed class Bullet : MonoBehaviour
    {
        public event Action<Bullet, Collision> OnCollisionEntered;
        public event Action<Bullet> OnLifetimeFinished;

        public int Damage
        {
            get { return this.damage; }
        }

        [SerializeField]
        private float speed = 5;

        [SerializeField]
        private int damage = 1;

        [SerializeField]
        private float lifetime = 3;

        public void Move(Vector3 direction)
        {
            this.StartCoroutine(this.MoveRoutine(direction));
        }

        private IEnumerator MoveRoutine(Vector3 direction)
        {
            while (true)
            {
                this.transform.position += direction * this.speed * Time.fixedDeltaTime;
                yield return new WaitForFixedUpdate();
            }
        }

        public void Activate()
        {
            this.StartCoroutine(this.ActivateRoutine());
        }

        private IEnumerator ActivateRoutine()
        {
            yield return new WaitForSeconds(this.lifetime);
            this.OnLifetimeFinished?.Invoke(this);   
        }

        private void OnCollisionEnter(Collision collision)
        {
            this.OnCollisionEntered?.Invoke(this, collision);
        }
    }
}