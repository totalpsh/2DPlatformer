using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ResultPopup : MonoBehaviour
{
    //public GameObject highScoreLabel;
    public TextMeshProUGUI titleLabel;
    public TextMeshProUGUI scoreLabel;
    public GameObject HighScorePopup;

    private void OnEnable()
    {
        Time.timeScale = 0;

        if(GameManager.Instance.isCleared)
        {
            //float highScore = PlayerPrefs.GetFloat("HighScore", 0);
            //if(highScore < GameManager.Instance.timeLimit)
            //{
            //    highScoreLabel.SetActive(true);

            //    PlayerPrefs.SetFloat("HighScore", GameManager.Instance.timeLimit);
            //    PlayerPrefs.Save();
            //}
            //else
            //{
            //    highScoreLabel.SetActive(false);
            //}

            SaveHighScore();

            titleLabel.text = "Cleared!";
            scoreLabel.text = GameManager.Instance.timeLimit.ToString("#.##");
        }
        else
        {
            titleLabel.text = "Game Over...";
            scoreLabel.text = "";
        }
    }

    // 1위부터 10위까지의 기록들을 저장
    void SaveHighScore()
    {
        float score = GameManager.Instance.timeLimit;
        string currentScoreString = score.ToString("#.###");

        string savedScoreString = PlayerPrefs.GetString("HighScores", "");

        if(savedScoreString == "")
        {
            PlayerPrefs.SetString("HighScores", currentScoreString);
        }
        else
        {
            string[] scoreArray = savedScoreString.Split(",");
            List<string> scoreList = new List<string>(scoreArray);

            for(int i = 0; i < scoreList.Count; i++)
            {
                float savedScore = float.Parse(scoreList[i]);
                
                if(savedScore < score)
                {
                    scoreList.Insert(i, currentScoreString);
                    break;
                }
            }

            if(scoreArray.Length == scoreList.Count)
            {
                scoreList.Add(currentScoreString);
            }

            if(scoreList.Count > 10)
            {
                scoreList.RemoveAt(10);
            }

            string result = string.Join(",", scoreList);

            PlayerPrefs.SetString("HighScores", result);
        }

        PlayerPrefs.Save();
    }

    public void PlayAgainPressed()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("GameScene");
    }

    public void HighScorePressed()
    {
        HighScorePopup.SetActive(true);
    }
}
