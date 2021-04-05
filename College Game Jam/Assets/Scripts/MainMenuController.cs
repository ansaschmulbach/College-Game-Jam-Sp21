using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{

    public void StartGame()
    {
        GameManager.Instance.CustomerEnter();   
    }

    public void GoBackToMain()
    {
        GameManager.Instance.StartGame();   
    }

    public void Credits()
    {
        GameManager.Instance.Credits();   
    }
    
}
