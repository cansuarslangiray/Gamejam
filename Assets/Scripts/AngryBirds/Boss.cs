using System.Collections;
using DG.Tweening;
using UnityEngine;

namespace AngryBirds
{
    public class Boss : MonoBehaviour
    {
        [SerializeField] private float[] horizontalSpots;
        [SerializeField] private float[] verticalSpots;
        [SerializeField] private Vector3 movementDestination;
        [SerializeField] private int[] shootTargets;
        [SerializeField] private float moveSpeed;
        [SerializeField] private GameObject projectilePrefab;
        [SerializeField] private GameManager gameManager;

        public IEnumerator MakeMove()
        {
            yield return new WaitForSeconds(5);
            GameManager.PlayerTurn = false;
            Shoot();
            yield return new WaitForSeconds(5);
            yield return Relocate();
        }

        private IEnumerator Relocate()
        {
            var horizontalSpot = horizontalSpots[Random.Range(0, horizontalSpots.Length)];
            var verticalSpot = verticalSpots[Random.Range(0, verticalSpots.Length)];
            movementDestination = new Vector3(horizontalSpot, verticalSpot, 0);
            transform.DOMove(movementDestination, 1).OnComplete(() =>
            {
                gameManager.SetCamera(FocusedCamera.Player);
            });
            yield return null;
        }

        private void Shoot()
        {
            var selectedTargets = new int[]
            {
                shootTargets[Random.Range(0, shootTargets.Length)], shootTargets[Random
                    .Range(0, shootTargets.Length)]
            };
            StartCoroutine(ShootRoutine(selectedTargets));
        }

        private IEnumerator ShootRoutine(int[] targets)
        {
            for (int i = 0; i < targets.Length; i++)
            {
                var bossProjectileObject = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
                var bossProjectile = bossProjectileObject.GetComponent<BossProjectile>();
                bossProjectile.targetPosition = new Vector2(targets[i], 0);
                bossProjectile.MoveToTarget();
                if (i + 1 == targets.Length)
                {
                    bossProjectile.isLast = true;
                }
                yield return new WaitForSeconds(0.5f);
            }            
        }
    }
}