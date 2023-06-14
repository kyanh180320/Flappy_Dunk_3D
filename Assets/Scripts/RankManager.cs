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
    bool checkRandomImage;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        checkRandomImage = true;
    }

    // Update is called once per frame
    void Update()
    {

        if (GameManager.instance.GetScore() >= 8 && GameManager.instance.GetScore() < 12)
        {
            checkRandomImage = true;
            ChangeRank("12", "BEGINNER I");
        }
        else if (GameManager.instance.GetScore() >= 12 && GameManager.instance.GetScore() < 18)
        {
            checkRandomImage = true;
            ChangeRank("18", "BEGGINER II");
        }
        else if (GameManager.instance.GetScore() >= 18 && GameManager.instance.GetScore() < 23)
        {
            checkRandomImage = true;
            ChangeRank("23", "BEGGINER III");
        }
        else if (GameManager.instance.GetScore() >= 23 && GameManager.instance.GetScore() < 35)
        {
            checkRandomImage = true;
            ChangeRank("35", "INTERMEDIATE I");
        }
        else if (GameManager.instance.GetScore() >= 35 && GameManager.instance.GetScore() < 40)
        {
            checkRandomImage = true;
            ChangeRank("40", "INTERMEDIATE I");
        }
    }



    void ChangeRank(string scoreRank, string nameRank)
    {
        Color currentColor = imageRank.color;
        currentColor.a = 0.5f;
        imageRank.color = currentColor;
        this.scoreRank.text = scoreRank;
        this.nameRank.text = nameRank;
        if (checkRandomImage)
        {
            greenTickImage.gameObject.SetActive(true);
        }

        WaitToChangeRankImage(nameRank);

    }
    void WaitToChangeRankImage(string newRank)
    {
        timeChangeImageCounter += Time.deltaTime;
        if (timeChangeImageCounter > timeToChangeImage)
        {
            timeChangeImageCounter = 0;
            if (checkRandomImage)
            {
                RandomImageRank();
            }
            nameRank.text = newRank;
            greenTickImage.gameObject.SetActive(false);
            Color currentColor = imageRank.color;
            currentColor.a = 1f;
            imageRank.color = currentColor;

        }

    }


    void RandomImageRank()
    {
        int randomImage = Random.Range(0, imageRankList.Length);
        imageRank.sprite = imageRankList[randomImage];
        checkRandomImage = false;
    }
}
