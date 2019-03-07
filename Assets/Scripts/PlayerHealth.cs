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


    MovementController movement;

    void Start()
    {
        currentHP = startHP;
        movement = GetComponent<MovementController>();
    }

    void Update() {
        if (currentHP < 0)
            currentHP = 0;
        hpBar.value = currentHP;
        hpText.text = currentHP.ToString();
    }

    public void TakeDamage(int amount)
    {
       


        currentHP -= amount;
        
        //playerAudio.Play();


        if (currentHP <= 0 && !isDead)
        {
            Death();
        }
    }

    public void Death() {
        isDead = true;
        movement.enabled = false;
    }

}
