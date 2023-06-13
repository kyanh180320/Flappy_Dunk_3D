using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SelectSkin : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Material skin;
    [SerializeField] private GameObject body, eye, foot, head;
    [SerializeField] private Button btnSelectSkin;
    [SerializeField] private TextMeshProUGUI stateSelectSkinText;
    private int skinIndex; // Index của skin trong danh sách

    void Start()
    {
        // Gán skinIndex dựa vào vị trí của SelectSkin trong danh sách
        skinIndex = transform.GetSiblingIndex();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void ChangeStateSelect()
    {
        if (stateSelectSkinText.text == "Equip")
        {
            SkinSelectManager.instance.ReSetStateSelect();
            stateSelectSkinText.text = "Equiped";

            print("Tha doi equip");
            btnSelectSkin.image.color = new Color(0.105f, 0.654f, 0.352f);
            ChangeMaterial(body, eye, foot, head, skin);
            PlayerPrefs.SetInt("EquippedSkinIndex", skinIndex);
            PlayerPrefs.Save();
        }
    
    }
    public string GetStateSelectSkinText()
    {
        return stateSelectSkinText.text;
    }
    public void SetStateSelectSkinText(string text)
    {
        stateSelectSkinText.text = text;
        btnSelectSkin.image.color = new Color(0.1647f, 0.8627f, 0.4431f);
    }
    void ChangeMaterial(GameObject body, GameObject eye, GameObject foot, GameObject head, Material skin)
    {
        body.GetComponent<Renderer>().material = skin;
        eye.GetComponent<Renderer>().material = skin;
        head.GetComponent<Renderer>().material = skin;
        foot.GetComponent<Renderer>().material = skin;
    }

}
