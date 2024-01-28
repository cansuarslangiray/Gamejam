using System;
using DG.Tweening;
using UnityEngine;

namespace AngryBirds
{
    public class BossProjectile : MonoBehaviour
    {
        public Vector2 targetPosition;
        public bool isLast;
        public GameManager gameManager;
        public PlayerMovement player;
        public Vector2 explosionSize;
        public SpriteRenderer spriteRenderer;
        public CapsuleCollider2D boxCollider2D;

        private void Start()
        {
            gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
            player = GameObject.Find("Player").GetComponent<PlayerMovement>();
        }

        public void MoveToTarget()
        {
            transform.DOLocalRotate(new Vector3(0, 0, 25), (0.5f * (transform.position.x - targetPosition.x) / 20));
            transform.DOMoveY(targetPosition.y - 1, (0.5f * (transform.position.x - targetPosition.x) / 20)).SetEase
                (Ease
                    .InSine)
                .OnComplete(
                    () =>
                    {
                        if (isLast)
                        {
                            player.ReloadBaby();
                            GameManager.PlayerTurn = true;
                            DOTween.Kill(this);
                        }
                    });
            transform.DOMoveX(targetPosition.x, (0.5f * (transform.position.x - targetPosition.x) / 20)).SetEase(Ease
                .Linear);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Ground") || other.CompareTag("Player"))
            {
                Debug.Log("hit: " + other.gameObject.name);
                var hit = Physics2D.BoxCastAll(transform.position, explosionSize, 0, transform.up);
                for (int i = 0; i < hit.Length; i++)
                {
                    if (hit[i].transform.CompareTag("Player"))
                    {
                        Debug.Log("hit: player");
                        hit[i].transform.GetComponent<PlayerMovement>().TakeDamage(10);
                    }
                }
                Debug.Log("Disabling collider");
                boxCollider2D.enabled = false;
                spriteRenderer.enabled = false;
                Destroy(gameObject, 5);
            }
        }
    }
}