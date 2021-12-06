using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }
    
    void Update()
    {
        anim.SetInteger("walkH", (int)Input.GetAxisRaw("Horizontal"));
        anim.SetInteger("walkV", (int)Input.GetAxisRaw("Vertical"));
    }
}
