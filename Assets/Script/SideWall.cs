using System;
using UnityEngine;

public class SideWall : MonoBehaviour {
    
    [SerializeField]
    private bool isRight;

    [SerializeField]
    private GameManager gameManager;

    void Start() {
        if (gameManager == null) {
            throw new MissingFieldException("GameManager is required!");
        }
    }
    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.GetComponent<Ball>()) {
            if (isRight) {
                gameManager.AddScore(false);
            } else {
                gameManager.AddScore(true);
            }
        }
    }
}
