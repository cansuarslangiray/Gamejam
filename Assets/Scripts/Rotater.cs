using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotater : MonoBehaviour
{
    public bool clockwise;

    [SerializeField] private float speed = 35;

    public bool isEmpty;

    public bool isLocal;

    public enum axis
    {
        X,
        Y,
        Z
    }

    public axis rotationAxis;

    void Update()
    {
        if (!isEmpty)
        {
            if (!isLocal)
            {
                switch (rotationAxis)
                {
                    case axis.X:
                        transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.eulerAngles.x + speed * Time.deltaTime * (System.Convert.ToInt32(clockwise) * 2 - 1), transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z));
                        break;
                    case axis.Y:
                        transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y + speed * Time.deltaTime * (System.Convert.ToInt32(clockwise) * 2 - 1), transform.rotation.eulerAngles.z));
                        break;
                    case axis.Z:
                        transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z + speed * Time.deltaTime * (System.Convert.ToInt32(clockwise) * 2 - 1)));
                        break;
                }
            }
            else
            {
                switch (rotationAxis)
                {
                    case axis.X:
                        transform.localRotation = Quaternion.Euler(new Vector3(transform.localRotation.eulerAngles.x + speed * Time.deltaTime * (System.Convert.ToInt32(clockwise) * 2 - 1), transform.localRotation.eulerAngles.y, transform.localRotation.eulerAngles.z));
                        break;
                    case axis.Y:
                        transform.localRotation = Quaternion.Euler(new Vector3(transform.localRotation.eulerAngles.x, transform.localRotation.eulerAngles.y + speed * Time.deltaTime * (System.Convert.ToInt32(clockwise) * 2 - 1), transform.localRotation.eulerAngles.z));
                        break;
                    case axis.Z:
                        transform.localRotation = Quaternion.Euler(new Vector3(transform.localRotation.eulerAngles.x, transform.localRotation.eulerAngles.y, transform.localRotation.eulerAngles.z + speed * Time.deltaTime * (System.Convert.ToInt32(clockwise) * 2 - 1)));
                        break;
                }

            }
        }
    }
}
