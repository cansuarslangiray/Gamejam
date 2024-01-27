using System;
using Cinemachine;
using UnityEngine;

namespace AngryBirds
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float xPosition;
        [SerializeField] private float horizontalSpeed;
        [SerializeField] private bool hasBaby;
        [SerializeField] private BabyHead currentBaby;
        [SerializeField] private Vector3 movementVector;
        [SerializeField] private CinemachineVirtualCamera babyCamera;
        [SerializeField] private int health;
        
        private void Start()
        {
            ReloadBaby();
        }

        private void Update()
        {
            Movement();
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
                baby.transform.position = transform.position + Vector3.one;
                baby.transform.SetParent(this.transform);
                baby.SetActive(true);
            }
            currentBaby = baby.GetComponent<BabyHead>();
            hasBaby = true;
            babyCamera.Follow = baby.transform;
            babyCamera.LookAt = baby.transform;
        }

        public void TakeDamage(int damage)
        {
            health -= damage;
        }
    }
}
