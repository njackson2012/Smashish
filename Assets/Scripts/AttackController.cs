﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackController : MonoBehaviour
{
    private Animator anim;
    InputManager input;
    // Start is called before the first frame update
    void Start()
    {
        input = GetComponent<InputManager>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis(input.leftAnalogY) > 0 && Input.GetButtonDown(input.bButton))
        {
            anim.SetTrigger("DownSmash");
        }

        else if (Input.GetAxis(input.leftAnalogY) < 0 && Input.GetButtonDown(input.bButton))
        {
            anim.SetTrigger("UpSmash");
        }
    }
}
