using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UI.Extensions;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    int countCheck = 1;
    public static GameManager instance;
    [SerializeField] private float force;
    [SerializeField] private HorizontalScrollSnap changeGameModeSnapView;
    [SerializeField] private MeshRenderer backgroundRenderer;
    [SerializeField] private Image backgroundHomeImage;
    [SerializeField] private Material chickenBgMat;
    [SerializeField] private Material toiletBgMat;
    [SerializeField] private TextMeshProUGUI textScore, textScoreEndUI, textHighScore;
    [SerializeField] private TextMeshProUGUI textXScore;
    [SerializeField] private TextMeshProUGUI Praise;
    [SerializeField] private GameObject HomeUI, SettingUI, SkinUI, AchievementUI, PauseUI, LooseUIGameObj, EndUI, SpawnManagerGM, player;
    [SerializeField] private LooseUI looseUI;
    [SerializeField] private GameObject body, eye, foot, head;
    [SerializeField] private List<Material> materialList;
    Rigidbody rb;
    [SerializeField] int score;
    int highScore;
    bool stateGame;
    int XScore;
    bool runGame;
    Vector3 initialPos;
    bool checkSpawnRetry;
    //public GameObject panelGameOver;
    private void Awake()
    {
        rb = player.GetComponent<Rigidbody>();
        checkSpawnRetry = false;
        XScore = 1;
        stateGame = true;
        instance = this;
        initialPos = player.transform.position;
        textHighScore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
    }
    void Start()
    {
        //score = 35;
        runGame = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            score += 10;
            textScore.SetText(score.ToString());
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            score += 50;
            textScore.SetText(score.ToString());
        }
        if (Input.GetMouseButton(0) && !rb.useGravity)
        {
            rb.useGravity = true;
            return;
        }
    }
    public bool GetSateRunGame()
    {
        return runGame;
    }
    public void SetStateRunGame(bool state)
    {
        runGame = state;
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
                changeColorText(1, 1, 1);
            }
            else if (XScore == 4)
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
                XScore = 7;
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
    public void IncreamentXScore(int state)
    {
        XScore += state;
    }
    public int GetXScore()
    {
        return XScore;
    }


    public int GetScore()
    {
        return score;
    }

    public void ResetXXXScore()
    {
        XScore = 1;
    }
    public void Plus10Score()
    {
        score += 10;
        //textScore.text = score.ToString();
    }
    public void Plus5XScore()
    {
        if (GameManager.instance.GetXScore() < 4)
        {
            XScore = 4;
        }

        //textScore.text = score.ToString();  
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

    void changeColorText(float r, float g, float b)
    {
        Praise.color = new Color(r, g, b);
        textXScore.color = new Color(r, g, b);
    }

    // --------UI--------
    public void TapToPlay()
    {
        HomeUI.SetActive(false);
        SpawnManagerGM.SetActive(true);
        player.SetActive(true);
        int selectedIndex = GameData.ChickenSkinIndex;
        body.GetComponent<Renderer>().material = materialList[selectedIndex];
        eye.GetComponent<Renderer>().material = materialList[selectedIndex];
        head.GetComponent<Renderer>().material = materialList[selectedIndex];
        foot.GetComponent<Renderer>().material = materialList[selectedIndex];
    }

    public void ChangePage()
    {
        if (changeGameModeSnapView.CurrentPage == 0)
        {
            backgroundRenderer.material = chickenBgMat;
            backgroundHomeImage.color = chickenBgMat.color;
        }
        else if (changeGameModeSnapView.CurrentPage == 1)
        {
            backgroundRenderer.material = toiletBgMat;
            backgroundHomeImage.color = toiletBgMat.color;
        }
    }
    public void CloseSettingUI()
    {
        SettingUI.SetActive(false);
    }
    public void OpenSettingUI()
    {
        SettingUI.SetActive(true);
    }
    public void OpentSkinUI()
    {
        SkinUI.SetActive(true);
        HomeUI.SetActive(false);
    }
    public void OpenAchivementUI()
    {
        AchievementUI.SetActive(true);
        HomeUI.SetActive(false);
    }
    public void ReturnHomeUI()
    {
        SkinUI.SetActive(false);
        AchievementUI.SetActive(false);
        HomeUI.SetActive(true);
    }
    public void OpeanPauseUI()
    {
        PauseUI.SetActive(true);
        Time.timeScale = 0;
    }
    public void Resume()
    {
        PauseUI.SetActive(false);
        Time.timeScale = 1;
    }
    public void LooseUIActive()
    {
        if (score > GameData.HighestScore)
        {
            GameData.HighestScore = score;
        }
        LooseUIGameObj.SetActive(true);
        looseUI.SetUp(score);
    }
    public void SkipLooseUI()
    {

        LooseUIGameObj.SetActive(false);
        if (score > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", score);
            textHighScore.text = score.ToString();
        }
        textScoreEndUI.text = score.ToString();
        EndUI.SetActive(true);

    }
    public void ResetAll()
    {
        PlayerPrefs.DeleteKey("HighScore");
        textHighScore.text = "0";
    }
    public void Retry()
    {
        score = 0;
        textScore.text = score.ToString();
        player.transform.position = new Vector3(-2, 0, 2);
        rb.useGravity = false;
        player.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        SetStateGame(true);
        EndUI.SetActive(false);
        HomeUI.SetActive(false);
        PauseUI.SetActive(false);
        Praise.gameObject.SetActive(false);
        XScore = 1;
        GameObject[] objectToDestroy = GameObject.FindGameObjectsWithTag("Circle");
        foreach (GameObject obj in objectToDestroy)
        {
            Destroy(obj);
        }
        Time.timeScale = 1.0f;

        SpawnManager.Instance.Reset();
    }
    public void EndUIOrPauseUIReturnHomeUI()
    {
        print("Tro ve home");

        SceneManager.LoadScene(0);
    }
    // --------UI--------


    //--------
}
