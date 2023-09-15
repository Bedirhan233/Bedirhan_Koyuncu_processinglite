using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour
{
    public int currentScore;
    public TextMeshProUGUI DisplayScore;
    public TextMeshProUGUI FinalScore;

    public GameObject GameOverUI;


    public Image healthbar;
    // Start is called before the first frame update
    void Start()
    {
        GameOverUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ScoreManagment (int getScore, float LoseHealth)
    {
        
        currentScore = currentScore + getScore;


        DisplayScore.text = currentScore.ToString();
        

        healthbar.fillAmount = healthbar.fillAmount - LoseHealth;

        if(healthbar.fillAmount <= 0)
        {
            GameisOver();
        }

    }

     void GameisOver()
    {
        FinalScore.text = currentScore.ToString();
        Time.timeScale = 0;
        GameOverUI.SetActive(true);
    }

    public void restart()
    {
        SceneManager.LoadScene("SampleScene");
        Time.timeScale = 1;
        GameOverUI.SetActive(false);
    }
}
