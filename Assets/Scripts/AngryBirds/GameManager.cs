using System;
using System.Collections;
using Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

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
        [SerializeField] private Animator volcanoAnimator;
        public static bool PlayerTurn;
        public static Action BossTurn;
        private static readonly int Explode = Animator.StringToHash("Explode");

        private void Start()
        {
            StartCoroutine(VolcanoRoutine());
        }

        private IEnumerator VolcanoRoutine()
        {
            while (true)
            {
                yield return new WaitForSeconds(3);
                var random = Random.Range(0, 3);
                if (random == 2)
                {
                    volcanoAnimator.SetTrigger(Explode);
                }
            }
            yield break;
        }

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
        
        public void Retry()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
