using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace AngryBirds
{
    public class BabyHead : MonoBehaviour
    {
        [SerializeField] private float currentPower;
        [SerializeField] private bool isDragging;
        [SerializeField] private Vector3 startPosition;
        [SerializeField] private Rigidbody2D rb;
        [SerializeField] private DirectionVisualizer directionVisualizer;
        [SerializeField] private LayerMask babyLayer;
        [SerializeField] private Vector3 currentMousePosition;
        [SerializeField] private Vector3 currentDragDirection;
        [SerializeField] private GameManager gameManager;
        [SerializeField] private CircleCollider2D circleCollider;
        [SerializeField] private GameObject container;
        private Plane _inputPlane;
        private Camera _camera;

        private void Start()
        {
            _camera = Camera.main;
            gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
            container = GameObject.Find("BabyHeadContainer");
        }

        private void Update()
        {
            GetInput();
        }

        private void GetInput()
        {
            if (Input.GetMouseButtonDown(0))
            {
                var maxRayDistance = 100f;
                var hit = Physics2D.Raycast(_camera.ScreenToWorldPoint(Input.mousePosition), Vector2.zero,
                    maxRayDistance, babyLayer);
                if (hit && hit.transform.CompareTag("Player"))
                {
                    directionVisualizer.gameObject.SetActive(true);
                    isDragging = true;
                    startPosition = transform.position;
                }
            }

            if (isDragging && Input.GetMouseButton(0))
            {
                _inputPlane.SetNormalAndPosition(Vector3.forward, transform.position);
                var ray = _camera.ScreenPointToRay(Input.mousePosition);
                if (_inputPlane.Raycast(ray, out var hit))
                {
                    currentMousePosition = ray.GetPoint(hit);
                    currentDragDirection = (startPosition - currentMousePosition).normalized;
                }

                var rotatedVectorToTarget = currentDragDirection;
                var targetRotation = Quaternion.LookRotation(Vector3.forward, rotatedVectorToTarget);
                var distance = Vector3.Distance(startPosition, currentMousePosition);
                currentPower = Mathf.Clamp(distance, 0, 5);
                transform.rotation = targetRotation;
            }

            if (isDragging && Input.GetMouseButtonUp(0))
            {
                rb.gravityScale = 1;
                transform.SetParent(container.transform);
                gameManager.SetCamera(FocusedCamera.Baby);
                directionVisualizer.gameObject.SetActive(false);
                if (currentPower > 1)
                {
                    rb.AddForce(transform.up * (currentPower * 10), ForceMode2D.Impulse);
                }
                isDragging = false;
            }
        }

        public float GetPower()
        {
            return currentPower;
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            gameManager.SetCamera(FocusedCamera.Area);
            if (other.transform.CompareTag("Boss"))
            {
                other.transform.GetComponent<Boss>().TakeDamage(Random.Range(10, 16));
            }
            GameManager.BossTurn.Invoke();
            rb.gravityScale = 0;
            gameObject.SetActive(false);
        }
    }
}