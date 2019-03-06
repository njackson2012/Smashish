using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAttack : MonoBehaviour
{
    public GameObject playerOne;
    public GameObject playerTwo;

    PlayerHealth playerOneHP;
    PlayerHealth playerTwoHP;

    InputController inputController;


    void Start()
    {
        playerOneHP = playerOne.GetComponent<PlayerHealth>();
        playerTwoHP = playerTwo.GetComponent<PlayerHealth>();
        inputController = GetComponent<InputController>();
    }

    void Update()
    {
        if (Input.GetButtonDown(inputController.bButton))
        {
            playerTwoHP.TakeDamage(10);
        }
    }
}
