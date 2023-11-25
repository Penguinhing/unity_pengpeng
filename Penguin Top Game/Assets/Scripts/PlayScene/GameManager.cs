using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    // 싱글톤 패턴 적용
    public static GameManager instance = null;

    


    private TextMeshProUGUI scoreText;


    private GameObject heartPanel;



    private GameObject gameOverPanel;


    private GameObject alertPanel;


    private GameObject scoreSavePanel;




    private int score = 0;
    private int penguins = 0;
    private int heart = 3;
    private float bubbleSpeed = 3.0f;


    private bool gameOver = false;


    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        scoreText = GameObject.Find("ScoreText").GetComponent<TextMeshProUGUI>();
        heartPanel = GameObject.Find("HeartPanel").gameObject;
        gameOverPanel = GameObject.Find("GameOverPanel").gameObject;
        alertPanel = GameObject.Find("AlertPanel").gameObject;
        scoreSavePanel = GameObject.Find("ScoreSavePanel").gameObject;

        gameOverPanel.SetActive(false);
        scoreSavePanel.SetActive(false);


    }


    public void IncreaseScore(bool redFish)
    {
        if (redFish)
        {
            score += 300;
        }
        else
        {
            ++penguins;
            score += 100;
        }
        

        scoreText.SetText(score.ToString());
        StartCoroutine(GameObject.Find("Frame").GetComponent<Background>().Refresh());

        // speed up
        if (penguins == 2 || penguins == 10 || penguins == 15 || penguins == 20)
        {
            SoundManager.instance.PlaySpeedUpSound();
            alertPanel.transform.GetChild(0).gameObject.SetActive(true);
            this.bubbleSpeed += 1.5f;
        }

    }




    public void KillPenguin()
    {
        Destroy(heartPanel.transform.Find("Layout").GetChild(0).gameObject);
        if (--heart <= 0)
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        SoundManager.instance.PlayGameOverSound();
        gameOver = true;
        gameOverPanel.SetActive(true);

        GameObject sc = gameOverPanel.transform.Find("score").gameObject;
        GameObject peng = gameOverPanel.transform.Find("peng").gameObject;

        sc.GetComponent<TextMeshProUGUI>().SetText(this.score.ToString() + "점 달성!");
        peng.GetComponent<TextMeshProUGUI>().SetText(this.penguins.ToString() + "마리 쌓아올림");



        Data data = RankManager.instance.Load();
        if (data == null || data.scores[data.scores.Count - 1] < this.score || data.scores.Count < 10)
        {
            scoreSavePanel.SetActive(true);
        }



        // 불필요한 오브젝트 삭제
        GameObject[] arr = new GameObject[3] { 
            GameObject.Find("Penguin") , GameObject.Find("Bubble(Clone)"), GameObject.Find("Bird") };

        for(int i = 0; i < arr.Length; i++)
        {
            if (arr[i] != null)
            {
                Destroy(arr[i].gameObject);
            }
        }
        



    }





    /*
     * Getter
     */
    public bool GetGameStatus()
    {
        return this.gameOver;
    }

    public GameObject GetGameOverPanel()
    {
        return this.gameOverPanel;
    }


    public int GetPenguins()
    {
        return this.penguins;
    }

    public float GetBubbleSpeed()
    {
        return this.bubbleSpeed;
    }


    public int GetScore()
    {
        return score;
    }
}
