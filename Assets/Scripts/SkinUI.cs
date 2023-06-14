using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UI.Extensions;

public class SkinUI : MonoBehaviour
{
    public HorizontalScrollSnap horizontalScrollSnap;
    public Button equipBtn;

    public RectTransform contentRectTransform;

    [SerializeField] private GameObject body, eye, foot, head;
    [SerializeField] private List<Material> materialList;

    private void Awake()
    {
        equipBtn.onClick.AddListener(OnEquipButtonClicked);
    }

    private void Start()
    {

    }

    private void Update()
    {
        //Debug.Log(horizontalScrollSnap.CurrentPage);
    }

    private void OnEquipButtonClicked()
    {
        int selectedIndex = horizontalScrollSnap.CurrentPage;
        body.GetComponent<Renderer>().material = materialList[selectedIndex];
        eye.GetComponent<Renderer>().material = materialList[selectedIndex];
        head.GetComponent<Renderer>().material = materialList[selectedIndex];
        foot.GetComponent<Renderer>().material = materialList[selectedIndex];

        GameData.ChickenSkinIndex = selectedIndex;
    }
}
