﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static GameManager instance;

    public AudioSource sound;
    public AudioClip music;
    public AudioClip gameOver;
    public Text scoreUI;
    public Text highScoreUI;
    public Text gameOverUI;

    public int score = 0;
    public int highScore;

    void Awake()
    {
        if (instance == null)
        {
            Debug.Log("yeas!");
            instance = this;
        }
        else
        {
            Debug.Log("Nooo");
        }
    }

    void Start()
    {
        instance.highScoreUI.text = "HighScore: " + PlayerPrefs.GetInt("highScore");
        sound = GetComponent<AudioSource>();
        scoreUI.text = "Score: " + score;
        instance.sound.clip = instance.music;
        instance.sound.Play();
    }

    private void Update()
    {
        HighScore();
    }

    public static void HighScore()
    {
        if (instance.score > instance.highScore)
        {
            instance.highScore = instance.score;
        }
        if (instance.highScore > PlayerPrefs.GetInt("highScore"))
        {
            instance.highScoreUI.text = "highScore: " + instance.highScore;
        }
    }
    public static void HighScoreSaver()
    {
        if (PlayerPrefs.HasKey("highScore") == true)
        {
            if (instance.highScore > PlayerPrefs.GetInt("highScore"))
            {
                int newHighScore = instance.highScore;
                PlayerPrefs.SetInt("highScore", newHighScore);
                PlayerPrefs.Save();
            }
        }
        else
        {
            int newHighScore = instance.highScore;
            PlayerPrefs.SetInt("highScore", newHighScore);
            PlayerPrefs.Save();
        }
    }
}
