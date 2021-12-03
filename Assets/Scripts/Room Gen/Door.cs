using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    Transform trans;

    void Awake()
    {
        trans = GetComponent<Transform>();

        Open();
    }

    public void Open()
    {
        trans.localScale = Vector3.zero;
    }

    public void Close()
    {
        trans.localScale = Vector3.one;
    }
}
