using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using UnityEngine.UI.Extensions;

public class SkinUI : MonoBehaviour
{
    public bool isChickenUI;

    public Sprite btnGray;
    public Sprite btnGreen;
    public GameObject chickenUIObj;
    public GameObject circleUIObj;
    public HorizontalScrollSnap horizontalScrollSnap_Chicken;
    public HorizontalScrollSnap horizontalScrollSnap_Circle;
    public Button equipBtn;
    
    public RectTransform contentRectTransform;

    [SerializeField] private GameObject body, eye, foot, head;
    [SerializeField] private List<Material> materialList;
    [SerializeField] private List<Material> circleMaterialList;
    [SerializeField] private List<RectTransform> skinRects;
    [SerializeField] private List<RectTransform> circleSkinRects;
    public float scaleFactor;
    private void Awake()
    {
        equipBtn.onClick.AddListener(OnEquipButtonClicked);
        isChickenUI = true;
    }

    private void Start()
    {
        
    }

    private void OnEnable()
    {
        isChickenUI = true;
    }

    private void Update()
    {
        if (isChickenUI)
        {
            int currentPage = horizontalScrollSnap_Chicken.CurrentPage;
            skinRects[currentPage].localScale = new Vector3(scaleFactor, scaleFactor, scaleFactor);
            if (currentPage - 1 >= 0)
            {
                skinRects[currentPage - 1].localScale = new Vector3(1, 1, 1);
            }
            if (currentPage + 1 <= skinRects.Count - 1)
            {
                skinRects[currentPage + 1].localScale = new Vector3(1, 1, 1);
            }

            if (AchievementController.Instance.achievementUI.CheckGiftTypeIsUnlocked(GameGiftType.ChickenSkin,
                    currentPage) || currentPage == 0)
            {
                equipBtn.interactable = true;
                equipBtn.GetComponent<Image>().sprite = btnGreen;
                equipBtn.GetComponentInChildren<TextMeshProUGUI>().SetText("Equip");
            }
            else
            {
                equipBtn.interactable = false;
                equipBtn.GetComponent<Image>().sprite = btnGray;
                equipBtn.GetComponentInChildren<TextMeshProUGUI>().SetText("Locked");
            }
        }
        else
        {
            int currentPage = horizontalScrollSnap_Circle.CurrentPage;
            circleSkinRects[currentPage].localScale = new Vector3(scaleFactor, scaleFactor, scaleFactor);
            if (currentPage - 1 >= 0)
            {
                circleSkinRects[currentPage - 1].localScale = new Vector3(1, 1, 1);
            }
            if (currentPage + 1 <= circleSkinRects.Count - 1)
            {
                circleSkinRects[currentPage + 1].localScale = new Vector3(1, 1, 1);
            }
        }
    }

    private void OnEquipButtonClicked()
    {
        int selectedIndex = horizontalScrollSnap_Chicken.CurrentPage;
        body.GetComponent<Renderer>().material = materialList[selectedIndex];
        eye.GetComponent<Renderer>().material = materialList[selectedIndex];
        head.GetComponent<Renderer>().material = materialList[selectedIndex];
        foot.GetComponent<Renderer>().material = materialList[selectedIndex];

        GameData.ChickenSkinIndex = selectedIndex;
    }

    private void ToggleUI()
    {
        chickenUIObj.SetActive(isChickenUI);
        circleUIObj.SetActive(!isChickenUI);
    }

    public void SetBoolUI(bool value)
    {
        isChickenUI = value;
        ToggleUI();
    }
}
