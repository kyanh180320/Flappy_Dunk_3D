using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RankManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static RankManager instance;
    [SerializeField] private Image imageRank, greenTickImage;
    [SerializeField] private TextMeshProUGUI nameRank, scoreRank;
    [SerializeField] private Sprite[] imageRankList;
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
        if (score >= 2 && score < 12)
        {
            if (checkRandomImage == 1)
            {
               
                StartCoroutine(ChangeSprite());
                ChangeRank("12", "BEGINNER I");
                checkRandomImage++;
            }
        }
        else if (score >= 12 && score < 28)
        {
            if (checkRandomImage == 2)
            {
                StartCoroutine(ChangeSprite());
                checkRandomImage++;

            }
        }
        else if (score >= 38 && score < 58)
        {
            if (checkRandomImage == 3)
            {
                StartCoroutine(ChangeSprite());
                checkRandomImage++;
            }
        }
        //else if (score >= 18 && score < 23)
        //{
        //    checkRandomImage = true;
        //    if (checkRandomImage)
        //    {
        //        ChangeRank("23", "BEGGINER III");
        //        checkRandomImage = false;
        //    }
        //}
        //else if (score >= 23 && score < 35)
        //{
        //    checkRandomImage = true;
        //    if (checkRandomImage)
        //    {
        //        ChangeRank("35", "INTERMEDIATE I");
        //        checkRandomImage = false;
        //    }
        //}
        //else if (score >= 35 && score < 40)
        //{
        //    checkRandomImage = true;

        //    if (checkRandomImage)
        //    {
        //        ChangeRank("40", "INTERMEDIATE I");
        //        checkRandomImage = false;
        //    }
        //}
    }
    IEnumerator ChangeSprite()
    {

        Color currentColor = imageRank.color;
        currentColor.a = 0.5f;
        imageRank.color = currentColor;
        greenTickImage.gameObject.SetActive(true);

        yield return new WaitForSeconds(3f);
        greenTickImage.gameObject.SetActive(false);
        imageRank.sprite = imageRankList[Random.Range(0,imageRankList.Length)];
        currentColor.a = 1f;
        imageRank.color = currentColor;

    }

  



    void ChangeRank(string scoreRank, string nameRank)
    {
        this.scoreRank.text = scoreRank;
        this.nameRank.text = nameRank;
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
