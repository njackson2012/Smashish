using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAttack : MonoBehaviour
{
    public GameObject playerOne;
    public GameObject playerTwo;

    PlayerHealth playerOneHP;
    PlayerHealth playerTwoHP;

    InputManager input;


    void Start()
    {
        playerOneHP = playerOne.GetComponent<PlayerHealth>();
        playerTwoHP = playerTwo.GetComponent<PlayerHealth>();
        input = GetComponent<InputManager>();
    }

    void Update()
    {
        if (Input.GetButtonDown(input.bButton))
        {
            playerTwoHP.TakeDamage(10);
        }
    }
}
