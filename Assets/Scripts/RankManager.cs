using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class RankManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static RankManager instance;
    [SerializeField] private Image imageRank, greenTickImage;
    [SerializeField] private TextMeshProUGUI nameRank, scoreRank;
    [SerializeField] private Sprite[] imageRankList;
    [SerializeField] private Sprite borderBeginner, borderIntermediate, borderAdvanced, borderProfessional, borderMaster, borderLegendary;
    [SerializeField] private Image backgroundRank;
    float timeChangeImageCounter;
    [SerializeField] private float timeToChangeImage;
    int checkRandomImage;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        checkRandomImage = 1;
    }

    // Update is called once per frame
    void Update()
    {

        int score = GameManager.instance.GetScore();
        if (score >= 8 && score < 12)
        {
            if (checkRandomImage == 1)
            {
               
                StartCoroutine(ChangeSprite());
                ChangeRank("12", "BEGINNER I",borderBeginner,113,113, 0.91f, 0.57f, 0.4f);
                checkRandomImage++;
            }
        }
        else if (score >= 12 && score < 18)
        {
            if (checkRandomImage == 2)
            {
                StartCoroutine(ChangeSprite());
                ChangeRank("18", "BEGGINNER II",borderBeginner,113,113, 0.91f, 0.57f, 0.4f);
                checkRandomImage++;

            }
        }
        else if (score >= 18 && score < 23)
        {
            if (checkRandomImage == 3)
            {
                StartCoroutine(ChangeSprite());
                ChangeRank("23", "BEGGINNER III", borderBeginner, 113, 113, 0.91f, 0.57f, 0.4f);
                checkRandomImage++;
            }
        }
        else if (score >= 23 && score < 35)
        {
            if(checkRandomImage == 4)
            {
                StartCoroutine(ChangeSprite());
                ChangeRank("35", "INTERMEDIATE I", borderIntermediate, 255, 113, 0.42f, 0.34f, 0.64f);
                checkRandomImage++;
            }
        }
        else if (score >= 35 && score < 40)
        {
            if(checkRandomImage==5)
            {
                StartCoroutine(ChangeSprite());
                ChangeRank("40", "INTERMEDIATE II", borderIntermediate, 255, 113, 0.42f, 0.34f, 0.64f);
                checkRandomImage++;
            }
        }
        else if (score >= 40 && score < 48)
        {
            if(checkRandomImage == 6)
            {
                StartCoroutine(ChangeSprite());
                ChangeRank("48", "INTERMEDIATE III", borderIntermediate, 255, 113, 0.42f, 0.34f, 0.64f);
                checkRandomImage++;
            }
        }
        else if (score >= 48 && score < 57)
        {
            if(checkRandomImage == 7)
            {
                StartCoroutine(ChangeSprite());
                ChangeRank("57", "ADVANCED I", borderAdvanced, 200, 113, 0.87f, 0.47f, 0.32f);
                checkRandomImage++;
            }
        }
        else if (score >= 57 && score < 65)
        {
            if (checkRandomImage == 8)
            {
                StartCoroutine(ChangeSprite());
                ChangeRank("65", "ADVANCED I", borderAdvanced, 200, 113, 0.87f, 0.47f, 0.32f);
                checkRandomImage++;
            }
        }
        else if (score >= 65 && score < 71)
        {
            if (checkRandomImage == 9)
            {
                StartCoroutine(ChangeSprite());
                ChangeRank("71", "ADVANCED II", borderAdvanced, 200, 113, 0.87f, 0.47f, 0.32f);
                checkRandomImage++;
            }
        }
        else if (score >= 71 && score < 80)
        {
            if (checkRandomImage == 10)
            {
                StartCoroutine(ChangeSprite());
                ChangeRank("80", "ADVANCED II", borderAdvanced, 200, 113, 0.87f, 0.47f, 0.32f);
                checkRandomImage++;
            }
        }
        else if (score >= 80 && score < 90)
        {
            if (checkRandomImage == 11)
            {
                StartCoroutine(ChangeSprite());
                ChangeRank("90", "ADVANCED III", borderAdvanced, 200, 113, 0.87f, 0.47f, 0.32f);
                checkRandomImage++;
            }
        }
        else if (score >= 90 && score < 100)
        {
            if (checkRandomImage == 12)
            {
                StartCoroutine(ChangeSprite());
                ChangeRank("100", "ADVANCED III", borderAdvanced, 200, 113, 0.87f, 0.47f, 0.32f);
                checkRandomImage++;
            }
        }
        else if (score >= 100 && score < 125)
        {
            if (checkRandomImage == 13)
            {
                StartCoroutine(ChangeSprite());
                ChangeRank("125", "PROFESSIONAL I", borderProfessional, 125, 113, 0.69f, 0.74f, 0.85f);
                checkRandomImage++;
            }
        }
        else if (score >= 125 && score < 140)
        {
            if (checkRandomImage == 14)
            {
                StartCoroutine(ChangeSprite());
                ChangeRank("140", "PROFESSIONAL I", borderProfessional, 125, 113, 0.69f, 0.74f, 0.85f);
                checkRandomImage++;
            }
        }
        else if (score >= 140 && score < 150)
        {
            if (checkRandomImage == 15)
            {
                StartCoroutine(ChangeSprite());
                ChangeRank("150", "PROFESSIONAL II", borderProfessional, 125, 113, 0.69f, 0.74f, 0.85f);
                checkRandomImage++;
            }
        }
        else if (score >= 150 && score < 164)
        {
            if (checkRandomImage == 16)
            {
                StartCoroutine(ChangeSprite());
                ChangeRank("164", "PROFESSIONAL II", borderProfessional, 125, 113, 0.69f, 0.74f, 0.85f);
                checkRandomImage++;
            }
        }
        else if (score >= 164 && score < 180)
        {
            if (checkRandomImage == 17)
            {
                StartCoroutine(ChangeSprite());
                ChangeRank("180", "PROFESSIONAL III", borderProfessional, 125, 113, 0.69f, 0.74f, 0.85f);
                checkRandomImage++;
            }
        }
        else if (score >= 180 && score < 193)
        {
            if (checkRandomImage == 18)
            {
                StartCoroutine(ChangeSprite());
                ChangeRank("193", "MASTER I", borderMaster, 258, 110, 0.94f, 0.68f, 0.29f);
                checkRandomImage++;
            }
        }
        else if (score >= 193 && score < 202)
        {
            if (checkRandomImage == 19)
            {
                StartCoroutine(ChangeSprite());
                ChangeRank("202", "MASTER I", borderMaster, 258, 110, 0.94f, 0.68f, 0.29f);
                checkRandomImage++;
            }
        }
        else if (score >= 202 && score < 215)
        {
            if (checkRandomImage == 20)
            {
                StartCoroutine(ChangeSprite());
                ChangeRank("215", "MASTER I", borderMaster, 258, 110, 0.94f, 0.68f, 0.29f);
                checkRandomImage++;
            }
        }
        else if (score >= 215 && score < 226)
        {
            if (checkRandomImage == 21)
            {
                StartCoroutine(ChangeSprite());
                ChangeRank("226", "MASTER II", borderMaster, 258, 110, 0.94f, 0.68f, 0.29f);
                checkRandomImage++;
            }
        }
        else if (score >= 226 && score < 239)
        {
            if (checkRandomImage == 22)
            {
                StartCoroutine(ChangeSprite());
                ChangeRank("239", "MASTER II", borderMaster, 258, 110, 0.94f, 0.68f, 0.29f);
                checkRandomImage++;
            }
        }
        else if (score >= 239 && score < 250)
        {
            if (checkRandomImage == 23)
            {
                StartCoroutine(ChangeSprite());
                ChangeRank("250", "MASTER II", borderMaster, 258, 110, 0.94f, 0.68f, 0.29f);
                checkRandomImage++;
            }
        }
        else if (score >= 250 && score < 264)
        {
            if (checkRandomImage == 24)
            {
                StartCoroutine(ChangeSprite());
                ChangeRank("264", "MASTER III", borderMaster, 258, 110, 0.94f, 0.68f, 0.29f);
                checkRandomImage++;
            }
        }
        else if (score >= 264 && score < 273)
        {
            if (checkRandomImage == 25)
            {
                StartCoroutine(ChangeSprite());
                ChangeRank("273", "MASTER III", borderMaster, 258, 110, 0.94f, 0.68f, 0.29f);
                checkRandomImage++;
            }
        }
        else if (score >= 273 && score < 285)
        {
            if (checkRandomImage == 26)
            {
                StartCoroutine(ChangeSprite());
                ChangeRank("285", "MASTER III", borderMaster, 258, 110, 0.94f, 0.68f, 0.29f);
                checkRandomImage++;
            }
        }
        else if (score >= 285 && score < 296)
        {
            if (checkRandomImage == 27)
            {
                StartCoroutine(ChangeSprite());
                ChangeRank("296", "LEGENDARY I", borderMaster, 258, 110, 0.76f,0.5f,0.95f);
                checkRandomImage++;
            }
        }
        else if (score >= 296 && score < 312)
        {
            if (checkRandomImage == 28)
            {
                StartCoroutine(ChangeSprite());
                ChangeRank("312", "LEGENDARY I", borderMaster, 258, 110, 0.76f,0.5f,0.95f);
                checkRandomImage++;
            }
        }
        else if (score >= 312 && score < 325)
        {
            if (checkRandomImage == 29)
            {
                StartCoroutine(ChangeSprite());
                ChangeRank("325", "LEGENDARY I", borderMaster, 258, 110, 0.76f, 0.5f, 0.95f);
                checkRandomImage++;
            }
        }
        else if (score >= 325 && score < 337)
        {
            if (checkRandomImage == 30)
            {
                StartCoroutine(ChangeSprite());
                ChangeRank("337", "LEGENDARY II", borderMaster, 258, 110, 0.76f, 0.5f, 0.95f);
                checkRandomImage++;
            }
        }
        else if (score >= 337 && score < 349)
        {
            if (checkRandomImage == 31)
            {
                StartCoroutine(ChangeSprite());
                ChangeRank("349", "LEGENDARY II", borderMaster, 258, 110, 0.76f, 0.5f, 0.95f);
                checkRandomImage++;
            }
        }
        else if (score >= 349 && score < 360)
        {
            if (checkRandomImage == 32)
            {
                StartCoroutine(ChangeSprite());
                ChangeRank("360", "LEGENDARY II", borderMaster, 258, 110, 0.76f, 0.5f, 0.95f);
                checkRandomImage++;
            }
        }
        else if (score >= 360 && score < 370)
        {
            if (checkRandomImage == 33)
            {
                StartCoroutine(ChangeSprite());
                ChangeRank("370", "LEGENDARY II", borderMaster, 258, 110, 0.76f, 0.5f, 0.95f);
                checkRandomImage++;
            }
        }
        else if (score >= 370 && score < 381)
        {
            if (checkRandomImage == 34)
            {
                StartCoroutine(ChangeSprite());
                ChangeRank("381", "LEGENDARY III", borderMaster, 258, 110, 0.76f, 0.5f, 0.95f);
                checkRandomImage++;
            }
        }
        else if (score >= 381 && score < 393)
        {
            if (checkRandomImage == 34)
            {
                StartCoroutine(ChangeSprite());
                ChangeRank("393", "LEGENDARY III", borderMaster, 258, 110, 0.76f, 0.5f, 0.95f);
                checkRandomImage++;
            }
        }
        else if (score >= 393 && score < 400)
        {
            if (checkRandomImage == 34)
            {
                StartCoroutine(ChangeSprite());
                ChangeRank("400", "LEGENDARY III", borderMaster, 258, 110, 0.76f, 0.5f, 0.95f);
                checkRandomImage++;
            }
        }

    
    }
    IEnumerator ChangeSprite()
    {

        Color currentColor = imageRank.color;
        currentColor.a = 0.5f;
        imageRank.color = currentColor;
        greenTickImage.gameObject.SetActive(true);

        yield return new WaitForSeconds(2f);
        greenTickImage.gameObject.SetActive(false);
        imageRank.sprite = imageRankList[Random.Range(0,imageRankList.Length)];
        currentColor.a = 1f;
        imageRank.color = currentColor;

    }

  



    void ChangeRank(string scoreRank, string nameRank,Sprite borderRank, float x, float y,float r, float g, float b)
    {
        this.scoreRank.text = scoreRank;
        this.nameRank.text = nameRank;
        this.nameRank.color = new Color(r, g, b);   
        this.backgroundRank.sprite = borderRank;    
        this.backgroundRank.GetComponent<RectTransform>().sizeDelta = new Vector2(x, y);
    }
    void WaitToChangeRankImage(string newRank)
    {
        timeChangeImageCounter += Time.deltaTime;
        if (timeChangeImageCounter > timeToChangeImage)
        {
            print("Thoi gian chay");
            timeChangeImageCounter = 0;

            int randomImage = Random.Range(0, imageRankList.Length);
            imageRank.sprite = imageRankList[randomImage];

            nameRank.text = newRank;
            greenTickImage.gameObject.SetActive(false);
            Color currentColor = imageRank.color;
            currentColor.a = 1f;
            imageRank.color = currentColor;
        }

    }

}
