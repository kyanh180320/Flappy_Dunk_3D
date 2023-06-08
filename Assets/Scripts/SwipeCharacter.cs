using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwipeCharacter : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject scollbar;
    float scroll_pos = 0;
    float[] pos;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        pos = new float[transform.childCount];
        float distance = 1f / (pos.Length - 1f);
        for(int i = 0; i < pos.Length; i++)
        {
            pos[i] = distance * 1;
           
        }
        if(Input.GetMouseButton(0))
        {
            scroll_pos = scollbar.GetComponent<Scrollbar>().value;
        }
        else
        {
            for (int i = 0, i < pos.Length; i++)
            {

            }
        }
    }
}
