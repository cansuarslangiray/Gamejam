using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour
{
    Color lerpedColor = Color.white;
    Renderer renderer;
    float time;
    float time2;
    [SerializeField] Color color1;
    [SerializeField] Color color2;
    [SerializeField] Color color3;
    private int colorIndex;
    private MenuManager menuManager;
    private bool isDone;

    void Start()
    {
        print("timeis" + Time.time);
        renderer = GetComponent<SpriteRenderer>();
        menuManager = GameObject.FindAnyObjectByType<MenuManager>();
    }

    void Update()
    {

        if (colorIndex >1 && !isDone)
        {
            isDone = true;
            print("LION");
            FindObjectOfType<MenuManager>().NextLevel();
        }
        //print("TEST " + Time.time);
        if (colorIndex < 1)
        {
            time = Time.time / 30;
            lerpedColor = Color.Lerp(color1, color2, time);
            renderer.material.color = lerpedColor;

            if (lerpedColor == color2)
                colorIndex++;
            return;
        }

        if (colorIndex < 2)
        {
            time2 = (Time.time-30) / 60;
            lerpedColor = Color.Lerp(color2, color3, time2);
            renderer.material.color = lerpedColor;

            if (lerpedColor == color3)
                colorIndex++;
        }
        Debug.Log("Hereee");
        
    }
}
