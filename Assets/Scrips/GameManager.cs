using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject virtualCamera;
    public Player player;
    public Lifes lifeDisplayer;
    public GameObject resultPopup;
    public TextMeshProUGUI scoreLabel;

    public float timeLimit = 30;
    public int lifes = 3;
    public bool isCleared;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;

        lifeDisplayer.SetLifes(lifes);

        isCleared = false;
    }

    // Update is called once per frame
    void Update()
    {
        timeLimit -= Time.deltaTime;

        scoreLabel.text = "Time Left : " + timeLimit.ToString("##.#");
    }

    public void AddTime(float time)
    {
        timeLimit += time;
    }

    public void Die()
    {
        virtualCamera.SetActive(false);

        lifes -= 1;
        lifeDisplayer.SetLifes(lifes);
        Invoke("Restart", 2);

    }

    public void Restart()
    {
        if (lifes == 0)
        {
            GameOver();
        }
        else
        {
            virtualCamera.SetActive(true);
            player.Restart();
        }
    }

    public void StageClear()
    {
        isCleared = true;

        resultPopup.SetActive(true);
    }

    public void GameOver()
    {
        isCleared = false;

        resultPopup.SetActive(true);
    }
}
