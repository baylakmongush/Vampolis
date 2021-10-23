using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
	public static GameManager instance;

    public event Action gameIsStart, gameIsOver;

    public bool isPlaying = false;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        if (isPlaying == false)
        {
            if (Input.anyKey)
            {
                isPlaying = true;
                GameIsStart();
            }
        }
    }

    public void GameIsStart()
    {
        gameIsStart?.Invoke();
    }

    public void GameIsOver()
    {
        isPlaying = false;
        gameIsOver?.Invoke();
    }
}
