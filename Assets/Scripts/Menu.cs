using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class Menu : MonoBehaviour
{

    public EventSystem ES;
    private GameObject storeSelected;
    private GameObject lastSelectedGameObject;

    void Update()
    {
        if (ES.currentSelectedGameObject != storeSelected)
        {
            lastSelectedGameObject = storeSelected;
            storeSelected = ES.currentSelectedGameObject;
            if (ES.currentSelectedGameObject == null)
                ES.SetSelectedGameObject(lastSelectedGameObject);
        }
    }
    public void LoadGame(int scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    private void GetLastGameObjectSelected()
    {
        if (ES.currentSelectedGameObject != storeSelected)
        {
            
        }
    }

    public void SetBack()
    {
        ES.SetSelectedGameObject(GameObject.Find("BackButton"));
    }
    public void SetHelp()
    {
        ES.SetSelectedGameObject(GameObject.Find("HelpButton"));
    }
}
