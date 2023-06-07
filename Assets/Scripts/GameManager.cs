using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    int countCheck = 1;
    public static GameManager instance;
    [SerializeField] private TextMeshProUGUI textScore;
    [SerializeField] private TextMeshProUGUI textXScore;
    [SerializeField] private TextMeshProUGUI Praise;
    //public TextMeshProUGUI textYourScore;
    //public TextMeshProUGUI textHighScore;

    int score;
    //int highScore;
    bool stateGame;
    int XScore;
    //public GameObject panelGameOver;
    private void Awake()
    {
        XScore = 1;
        stateGame = true;
        instance = this;
        //PlayerPrefs.GetInt("HighScore", 0);
    }
    void Start()
    {
        score = 25;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void PraiseActive()
    {
        if (XScore > 1)
        {
            if (XScore == 2)
            {
                Praise.text = "Smooth";
                changeColorText(0.5804f, 0.5529f, 0.5098f);
            }
            else if (XScore == 3)
            {
                Praise.text = "Nice";
                changeColorText(1,1,1);
            }
            else if(XScore == 4)
            {
                Praise.text = "Sweet";
                changeColorText(0.8902f, 0.8118f, 0.3922f);
            }
            else if (XScore == 5)
            {
                Praise.text = "Awsome";
                changeColorText(0.9922f, 0.5961f, 0.0f);
            }
            else if (XScore == 6)
            {
                Praise.text = "Amazing";
                changeColorText(0.9098f, 0.2235f, 0.2235f);
            }
            else if (XScore == 7)
            {
                Praise.text = "Spectacular";
                changeColorText(0.5804f, 0.1922f, 0.8863f);
            }
            else
            {
                Praise.text = "Spectacular";
                changeColorText(0.5804f, 0.1922f, 0.8863f);
            }
            textXScore.text = "X" + XScore.ToString();

            Praise.gameObject.SetActive(true);
        }
        else
        {
            Praise.gameObject.SetActive(false);
        }

    }


    public void SetStateGame(bool state)
    {
        stateGame = state;
    }
    public bool GetStateGame()
    {
        return stateGame;
    }

    public void IncreamentScoreText()
    {
        score += XScore;
        textScore.text = score.ToString();

    }
    public void IncreamentXScore()
    {
        XScore++;
    }


    public int GetScore()
    {
        return score;
    }
 
    public void ResetXXXScore()
    {
        XScore = 1;
    }
    //public void ReplayGamew()
    //{
    //    SceneManager.LoadScene(0);
    //}
    //public void SetPanelGameOver(bool state)
    //{
    //    swish.SetActive(false);
    //    if (score > highScore)
    //    {

    //        PlayerPrefs.SetInt("HighScore", score);
    //        PlayerPrefs.Save();
    //    }

    //    textYourScore.text = "YOUR SCORE : " + score.ToString();
    //    textHighScore.text = "HIGH SCORE : " + PlayerPrefs.GetInt("HighScore", score).ToString();
    //    panelGameOver.SetActive(state);
    //}

    void changeColorText(float r, float g, float b )
    {
        Praise.color = new Color(r, g, b);
        textXScore.color = new Color(r, g, b);
    }

}
