using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreController : MonoBehaviour
{

    public static HighScoreController instance;

    public GameObject newHighScorePanel;
    public bool panelShowed = true;

    public Text pName1;
    public Text pName2;
    public Text pName3;
    public Text pName4;
    public Text pName5;

    public Text pScore1;
    public Text pScore2;
    public Text pScore3;
    public Text pScore4;
    public Text pScore5;

    public InputField inputField;

    public Text temp;
    public string tempString = "";

    void Start()
    {
        instance = this;
        UpdateUI();
        CheckScore();
        UpdateUI();
    }

    private void UpdateUI()
    {
        pName1.text = PlayerPrefs.GetString("Player1", "Anonymus");
        pName2.text = PlayerPrefs.GetString("Player2", "Anonymus");
        pName3.text = PlayerPrefs.GetString("Player3", "Anonymus");
        pName4.text = PlayerPrefs.GetString("Player4", "Anonymus");
        pName5.text = PlayerPrefs.GetString("Player5", "Anonymus");

        pScore1.text = PlayerPrefs.GetInt("HighScore1", 500).ToString().PadLeft(6,'0');
        pScore2.text = PlayerPrefs.GetInt("HighScore2", 500).ToString().PadLeft(6, '0');
        pScore3.text = PlayerPrefs.GetInt("HighScore3", 500).ToString().PadLeft(6, '0');
        pScore4.text = PlayerPrefs.GetInt("HighScore4", 500).ToString().PadLeft(6, '0');
        pScore5.text = PlayerPrefs.GetInt("HighScore5", 500).ToString().PadLeft(6, '0');


    }

    private void CheckScore()
    {
        int lastScore = PlayerPrefs.GetInt("LastScore");

        if (lastScore >= PlayerPrefs.GetInt("HighScore1"))
        {
            MagicLoop(1);
            PlayerPrefs.SetInt("HighScore1", lastScore);
            newHighScorePanel.SetActive(true);
            pScore1.text = lastScore.ToString().PadLeft(6, '0');
            temp = pName1;
            tempString = "Player1";

            panelShowed = false;
        }
        else if (lastScore >= PlayerPrefs.GetInt("HighScore2"))
        {
            MagicLoop(2);
            PlayerPrefs.SetInt("HighScore2", lastScore);
            newHighScorePanel.SetActive(true);
            pScore2.text = lastScore.ToString().PadLeft(6, '0');
            temp = pName2;
            panelShowed = false;
            tempString = "Player2";
        }
        else if (lastScore >= PlayerPrefs.GetInt("HighScore3"))
        {
            MagicLoop(3);
            PlayerPrefs.SetInt("HighScore3", lastScore);
            newHighScorePanel.SetActive(true);
            pScore3.text = lastScore.ToString().PadLeft(6, '0');
            temp = pName3;
            panelShowed = false;
            tempString = "Player3";
        }
        else if (lastScore >= PlayerPrefs.GetInt("HighScore4"))
        {
            MagicLoop(4);
            PlayerPrefs.SetInt("HighScore4", lastScore);
            newHighScorePanel.SetActive(true);
            pScore4.text = lastScore.ToString().PadLeft(6, '0');
            temp = pName3;
            panelShowed = false;
            tempString = "Player4";
        }
        else if (lastScore >= PlayerPrefs.GetInt("HighScore5"))
        {
            PlayerPrefs.SetInt("HighScore5", lastScore);
            newHighScorePanel.SetActive(true);
            pScore5.text = lastScore.ToString().PadLeft(6, '0');
            temp = pName4;
            panelShowed = false;
            tempString = "Player5";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Done()
    {
        temp.text = inputField.text;
        PlayerPrefs.SetString(tempString, inputField.text);
        panelShowed = true;
    }

    public void MagicLoop(int counter)
    {
        for(int i=4; i>=counter; i--)
        {
            string tempName = PlayerPrefs.GetString("Player" + (i),"Anonymus");
            int tempScore = PlayerPrefs.GetInt("HighScore" + (i),500);

            PlayerPrefs.SetInt("HighScore" + (i+1),tempScore);
            PlayerPrefs.SetString("Player" + (i+1), tempName);

        }
    }
}
