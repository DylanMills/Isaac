using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class End : MonoBehaviour
{
    Image image;

    float timer;

    void Awake()
    {
        image = GetComponent<Image>();

        timer = 0f;
    }

    void Update()
    {
        image.color = new Color(0, 0, 0, Mathf.Clamp01(timer));

        timer += .0005f;
    }
}
