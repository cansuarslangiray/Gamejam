using System;
using Cinemachine;
using UnityEngine;
using UnityEngine.UI;

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
        }
        
        public void ReloadBaby()
        {
            var baby = ObjectPool.SharedInstance.GetPooledObject();
            if (baby != null)
            {
                baby.transform.position = transform.position + Vector3.one * 5;
                baby.transform.SetParent(this.transform);
                baby.SetActive(true);
            }
            currentBaby = baby.GetComponent<BabyHead>();
            babyCamera.Follow = baby.transform;
            babyCamera.LookAt = baby.transform;
        }

        public void TakeDamage(int damage)
        {
            currentHealth -= damage;
        }
    }
}
