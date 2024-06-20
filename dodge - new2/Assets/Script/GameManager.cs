using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameovreText;
    public Text timeText;
    public Text recodeText;
    public Text myrecodeText;
    public GameObject hiddenButton;

    float surviveTime;
    bool isGameover;

    public Text scoreText;
    int currentScore = 0;

    public void SetScore(int score)
    {
        currentScore += score;
        scoreText.text = "Score: " + currentScore.ToString();
    }

    // Start is called before the first frame update
    void Start()
    {
        surviveTime = 0;
        isGameover = false;
                
    }

    public void LoadScene(int sceneId)
    {
        SceneManager.LoadScene(sceneId);
    }

    


    public void EndGame()
    {
        isGameover=true;

        gameovreText.SetActive(true);

        float b = PlayerPrefs.GetFloat("BestScore");

        if(surviveTime + currentScore > b + currentScore)
        {
            b = surviveTime + currentScore;
            PlayerPrefs.SetFloat("BestScore", b);
        }

        recodeText.text = "Best Score: " + (int)b;

        float m = PlayerPrefs.GetFloat("MyRecord");
        m = surviveTime + currentScore;
        myrecodeText.text = "My Record: " + (int) m;

        if(m > 25)
        {
            hiddenButton.SetActive(true);
        }
    }

    public void Retry() //Retry 함수를 만들어냄
    {
        SceneManager.LoadScene("SampleScene"); //Retry를 누르면 씬을 로드
    }

    public void GameExit()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }


    // Update is called once per frame
    void Update()
    {
       
        if(!isGameover) 
        {
            surviveTime += Time.deltaTime;
            timeText.text = "Time: " + (int) surviveTime;
        }
        else
        {
            if(Input.GetKeyDown(KeyCode.R)) 
            {
                SceneManager.LoadScene("SampleScene");
            }
        }
    }
}
