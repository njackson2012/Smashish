using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour
{

    bool gameOver;

    public GameObject playerOne;
    public GameObject playerTwo;
    public GameObject playerOneWin;
    public GameObject playerTwoWin;
    public GameObject gameOverMenu;
    public EventSystem ES;

    PlayerHealth playerOneHP;
    PlayerHealth playerTwoHP;

   
    void Start()
    {

        Time.timeScale = 1.0f;
        gameOver = false;

        playerOneWin.SetActive(false);
        playerTwoWin.SetActive(false);
        gameOverMenu.SetActive(false);

        playerOneHP = playerOne.GetComponent<PlayerHealth>();
        playerTwoHP = playerTwo.GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {

        if (playerOneHP.isDead == true && gameOver == false) {
            GameOver();
            playerTwoWin.SetActive(true);
        }

        if (playerTwoHP.isDead == true && gameOver == false)
        {
            GameOver();
            playerOneWin.SetActive(true);
        }
    }

    void GameOver()
    {
        gameOver = true;
        StartCoroutine("SlowDown");
    }

    IEnumerator SlowDown()
    {
        for (float f = 1f; f >= 0; f -= 0.1f)
        {
            if (f > 0.11f)
                Time.timeScale -= 0.1f;
            else
            {
                gameOverMenu.SetActive(true);
                ES.SetSelectedGameObject(GameObject.Find("RematchButton"));
                Time.timeScale = 0;
            }

            yield return new WaitForSeconds(.1f);
        }

    }
}
