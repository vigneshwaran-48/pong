using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultUI : MonoBehaviour {

    [SerializeField]
    private GameManager gameManager;

    void Start() {
        if (!gameManager) {
            throw new MissingFieldException("GameManager is required!");
        }
    }

    public void OnPlayAgain() {
        gameManager.Restart();
    }

    public void OnExit() {
        Application.Quit();
    }
}

