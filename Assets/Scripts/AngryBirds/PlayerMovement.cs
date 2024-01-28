using System;
using Cinemachine;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace AngryBirds
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float xPosition;
        [SerializeField] private float horizontalSpeed;
        [SerializeField] private BabyHead currentBaby;
        [SerializeField] private Vector3 movementVector;
        [SerializeField] private CinemachineVirtualCamera babyCamera;
        [SerializeField] private int maxHealth;
        [SerializeField] private int currentHealth;
        [SerializeField] private Slider playerHealth;
        [SerializeField] private Sprite[] sprites;
        [SerializeField] private Animator playerAnimator;
        [SerializeField] private GameObject deathPanel;
        private static readonly int Horizontal = Animator.StringToHash("horizontal");

        private void Start()
        {
            currentHealth = maxHealth;
            ReloadBaby();
        }

        private void Update()
        {
            Movement();
            UpdateUI();
        }

        private void UpdateUI()
        {
            playerHealth.value = (float)currentHealth / maxHealth;
        }

        private void Movement()
        {
            if (!GameManager.PlayerTurn)
            {
                var horziontalInput = Input.GetAxis("Horizontal");
                playerAnimator.SetFloat(Horizontal, horziontalInput);
                if (Input.GetKey(KeyCode.A))
                {
                    xPosition -= Time.deltaTime * horizontalSpeed;
                }
                else if (Input.GetKey(KeyCode.D))
                {
                    xPosition += Time.deltaTime * horizontalSpeed;
                }

                xPosition = Mathf.Clamp(xPosition, -80, -20);
                movementVector = transform.position;
                movementVector.x = xPosition;
                transform.position = movementVector;
            }
            else
            {
                playerAnimator.SetFloat(Horizontal, 0);
            }
        }
        
        public void ReloadBaby()
        {
            var baby = ObjectPool.SharedInstance.GetPooledObject();
            if (baby != null)
            {
                baby.transform.position = transform.position + Vector3.right * 8;
                baby.transform.SetParent(transform);
                baby.GetComponent<SpriteRenderer>().sprite = sprites[Random.Range(0, sprites.Length)];
                baby.SetActive(true);
            }
            currentBaby = baby.GetComponent<BabyHead>();
            currentBaby.playerAnimator = GetComponent<Animator>();
            babyCamera.Follow = baby.transform;
            babyCamera.LookAt = baby.transform;
        }

        public void TakeDamage(int damage)
        {
            currentHealth -= damage;
            if (currentHealth <= 0)
            {
                deathPanel.SetActive(true);
            }
        }

        public void Shoot()
        {
            currentBaby.ShootTheThing();
            currentBaby.SetValues();
        }
    }
}
