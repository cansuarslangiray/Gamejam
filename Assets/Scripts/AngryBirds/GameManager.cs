using System;
using Cinemachine;
using UnityEngine;

namespace AngryBirds
{
    public enum FocusedCamera
    {
        Player,
        Baby,
        Area
    }
    
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private CinemachineVirtualCamera playerCamera;
        [SerializeField] private CinemachineVirtualCamera babyCamera;
        [SerializeField] private CinemachineVirtualCamera areaCamera;
        [SerializeField] private Boss boss;
        public static bool PlayerTurn;
        public static Action BossTurn;

        private void OnEnable()
        {
            BossTurn += StartBossTurn;
        }

        private void OnDisable()
        {
            BossTurn -= StartBossTurn;
        }

        private void StartBossTurn()
        {
            StartCoroutine(boss.MakeMove());
        }

        public void SetCamera(FocusedCamera camera)
        {
            switch (camera)
            {
                case FocusedCamera.Player: 
                    playerCamera.gameObject.SetActive(true);
                    babyCamera.gameObject.SetActive(false);
                    areaCamera.gameObject.SetActive(false);
                    break;
                case FocusedCamera.Baby:
                    babyCamera.gameObject.SetActive(true);
                    playerCamera.gameObject.SetActive(false);
                    areaCamera.gameObject.SetActive(false);
                    break;
                case FocusedCamera.Area:
                    areaCamera.gameObject.SetActive(true);
                    babyCamera.gameObject.SetActive(false);
                    playerCamera.gameObject.SetActive(false);
                    break;
            }
        }
    }
}
