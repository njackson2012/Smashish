using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

    public int startHP = 100;                       
    public int currentHP;                                
    public Slider hpBar;
    public Text hpText;

    [HideInInspector]
    public bool isDead = false;


    InputController inputController;

    void Start()
    {
        currentHP = startHP;
        inputController = GetComponent<InputController>();
    }

    void Update() {
        if (currentHP < 0)
            currentHP = 0;
        hpBar.value = currentHP;
        hpText.text = currentHP.ToString();
    }

    public void TakeDamage(int amount)
    {
       

        // Reduce the current health by the damage amount.
        currentHP -= amount;
        
        //playerAudio.Play();

        // If the player has lost all it's health and the death flag hasn't been set yet...
        if (currentHP <= 0 && !isDead)
        {
            Death();
        }
    }

    public void Death() {
        isDead = true;
        inputController.enabled = false;
    }

}
