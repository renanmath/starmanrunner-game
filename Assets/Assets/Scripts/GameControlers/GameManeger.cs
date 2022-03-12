using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class GameManeger : MonoBehaviour
{
    public GameObject gameOverScreen;
    //public GameObject mainCam;
    public static GameManeger instance;
    public Text scoreText;
    public double score;
    private double plusScore;    
    private GameObject mainPlayer;

    void Start()
    {
        instance = this;
        Time.timeScale = 1f;
        mainPlayer = GameObject.FindGameObjectWithTag("Player");
       
    }

    // Update is called once per frame
    void LateUpdate()
    {
      score = plusScore + Math.Ceiling(mainPlayer.transform.position.x/10);
      scoreText.text = score.ToString();
    }

    public void showGameOverScreen()
    {
        gameOverScreen.SetActive(true);
        Time.timeScale = 0f;
    }


    public void RestartGame()
    {
        SceneManager.LoadScene(1);
    }


     public void exitGame()
    {
        SceneManager.LoadScene(0);
    }


    public void changePlayStatus()
    {
        AudioManager.instance.changeAudioStatus(Time.timeScale);
        Time.timeScale = 1f - Time.timeScale;
        
      
    }


    public void increaseScore(double plus)
    {
        plusScore += plus;
    }
}
