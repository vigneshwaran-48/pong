using System;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour {
    
    [SerializeField]
    private GameObject ballPrefab;

    [SerializeField]
    private Transform[] ballSpawnPoints;
    
    [SerializeField]
    private TextMeshProUGUI aiScoreText;

    [SerializeField]
    private TextMeshProUGUI playerScoreText;

    [SerializeField]
    private TextMeshProUGUI resultMessage;

    [SerializeField]
    private TextMeshProUGUI resultAIScore;

    [SerializeField]
    private TextMeshProUGUI resultPlayerScore;

    [SerializeField]
    private GameObject resultUI;


    private GameObject currentBall;

    private int playerScore;
    private int aiScore;

    void Start() {
        if (ballSpawnPoints == null || ballSpawnPoints.Length == 0) {
            throw new MissingFieldException("ballSpawnPoints is empty!");
        }
        if (!playerScoreText || !aiScoreText) {
            throw new MissingFieldException("aiScoreText or playerScoreText is missing!");
        }
        Init();
        SpawnBall();
    }

    public void AddScore(bool isPlayer) {
        DestroyBall();
        setScore(isPlayer, isPlayer ? playerScore + 1 : aiScore + 1);
        if (playerScore == 10 || aiScore == 10) {
            OnGameFinish();
            return;
        }
        SpawnBall();
    }

    public void Restart() {
        Init();
        SpawnBall();
    }



    private void Init() {
        setScore(false, 0);
        setScore(true, 0);
        resultUI.SetActive(false);
    }

    private void DestroyBall() {
        if (currentBall) {
            Destroy(currentBall.gameObject);
        }
    }

    private void SpawnBall() {
        int index = UnityEngine.Random.Range(0, ballSpawnPoints.Length);
        currentBall = Instantiate(ballPrefab, ballSpawnPoints[index].position, Quaternion.identity, ballSpawnPoints[index].parent);
    }

    private void setScore(bool isPlayer, int score) {
        if (isPlayer) {
            playerScore = score;
            playerScoreText.SetText(score + "");
        } else {
            aiScore = score;
            aiScoreText.SetText(score + "");
        }
    }

    private void OnGameFinish() {
        resultUI.SetActive(true);
        resultAIScore.SetText(aiScore + "");
        resultPlayerScore.SetText(playerScore + "");
        if (playerScore == 10) {
            resultMessage.SetText("You Won!");
        } else if (aiScore == 10) {
            resultMessage.SetText("Game Over!");
        } else {
            resultMessage.SetText("Game Stopped!");
        }
    }

}
