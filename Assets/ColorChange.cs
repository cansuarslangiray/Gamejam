using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour
{
    Color lerpedColor = Color.white;
    Renderer renderer;
    float time;

    void Start()
    {
        renderer = GetComponent<Renderer>();
    }

    void Update()
    {
        time = Time.time / 30;
        lerpedColor = Color.Lerp(new Color(1, 1, 1, 1), Color.red, time);
        renderer.material.color = lerpedColor;
    }
}
