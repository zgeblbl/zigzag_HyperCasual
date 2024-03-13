using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject loseUI;
    public GameObject winUI;
    public int score;
    public TextMeshProUGUI winScoreText;
    public TextMeshProUGUI loseScoreText;
    public TextMeshProUGUI ingameScoreText;
    public AudioSource winSound;

    void Start()
    {
        
    }
    public void LevelEnd()
    {
        loseUI.SetActive(true);
        loseScoreText.text = "FINAL SCORE: " + score;
        ingameScoreText.gameObject.SetActive(false);
    }
    public void WinLevel()
    {
        winUI.SetActive(true);
        winScoreText.text = "FINAL SCORE: " + score;
        winSound.Play();
        ingameScoreText.gameObject.SetActive(false);
    }
    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void AddScore(int pointValue)
    {
        score += pointValue;
        ingameScoreText.text = ("SCORE: ") + score;
    }

    public void StartApp()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void GameQuit()
    {
        Application.Quit();
    }
}
