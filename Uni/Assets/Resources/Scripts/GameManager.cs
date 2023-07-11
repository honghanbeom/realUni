using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
// using TMPro; tmp를 사용했으면 붙여줘야함

public class GameManager : MonoBehaviour 
{
    public static GameManager instance;
    public Text scoreText;
    // public TMP_Text scoreText; 만약 tmp를 사용한 경우
    public GameObject gameOverUI;

    public bool isGameOver = false;
    public int score = 0;
    public int mushCount = 0;

    private void Awake() 
    {
        if /*(instance == null)*/(instance.isValid() == false)
        {
            instance = this;
        }
        else 
        {
            GFunc.LogWarning("씬에 두 개 이상의 게임 매니저가 존재합니다.");
            Destroy(gameObject);
        }


        

    }

    void Update() 
    {
        if (isGameOver == true && Input.GetMouseButtonDown(0))
        {
            //GFunc.LoadScene("SampleScene"); 
            GFunc.LoadScene(GFunc.GetActiveSceneName());
        }
    }

    public void AddScore(int newScore)
    {
        if (isGameOver == false)
        {
            score += newScore;
            scoreText.text = string.Format("Score : {0}",score);
        }
    }

    public void OnPlayerDead()
    {
        isGameOver = true;
        gameOverUI.SetActive(true);
    }



}