using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{

    public static ScoreManager instance;

    public Text highScoreText;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        highScoreText.text = PlayerPrefs.GetInt("HighScore").ToString().PadLeft(6, '0');
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetHighScore(int currentScore)
    {
        if (currentScore > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", currentScore);
            PlayerPrefs.SetInt("LastScore", currentScore);
            highScoreText.text = PlayerPrefs.GetInt("HighScore").ToString().PadLeft(6, '0');
        }
        else
        {
            PlayerPrefs.SetInt("LastScore", currentScore);
        }
    }
}

[SerializeField]
public class Player
{
    public string playerName;
    public int playerScore;
}
