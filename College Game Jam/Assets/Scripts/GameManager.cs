﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance = null;
    public GameState gameState = new GameState();

    #region Unity_functions
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        } else if (Instance != this)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
    #endregion

    #region Scene_transitions
    public void StartGame()
    {
        SceneManager.LoadScene("StartScene"); //very specific names! make sure they match in unity :D
    }
    public void GameScreen()
    {
        SceneManager.LoadScene("AssemblyScene");
    }
    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }
    #endregion
}
