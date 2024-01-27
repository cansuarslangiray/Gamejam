using UnityEngine;

namespace AngryBirds
{
    public class DirectionVisualizer : MonoBehaviour
    {
        [SerializeField] private float currentPower;
        [SerializeField] private GameObject[] directionParts;
        [SerializeField] private GameObject direction;
        [SerializeField] private BabyHead head;
        
        private void Start()
        {
            directionParts = new GameObject[direction.transform.childCount];
            for (int i = 0; i < direction.transform.childCount; i++)
            {
                directionParts[i] = direction.transform.GetChild(i).gameObject;
            }
        }

        private void Update()
        {
            currentPower = head.GetPower();
            UpdateVisualizer();
        }

        private void UpdateVisualizer()
        {
            for (int i = 1; i <= directionParts.Length; i++)
            {
                if (currentPower >= i)
                {
                    directionParts[i - 1].SetActive(true);
                }
                else
                {
                    directionParts[i - 1].SetActive(false);
                }
            }
        }
    }
}
