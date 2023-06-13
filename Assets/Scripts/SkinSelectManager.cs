using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinSelectManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static SkinSelectManager instance;
    SelectSkin[] selectSkin;


    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        selectSkin = FindObjectsOfType<SelectSkin>();
        int equippedSkinIndex = PlayerPrefs.GetInt("EquippedSkinIndex", -1);
        if (equippedSkinIndex >= 0 && equippedSkinIndex < selectSkin.Length)
        {
            selectSkin[equippedSkinIndex].SetStateSelectSkinText("Equiped");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ReSetStateSelect()
    {
        for(int i = 0; i < selectSkin.Length; i++)
        {
            if (selectSkin[i].GetStateSelectSkinText() == "Equiped")
            {
                print("Thay doi toan bo button");
                selectSkin[i].SetStateSelectSkinText("Equip");
            }
        }
    }
}
